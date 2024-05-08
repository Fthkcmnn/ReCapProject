using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Admin.Models.AdminCustomerModels;
using MVC.Areas.Admin.Models.AdminUserModels;
using MVC.Session;

namespace MVC.Areas.Admin.Controllers
{
    [ServiceFilter(typeof(SessionAuthorizationFilter))]
    [Area("Admin")]
    public class AdminCustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public AdminCustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var model = new AdminCustomerIndexViewModel
            {
                Customer = _customerService.GetAll()
            };

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AdminCustomerAddViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = _customerService.Add(model.Customer.Data);
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
            var model = new AdminCustomerEditViewModel
            {
                Customer = _customerService.GetCustomerById(id)
            };

            if (!model.Customer.IsSuccess)
            {
                return NotFound();
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, AdminCustomerEditViewModel model)
        {
            if (id != model.Customer.Data.CustomerID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var result = _customerService.Update(model.Customer.Data);
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
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            customer.Data.isDeleted = true;
            var result = _customerService.Update(customer.Data);
            if (!result.IsSuccess) { return BadRequest(); }
            return RedirectToAction(nameof(Index));
        }
    }
}
