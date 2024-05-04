using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using MVC.Models.CarModels;
using MVC.Models.HomeModels;
using System.Diagnostics;

namespace MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarService _carService;

        public HomeController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index()
        {

            var model = new HomeIndexViewModel
            {
                CarDetails = _carService.GetCarDetails().Data.Take(5).ToList()
            };
            return View(model);
        }

  
        public IActionResult FloatingCars()
        {
            return PartialView("_FloatingCars");
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}

    }
}
