using System;
using System.Collections.Generic;
using api_flashcards_dotnet.Models;

namespace api_flashcards_dotnet.Dtos
{
    public class DecksResponse
    {
        public List<Deck> Decks { get; set; }
    }
}
