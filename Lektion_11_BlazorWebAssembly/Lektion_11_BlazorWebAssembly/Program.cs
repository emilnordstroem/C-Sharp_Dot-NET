using Lektion_11_BlazorWebAssembly.Client.Pages;
using Lektion_11_BlazorWebAssembly.Components;
using Lektion_11_WebAPI.Models;

namespace Lektion_11_BlazorWebAssembly
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDbContext<CalculationContext>();
			builder.Services.AddControllers();
			builder.Services.AddRazorComponents()
				.AddInteractiveWebAssemblyComponents();
			builder.Services.AddScoped(sp => new HttpClient
			{
				BaseAddress = new Uri("http://localhost:5088/")
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
			}
			app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
			app.UseAntiforgery();

			app.MapStaticAssets();
			app.MapControllers();
			app.MapRazorComponents<App>()
				.AddInteractiveWebAssemblyRenderMode()
				.AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

			app.Run();
		}
	}
}
