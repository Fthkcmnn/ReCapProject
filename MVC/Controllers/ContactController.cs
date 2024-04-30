using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
