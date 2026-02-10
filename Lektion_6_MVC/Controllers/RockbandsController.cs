using Microsoft.AspNetCore.Mvc;

namespace Lektion_6_MVC.Controllers
{
    public class RockbandsController : Controller
    {
        public IActionResult Rockbands()
        {
            string[] rockbands = { 
                "Led Zeppelin",
                "The Beatles",
                "Pink Floyd",
                "The Jimi Hendrix Experience", 
                "Van Halen",
                "Queen",
                "The Eagles",
                "U2",
                "Bob Marley and the Wailers"
            };
            ViewBag.rockbands = rockbands;
            return View();
        }
    }
}
