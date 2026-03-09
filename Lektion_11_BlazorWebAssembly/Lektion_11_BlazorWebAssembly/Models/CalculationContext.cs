using Microsoft.EntityFrameworkCore;

namespace Lektion_11_WebAPI.Models
{
	public class CalculationContext : DbContext
	{
		public CalculationContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=LENOVO-THINKPAD\\SQLEXPRESS; Initial Catalog = EntityFrameworkCalculations; Integrated Security = SSPI; TrustServerCertificate = true");
		}

		public DbSet<Calculation> Calculations { get; set; }
	}
}
