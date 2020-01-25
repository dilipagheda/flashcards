using System.Collections.Generic;
using api_flashcards_dotnet.Dtos.Models;

namespace api_flashcards_dotnet.Dtos
{
    public class DeckResponse
    {
        public List<DeckResponseDto> Decks { get; set; }
    }
}
