using Microsoft.EntityFrameworkCore;
using Lektion_9_PersonerWebAPI.Models;
using Scalar.AspNetCore;

namespace Lektion_9_PersonerWebAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddDbContext<PersonContext>(opt =>
					opt.UseInMemoryDatabase("PeopleList")
					);
			// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
			builder.Services.AddOpenApi();

			var app = builder.Build();

			// Seed the in-memory database
			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				try
				{
					var context = services.GetRequiredService<PersonContext>();
					context.Person.AddRange(
						new Person { Id = 1, Name = "John Doe" },
						new Person { Id = 2, Name = "Jane Smith" },
						new Person { Id = 3, Name = "Bob Johnson" }
					);
					context.SaveChanges();
				}
				catch (Exception ex)
				{
					var logger = services.GetRequiredService<ILogger<Program>>();
					logger.LogError(ex, "An error occurred seeding the DB.");
				}
			}

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapScalarApiReference();

			app.MapControllers();

			app.Run();
		}
	}
}
