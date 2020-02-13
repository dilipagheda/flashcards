using System;
using api_flashcards_dotnet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api_flashcards_dotnet.Data
{
    public class FlashcardDbContext:IdentityDbContext<ApplicationUser>
    {
        public FlashcardDbContext(DbContextOptions<FlashcardDbContext> options)
            : base(options)
        { }

        public DbSet<Deck> Decks { get; set; }
        public DbSet<Card> Cards { get; set; }
    }
}
