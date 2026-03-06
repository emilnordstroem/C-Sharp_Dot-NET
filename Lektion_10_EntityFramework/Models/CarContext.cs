using Microsoft.EntityFrameworkCore;

namespace Lektion_10_EntityFramework.Models
{
	public class CarContext : DbContext
	{

		public CarContext()
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Car>().HasData(new Car[]
			{
				new Car
				{
					CarId = 1,
					Brand = "Porsche",
					Model = "Taycan",
					Year = 2026,
					OwnerId = 1
				}
			});

			modelBuilder.Entity<Owner>().HasData(new Owner[]
			{
				new Owner 
				{ 
					OwnerId = 1, 
					Name = "Emil" 
				}
			});
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=LENOVO-THINKPAD\\SQLEXPRESS; Initial Catalog = EntityFrameworkCars; Integrated Security = SSPI; TrustServerCertificate = true");
		}

		public DbSet<Car> Cars { get; set; }
		public DbSet<Owner> Owners { get; set; }

	}
}
