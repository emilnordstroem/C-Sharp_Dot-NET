using System;
using System.Collections.Generic;
using System.Text;
using Lektion_14_TLA_DTO;
using Lektion_14_TLA_DataAccess;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Lektion_14_TLA_DataAccess.Repository
{
	public class StuderendeRepository
	{
		public async Task<IEnumerable<StuderendeDTO>> GetStuderende()
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				var dbStuderende = await _context.Studerende
					.Include(studerende => studerende.Hold)
					.ToListAsync();
				return dbStuderende.Select(studerende => MapToModelDTO(studerende));
			}
		}

		public async Task<StuderendeDTO> GetStuderende(Guid id)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				var studerende = await _context.Studerende.FindAsync(id);
				return MapToModelDTO(studerende);
			}
		}

		public async Task<StuderendeDTO> PostStuderende(StuderendeDTO studerende)
		{
			using (StuderendeContext _context = new StuderendeContext()) 
			{
				var dbStuderende = await MapToModelDB(studerende, _context);
				_context.Studerende.Add(dbStuderende);
				await _context.SaveChangesAsync();
				return studerende;
			}
		}

		public async Task<StuderendeDTO> PutStuderende(Guid id, StuderendeDTO studerendeDTO)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				var studerendeDB = await _context.Studerende
					.FindAsync(id);
				var holdDB = await _context.Hold
					.FirstOrDefaultAsync(hold => hold.Navn == studerendeDTO.Hold);

				if (studerendeDB == null || holdDB == null)
				{
					return null;
				}

				// Det er ikke not blot at ændre id på et nyt DB objekt - derfor eksplicit
				studerendeDB.Navn = studerendeDTO.Navn;
				studerendeDB.StudieStart = studerendeDTO.StudieStart;
				studerendeDB.Alder = studerendeDTO.Alder;
				studerendeDB.HoldId = holdDB.Id;
				studerendeDB.Uddannelse = Enum.Parse<Uddannelse>(studerendeDTO.Uddannelse);
				studerendeDB.Niveau = Enum.Parse<UddannelsesNiveau>(studerendeDTO.Niveau);

				await _context.SaveChangesAsync();
				return studerendeDTO;
			}
		}

		public bool StuderendeExists(Guid id)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				return _context.Studerende.Any(studerende => studerende.Id == id);
			}
		}

		// Mapping
		internal static StuderendeDTO MapToModelDTO(StuderendeDB studerende)
		{
			return new StuderendeDTO
			{
				Navn = studerende.Navn,
				StudieStart = studerende.StudieStart,
				Alder = studerende.Alder,
				Hold = studerende.Hold?.Navn ?? string.Empty,
				Uddannelse = studerende.Uddannelse.ToString(),
				Niveau = studerende.Niveau.ToString()
			};
		}

		private static async Task<StuderendeDB> MapToModelDB(StuderendeDTO studerende, StuderendeContext context)
		{
			Guid? holdId = await context.Hold
					.Where(hold => hold.Navn == studerende.Hold)
					.Select(hold => (Guid?)hold.Id)
					.FirstOrDefaultAsync();

			return new StuderendeDB
			{
				Id = Guid.NewGuid(),
				Navn = studerende.Navn,
				StudieStart = studerende.StudieStart,
				Alder = studerende.Alder,
				HoldId = holdId,
				Uddannelse = Enum.Parse<Uddannelse>(studerende.Uddannelse),
				Niveau = Enum.Parse<UddannelsesNiveau>(studerende.Niveau)
			};
		}

	}
}