using Microsoft.EntityFrameworkCore;
using Lektion_10_EntityFramework.Models;

namespace Lektion_10_EntityFramework.DAL
{
	public class BilContext : DbContext
	{

		public BilContext()
		{
		}
		public DbSet<Bil> Biler { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Bil>().HasData(new Bil[]
			{
				new Bil {ID = 1, Navn = "Porsche", Vaegt = 2000}
			});
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=LENOVO-THINKPAD\\SQLEXPRESS; Initial Catalog = EntityFrameworkBiler; Integrated Security = SSPI; TrustServerCertificate = true");
		}

	}
}
