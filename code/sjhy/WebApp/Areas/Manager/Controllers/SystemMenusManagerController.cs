using Microsoft.AspNetCore.Mvc;
using Entity.ViewModels.SystemMenus;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class SystemMenusManagerController : Controller
    {
        private ISystemMenusService _menusSvc;
        public SystemMenusManagerController(ISystemMenusService menusSvc)
        {
            _menusSvc = menusSvc;
        }

        [HttpGet]
        public async Task<IActionResult> List(string? search,int page= 1)
        {
            search = search ?? string.Empty;
            var data = await _menusSvc.GetDataByTitleAsync(search);

            var list = new List<SystemMenusListViewModel>();

            foreach (var item in data)
            {
                list.Add(new SystemMenusListViewModel
                {
                    Id = item.Id,
                    Title = item.Title,
                    Link = item.Link,
                    Icons = item.Icon,
                    ParentTitle = await getTitle(item.ParentId),
                    UpdateTime = item.UpdateTime.ToString("yyyy-MM-dd")
                });
            }
            IPagedList<SystemMenusListViewModel> pages = list.ToPagedList(page, PageConfig.PageSize);
            ViewBag.Search = search;
            return View(pages);
        }

        [HttpGet]

        public async Task<IActionResult> Add() 
        {
            await Bind(null);
           
            return View(new SystemMenusAddViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Add(SystemMenusAddViewModel model) 
        {
            if (ModelState.IsValid) 
            {

                int parentId = model.FirstSelect == 0 ? 0 : (int)model.SecondSelect;
                var res = await _menusSvc.AddMenusAsync(model.Title, model.Link, model.Icon, parentId);
                if (res > 0)
                    return Redirect("../../../Manager/SystemMenusManager/List");
            }

            Bind(model.SecondSelect);
            return View(model);
        }


        private async Task Bind(int? parentId) 
        {
            var data = await _menusSvc.GetDataByParentsIdAsync(0);
            SelectList sl = parentId == null ?
                new SelectList(data, "Id", "Title")
                : new SelectList(data, "Id", "Title",parentId);

            ViewBag.SecondMenu = sl;
        }

        private async Task<string> getTitle(int parentId) 
        {
            if (parentId == 0)
                return "一级菜单";
            var data = await _menusSvc.GetDataByIdAsync(parentId);
            return data.Title; 
        }
    }
}
