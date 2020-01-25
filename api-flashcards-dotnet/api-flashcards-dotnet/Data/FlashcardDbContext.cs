using System;
using api_flashcards_dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace api_flashcards_dotnet.Data
{
    public class FlashcardDbContext:DbContext
    {
        public FlashcardDbContext(DbContextOptions<FlashcardDbContext> options)
            : base(options)
        { }

        public DbSet<Deck> Decks { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
