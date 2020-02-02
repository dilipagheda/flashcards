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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace api_flashcards_dotnet.Controllers
{
    public class Try
    {
        public string Name { get; set; }
    }

    [ApiController]
    [Route("[controller]")]
    public class DecksController : ControllerBase
    {
        private readonly IFlashcardDataRepository _flashcardDataRepository;
        private readonly IMapper _mapper;

        public DecksController(IFlashcardDataRepository flashcardDataRepository, IMapper mapper)
        {
            _flashcardDataRepository = flashcardDataRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Deck> _decks = await _flashcardDataRepository.GetAllDecks();


            DeckResponse _deckResponse =_mapper.Map<DeckResponse>(_decks);

            return Ok(_deckResponse);
        }

        [HttpPost]
        public async Task<IActionResult> AddDeck([FromBody] DeckRequest deckRequest)
        {
            Deck _newDeck = await _flashcardDataRepository.AddDeck(deckRequest.Name);
            DeckResponseDto _deckResponseDto = _mapper.Map<DeckResponseDto>(_newDeck);

            return CreatedAtAction(nameof(GetDeckById), new { id = _deckResponseDto.Id }, _deckResponseDto); 
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<IActionResult> GetDeckById(int id)
        {
            Deck _deck = await _flashcardDataRepository.GetDeckById(id);

            if(_deck==null)
            {
                var resp = new ErrorResponse()
                {
                    Error = $"Deck with Id {id} not found"
                };
                return NotFound(resp);
            }
            DeckResponseDto _deckResponseDto = _mapper.Map<DeckResponseDto>(_deck);

            return Ok(_deckResponseDto);
        }

        [HttpDelete("{id:int:min(1)}")]
        public async Task<IActionResult> DeleteDeckById(int id)
        {
            bool result = await _flashcardDataRepository.DeleteDeckById(id);
            if(!result)
            {
                var resp = new ErrorResponse()
                {
                    Error = $"Deck with Id {id} not found"
                };
                return NotFound(resp);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("{id:int:min(1)}")]
        public async Task<IActionResult> UpdateDeckById(int id, [FromBody] Try _try)
        {
            bool result = await _flashcardDataRepository.UpdateDeckNameById(id,_try.Name);
            if (!result)
            {
                var resp = new ErrorResponse()
                {
                    Error = $"Deck with Id {id} not found"
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
