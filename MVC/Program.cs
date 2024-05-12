using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolvers.Autofac;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using System;
using Autofac.Core;

var builder = WebApplication.CreateBuilder(args);

// Razor view engine configuration
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.AreaViewLocationFormats.Clear();
    options.AreaViewLocationFormats.Add("/admin/{2}/Views/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/admin/{2}/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
});

// Add services to the container
builder.Services.AddSession();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = "/Account/Login"; // Redirect to login page when not authenticated
            options.LogoutPath = "/Account/Logout"; // Redirect to logout page when user logs out
            options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect to access denied page when user is not authorized
            options.Cookie.Name = "YourAppCookieName"; // Cookie name for session
            options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // Session timeout
        });
builder.Services.AddControllersWithViews();

// Autofac integration
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});
builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true; // Make the session cookie essential
});
builder.Services.AddScoped<MVC.Session.SessionAuthorizationFilter>();

// Database configuration
//var configuration = builder.Configuration;
//var connectionString = configuration.GetConnectionString("DefaultConnection");
//builder.Services.AddDbContext<ReCarContext>(options =>
//    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.UseAuthentication(); // Add this line for authentication

// Controller routing
app.MapControllerRoute(
        name: "Admin",
        pattern: "{area:exists}/{controller=AdminHome}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
