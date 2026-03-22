
using Lektion_14_TLA_DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Lektion_14_TLA_Presentation
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers();
			builder.Services.AddDbContext<StuderendeContext>();
			// builder.Services.AddDbContext<StuderendeContext>(options =>
			//	options.UseInMemoryDatabase("Studerende"));

			builder.Services.AddOpenApi();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
