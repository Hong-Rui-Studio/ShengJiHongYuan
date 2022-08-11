global using Commons.Pages;
global using IServices;
global using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using Entity.ViewModels.Roles;

namespace WebApp.Areas.Manager.Controllers
{
    [Area("Manager")]
    public class RolesManagerController : Controller
    {
        private IRolesService _rolesSvc;
        public RolesManagerController(IRolesService rolesSvc)
        {
            _rolesSvc = rolesSvc;
        }

        [HttpGet]
        public async Task<IActionResult> List(string? search,int page = 1)
        {
            search = search ?? string.Empty;
            var data = await _rolesSvc.GetRolesByTitleAsync(search);
            var list = data.Select(r => new RolesListViewModel 
            {
                RolesId = r.Id,
                RolesTitle = r.Title,
                UpdateTime = r.UpdateTime
            }).ToList();

            IPagedList<RolesListViewModel> pages = list.ToPagedList(page, PageConfig.PageSize);
            ViewBag.Search = search;
            return View(pages);
        }


        [HttpGet]
        public IActionResult Add() 
        {
            return View(new RolesAddViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Add(RolesAddViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                //如果能够进入到这个if就代表通过验证了
               var res = await 
                    _rolesSvc.AddRolesAsync(model.RolesTitle);

                if (res > 0)
                    return Redirect("../../../Manager/RolesManager/List");
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var data = await _rolesSvc.GetRolesByIdAsync(id);
            if(data == null || string.IsNullOrEmpty(data.Title))
                return Redirect("../../../Manager/RolesManager/List");
            return View(new RolesEditViewModel 
            {
                RolesId = data.Id,
                RolesTitle = data.Title
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RolesEditViewModel model) 
        {
            if (ModelState.IsValid) 
            {
                var res = await _rolesSvc.EditRolesAsync(model.RolesId, model.RolesTitle);
                if(res > 0)
                    return Redirect("../../../Manager/RolesManager/List");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) 
        {
            var res = await _rolesSvc.DeleteRolesAsync(id);
            return Json(res > 0);
        }   





    }
}
