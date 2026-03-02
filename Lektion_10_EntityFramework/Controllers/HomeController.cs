using System.Diagnostics;
using Lektion_10_EntityFramework.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lektion_10_EntityFramework.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

	}
}
