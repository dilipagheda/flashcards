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

        public async Task<Deck> AddDeck(string deckName)
        {
            Deck deck = new Deck()
            {
                Name = deckName
            };
            _context.Decks.Add(deck);
            await _context.SaveChangesAsync();
            return deck;
        }

        public async Task<List<Deck>> GetAllDecks()
        {
           return await _context.Decks.ToListAsync();
        }
    }
}
