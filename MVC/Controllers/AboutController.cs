using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
