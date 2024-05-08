using Core.Utilities.Result;
using Entities.Concrete;

namespace MVC.Areas.Admin.Models.AdminCarModels
{
    public class AdminCarIndexViewModel
    {
        public IDataResult<IEnumerable<Car>> Car { get; set; }
        public AdminCarIndexViewModel()
        {
            Car = new SuccessDataResult<IEnumerable<Car>>(new List<Car>()); // Varsayılan olarak bir örnek oluştur
        }
    }
}
