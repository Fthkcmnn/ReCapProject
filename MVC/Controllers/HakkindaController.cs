using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class HakkindaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
