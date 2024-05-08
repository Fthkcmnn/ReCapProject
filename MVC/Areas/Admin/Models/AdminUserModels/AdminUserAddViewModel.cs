using Core.Utilities.Result;
using Entities.Concrete;

namespace MVC.Areas.Admin.Models.AdminUserModels
{
    public class AdminUserAddViewModel
    {
        public IDataResult<User> User { get; set; }
        public AdminUserAddViewModel()
        {
            User = new SuccessDataResult<User>(new User()); // Varsayılan olarak bir örnek oluştur

        }
    }
}
