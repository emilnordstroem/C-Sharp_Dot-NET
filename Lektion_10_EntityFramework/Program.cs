using Context;

namespace Lektion_10_EntityFramework
{
	public class Program
	{
		private static BilContext context = new BilContext();
		public static void Main(string[] args)
		{

			// Check om DB findes ud fra database string i context
			bool created = context.Database.EnsureCreated();
			if (created)
			{
				Console.WriteLine("Database created");
			}

			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();

			var app = builder.Build();

			app.UseHttpsRedirection();
			app.UseRouting();

			app.UseAuthorization();

			app.MapStaticAssets();
			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}"
			).WithStaticAssets();

			app.Run();
		}
	}
}
