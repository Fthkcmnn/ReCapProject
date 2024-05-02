using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.CarModels;
using MVC.Models.PricingModels;

namespace MVC.Controllers
{
    public class PricingController : Controller
    {
        ICarService _carService;
        public PricingController(ICarService carService)
        {
            _carService = carService;
        }
        public IActionResult Index()
        {
            var model = new PricingIndexViewModel
            {
                CarDetails = _carService.GetCarDetails().Data?.Take(6).ToList()
            };
            return View(model);
        }
    }
}
