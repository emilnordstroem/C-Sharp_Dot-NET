using Microsoft.EntityFrameworkCore;
using Lektion_10_EntityFramework.Models;

namespace Context
{
	public class BilContext : DbContext
	{
		public BilContext()
		{
		}

		public BilContext(DbContextOptions options) : base(options)
		{
		}

		// Connection string
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=LENOVO-THINKPAD\\SQLEXPRESS;Initial Catalog=EntityFrameworkBiler;Integrated Security=SSPI;TrustServerCertificate=true");
		}

		// tabeller
		public DbSet<Bil> Biler { get; set; }

	}
}
