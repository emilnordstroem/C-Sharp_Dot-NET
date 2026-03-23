using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lektion_14_TLA_DataAccess.Repository;
using Lektion_14_TLA_DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lektion_14_TLA_Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StuderendeController : ControllerBase
    {
        private readonly StuderendeRepository _studerende;

        public StuderendeController(StuderendeRepository studerende)
        {
            _studerende = studerende;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Studerende>>> GetStuderende()
        {
            return Ok(await _studerende.GetStuderende());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Studerende>> GetStuderende(Guid id)
        {
            var studerende = await _studerende.GetStuderende(id);

            if (studerende == null)
            {
                return NotFound();
            }

            return Ok(studerende);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutStuderende(Guid id, Studerende studerende)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public async Task<ActionResult<Studerende>> PostStuderende(Studerende studerende)
        {
            if (studerende == null)
            {
                return BadRequest();
            }
		    await _studerende.PostStuderende(studerende);
            return CreatedAtAction("GetStuderende", new { id = studerende.Id }, studerende);
        }

        private bool StuderendeExists(Guid id)
        {
            return _studerende.StuderendeExists(id);
        }
    }
}
