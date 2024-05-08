using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using MVC.Areas.Admin.Models.AdminRentals;
using MVC.Session;

namespace MVC.Areas.Admin.Controllers
{
    [ServiceFilter(typeof(SessionAuthorizationFilter))]
    [Area("Admin")]
    public class AdminRentalController : Controller
    {
        private readonly IRentalService _rentalService;

        public AdminRentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        public IActionResult Index()
        {
            var model = new AdminRantalViewModel
            {
                Rental =  _rentalService.GetRentalDetails().Data
            };
            return View(model);
        }
    }
}
