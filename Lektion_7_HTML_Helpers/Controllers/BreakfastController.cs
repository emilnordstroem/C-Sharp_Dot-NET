using Lektion_7_HTML_Helpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lektion_7_HTML_Helpers.Controllers
{
	public class BreakfastController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult Confirmation(BreakfastOrder breakfastOrder)
		{
			if (breakfastOrder == null)
			{
				return View("Index");
			}
			return View(breakfastOrder);
		}

		[HttpPost]
		public IActionResult Index(IFormCollection formData)
		{
			string fullname = formData["fullname"];
			string roomnumber = formData["roomnumber"];

			List<string> selectedItems = new List<string>();
			foreach (var data in formData)
			{
				if (data.Key == "menuitem")
				{
					selectedItems.Add(data.Value);
				}
			}

			DateTime deliverydatetime = DateTime.Parse(formData["deliverydatetime"]);

			BreakfastOrder breakfastOrder = new BreakfastOrder() 
			{ 
				Fullname = fullname,
				RoomNumber = roomnumber,
				SelectedItems = selectedItems.ToArray(),
				DeliveryDateTime = deliverydatetime
			};

			return View("Confirmation", breakfastOrder);
		}
	}
}
