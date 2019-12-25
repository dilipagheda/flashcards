using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web_flashcards_dotnet_mvc.Data;
using web_flashcards_dotnet_mvc.Models;

namespace web_flashcards_dotnet_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDeckData deckData;

        public HomeController(ILogger<HomeController> logger, IDeckData deckData)
        {
            _logger = logger;
            this.deckData = deckData;
        }

        public IActionResult Index()
        {
            return View(this.deckData);
        }

        public IActionResult CreateDeck()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDeck(Deck deck)
        {
            if (!ModelState.IsValid)
            {
                return View(deck);
            }
            deckData.AddDeck(deck.Name);
            return RedirectToAction("Index");
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
