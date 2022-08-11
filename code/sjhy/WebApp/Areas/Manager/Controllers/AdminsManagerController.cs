using Microsoft.AspNetCore.Mvc;
using Entity.ViewModels.Admins;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class AdminsManagerController : Controller
    {
        private IAdminsService _adminSvc;
        private IRolesService _rolesSvc;
        private IWebHostEnvironment _webEnv;
        public AdminsManagerController(IAdminsService adminSvc, 
                                       IRolesService rolesSvc,
                                       IWebHostEnvironment webEnv)
        {
            _adminSvc = adminSvc;
            _rolesSvc = rolesSvc;
            _webEnv = webEnv;
        }

        [HttpGet]
        public async Task<IActionResult> List(string? search,int page =1)
        {
            search = search ?? "";
            var data = await _adminSvc.GetDataByNameAsync(search);

            var list = new List<AdminsListViewModel>();
            foreach (var item in data)
            {
                list.Add(new AdminsListViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    BornDate = item.UpdateTime,
                    Age = item.Age,
                    Gender = item.Gender == 1 ? "男" : "女",
                    Email = item.Email,
                    Tel = item.Tel,
                    Photo = item.Photo,
                    RolesTitle = await GetRolesTitle(item.RolesId),
                    UpdateTime = item.UpdateTime
                });
            }

            IPagedList<AdminsListViewModel> pages = list.ToPagedList(page, PageConfig.PageSize);

            ViewBag.Searcha = search;

            return View(pages);
        }

        [HttpGet]
        public async Task<IActionResult> Add() 
        {
            //1.绑定下拉列表
            //var rolesList = await _rolesSvc.GetAllAsync();
            //SelectList sl = new SelectList(rolesList,"Id","Title");
            //ViewBag.RoleList = sl;
            await Bind(null);
            //SelectList
            return View(new AdminsAddViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdminsAddViewModel model, IFormFile imgUpload) 
        {
            if (ModelState.IsValid) 
            {
                var img = UploadImage(imgUpload, @"/upload/admins");

                var res = await _adminSvc.AddAdminsAsync(model.Name, model.BornDate, model.Gender, model.Email, model.Tel, img, model.Pwd, model.RolesId);
                if (res > 0)
                    return Redirect("../../../Manager/AdminsManager/List");
            }

            await Bind(null);
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id) 
        {
            var model = await _adminSvc.GetDataByIdAsync(id);
            if(model == null)
                return  Redirect("../../../Manager/AdminsManager/List");

            await Bind(model.RolesId);

            return View(new AdminsEditViewModel 
            {
                Id = model.Id,
                Name = model.Name,
                BornDate = model.BornDate,
                Gender = model.Gender,
                Email = model.Email,
                Tel = model.Tel,
                Photo = model.Photo,
                RolesId = model.RolesId
            
            });
        }
        

        private async Task<string> GetRolesTitle(int id) 
        {
            var data = await _rolesSvc.GetRolesByIdAsync(id);
            return data.Title;
        }

        private async Task Bind(int? id) 
        {
            //1.绑定下拉列表
            var rolesList = await _rolesSvc.GetAllAsync();
            SelectList sl = null;
            if (id == null)
            {
                sl = new SelectList(rolesList, "Id", "Title");
            }
            else 
            {
                sl = new SelectList(rolesList, "Id", "Title",id);
            }
            ViewBag.RoleList = sl;
        }


        private string UploadImage(IFormFile file, string uploadUrl) 
        {
            #region 图片上传
            string img = null;
            if (file == null || string.IsNullOrEmpty(file.FileName))
            {
                img = "default.png";
            }
            else
            {
                //1. 新生成一个图片名称
                Random rand = new Random();
                var newName = DateTime.Now.ToString("yyyyMMdd") + rand.Next(1, 99999)
                            + file.FileName.Substring(file.FileName.LastIndexOf("."));

                //2. 设置要保存到的路径
                string path = _webEnv.WebRootPath + uploadUrl;
                //3.把我们要保存到的路径与图片名称组合在一起形成一个绝对路径
                string url = Path.Combine(path, newName);
                //4. 通过文件流复制这个图片信息到指定的位置
                file.CopyTo(new FileStream(url, FileMode.Create));
                img = newName;
            }
            return img;
            #endregion
        }
    }
}
