using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.DependencyResolvers.AutoMapper;
using Core.Mapping.AutoMapper;
using Core.Utilities.Result;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.Session;

namespace MVC.Areas.Admin.Controllers
{
    [ServiceFilter(typeof(SessionAuthorizationFilter))]
    [Area("Admin")]
    public class AdminCarController : Controller
    {
        private readonly ICarService _carService;

        public AdminCarController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: /Admin/AdminCar/Index
        public IActionResult Index()
        {
            var cars = _carService.GetCarDetails().Data;    
            return View(cars);
        }

        // GET: /Admin/AdminCar/Create
        public IActionResult Add()
        {
            return View();
        }

        // POST: /Admin/AdminCar/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Car car)
        {
            if (ModelState.IsValid)
            {
                _carService.Add(car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: /Admin/AdminCar/Edit/5
        public IActionResult Edit(int id)
        {

            var model = _carService.GetCarDetailEdit(id).Data;

            if (model == null)
                return NotFound();

            #region SelectListItem
            ViewData["Transmission"] = model.Transmision.Select(t => new SelectListItem
            {
                Value = t.TransmissionID.ToString(),
                Text = t.Name
            }).ToList();

            ViewData["Brand"] = model.Brand.Select(b => new SelectListItem
            {
                Value = b.BrandID.ToString(),
                Text = b.Name
            }).ToList();

            ViewData["Model"] = model.Model.Select(m => new SelectListItem
            {
                Value = m.ModelID.ToString(),
                Text = m.Name
            }).ToList();

            ViewData["Color"] = model.Color.Select(c => new SelectListItem
            {
                Value = c.ColorId.ToString(),
                Text = c.Name
            }).ToList();

            ViewData["Fuel"] = model.Fuel.Select(f => new SelectListItem
            {
                Value = f.FuelID.ToString(),
                Text = f.Name
            }).ToList();

            #endregion

            return View(model);
        }

        // POST: /Admin/AdminCar/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CarDetailEditDTO dto)
        {

            if (ModelState.IsValid)
            {

                #region TODO: Dto Bakılacak
                // AutoMapper'ı yapılandır
                var mapperConfiguration = new AutoMapperConfiguration();
                var mapper = mapperConfiguration.Configure(new MappingProfile());

                // CarDetailEditDTO'yu Car nesnesine dönüştür
                var car = mapper.Map<Car>(dto);
                #endregion

                // Arabayı güncelle
                var result = _carService.Update(car);

                // Güncelleme işlemi başarılıysa, Index sayfasına yönlendir
                return RedirectToAction(nameof(Index));
            }
            #region SelectListItem
            var model = _carService.GetCarDetailEdit(id).Data;
            ViewData["Transmission"] = model.Transmision.Select(t => new SelectListItem
            {
                Value = t.TransmissionID.ToString(),
                Text = t.Name
            }).ToList();

            ViewData["Brand"] = model.Brand.Select(b => new SelectListItem
            {
                Value = b.BrandID.ToString(),
                Text = b.Name
            }).ToList();

            ViewData["Model"] = model.Model.Select(m => new SelectListItem
            {
                Value = m.ModelID.ToString(),
                Text = m.Name
            }).ToList();

            ViewData["Color"] = model.Color.Select(c => new SelectListItem
            {
                Value = c.ColorId.ToString(),
                Text = c.Name
            }).ToList();

            ViewData["Fuel"] = model.Fuel.Select(f => new SelectListItem
            {
                Value = f.FuelID.ToString(),
                Text = f.Name
            }).ToList();

            #endregion
            return View(dto);
        }

        // GET: /Admin/AdminCar/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }
            car.Data.isDeleted = true;
            var result = _carService.Update(car.Data);
            if (!result.IsSuccess) { return BadRequest(); }
            return RedirectToAction(nameof(Index));
        }


        private bool CarExists(int id)
        {
            // Burada, verilen id'ye sahip bir aracın veritabanında var olup olmadığını kontrol edebilirsiniz
            // Örneğin:
            // return _carService.GetCarByIdAsync(id) != null;

            // Örnek olarak false döndürüyoruz, çünkü gerçek uygulamanıza göre değişebilir.
            return false;
        }
    }
}
