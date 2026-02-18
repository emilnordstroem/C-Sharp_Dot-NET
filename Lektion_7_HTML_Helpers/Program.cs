namespace Lektion_7_HTML_Helpers
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			builder.Services.AddDistributedMemoryCache();
			builder.Services.AddSession(options =>
			{
				options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
				options.Cookie.HttpOnly = true; // Security
				options.Cookie.IsEssential = true; // Required for GDPR compliance
			});

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			app.UseSession();

			app.UseRouting();

			app.UseAuthorization();

			app.MapStaticAssets();
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Breakfast}/{action=Index}/{id?}")
				.WithStaticAssets();

			app.Run();
		}
	}
}
