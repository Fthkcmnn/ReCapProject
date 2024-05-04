using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MVC.Areas.Admin.Controllers
{

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
            var cars = _carService.GetAll().Data.ToList();
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
            var model = _carService.GetCarDetailsById(id).Data;
            if (model == null)
                return NotFound();
            
            return View(model);
        }

        // POST: /Admin/AdminCar/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Car car)
        {
            if (id != car.CarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _carService.Update(car);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: /Admin/AdminCar/Delete/5
        public IActionResult Delete(int id)
        {
            var car = _carService.GetCarById(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: /Admin/AdminCar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var car = _carService.GetCarById(id);
            _carService.Delete(car.Data);
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
