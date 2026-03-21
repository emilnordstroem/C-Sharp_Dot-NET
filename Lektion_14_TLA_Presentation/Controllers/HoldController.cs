using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lektion_14_TLA_Business;
using Lektion_14_TLA_DataAccess;

namespace Lektion_14_TLA_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoldController : ControllerBase
    {
        private readonly StuderendeContext _context;

        public HoldController(StuderendeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hold>>> GetHold()
        {
            return await _context.Hold.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hold>> GetHold(Guid? id)
        {
            var hold = await _context.Hold.FindAsync(id);

            if (hold == null)
            {
                return NotFound();
            }

            return hold;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHold(Guid? id, Hold hold)
        {
            if (id != hold.Id)
            {
                return BadRequest();
            }

            _context.Entry(hold).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoldExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Hold>> PostHold(Hold hold)
        {
            _context.Hold.Add(hold);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHold", new { id = hold.Id }, hold);
        }

		[HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHold(Guid? id)
        {
            var hold = await _context.Hold.FindAsync(id);
            if (hold == null)
            {
                return NotFound();
            }

            _context.Hold.Remove(hold);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HoldExists(Guid? id)
        {
            return _context.Hold.Any(e => e.Id == id);
        }
    }
}
