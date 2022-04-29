using GalaSilver.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration;

//Добавление MVC сервисов
builder.Services.AddControllersWithViews(options => options.EnableEndpointRouting=false);
//Dependency injection 
builder.Services.AddTransient<IRepository, EfRepository>();
builder.Services.AddTransient<IOrderRepository, EfOrderRepository>();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

//database contexts
builder.Services.AddDbContext<ApplicationDbContext>(optionsBuilder =>
    optionsBuilder.UseMySql(
        configuration["Data:GalaSilver:ConnectionString"],
        ServerVersion.AutoDetect(configuration["Data:GalaSilver:ConnectionString"])));
builder.Services.AddDbContext<ApplicationIdentityDbContext>(opts =>
    opts.UseMySql( configuration["Data:GalaSilverIdentity:ConnectionString"],
        ServerVersion.AutoDetect(configuration["Data:GalaSilverIdentity:ConnectionString"])));

//other cfg
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
    {
        options.User.RequireUniqueEmail = true;
        options.Password.RequiredLength = 5;
        options.Password.RequireUppercase = false;  
        options.Password.RequireLowercase = false;
        options.Password.RequireDigit = false;
        options.Password.RequireNonAlphanumeric = false;
    } )
    .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddSession();
builder.Services.AddMemoryCache();


var app = builder.Build();

//application configuration
app.UseDeveloperExceptionPage();
app.UseAuthentication();
app.UseStaticFiles();
app.UseSession();

//Установка стандартной маршрутизации
app.UseMvcWithDefaultRoute();

app.Run();