namespace MVC.Session
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Authorization;
    using Entities.Concrete;

    public class RoleAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly string _requiredRole;

        public RoleAuthorizeAttribute(string requiredRole)
        {
            _requiredRole = requiredRole;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Session.GetObjectFromJson<User>("kullanici");

            if (user != null)
            {
                string userRole = user.Phone;

                if (userRole.Equals(_requiredRole, StringComparison.OrdinalIgnoreCase))
                {
                    return; // Kullanıcı yetkilendirilmiş, işlemi devam ettir
                }
            }

            // Yetkilendirme başarısız olduğunda yönlendirilecek sayfayı belirleyebilirsiniz
            context.Result = new RedirectResult("~/Error/Unauthorized");
        }
    }

}
