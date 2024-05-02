using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.CarModels;

namespace MVC.Controllers
{
    public class CarController : Controller
    {

        ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {
            var model = new CarIndexViewModel
            {
                CarDetails = _carService.GetCarDetails().Data?.ToList()
            };
            return View(model);
        }

        public IActionResult Detay(int id)
        {
            var model = new CarDetayViewModel
            {
                CarDetails = _carService.GetCarDetailsById(id).Data
            };
            if (model == null)
            {
                return BadRequest();
            }
            return View(model);
        }
    }
}
