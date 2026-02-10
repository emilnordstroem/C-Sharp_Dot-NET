using Microsoft.AspNetCore.Mvc;

namespace Lektion_6_MVC.Controllers
{
    public class CalculatorController : Controller
    {
        [HttpGet]
        public IActionResult TimeCalculator()
        {
            return View();
        }

		[HttpPost]
		public ActionResult TimeCalculator(IFormCollection formCollection)
		{
            int hours = Convert.ToInt32(formCollection["Hours"]);
			int minutes = Convert.ToInt32(formCollection["Minutes"]);
			int seconds = Convert.ToInt32(formCollection["Seconds"]);

            TimeSpan timespan = new TimeSpan(0, hours, minutes, seconds);
            double totalNumberOfSeconds = timespan.TotalSeconds;

            ViewBag.hours = hours;
			ViewBag.minutes = minutes;
			ViewBag.seconds = seconds;
			ViewBag.totalNumberOfSeconds = totalNumberOfSeconds;

            return View("TimeCalculationResult");
		}

	}
}
