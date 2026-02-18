using System.Text.Json;
using Lektion_7_HTML_Helpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lektion_7_HTML_Helpers.Controllers
{
	public class ParkingController : Controller
	{
		private ParkingTicketMachine _parkingTicketMachine;

		[HttpGet]
		public IActionResult Index()
		{
			if (HttpContext.Session.GetString("ParkingTicketMachine") == null)
			{
				_parkingTicketMachine = new ParkingTicketMachine
				{
					TimeNow = DateTime.Now,
					PaidUntil = DateTime.Now,
					MinutesPerKr = 3,
					AmountInserted = 0,
					CoinsToInsert = [1, 2, 5, 10, 20]
				};
				HttpContext.Session.SetString(
					"ParkingTicketMachine",
					JsonSerializer.Serialize(_parkingTicketMachine)
				);
			}
			else
			{
				_parkingTicketMachine = JsonSerializer.Deserialize<ParkingTicketMachine>(
					HttpContext.Session.GetString("ParkingTicketMachine")
				);
			}

			return View(_parkingTicketMachine);
		}

		[HttpPost]
		public IActionResult Index(IFormCollection formCollection)
		{
			if (HttpContext.Session.GetString("ParkingTicketMachine") == null)
			{
				return Index();
			} 
			else
			{
				_parkingTicketMachine = JsonSerializer.Deserialize<ParkingTicketMachine>(
					HttpContext.Session.GetString("ParkingTicketMachine")
				);
			}

			if (!string.IsNullOrEmpty(formCollection["cancel"]))
			{
				HttpContext.Session.SetString(
					"ParkingTicketMachine",
					null
				);
				return View();
			}
			else if (!string.IsNullOrEmpty(formCollection["confirm"]))
			{
				return View("Confirm", _parkingTicketMachine);
			}

			int amountedInserted = 0;
			if (!string.IsNullOrEmpty(formCollection["AmountInserted"]))
			{
				amountedInserted += int.Parse(formCollection["AmountInserted"]);
			}
			else if (!string.IsNullOrEmpty(formCollection["1"]))
			{
				amountedInserted += 1;
			}
			else if (!string.IsNullOrEmpty(formCollection["2"]))
			{
				amountedInserted += 2;
			}
			else if (!string.IsNullOrEmpty(formCollection["5"]))
			{
				amountedInserted += 5;
			}
			else if (!string.IsNullOrEmpty(formCollection["10"]))
			{
				amountedInserted += 10;
			}
			else if (!string.IsNullOrEmpty(formCollection["20"]))
			{
				amountedInserted += 20;
			}
			_parkingTicketMachine.InsertAmount(amountedInserted);

			HttpContext.Session.SetString(
				"ParkingTicketMachine",
				JsonSerializer.Serialize(_parkingTicketMachine)
			);

			return View(_parkingTicketMachine);
		}

		[HttpGet]
		public IActionResult Confirm(ParkingTicketMachine? parkingTicketMachine)
		{
			if (parkingTicketMachine == null)
			{
				return View("Index", parkingTicketMachine);
			}
			return View(parkingTicketMachine);
		}
	}
}