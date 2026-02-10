using Microsoft.AspNetCore.Mvc;
using Lektion_6_MVC.Models;

namespace Lektion_6_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            string name = "Emil";            
            int age = 23;            
            DateTime birthday = DateTime.Now;

			ViewBag.name = name;
			ViewBag.age = age;
			ViewBag.birthday = birthday;

			return View(new Person(name, age, birthday));
        }
    }
}
