using Lektion_14_TLA_DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Lektion_14_TLA_DataAccess
{
	internal class StuderendeContext : DbContext
	{

		public StuderendeContext() { }
		public StuderendeContext (DbContextOptions<StuderendeContext> options) : base(options)
		{ 
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<HoldDB>()
				.HasMany(hold => hold.Studerende)
				.WithOne(studerende => studerende.Hold)
				.HasForeignKey(studerende => studerende.HoldId);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=LENOVO-THINKPAD\\SQLEXPRESS; Initial Catalog = UddannelseEntityFramework; Integrated Security = SSPI; TrustServerCertificate = true");
		}

		public DbSet<StuderendeDB> Studerende { get; set; }
		public DbSet<HoldDB> Hold { get; set; }

	}
}
