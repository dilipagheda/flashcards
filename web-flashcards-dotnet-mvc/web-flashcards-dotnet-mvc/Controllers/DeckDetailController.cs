using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_flashcards_dotnet_mvc.Data;
using web_flashcards_dotnet_mvc.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_flashcards_dotnet_mvc.Controllers
{
    public class DeckDetailController : Controller
    {
        private readonly IDeckData deckData;

        public DeckDetailController(IDeckData deckData)
        {
            this.deckData = deckData;
        }

        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            Deck deck = this.deckData.GetDecks().FirstOrDefault(deck => deck.Id == id);
            return View(deck);
        }

        // GET
        [HttpGet]
        public IActionResult AddNewCard(int id)
        {
            Deck deck = deckData.GetDecks().FirstOrDefault(deck => deck.Id == id);
            Card card = new Card
            {
                DeckId = deck.Id
            };
            ViewData["DeckName"] = deck.Name;
            return View(card);
        }

        // POST
        [HttpPost]
        public IActionResult AddNewCard(int id,Card card)
        {
            Deck deck = deckData.GetDecks().FirstOrDefault(deck => deck.Id == id);
            if (!ModelState.IsValid)
            {
                ViewData["DeckName"] = deck.Name;
                return View(card);
            }
            card.DeckId = deck.Id;
            deckData.AddCardToDeck(card);
            return RedirectToAction("Index", new { id = deck.Id});
            
        }

        // POST
        [HttpPost]
        public IActionResult DeleteCard(int deckId, int cardId)
        {
            deckData.DeleteCardFromDeck(deckId, cardId);
            return RedirectToAction("Index", new { id = deckId });
        }

    }
}
