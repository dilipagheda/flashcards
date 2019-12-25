using System;
using System.Collections.Generic;
using web_flashcards_dotnet_mvc.Models;

namespace web_flashcards_dotnet_mvc.Data
{
    public class InMemoryDeckData:IDeckData
    {
        readonly List<Deck> _decks;

        public InMemoryDeckData()
        {
            _decks = new List<Deck>();
            _decks.Add(new Deck() { Id = 1, Name = "JavaScript" });
            _decks.Add(new Deck() { Id = 1, Name = "React" });
            _decks.Add(new Deck() { Id = 1, Name = ".NET" });
        }

        public void AddDeck(string name)
        {
            int count = _decks.Count;
            _decks.Add(new Deck() { Id = count + 1, Name = name });
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Deck> GetDecks()
        {
            return _decks;
        }
    }
}
