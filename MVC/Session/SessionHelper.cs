namespace MVC.Session
{
    public static class SessionHelper
    {
        public static void SetUserRole(HttpContext httpContext, string role)
        {
            httpContext.Session.SetString("UserRole", role);
        }

        public static string GetUserRole(HttpContext httpContext)
        {
            return httpContext.Session.GetString("UserRole");
        }
    }
}
