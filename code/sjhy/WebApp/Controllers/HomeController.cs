using Microsoft.AspNetCore.Mvc;
using IServices;
namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private IRolesService _rolesSvc;
        public HomeController(IRolesService rolesSvc)
        {
            _rolesSvc = rolesSvc;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var data = await _rolesSvc.GetAllAsync();


        //    return View();
        //}
    }
}
