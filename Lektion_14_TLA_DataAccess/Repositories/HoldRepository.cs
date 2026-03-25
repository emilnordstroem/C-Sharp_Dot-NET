using System;
using System.Collections.Generic;
using System.Text;
using Lektion_14_TLA_DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Lektion_14_TLA_DataAccess.Repository
{
	public class HoldRepository
	{
		public async Task<IEnumerable<HoldDTO>> GetHold()
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				var hold = await _context.Hold.ToListAsync();
				return hold.Select(hold => MapToDTO(hold));
			}
		}

		public async Task<HoldDTO> GetHold(Guid? id)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				var hold = await _context.Hold.FindAsync(id);
				return MapToDTO(hold);
			}
		}

		public async Task<HoldDTO> GetHoldMedStuderende(Guid? id)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				var holdDB = await _context.Hold
					.Where(hold => hold.Id == id)
					.Include(hold => hold.Studerende)
					.FirstOrDefaultAsync();
				if (holdDB == null || holdDB.Studerende.IsNullOrEmpty())
				{
					return null;
				}
				HoldDTO holdDTO = HoldRepository.MapToDTO(holdDB);
				holdDTO.Studerende = holdDB.Studerende
					.Select(studerende => StuderendeRepository.MapToDTO(studerende).ToString())
					.ToList();
				return holdDTO;
			}
		}

		public async Task<HoldDTO> PostHold(HoldDTO hold)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				var dbHold = MapToDBModel(hold);
				_context.Hold.Add(dbHold);
				await _context.SaveChangesAsync();
				return hold;
			}
		}

		public async Task<HoldDTO> PutHold(Guid id, HoldDTO hold)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				throw new NotImplementedException();
			}
		}

		// Mapping
		private static HoldDTO MapToDTO(HoldDB hold)
		{
			return new HoldDTO
			{
				Navn = hold.Navn,
				Studerende = hold.Studerende?.Select(s => s.Navn).ToList() ?? new List<string>()
			};
		}

		private static HoldDB MapToDBModel(HoldDTO hold)
		{
			return new HoldDB
			{
				Id = Guid.NewGuid(),
				Navn = hold.Navn,
			};
		}
	}
}
