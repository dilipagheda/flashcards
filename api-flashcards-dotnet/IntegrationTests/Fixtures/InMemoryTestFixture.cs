using System;
using api_flashcards_dotnet.Data;
using Microsoft.EntityFrameworkCore;

namespace IntegrationTests.Fixtures
{
    public class InMemoryTestFixture : IDisposable
    {
        public FlashcardDbContext Context => InMemoryContext();

        public void Dispose()
        {
            Context?.Dispose();
        }

        private static FlashcardDbContext InMemoryContext()
        {
            var options = new DbContextOptionsBuilder<FlashcardDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            var context = new FlashcardDbContext(options);

            return context;
        }
     }
}
