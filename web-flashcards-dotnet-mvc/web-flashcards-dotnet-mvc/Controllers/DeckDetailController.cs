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
    }
}
