using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lektion_11_WebAPI.Models;

namespace Lektion_11_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly CalculationContext _context;

        public CalculationController(CalculationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Calculation>>> Calculation()
        {
            return await _context.Calculations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Calculation>> Calculation(int id)
        {
            var calculation = await _context.Calculations.FindAsync(id);

            if (calculation == null)
            {
                return NotFound();
            }

            return calculation;
        }

        [HttpPost]
        public async Task<ActionResult<Calculation>> Calculation(Calculation calculation)
        {
            _context.Calculations.Add(calculation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalculation", new { id = calculation.Id }, calculation);
        }
    }
}
