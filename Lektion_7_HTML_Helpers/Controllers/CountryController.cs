using System.Text.Json;
using Lektion_7_HTML_Helpers.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lektion_7_HTML_Helpers.Controllers
{
	public class CountryController : Controller
	{
		private List<SelectListItem> _countryList = new List<SelectListItem>();

		// Task 1
		public IActionResult Index(string SelectedCountry)
		{
			if (HttpContext.Session.GetString("CountryList") == null)
			{
				_countryList.Add(new SelectListItem { Text = "China", Value = "CN" });
				_countryList.Add(new SelectListItem { Text = "Denmark", Value = "DK" });
				_countryList.Add(new SelectListItem { Text = "Germany", Value = "DE" });
				_countryList.Add(new SelectListItem { Text = "France", Value = "FR" });
				_countryList.Add(new SelectListItem { Text = "Sweden", Value = "SE" });
				HttpContext.Session.SetString(
					"CountryList", 
					JsonSerializer.Serialize(_countryList)
				);
			}
			else
			{
				_countryList = JsonSerializer.Deserialize<List<SelectListItem>>(HttpContext.Session.GetString("CountryList"));
			}

			Utilities.SortSelectedList(_countryList, SelectedCountry);

			ViewBag.Countries = _countryList;
			ViewBag.CountryCode = SelectedCountry;

			return View();
		}

		[HttpPost]
		public IActionResult Index(IFormCollection formData)
		{
			if (HttpContext.Session.GetString("CountryList") != null)
			{
				_countryList = JsonSerializer.Deserialize<List<SelectListItem>>(HttpContext.Session.GetString("CountryList"));
			}

			_countryList.Add(
				new SelectListItem 
				{ 
					Text = formData["Country"], 
					Value = formData["Code"] 
				}
			);

			HttpContext.Session.SetString(
				"CountryList",
				JsonSerializer.Serialize(_countryList)
			);

			ViewBag.Countries = _countryList;

			return View();
		}
	}
}
