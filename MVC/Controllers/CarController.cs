using Business.Abstract;
using Entities.Concrete;
using X.PagedList;
using Microsoft.AspNetCore.Mvc;
using MVC.Models.CarModels;
using System.Drawing.Printing;

namespace MVC.Controllers
{
    public class CarController : Controller
    {

        ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        public IActionResult Index(int page = 1)
        {
            //if (page < 1)
            //{
            //    return NotFound();
            //}
            //int pageNumber = page; // Sayfa numarasını al, yoksa varsayılan olarak 1.
            //int pageSize = 10; // Her sayfada kaç öğe gösterileceği.
            //var records = _carService.GetCarDetails().Data.ToPagedList(pageNumber, pageSize);
            
            //if (records.PageNumber != 1 && page > records.PageCount)
            //{
            //    return NotFound();
            //}
            var model = new CarIndexViewModel
            {
                CarDetails = _carService.GetCarDetails().Data.ToList()
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
