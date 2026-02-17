using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Lektion_7_HTML_Helpers.Models
{
	public class ParkingTicketMachine
	{
		[Display(Name = "Coin Insert")]
		public List<int>? CoinsToInsert { get; set; }

		[Display(Name = "Kr per Minute")]
		public required int MinutesPerKr { get; set; }

		[Display(Name = "From")]
		public required DateTime TimeNow { get; set; }

		[Display(Name = "Paid until")]
		public DateTime PaidUntil { get; set; }
		
		[Display(Name = "Amount inserted")]
		public required int AmountInserted { get; set; }

		public void InsertAmount(int amount)
		{
			AmountInserted += amount;
			PaidUntil = PaidUntil.AddMinutes(MinutesPerKr * amount);
		}
	}
}