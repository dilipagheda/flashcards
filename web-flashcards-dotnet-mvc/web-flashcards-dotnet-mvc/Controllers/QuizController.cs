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
                QuizResult quizResult = new QuizResult()
                {
                    totalCorrect = 10,
                    totalQuestions = 3
                };
                return View("QuizResult", quizResult);
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

            return RedirectToAction("Index", new { id , currentCardId });
        }
    }
}
