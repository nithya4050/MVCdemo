using Microsoft.EntityFrameworkCore;
using MVCDemo;
using MVCDemo.Helper;
using Microsoft.Extensions.Localization;
using System.Globalization;
using System.Runtime.Versioning;
using MVCDemo.Controllers;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();


//add localization services
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Add services to the container.
builder.Services.AddControllersWithViews()
     .AddViewLocalization()
     .AddDataAnnotationsLocalization(options =>
   {
       options.DataAnnotationLocalizerProvider = (type, factory) =>
           factory.Create(typeof(MVCDemo.Controllers.HomeController));
   });


// Enable Localization
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc()
    .AddViewLocalization()
    .AddDataAnnotationsLocalization();


var supportedCultures = new[] { "en-US", "ta-IN" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("ta-IN")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);



var Connection = builder.Configuration.GetConnectionString("Jsconn");

builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(Connection));


//inject interface
builder.Services.AddTransient<IMathLogiccs,MathLogic>();



var app = builder.Build();
app.UseRequestLocalization(localizationOptions);
app.UseStaticFiles();
app.UseRouting();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"); 
app.Run();
