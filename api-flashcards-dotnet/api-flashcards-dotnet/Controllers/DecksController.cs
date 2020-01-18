using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_flashcards_dotnet.Data;
using api_flashcards_dotnet.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_flashcards_dotnet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DecksController : Controller
    {
        private readonly FlashcardDataRepository _flashcardDataRepository;

        public DecksController(FlashcardDataRepository flashcardDataRepository)
        {
            _flashcardDataRepository = flashcardDataRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Deck>>> Get()
        {
            List<Deck> _decks = await _flashcardDataRepository.GetAllDecks();
            return Ok(_decks);
        }

        [HttpPost]
        public async Task<ActionResult<Deck>> AddDeck([FromBody] Deck deck)
        {
            await _flashcardDataRepository.AddDeck(deck.Name);
            return CreatedAtAction(nameof(Get), new { id = deck.Id }, deck); 
        }
    }
}
