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
					Id = 1,
					Brand = "Porsche",
					Model = "Taycan"
				}
			});
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=LENOVO-THINKPAD\\SQLEXPRESS; Initial Catalog = EntityFrameworkCars; Integrated Security = SSPI; TrustServerCertificate = true");
		}

		public DbSet<Car> Cars { get; set; }

	}
}
