using Core.Utilities.Result;
using Entities.Concrete;

namespace MVC.Areas.Admin.Models.AdminUserModels
{
    public class AdminUserIndexViewModel
    {
        public IDataResult<IEnumerable<User>> User { get; set; }
        public AdminUserIndexViewModel()
        {
            User = new SuccessDataResult<IEnumerable<User>>(new List<User>()); // Varsayılan olarak bir örnek oluştur
        }
    }
}
