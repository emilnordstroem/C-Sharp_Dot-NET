using Lektion_10_EntityFramework.DAL;
using Lektion_10_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lektion_10_EntityFramework.Controllers
{
	public class HomeController : Controller
	{
		private readonly BilContext _context;

		public HomeController(BilContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var biler = await _context.Biler.ToListAsync();
			ViewBag.Biler = biler;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(IFormCollection collection)
		{
			int id = Convert.ToInt32(collection["Id"]);
			string navn = collection["Navn"];
			int vaegt = Convert.ToInt32(collection["Vaegt"]);

			Bil bil = new Bil(id, navn, vaegt);
			_context.Biler.Add(bil);
			await _context.SaveChangesAsync();

			return RedirectToAction("Index");
		}

	}
}
