using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_flashcards_dotnet.Data;
using api_flashcards_dotnet.Dtos;
using api_flashcards_dotnet.Dtos.Models;
using api_flashcards_dotnet.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_flashcards_dotnet.Controllers
{
    [ApiController]
    [Route("decks/{id:int:min(1)}/[controller]")]
    public class CardsController : ControllerBase
    {
        private readonly IFlashcardDataRepository _flashcardDataRepository;
        private readonly IMapper _mapper;

        public CardsController(IFlashcardDataRepository flashcardDataRepository, IMapper mapper)
        {
            _flashcardDataRepository = flashcardDataRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            bool isDeckExist = await _flashcardDataRepository.isDeckExist(id);
            if(!isDeckExist)
            {
                var resp = new ErrorResponse()
                {
                    Errors = new List<string>() { $"Deck with Id {id} not found" }
                };
                return NotFound(resp);
            }

            List<Card> _cards = await _flashcardDataRepository.GetCardsByDeckId(id);

            CardResponse _cardResponse = _mapper.Map<CardResponse>(_cards);

            return Ok(_cardResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int id, [FromBody] CardRequest cardRequest)
        {
            bool isDeckExist = await _flashcardDataRepository.isDeckExist(id);
            if (!isDeckExist)
            {
                var resp = new ErrorResponse()
                {
                    Errors = new List<string>() { $"Deck with Id {id} not found" }
                };
                return NotFound(resp);
            }

            Card _card = await _flashcardDataRepository.AddCardToDeck(id, cardRequest.QuestionText, cardRequest.AnswerText);

            CardResponseDto _cardResponseDto = _mapper.Map<CardResponseDto>(_card);

            return CreatedAtAction(nameof(GetCardFromDeckById), new { id , cardId = _cardResponseDto.Id }, _cardResponseDto);
        }

        [HttpGet("{cardId}")]
        public async Task<IActionResult> GetCardFromDeckById(int id, int cardId)
        {
            bool isDeckExist = await _flashcardDataRepository.isDeckExist(id);
            if (!isDeckExist)
            {
                var resp = new ErrorResponse()
                {
                    Errors = new List<string>() { $"Deck with Id {id} not found" }
                };
                return NotFound(resp);
            }

            Card _card = await _flashcardDataRepository.GetCardFromDeckByCardId(id, cardId);

            CardResponseDto _cardResponseDto = _mapper.Map<CardResponseDto>(_card);

            return Ok(_cardResponseDto);
        }

        [HttpDelete("{cardId}")]
        public async Task<IActionResult> DeleteCardFromDeckById(int id, int cardId)
        {
            bool isDeckExist = await _flashcardDataRepository.isDeckExist(id);
            if (!isDeckExist)
            {
                var resp = new ErrorResponse()
                {
                    Errors = new List<string>() { $"Deck with Id {id} not found" }
                };
                return NotFound(resp);
            }

            bool result = await _flashcardDataRepository.DeleteCardFromDeckByCardId(id, cardId);

            if (!result)
            {
                var resp = new ErrorResponse()
                {
                    Errors = new List<string>() { $"Card with Id {id} not found" }
                };
                return NotFound(resp);
            }
            else
            {
                return NoContent();
            }

        }

        [HttpPut("{cardId}")]
        public async Task<IActionResult> UpdateCardFromDeckById(int id, int cardId, [FromBody] Card card)
        {
            bool isDeckExist = await _flashcardDataRepository.isDeckExist(id);
            if (!isDeckExist)
            {
                var resp = new ErrorResponse()
                {
                    Errors = new List<string>() { $"Deck with Id {id} not found" }
                };
                return NotFound(resp);
            }

            bool result = await _flashcardDataRepository.UpdateCardFromDeckByCardId(id, cardId, card.QuestionText, card.AnswerText);

            if (!result)
            {
                var resp = new ErrorResponse()
                {
                    Errors = new List<string>() { $"Card with Id {id} not found" }
                };
                return NotFound(resp);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
