using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class ListeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
