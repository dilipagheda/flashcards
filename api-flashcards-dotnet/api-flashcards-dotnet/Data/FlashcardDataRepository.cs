using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_flashcards_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace api_flashcards_dotnet.Data
{
    public class FlashcardDataRepository
    {
        private readonly FlashcardDbContext _context;

        public FlashcardDataRepository(FlashcardDbContext context)
        {
            _context = context;
        }

        public async Task AddDeck(string deckName)
        {
            Deck deck = new Deck()
            {
                Name = deckName
            };
            _context.Decks.Add(deck);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Deck>> GetAllDecks()
        {
           return await _context.Decks.ToListAsync();
        }
    }
}
