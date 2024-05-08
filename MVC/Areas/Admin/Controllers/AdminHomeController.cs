using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC.Session;

namespace MVC.Areas.Admin.Controllers
{

    [ServiceFilter(typeof(SessionAuthorizationFilter))]
    [Area("Admin")]
    public class AdminHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
