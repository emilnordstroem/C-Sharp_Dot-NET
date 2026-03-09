using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Lektion_11_BlazorWebAssembly.Client
{
	internal class Program
	{
		static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);

			await builder.Build().RunAsync();
		}
	}
}
