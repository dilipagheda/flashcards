using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using api_flashcards_dotnet.Models;

namespace api_flashcards_dotnet.Data
{
    public interface IFlashcardDataRepository
    {
        public Task AddDeck(string deckName);

        public Task<List<Deck>> GetAllDecks();
    }
}
