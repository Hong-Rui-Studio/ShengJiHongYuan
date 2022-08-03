using Microsoft.AspNetCore.Mvc;
using IServices;
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
        public async Task<IActionResult> List()
        {
            var data = await _rolesSvc.GetAllAsync();


            return View(data);
        }
    }
}
