using Core.Utilities.Result;
using Entities.Concrete;

namespace MVC.Areas.Admin.Models.AdminCustomerModels
{
    public class AdminCustomerAddViewModel
    {
        public IDataResult<Customer> Customer { get; set; }
        public AdminCustomerAddViewModel()
        {
            Customer = new SuccessDataResult<Customer>(new Customer()); // Varsayılan olarak bir örnek oluştur

        }
    }
}
