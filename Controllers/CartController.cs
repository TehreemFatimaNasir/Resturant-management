using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication4.Models;

public class CartController : Controller
{
    private readonly ResturantDbContext _context;

    public CartController(ResturantDbContext context)
    {
        _context = context;
    }

    public IActionResult ViewCart() 
    {
        ViewBag.Foods = _context.Foods.ToList(); 
        var cartItems = _context.Carts.ToList();
        return View(cartItems);
    }

    [HttpPost]
    public IActionResult AddToCart(int foodId, int quantity)
    {
        var food = _context.Foods.FirstOrDefault(f => f.Id == foodId);
        if (food == null)
        {
           return RedirectToAction("Menu", "Order");

        }

        var existingCartItem = _context.Carts.FirstOrDefault(c => c.foodname == food.foodname);

        if (existingCartItem != null)
        {
            
            existingCartItem.quantity += quantity;
        }
        else
        {
            var cartItem = new Cart
            {
                foodname = food.foodname,
                quantity = quantity
            };
            _context.Carts.Add(cartItem);
        }

        _context.SaveChanges();

        return RedirectToAction("ViewCart"); 
    }

    public IActionResult Edit(int id)
    {
        var cartItem = _context.Carts.FirstOrDefault(c => c.id == id);
        if (cartItem == null)
        {
           
        }
        return View(cartItem);
    }

    [HttpPost]
    public IActionResult Edit(Cart cart)
    {
        if (ModelState.IsValid)
        {
            _context.Carts.Update(cart);
            _context.SaveChanges();
            return RedirectToAction("ViewCart"); 
        }
        return View(cart);
    }

    public IActionResult Delete(int id)
    {
        var cartItem = _context.Carts.FirstOrDefault(c => c.id == id);
        if (cartItem == null)
        {
            return NotFound();
        }
        _context.Carts.Remove(cartItem);
        _context.SaveChanges();
        return RedirectToAction("ViewCart"); 
    }

    public IActionResult Checkout()
    {
        var cartItems = _context.Carts.ToList();
        return View(cartItems);
    }
    [HttpPost]
    public IActionResult ConfirmOrder(string paymentMethod)
    {
        if (paymentMethod == "CashOnDelivery")
        {
            ViewBag.OrderSuccess = "Your order has been Confirmed with Cash on Delivery!";
        }

        return View("OrderConfirmation");
    }

    public IActionResult OrderConfirmation()
    {
        return View();
    }
  


}
