using Business.Abstract;
using Entities.Concrete;
using Humanizer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class AccountController : Controller
    {
        IUserService _UserService;

        public AccountController(IUserService userService)
        {
            _UserService = userService;
        }

        public IActionResult Login()
        {
            var model = new User();
            return View(model);
        }
        [HttpPost]
        public IActionResult Login(User u)
        {

            var user = _UserService.GetUserLogin(u.Email,u.PasswordSalt);
            if (user.IsSuccess)
            {
                // Set session variables
                HttpContext.Session.SetInt32("UserId", user.Data.UserId);
                HttpContext.Session.SetString("UserRole", user.Data.rol);

                // Redirect to the home page
                return RedirectToAction("Index", "AdminHome" , new { area = "Admin" });
            }
            else
            {
                // If authentication fails, you might want to display an error message or redirect to a login page
                ViewBag.Message = "Invalid email or password";
                return View();
            }
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clears all items from the session
            return RedirectToAction("Index", "Home"); // Redirect to the home page after logout
        }

    }
}
