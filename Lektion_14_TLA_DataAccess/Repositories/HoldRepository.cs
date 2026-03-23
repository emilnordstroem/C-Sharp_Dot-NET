using System;
using System.Collections.Generic;
using System.Text;
using Lektion_14_TLA_DataAccess;
using Lektion_14_TLA_DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Lektion_14_TLA_DataAccess.Repository
{
	public class HoldRepository
	{
		public async Task<IEnumerable<Lektion_14_TLA_DTO.Hold>> GetHold()
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				var hold = await _context.Hold.ToListAsync();
				return hold.Select(hold => MapToDTO(hold));
			}
		}

		public async Task<Lektion_14_TLA_DTO.Hold> GetHold(Guid? id)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				var hold = await _context.Hold.FindAsync(id);
				return MapToDTO(hold);
			}
		}

		public async Task<IEnumerable<Lektion_14_TLA_DTO.Studerende>> GetStuderende(Guid? id)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				var dbHoldStuderende = await _context.Hold
					.Where(hold => hold.Id == id)
					.SelectMany(hold => hold.Studerende)
					.ToListAsync();
				if (dbHoldStuderende.IsNullOrEmpty())
				{
					return null;
				}
				return dbHoldStuderende.Select(studerende => StuderendeRepository.MapToDTO(studerende));
			}
		}

		public async Task<Lektion_14_TLA_DTO.Hold> PostHold(Lektion_14_TLA_DTO.Hold hold)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				var dbHold = MapToDBModel(hold);
				_context.Hold.Add(dbHold);
				await _context.SaveChangesAsync();
				return hold;
			}
		}

		public async Task<Lektion_14_TLA_DTO.Hold> PutHold(Guid id, Lektion_14_TLA_DTO.Hold hold)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				throw new NotImplementedException();
			}
		}

		public bool HoldExists(Guid? id)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				return _context.Hold.Any(e => e.Id == id);
			}
		}

		// Mapping
		private static Lektion_14_TLA_DTO.Hold MapToDTO(Lektion_14_TLA_DataAccess.Hold hold)
		{
			return new Lektion_14_TLA_DTO.Hold
			{
				Navn = hold.Navn,
				Studerende = hold.Studerende?.Select(s => s.Navn).ToList() ?? new List<string>()
			};
		}

		private static Lektion_14_TLA_DataAccess.Hold MapToDBModel(Lektion_14_TLA_DTO.Hold hold)
		{
			return new Lektion_14_TLA_DataAccess.Hold
			{
				Id = Guid.NewGuid(),
				Navn = hold.Navn,
			};
		}
	}
}
