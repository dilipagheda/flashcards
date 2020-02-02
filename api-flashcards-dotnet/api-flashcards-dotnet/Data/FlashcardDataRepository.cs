using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_flashcards_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace api_flashcards_dotnet.Data
{
    public class FlashcardDataRepository:IFlashcardDataRepository
    {
        private readonly FlashcardDbContext _context;

        public FlashcardDataRepository(FlashcardDbContext context)
        {
            _context = context;
        }

        public async Task<Card> AddCardToDeck(int deckId, string questionText, string answerText)
        {
            Deck deck = _context.Decks.FirstOrDefault(deck => deck.Id == deckId);

            Card card = new Card()
            {
                QuestionText = questionText,
                AnswerText = answerText,
                DeckId = deckId,
                Deck = deck
            };

            await _context.Cards.AddAsync(card);
            await _context.SaveChangesAsync();
            return card;
        }

        public async Task<Deck> AddDeck(string deckName)
        {
            Deck deck = new Deck()
            {
                Name = deckName
            };
            await _context.Decks.AddAsync(deck);
            await _context.SaveChangesAsync();
            return deck;
        }

        public async Task<List<Deck>> GetAllDecks()
        {
           return await _context.Decks
                            .Include(deck => deck.Cards)
                            .ToListAsync();
        }

        public async Task<Card> GetCardFromDeckByCardId(int deckId, int cardId)
        {
            return await _context.Cards.FirstOrDefaultAsync(card => card.DeckId == deckId && card.Id == cardId);
        }

        public async Task<List<Card>> GetCardsByDeckId(int id)
        {
            return await _context.Cards.Where(card => card.DeckId == id).ToListAsync();
        }

        public async Task<Deck> GetDeckById(int id)
        {
            return await _context.Decks
                    .Include(deck => deck.Cards)
                    .FirstOrDefaultAsync(deck => deck.Id == id);
        }

        public async Task<bool> DeleteDeckById(int id)
        {
            Deck deck = await _context.Decks.FirstOrDefaultAsync(deck => deck.Id == id);
            if(deck != null)
            {
                _context.Decks.Remove(deck);
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateDeckNameById(int id, string name)
        {
            Deck deck = await _context.Decks.FirstOrDefaultAsync(deck => deck.Id == id);
            if (deck != null)
            {
                deck.Name = name;
                await _context.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
