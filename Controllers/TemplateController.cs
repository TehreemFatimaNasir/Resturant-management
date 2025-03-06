using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models; 


namespace WebApplication4.Controllers
{
    public class TemplateController : Controller
    {
        private readonly ResturantDbContext _context;

        public TemplateController(ResturantDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(new Reservation()); 
        }

        [HttpPost]
        public IActionResult BookTable(Reservation model)
        {
            if (ModelState.IsValid)
            {
                _context.Reserve.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Success"); 
            }
            return View("Index", model); 
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
