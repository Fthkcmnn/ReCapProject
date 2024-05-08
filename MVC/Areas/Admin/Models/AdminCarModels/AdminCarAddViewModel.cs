using Core.Utilities.Result;
using Entities.Concrete;

namespace MVC.Areas.Admin.Models.AdminCarModels
{
    public class AdminCarAddViewModel
    {
        public IDataResult<Car> Car { get; set; }
        public AdminCarAddViewModel()
        {
            Car = new SuccessDataResult<Car>(new Car()); // Varsayılan olarak bir örnek oluştur

        }
    }
}
