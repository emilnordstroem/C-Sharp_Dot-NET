using Microsoft.AspNetCore.Mvc;
using Lektion_6_MVC.Models;

namespace Lektion_6_MVC.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {

            List<Person> people = new List<Person>
            {
                new Person("Megan", "Bite", "Coding Street 101", "8000", "Aarhus C", new List<string> { "10010110" }),
				new Person("Colen", "Huber", "Network Avenue 5", "8000", "Aarhus C", new List<string> { "10010110", "10110011" }),
				new Person("Keyn", "Board", "Hardware Ally 4", "8000", "Aarhus C", new List<string> { "10010110", "10110011", "11101100" }),
				new Person("Hugh", "Illy", "Algorithm Square 1", "8000", "Aarhus C", new List<string> { "10010110", "10110011", "11101100", "10010011" }),
				new Person("Marten", "Schreen", "Lambda Road 60", "8000", "Aarhus C", new List<string> { "10010110", "10110011", "11101100", "10010011", "01010001" })
			};
            people.First().Birthdate = DateTime.Now;

            ViewBag.people = people;

            return View();
        }
    }
}
