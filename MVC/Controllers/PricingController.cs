using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class PricingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
