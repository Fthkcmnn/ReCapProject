using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
