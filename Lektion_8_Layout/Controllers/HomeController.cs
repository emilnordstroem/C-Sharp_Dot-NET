using Microsoft.AspNetCore.Mvc;

namespace Lektion_8_Layout.Controllers
{
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Sale()
		{
			return View();
		}

		[HttpGet]
		public IActionResult MoreSales()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Buy()
		{
			return View();
		}

		[HttpGet]
		public IActionResult BuyAndSell()
		{
			return View();
		}
	}
}
