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
            _decks.Add(new Deck() { Id = 1, Name = "JavaScript", Cards = new List<Card>() {
                    new Card()
                    {
                        Id=1,
                        DeckId=1,
                        Question = "what is javascript?",
                        Answer = "it is language of internet"
                    },
                    new Card()
                    {
                        Id=2,
                        DeckId=1,
                        Question = "what is c#?",
                        Answer = "it is language invented by microsoft"
                    },
                    new Card()
                    {
                        Id=3,
                        DeckId=1,
                        Question = "who invented java?",
                        Answer = "sun microsystem"
                    }
                } }) ;
            _decks.Add(new Deck() { Id = 2, Name = "React", Cards = new List<Card>() });
            _decks.Add(new Deck() { Id = 3, Name = ".NET" , Cards = new List<Card>() });
        }

        public void AddDeck(string name)
        {
            int count = _decks.Count;
            _decks.Add(new Deck() { Id = count + 1, Name = name, Cards = new List<Card>() });
        }

        public int Commit()
        {
            return 0;
        }

        public IEnumerable<Deck> GetDecks()
        {
            return _decks;
        }

        public void AddCardToDeck(Card card)
        {
            card.Id = _decks[card.DeckId-1].Cards.Count + 1;
            _decks[card.DeckId-1].Cards.Add(card);
        }
        public void DeleteCardFromDeck(int deckId, int cardId)
        {
            _decks[deckId-1].Cards.RemoveAt(cardId-1);
        }

        //currentCardId = -1 for the first card request
        public Card GetNextCardFromDeck(int deckId, int currentCardId)
        {
            if (currentCardId == -1)
            {
                //return first element
                return _decks[deckId - 1].Cards[0];
            }
            if(currentCardId <= _decks[deckId - 1].Cards.Count - 1)
            {
                return _decks[deckId - 1].Cards[currentCardId];
            }
            else
            {
                return null;
            }
        }
    }
}
