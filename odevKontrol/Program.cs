using Microsoft.EntityFrameworkCore;
using odevKontrol.Repositories;
using odevKontrol.Models;
using System.Reflection;
using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.FileProviders;
using AutoMapper;



internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews();
        builder.Services.AddScoped<HomeworkRepository>();
        builder.Services.AddScoped<StudentRepository>();
        builder.Services.AddScoped<UserRepository>();
        builder.Services.AddScoped<TodoRepository>();

        builder.Services.AddScoped(typeof(GenericRepository<>));
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            opt.UseSqlServer(builder.Configuration.GetConnectionString("sqlCon"));
        });

        builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));


        builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
      
        builder.Services.AddNotyf(config =>
        {
            config.DurationInSeconds = 20;
            config.IsDismissable = true;
            config.Position = NotyfPosition.TopCenter;
        });

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(opt =>
    {
        opt.Cookie.Name = "CookieAuthApp";
        opt.ExpireTimeSpan = TimeSpan.FromDays(3);
        opt.LoginPath = "/Home/Login";
        opt.LogoutPath = "/Home/Logout";
        opt.AccessDeniedPath = "/Home/AccessDenied";
        opt.SlidingExpiration = false;
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
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}