using GalaSilver.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;


var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

//Добавление MVC сервисов
builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting=false);
//Dependency injection 
builder.Services.AddTransient<IRepository, ProductRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
    optionsBuilder.UseMySql(
        configuration["Data:GalaSilver:ConnectionString"],
        ServerVersion.AutoDetect(configuration["Data:GalaSilver:ConnectionString"])));

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();

//Установка стандартной маршрутизации
app.UseMvcWithDefaultRoute();

app.Run();