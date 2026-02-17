using Lektion_7_HTML_Helpers.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lektion_7_HTML_Helpers.Controllers
{
	public class CountryController : Controller
	{
		// Task 1
		public IActionResult Index(string SelectedCountry)
		{
			List<SelectListItem> countries = new List<SelectListItem>();
			
			countries.Add(new SelectListItem { Text = "China", Value = "CN" });
			countries.Add(new SelectListItem { Text = "Denmark", Value = "DK" });
			countries.Add(new SelectListItem { Text = "Germany", Value = "DE" });
			countries.Add(new SelectListItem { Text = "France", Value = "FR" });
			countries.Add(new SelectListItem { Text = "Sweden", Value = "SE" });

			Utilities.SortSelectedList(countries, SelectedCountry);

			ViewBag.Countries = countries;
			ViewBag.CountryCode = SelectedCountry;

			return View();
		}

		[HttpPost]
		public IActionResult Index(IFormCollection formData)
		{
			if (ViewBag.Countries == null)
			{
				ViewBag.Countries = new List<SelectListItem>();
			}
			ViewBag.Countries.Add(new SelectListItem { Text = formData["Country"], Value = formData["Code"] });
			return View();
		}
	}
}
