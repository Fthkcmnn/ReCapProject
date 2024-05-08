using Core.Utilities.Result;
using Entities.Concrete;

namespace MVC.Areas.Admin.Models.AdminCustomerModels
{
    public class AdminCustomerEditViewModel
    {
        public IDataResult<Customer> Customer { get; set; }

        public AdminCustomerEditViewModel()
        {
            Customer = new SuccessDataResult<Customer>(new Customer()); // Varsayılan olarak bir örnek oluştur
        }
    }
}
