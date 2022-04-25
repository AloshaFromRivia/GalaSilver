var builder = WebApplication.CreateBuilder(args);

//Добавление MVC сервисов
builder.Services.AddControllersWithViews(); 

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStaticFiles();


//Установка стандартной маршрутизации
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();