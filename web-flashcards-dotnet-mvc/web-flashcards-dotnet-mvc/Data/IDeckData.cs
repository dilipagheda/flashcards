using System;
using System.Collections.Generic;
using web_flashcards_dotnet_mvc.Models;

namespace web_flashcards_dotnet_mvc.Data
{
    public interface IDeckData
    {
        IEnumerable<Deck> GetDecks();
        void AddDeck(string name);
        int Commit();
    }
}
