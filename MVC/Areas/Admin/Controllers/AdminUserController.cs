using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Admin.Models.AdminUserModels;
using MVC.Session;
using X.PagedList;

namespace MVC.Areas.Admin.Controllers
{
    [ServiceFilter(typeof(SessionAuthorizationFilter))]
    [Area("Admin")]
    public class AdminUserController : Controller
    {
        private readonly IUserService _userService;

        public AdminUserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var model = new AdminUserIndexViewModel
            {
                User = _userService.GetAll()
            };

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AdminUserAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Add(model.User.Data);
                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = new AdminUserEditViewModel
            {
                User = _userService.GetById(id)
            };

            if (!model.User.IsSuccess)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, AdminUserEditViewModel model)
        {
            if (id != model.User.Data.UserId)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = _userService.Update(model.User.Data);
                if (result.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", result.Message);
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            user.Data.isDeleted = true;
            var result = _userService.Update(user.Data);
            if (!result.IsSuccess) { return BadRequest(); }
            return RedirectToAction(nameof(Index));
        }
    }

}
