using GalaSilver.Models;
using GalaSilver.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GalaSilver.Controllers;

public class CartController : Controller
{
    private IRepository _products;
    private Cart _cart;

    public CartController(IRepository products, Cart cart)
    {
        _cart = cart;
        _products = products;
    }
        
    // GET
    public ViewResult Index(string returnUrl)
    {
        return View(new CartViewIndexModel()
        {
            Cart = _cart,
            ReturnUrl = returnUrl
        });
    }

    public IActionResult AddToCart(long id,string returnUrl)
    {
        var product = _products.Products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _cart.AddItem(product,1);
        }
        return RedirectToAction("Index", new{ returnUrl});
    }
        
    public IActionResult RemoveFromCart(long id,string returnUrl)
    {
        var product = _products.Products.FirstOrDefault(p => p.Id == id);
        if (product != null)
        {
            _cart.Remove(product);
        }
        return RedirectToAction("Index", new{ returnUrl});
    }
}