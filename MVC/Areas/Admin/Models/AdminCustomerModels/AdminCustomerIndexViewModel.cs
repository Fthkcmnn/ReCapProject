using Core.Utilities.Result;
using Entities.Concrete;

namespace MVC.Areas.Admin.Models.AdminCustomerModels
{
    public class AdminCustomerIndexViewModel
    {
        public IDataResult<IEnumerable<Customer>> Customer { get; set; }
        public AdminCustomerIndexViewModel()
        {
            Customer = new SuccessDataResult<IEnumerable<Customer>>(new List<Customer>()); // Varsayılan olarak bir örnek oluştur
        }
    }
}
