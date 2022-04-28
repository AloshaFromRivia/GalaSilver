using System.Diagnostics;
using GalaSilver.Models;
using Microsoft.AspNetCore.Mvc;

namespace GalaSilver.Controllers;

public class HomeController : Controller
{
    private IRepository _repository;

    public HomeController(IRepository repository)
    {
        _repository = repository;
    }
    
    //  Home/Index
    public IActionResult Index() => View();

    // Home/Catalog
    public ViewResult Catalog() => View(_repository.Products);
    
    // Search form 
    //  Home/Catalog with query string
    [HttpGet]
    public IActionResult Catalog(int categoryId, string searchString)
    {
        List<Product> products = new List<Product>(_repository.Products);
        if (categoryId != -1) products = products.Where(p => p.Id == categoryId).ToList();
        if (!string.IsNullOrWhiteSpace(searchString)) products = products.Where(p => p.Name.Contains(searchString)).ToList();
        return View(products);
    }
    //Clear query string
    public ActionResult Clear() => RedirectToAction(nameof(Catalog));
    // Home/About
    public ViewResult About() => View();
}