using Core.Utilities.Result;
using Entities.Concrete;

namespace MVC.Areas.Admin.Models.AdminUserModels
{
    public class AdminUserEditViewModel
    {
        public IDataResult<User> User { get; set; }

        public AdminUserEditViewModel()
        {
            User = new SuccessDataResult<User>(new User()); // Varsayılan olarak bir örnek oluştur
        }
    }
}
