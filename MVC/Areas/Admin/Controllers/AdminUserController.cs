using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AdminUserController : Controller
	{
		IUserService _userService;

		public AdminUserController(IUserService userService)
		{
			_userService = userService;
		}

		public IActionResult Index()
		{
            ViewData["routeInfo"] = ControllerContext.RouteData.Values.ToString();
            var result = _userService.GetAllAsync().Result.Data.ToList();
			return View(result);
		}

	}
}
