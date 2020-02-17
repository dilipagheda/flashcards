using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using web_flashcards_dotnet_mvc.Data;
using web_flashcards_dotnet_mvc.Models;
using web_flashcards_dotnet_mvc.Services;
using web_flashcards_dotnet_mvc.Services.Models;
using web_flashcards_dotnet_mvc.ViewModels;

namespace web_flashcards_dotnet_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly FlashcardClient _flashcardClient;

        public HomeController(ILogger<HomeController> logger, FlashcardClient flashcardClient)
        {
            _logger = logger;
            _flashcardClient = flashcardClient;
        }

        [HttpGet]
        public async Task<ViewResult> Index()
        {
            DeckResponse deckResponse = await _flashcardClient.GetDecks();

            List<DeckViewModel> decksToDisplay = new List<DeckViewModel>();

            if(deckResponse != null)
            {
                foreach(var deck in deckResponse.Decks)
                {
                    decksToDisplay.Add(new DeckViewModel()
                    {
                        Id = deck.Id,
                        Name = deck.Name,
                        TotalCards = deck.totalCards
                    });
                }
            }


            return View(decksToDisplay);
        }

        public ViewResult CreateDeck()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeck(DeckViewModel deckViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(deckViewModel);
            }

            var result = await _flashcardClient.CreateDeck(deckViewModel.Name);

            if(!result.isSuccess)
            {
                foreach(var err in result.Errors.ErrorItems.Name)
                {
                    ModelState.AddModelError( err , err);
                }
                ModelState.AddModelError( "errorCreation" , "Problem creating a deck");
                return View(deckViewModel);
            }

            return RedirectToAction("Index");
        }

    }
}
