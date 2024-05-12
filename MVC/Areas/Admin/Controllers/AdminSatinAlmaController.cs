using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminSatinAlmaController : Controller
    {
        public IActionResult Index()
        {
            using var context = new ArabaContext();
            var model = context.Satis.ToList();
            return View(model);
        }

        public IActionResult Edit(int ıd)
        {
            using var context = new ArabaContext();
            var model = context.Satis.Where(a => a.satisID == ıd).SingleOrDefault();
            return View(model);
            
        }
    }
}
