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
            List<Card> _cards = await _flashcardDataRepository.GetCardsByDeckId(id);

            CardResponse _cardResponse = _mapper.Map<CardResponse>(_cards);

            return Ok(_cardResponse);
        }

        [HttpPost]
        public async Task<IActionResult> Post(int id, [FromBody] CardRequest cardRequest)
        {
            Card _card = await _flashcardDataRepository.AddCardToDeck(id, cardRequest.QuestionText, cardRequest.AnswerText);

            CardResponseDto _cardResponseDto = _mapper.Map<CardResponseDto>(_card);

            return Ok(_cardResponseDto);
        }
    }
}
