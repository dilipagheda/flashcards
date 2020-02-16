using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_flashcards_dotnet_mvc.Data;
using web_flashcards_dotnet_mvc.Models;
using web_flashcards_dotnet_mvc.Services;
using web_flashcards_dotnet_mvc.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_flashcards_dotnet_mvc.Controllers
{
    public class DeckDetailController : Controller
    {
        private readonly FlashcardClient _flashcardClient;

        public DeckDetailController(FlashcardClient flashcardClient)
        {
            _flashcardClient = flashcardClient;
        }

        public async Task<ViewResult> Index(int id)
        {
            var deck = await _flashcardClient.GetDeckById(id);
            var cardsByDeckId = await _flashcardClient.GetCardsByDeckId(id);

            if(deck != null && cardsByDeckId != null)
            {
                var deckViewModel = new DeckViewModel()
                {
                    Id = deck.Id,
                    Name = deck.Name,
                    TotalCards = deck.totalCards,
                    Cards = cardsByDeckId.Cards
                };

                return View(deckViewModel);
            }
            else
            {
                return View("NotFound");
            }

        }

        //// GET
        //[HttpGet]
        //public ViewResult AddNewCard(int id)
        //{
        //    Deck deck = deckData.GetDecks().FirstOrDefault(deck => deck.Id == id);
        //    Card card = new Card
        //    {
        //        DeckId = deck.Id
        //    };
        //    ViewData["DeckName"] = deck.Name;
        //    return View(card);
        //}

        //// POST
        //[HttpPost]
        //public IActionResult AddNewCard(int id,Card card)
        //{
        //    Deck deck = deckData.GetDecks().FirstOrDefault(deck => deck.Id == id);
        //    if (!ModelState.IsValid)
        //    {
        //        ViewData["DeckName"] = deck.Name;
        //        return View(card);
        //    }
        //    card.DeckId = deck.Id;
        //    deckData.AddCardToDeck(card);
        //    return RedirectToAction("Index", new { id = deck.Id});
            
        //}

        //// POST
        //[HttpPost]
        //public IActionResult DeleteCard(int deckId, int cardId)
        //{
        //    deckData.DeleteCardFromDeck(deckId, cardId);
        //    return RedirectToAction("Index", new { id = deckId });
        //}

    }
}
