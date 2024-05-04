using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCustomerController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
