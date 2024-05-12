using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminArabaController : Controller
    {

        public IActionResult Index()
        {
            using var context = new ArabaContext();
            var model = context.Araba.ToList();
            return View(model);
        }


        public IActionResult Edit(int id)
        {
            using var context = new ArabaContext();
            var model = context.Araba.Where(a=> a.arabaID == id).SingleOrDefault();
            return View(model);
        }

    }
}
