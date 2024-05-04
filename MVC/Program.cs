    using Autofac.Extensions.DependencyInjection;
    using Autofac;
    using Business.DependencyResolvers.Autofac;
    using Microsoft.AspNetCore.Mvc.Razor;

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.Configure<RazorViewEngineOptions>(options =>
    {
        options.AreaViewLocationFormats.Clear();
        options.AreaViewLocationFormats.Add("/admin/{2}/Views/{1}/{0}.cshtml");
        options.AreaViewLocationFormats.Add("/admin/{2}/Views/Shared/{0}.cshtml");
        options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
    });

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });
    var app = builder.Build();
    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();

    app.UseAuthorization();

    app.MapControllerRoute(
	    name: "Admin",
	    pattern: "{area:exists}/{controller=AdminHome}/{action=Index}/{id?}");

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    app.Run();
