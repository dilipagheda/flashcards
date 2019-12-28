using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_flashcards_dotnet_mvc.Data;
using web_flashcards_dotnet_mvc.Models;
using web_flashcards_dotnet_mvc.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_flashcards_dotnet_mvc.Controllers
{
    public class QuizController : Controller
    {
        private readonly IDeckData deckData;

        public QuizController(IDeckData deckData)
        {
            this.deckData = deckData;
        }

        // GET: /<controller>/
        public IActionResult Index(int id, int currentCardId)
        {
            Card card = deckData.GetNextCardFromDeck(id, currentCardId);
            if (card == null)
            {
                return View("QuizResult", deckData.GetQuizResult(id));
            }
            QuizCard quizCard = new QuizCard()
            {
                Question = card.Question,
                Answer = card.Answer,
                DeckId = card.DeckId,
                CardId = card.Id,
            };
            return View(quizCard);
        }
        //GET
        public IActionResult UserResponse(int id, bool isCorrect, int currentCardId)
        {
            deckData.UpdateQuizResult(id, isCorrect);
            return RedirectToAction("Index", new { id , currentCardId });
        }
    }
}
