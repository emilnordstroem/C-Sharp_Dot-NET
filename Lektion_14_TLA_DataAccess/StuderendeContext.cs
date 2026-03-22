using Lektion_14_TLA_Business;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Lektion_14_TLA_DataAccess
{
	public class StuderendeContext : DbContext
	{

		public StuderendeContext() { }
		public StuderendeContext (DbContextOptions<StuderendeContext> options) : base(options)
		{ 
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Hold>()
				.HasMany(hold => hold.Studerende)
				.WithOne(studerende => studerende.Hold)
				.HasForeignKey(studerende => studerende.HoldId);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=LENOVO-THINKPAD\\SQLEXPRESS; Initial Catalog = UddannelseEntityFramework; Integrated Security = SSPI; TrustServerCertificate = true");
		}

		public DbSet<Studerende> Studerende { get; set; }
		public DbSet<Hold> Hold { get; set; }

	}
}
