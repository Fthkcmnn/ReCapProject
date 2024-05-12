using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class GoruslerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
