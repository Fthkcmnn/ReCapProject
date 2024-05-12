using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminKullaniciController : Controller
    {
        public IActionResult Index()
        {
            using var context = new ArabaContext();
            var model = context.Kullanici.ToList();
            return View(model);
        }

        public IActionResult Edit(int id)
        {

            using var context = new ArabaContext();
            var model = context.Kullanici.Where(a => a.kullaniciID == id).SingleOrDefault();
            return View(model);

        }
    }
}
