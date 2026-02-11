using Microsoft.AspNetCore.Mvc;
using Lektion_6_MVC.Models;

namespace Lektion_6_MVC.Controllers
{
    public class MusicStoreController : Controller
    {
        public IActionResult Index()
        {

            Book book = new Book(
                "The Coming Wave", 
                "Mustafa Suleyman", 
                "The Bodley Head London", 
                2025, 
                "9781847927484", 
                214.28, 
                @"..\Image\The_Coming_Wave_Cover.jpg"
            );
            MusicCD cd = new MusicCD(
                "DeBí TiRAR MáS FOToS", 
                "Bad Bunny", 
                "Rimas Entertainment LLC", 
                2025, 
                new List<Track> { 
                    new Track("NUEVAYoL", "x", "2:28"), 
                    new Track("WELTiTA", "x", "2:57"),
                    new Track("DtMF", "x", "2:24")
                }, 
                8.99, 
                @"..\Image\Debi_Tirar_Mas_Fotos_Cover.png"
            );

            ViewBag.book = book;
            ViewBag.cd = cd;
            
            return View();
        }
    }
}
