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
    public class QuizController : Controller
    {
        private readonly FlashcardClient _flashcardClient;

        public QuizController(FlashcardClient flashcardClient)
        {
            _flashcardClient = flashcardClient;
        }

        public async Task<IActionResult> GetCardsByDeckId(int id)
        {
            var deck = await _flashcardClient.GetDeckById(id);
            if(deck==null)
            {
                return Json(new EmptyResult());
            }
            var result = await _flashcardClient.GetCardsByDeckId(id);
            return Json(result.Cards);
        }
    }
}
