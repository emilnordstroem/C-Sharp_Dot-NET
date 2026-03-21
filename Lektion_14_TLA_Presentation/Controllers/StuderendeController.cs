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
    public class StuderendeController : ControllerBase
    {
        private readonly StuderendeContext _context;

        public StuderendeController(StuderendeContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studerende>>> GetStuderende()
        {
            return await _context.Studerende.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Studerende>> GetStuderende(Guid id)
        {
            var studerende = await _context.Studerende.FindAsync(id);

            if (studerende == null)
            {
                return NotFound();
            }

            return studerende;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStuderende(Guid id, Studerende studerende)
        {
            if (id != studerende.Id)
            {
                return BadRequest();
            }

            _context.Entry(studerende).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StuderendeExists(id))
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
        public async Task<ActionResult<Studerende>> PostStuderende(Studerende studerende)
        {
            _context.Studerende.Add(studerende);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStuderende", new { id = studerende.Id }, studerende);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStuderende(Guid id)
        {
            var studerende = await _context.Studerende.FindAsync(id);
            if (studerende == null)
            {
                return NotFound();
            }

            _context.Studerende.Remove(studerende);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StuderendeExists(Guid id)
        {
            return _context.Studerende.Any(e => e.Id == id);
        }
    }
}
