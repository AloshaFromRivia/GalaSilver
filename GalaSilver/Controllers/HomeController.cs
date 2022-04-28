using System.Diagnostics;
using GalaSilver.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
    public ViewResult Catalog() 
    {
        ViewData["SelectItems"] = new SelectList(_repository.Categories, "Id", "Name");
        return View(_repository.Products);
    }
    
    // Search form 
    //  Home/Catalog with query string
    [HttpGet]
    public IActionResult Catalog(long categoryId, string searchString)
    {
        List<Product> products = new List<Product>(_repository.Products);
        if (categoryId != 0) products = products.Where(p => p.CategoryId == categoryId).ToList();
        if (!string.IsNullOrEmpty(searchString)) products = products.Where(p => p.Name.Contains(searchString)).ToList();
        ViewData["SelectItems"] = new SelectList(_repository.Categories, "Id", "Name");
        return View(products);
    }
    //Clear query string
    public ActionResult Clear() => RedirectToAction(nameof(Catalog));
    // Home/About
    public ViewResult About() => View();
}