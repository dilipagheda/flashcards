using System;
using System.Collections.Generic;
using web_flashcards_dotnet_mvc.Models;

namespace web_flashcards_dotnet_mvc.Data
{
    public interface IDeckData
    {
        IEnumerable<Deck> GetDecks();
        void AddDeck(string name);
        void AddCardToDeck(Card card);
        void DeleteCardFromDeck(int deckId, int cardId);
        Card GetNextCardFromDeck(int deckId, int currentCardId);
        int Commit();
    }
}
