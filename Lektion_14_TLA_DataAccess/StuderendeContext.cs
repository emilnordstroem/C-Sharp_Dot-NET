using Lektion_14_TLA_Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Lektion_14_TLA_DataAccess
{
	public class StuderendeContext : DbContext
	{

		public StuderendeContext (DbContextOptions<StuderendeContext> options) : base(options)
		{ 
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{ 
		}

		public DbSet<Studerende> Studerende { get; set; }

	}
}
