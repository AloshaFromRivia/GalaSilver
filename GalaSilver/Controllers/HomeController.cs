using Microsoft.AspNetCore.Mvc;

namespace GalaSilver.Controllers;

public class HomeController : Controller
{
    //  Home/Index
    public IActionResult Index() => View();

    // Home/Catalog
    public IActionResult Catalog => View();
    
    // Home/About
    public ViewResult About() => View();
}