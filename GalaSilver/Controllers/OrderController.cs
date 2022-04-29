using GalaSilver.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GalaSilver.Controllers;

[Authorize]
public class OrderController : Controller
{
    private IOrderRepository repository;
    private Cart cart;

    public OrderController(IOrderRepository repoService, Cart cartService) {
        repository = repoService;
        cart = cartService;
    }
    
    public ViewResult Checkout() => View(new Order());

    [HttpPost]
    public IActionResult Checkout(Order order) {
        if (cart.Items.Count() == 0) {
            ModelState.AddModelError("", "Ваша корзина пуста");
        }
        if (ModelState.IsValid) {
            repository.SaveOrder(order);
            return RedirectToAction(nameof(Completed));
        } else {
            return View(order);
        }
    }

    public ViewResult Completed() {
        cart.Clear();
        return View();
    }
}