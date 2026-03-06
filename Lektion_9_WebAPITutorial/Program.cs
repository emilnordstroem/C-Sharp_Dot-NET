using Microsoft.EntityFrameworkCore;
using Lektion_9_WebAPITutorial.Models;
using Scalar.AspNetCore;

namespace Lektion_9_WebAPITutorial
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddDbContext<TodoContext>(opt =>
				opt.UseInMemoryDatabase("TodoList")
				);
			// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
			builder.Services.AddOpenApi();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.MapOpenApi();
			}

			app.UseAuthorization();
			app.MapScalarApiReference();

			app.MapControllers();

			app.Run();
		}
	}
}
