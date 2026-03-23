using System;
using System.Collections.Generic;
using System.Text;
using Lektion_14_TLA_DTO;
using Lektion_14_TLA_DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Lektion_14_TLA_DataAccess.Repository
{
	public class StuderendeRepository
	{

		public async Task<IEnumerable<Lektion_14_TLA_DTO.Studerende>> GetStuderende()
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				var dbStuderende = await _context.Studerende.ToListAsync();
				return dbStuderende.Select(studerende => MapToDTO(studerende));
			}
		}

		public async Task<Lektion_14_TLA_DTO.Studerende> GetStuderende(Guid id)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				var studerende = await _context.Studerende.FindAsync(id);
				return MapToDTO(studerende);
			}
		}

		public async Task<Lektion_14_TLA_DTO.Studerende> PostStuderende(Lektion_14_TLA_DTO.Studerende studerende)
		{
			using (StuderendeContext _context = new StuderendeContext()) 
			{
				var dbStuderende = MapToDBModel(studerende);
				_context.Studerende.Add(dbStuderende);
				await _context.SaveChangesAsync();
				return studerende;
			}
		}

		public async Task<Lektion_14_TLA_DTO.Studerende> PutStuderende(Guid id, Lektion_14_TLA_DTO.Studerende studerende)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				throw new NotImplementedException();
			}
		}

		public bool StuderendeExists(Guid id)
		{
			using (StuderendeContext _context = new StuderendeContext())
			{
				return _context.Studerende.Any(e => e.Id == id);
			}
		}

		// Mapping
		internal static Lektion_14_TLA_DTO.Studerende MapToDTO(Lektion_14_TLA_DataAccess.Studerende studerende)
		{
			return new Lektion_14_TLA_DTO.Studerende
			{
				Navn = studerende.Navn,
				StudieStart = studerende.StudieStart,
				Alder = studerende.Alder,
				Hold = studerende.Hold?.Navn ?? string.Empty,
				Uddannelse = studerende.Uddannelse.ToString(),
				Niveau = studerende.Niveau.ToString()
			};
		}

		private static Lektion_14_TLA_DataAccess.Studerende MapToDBModel(Lektion_14_TLA_DTO.Studerende studerende)
		{
			return new Lektion_14_TLA_DataAccess.Studerende
			{
				Id = Guid.NewGuid(),
				Navn = studerende.Navn,
				StudieStart = studerende.StudieStart,
				Alder = studerende.Alder,
				Uddannelse = Enum.Parse<Uddannelse>(studerende.Uddannelse),
				Niveau = Enum.Parse<UddannelsesNiveau>(studerende.Niveau)
			};
		}

	}
}