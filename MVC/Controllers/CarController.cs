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
            return View();
        }

        public IActionResult List()
        {
            //var model = new CarListViewModel
            //{
            //    cars = _carService.GetAllAsync().Result.Data.ToList<Car>()
                
            //};
            var test = _carService.GetAllAsync().Result.Data;
            var result = "asdasd";
            return View();
        }
    }
}
