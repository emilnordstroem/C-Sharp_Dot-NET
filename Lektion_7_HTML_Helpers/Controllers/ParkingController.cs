using System.Text.Json;
using Lektion_7_HTML_Helpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lektion_7_HTML_Helpers.Controllers
{
	public class ParkingController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			ParkingTicketMachine parkingTicketMachine = new ParkingTicketMachine
			{
				TimeNow = DateTime.Now,
				PaidUntil = DateTime.Now,
				MinutesPerKr = 3,
				AmountInserted = 0,
				CoinsToInsert = [1,2,5,10,20]
			};
			return View(parkingTicketMachine);
		}

		[HttpPost]
		public IActionResult Index(IFormCollection formData)
		{
			ParkingTicketMachine parkingTicketMachine = new ParkingTicketMachine
			{
				TimeNow = DateTime.Now,
				PaidUntil = DateTime.Now,
				MinutesPerKr = 3,
				AmountInserted = 0,
				CoinsToInsert = [1, 2, 5, 10, 20]
			};

			int amountedInserted = 0;
			if (!string.IsNullOrEmpty(formData["AmountInserted"]))
			{
				amountedInserted += int.Parse(formData["AmountInserted"]);
			}
			else if (!string.IsNullOrEmpty(formData["1 kr"]))
			{
				amountedInserted += 1;
			}
			else if (!string.IsNullOrEmpty(formData["2 kr"]))
			{
				amountedInserted += 2;
			}
			else if (!string.IsNullOrEmpty(formData["5 kr"]))
			{
				amountedInserted += 5;
			}
			else if (!string.IsNullOrEmpty(formData["10 kr"]))
			{
				amountedInserted += 10;
			}
			else if (!string.IsNullOrEmpty(formData["20 kr"]))
			{
				amountedInserted += 20;
			}
			parkingTicketMachine.InsertAmount(amountedInserted);

			if (!string.IsNullOrEmpty(formData["cancel"]))
			{
				parkingTicketMachine = new ParkingTicketMachine
				{
					TimeNow = DateTime.Now,
					PaidUntil = DateTime.Now,
					MinutesPerKr = 3,
					AmountInserted = 0,
					CoinsToInsert = [1, 2, 5, 10, 20]
				};
			} 
			else if (!string.IsNullOrEmpty(formData["confirm"]))
			{
				return View("Confirm", parkingTicketMachine);
			}

			return View(parkingTicketMachine);
		}

		[HttpGet]
		public IActionResult Confirm(IFormCollection formData)
		{
			ParkingTicketMachine? parkingTicketMachine = JsonSerializer.Deserialize<ParkingTicketMachine>(formData["ParkingTicketMachine"]);
			if (parkingTicketMachine == null)
			{
				return View("Index");
			}
			return View(parkingTicketMachine);
		}
	}
}