using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace Restaurantmanagement.Controllers
{
    public class OrderController : Controller
    {
        private readonly ResturantDbContext _context;

        public OrderController(ResturantDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var orders = _context.Order.ToList();
            return View(orders);
        }

        public async Task<IActionResult> Order()
        {
            return View(await _context.Foods.ToListAsync());
        }

    

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Order.Add(order);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,customername,items,totalprice,status")] Order order)
        {
            if (id != order.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Order.Any(o => o.id == order.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order.FirstOrDefaultAsync(m => m.id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Order.FindAsync(id);
            if (order != null)
            {
                _context.Order.Remove(order);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

     

        

        public IActionResult AddNewFood()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNewFood(Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Foods.Add(food);
                _context.SaveChanges();
                return RedirectToAction("Menu");
            }
            return View(food);
        }
        public IActionResult Menu()
        {
            var foods = _context.Foods.ToList(); 
            return View(foods);
        }
    }
}