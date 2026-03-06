using Microsoft.EntityFrameworkCore;

namespace Lektion_9_PersonerWebAPI.Models
{
	public class PersonContext : DbContext
	{
		public PersonContext(DbContextOptions<PersonContext> options)
			: base(options)
		{
		}
		public DbSet<Person> Person { get; set; } = default!;

	}
}
