using System.ComponentModel.DataAnnotations;

namespace Lektion_7_HTML_Helpers.Models
{
	public class BreakfastOrder
	{
		[Display(Name = "Your full name")]
		public required string Fullname { get; set; }

		[Display(Name = "Room no.")]
		public required string RoomNumber { get; set; }

		public required string[] SelectedItems { get; set; }

		[Display(Name = "When")]
		public required DateTime DeliveryDateTime { get; set; }
	}
}
