using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using api_flashcards_dotnet;
using api_flashcards_dotnet.Data;
using api_flashcards_dotnet.Dtos;
using api_flashcards_dotnet.Dtos.Models;
using FluentAssertions;
using Flurl.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using api_flashcards_dotnet.Models;
using System.Linq;
using IntegrationTests.Fixtures;

namespace IntegrationTests
{
    public class DecksControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {

        private readonly CustomWebApplicationFactory<Startup> _factory;
        private HttpClient _client;

        public DecksControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
            _client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    var serviceProvider = services.BuildServiceProvider();

                    using (var scope = serviceProvider.CreateScope())
                    {
                        var scopedServices = scope.ServiceProvider;
                        var db = scopedServices
                            .GetRequiredService<FlashcardDbContext>();
                        var logger = scopedServices
                            .GetRequiredService<ILogger<DecksControllerTests>>();

                        db.Database.EnsureDeleted();

                        // Ensure the database is created.
                        db.Database.EnsureCreated();

                        try
                        {
                            // Seed the database with test data.
                            db.Decks.Add(new Deck()
                            {
                                Id = 1,
                                Name = "JavaScript"
                            });
                            db.Decks.Add(new Deck()
                            {
                                Id = 2,
                                Name = "C#"
                            });
                            db.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            logger.LogError(ex, "An error occurred seeding the " +
                                "database with test messages. Error: {Message}", ex.Message);
                        }
                    }
                });
            })
            .CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        [Fact]
        public async Task Get_Decks_ReturnSuccess_With_ValidResponse()
        {
            // Arrange
            //var _client = _factory.CreateClient();


            FlurlClient flurlClient = new FlurlClient(_client);

            // Act
            DeckResponse _deckResponse = await flurlClient.Request("/decks").GetJsonAsync<DeckResponse>();

            // Assert
            _deckResponse.Should().NotBeNull();
            _deckResponse.Decks.Count.Should().Be(2);
            _deckResponse.Decks.Should().BeEquivalentTo(
                new List<DeckResponseDto>()
                {
                    new DeckResponseDto()
                    {
                        Id = 1,
                        Name = "JavaScript",
                        TotalCards = 0
                    },
                    new DeckResponseDto()
                    {
                        Id=2,
                        Name="C#",
                        TotalCards = 0
                    }
                }
              );
        }

        [Fact]
        public async Task Add_NewDeck_ReturnsSuccess_Adds_NewDeck()
        {
            // Arrange
           //var _client = _factory.CreateClient();


            FlurlClient flurlClient = new FlurlClient(_client);

            // Act
            HttpResponseMessage _resp = await flurlClient.Request("/decks").PostJsonAsync(new DeckRequest() { Name = "React" });

            //Assert
            _resp.IsSuccessStatusCode.Should().BeTrue();
            _resp.StatusCode.Should().Be(HttpStatusCode.Created);

            DeckResponse _deckResponse = await flurlClient.Request("/decks").GetJsonAsync<DeckResponse>();

            // Do GET call and assert that new deck is added and returned
            _deckResponse.Decks.Count.Should().Be(3);
            _deckResponse.Decks.Should().BeEquivalentTo(
                new List<DeckResponseDto>()
                {
                    new DeckResponseDto()
                    {
                        Id = 1,
                        Name = "JavaScript",
                        TotalCards = 0
                    },
                    new DeckResponseDto()
                    {
                        Id=2,
                        Name="C#",
                        TotalCards = 0
                    },
                    new DeckResponseDto()
                    {
                        Id=3,
                        Name="React",
                        TotalCards = 0
                    }
                }
              );
            ////Clean up using Delete call
            //_resp = await flurlClient.Request("/decks/3").DeleteAsync();
            //_resp.IsSuccessStatusCode.Should().BeTrue("Failed to delete deck id 3");



        }
    }
}
