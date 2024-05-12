using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminMusteriController : Controller
    {
       
        public IActionResult Index()
        {
            using var context = new ArabaContext();
            var model = context.Musteri.ToList();
            return View(model);
        }

        public IActionResult Edit(int id)
        {

            using var context = new ArabaContext();
            var model = context.Musteri.Where(a => a.musteriID == id).SingleOrDefault();
            return View(model);

        }

    }
}
