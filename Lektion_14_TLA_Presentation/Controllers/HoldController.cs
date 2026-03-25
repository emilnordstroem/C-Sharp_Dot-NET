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
    public class HoldController : ControllerBase
    {
        private readonly HoldRepository _hold;

        public HoldController(HoldRepository hold)
        {
            _hold = hold;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HoldDTO>>> GetHold()
        {
            return Ok(await _hold.GetHold());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HoldDTO>> GetHold(Guid? id)
        {
            var hold = await _hold.GetHold(id);

            if (hold == null)
            {
                return NotFound();
            }

            return hold;
        }

		[HttpGet("{id}/studerende")]
		public async Task<ActionResult<HoldDTO>> GetHoldMedStuderende(Guid? id)
		{
            if (id == null)
            {
                return BadRequest();
            }
            return Ok(await _hold.GetHoldMedStuderende(id));
		}

		[HttpPut("{id}")]
        public async Task<IActionResult> PutHold(Guid id, HoldDTO hold)
        {
            throw new NotImplementedException();
		}

		[HttpPost]
        public async Task<ActionResult<HoldDTO>> PostHold(HoldDTO hold)
        {
            if(hold == null)
            {
                return BadRequest();
            }

            await _hold.PostHold(hold);
            return CreatedAtAction("GetHold", hold);
        }
	}
}
