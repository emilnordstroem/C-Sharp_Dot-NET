using System.Text.Json;
using Lektion_7_HTML_Helpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lektion_7_HTML_Helpers.Controllers
{
	public class ParkingController : Controller
	{
		[HttpGet]
		public IActionResult Index(ParkingTicketMachine? parkingTicketMachine)
		{
			if (parkingTicketMachine == null)
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
			return View(parkingTicketMachine);
		}

		[HttpPost]
		public IActionResult Index(IFormCollection formCollection)
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
			if (!string.IsNullOrEmpty(formCollection["AmountInserted"]))
			{
				amountedInserted += int.Parse(formCollection["AmountInserted"]);
			}
			else if (!string.IsNullOrEmpty(formCollection["1 kr"]))
			{
				amountedInserted += 1;
			}
			else if (!string.IsNullOrEmpty(formCollection["2 kr"]))
			{
				amountedInserted += 2;
			}
			else if (!string.IsNullOrEmpty(formCollection["5 kr"]))
			{
				amountedInserted += 5;
			}
			else if (!string.IsNullOrEmpty(formCollection["10 kr"]))
			{
				amountedInserted += 10;
			}
			else if (!string.IsNullOrEmpty(formCollection["20 kr"]))
			{
				amountedInserted += 20;
			}
			parkingTicketMachine.InsertAmount(amountedInserted);

			if (!string.IsNullOrEmpty(formCollection["cancel"]))
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
			else if (!string.IsNullOrEmpty(formCollection["confirm"]))
			{
				return View("Confirm", parkingTicketMachine);
			}

			return View(parkingTicketMachine);
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