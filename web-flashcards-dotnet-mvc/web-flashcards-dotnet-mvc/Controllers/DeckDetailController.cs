using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_flashcards_dotnet_mvc.Data;
using web_flashcards_dotnet_mvc.Models;
using web_flashcards_dotnet_mvc.Services;
using web_flashcards_dotnet_mvc.Services.Models;
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

        // GET
        [HttpGet]
        public async Task<ViewResult> AddNewCard(int id)
        {
            var deck = await _flashcardClient.GetDeckById(id);
            var cardViewModel = new CardViewModel()
            {
                DeckId = deck.Id,
                DeckName = deck.Name
            };

            return View(cardViewModel);
        }

        // POST
        [HttpPost]
        public async Task<IActionResult> AddNewCard(int id, CardViewModel cardViewModel)
        {
            var deck = await _flashcardClient.GetDeckById(id);
            cardViewModel.DeckId = deck.Id;
            cardViewModel.DeckName = deck.Name;
            if (!ModelState.IsValid)
            {
                return View(cardViewModel);
            }

            var response = await _flashcardClient.CreateCardByDeckId(id, cardViewModel.QuestionText, cardViewModel.AnswerText);

            if(!response.IsSuccess)
            {
                foreach(var err in response.Errors.ErrorItems.QuestionText)
                {
                    ModelState.AddModelError(err, err);
                }
                foreach (var err in response.Errors.ErrorItems.AnswerText)
                {
                    ModelState.AddModelError(err, err);
                }
                ModelState.AddModelError("errorCreation", "Problem creating card");
                return View(cardViewModel);
            }

            return RedirectToAction("Index", new { id = deck.Id });

        }

        // POST
        [HttpPost]
        public async Task<IActionResult> DeleteCard(int deckId, int cardId)
        {
            var response = await _flashcardClient.DeleteCardByDeckId(deckId, cardId);

            if(!response.IsSuccess)
            {
                return NotFound();
            }
            return RedirectToAction("Index", new { id = deckId });
        }

    }
}
