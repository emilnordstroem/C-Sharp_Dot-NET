using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lektion_10_EntityFramework.Models;

namespace Lektion_10_EntityFramework.Controllers
{
    public class CarController : Controller
    {
        private readonly CarContext _context;

        public CarController(CarContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Cars.Include(car => car.Owner).ToListAsync());
        }

    }
}
