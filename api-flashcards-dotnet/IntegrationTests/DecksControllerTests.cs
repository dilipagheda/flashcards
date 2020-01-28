using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using api_flashcards_dotnet;
using api_flashcards_dotnet.Dtos;
using api_flashcards_dotnet.Dtos.Models;
using api_flashcards_dotnet.Models;
using FluentAssertions;
using Flurl.Http;
using Xunit;

namespace IntegrationTests
{
    public class DecksControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {

        private readonly CustomWebApplicationFactory<Startup> _factory;

        public DecksControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }


        [Fact]
        public async Task Get_Decks_ReturnSuccess_With_ValidResponse()
        {
            // Arrange
            var _client = _factory.CreateClient();


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
                        Name = "JavaScript"
                    },
                    new DeckResponseDto()
                    {
                        Id=2,
                        Name="C#"
                    }
                }
              );
        }

        [Fact]
        public async Task Add_NewDeck_ReturnsSuccess_Adds_NewDeck()
        {
            // Arrange
            var _client = _factory.CreateClient();


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
                        Name = "JavaScript"
                    },
                    new DeckResponseDto()
                    {
                        Id=2,
                        Name="C#"
                    },
                    new DeckResponseDto()
                    {
                        Id=3,
                        Name="React"
                    }
                }
              );
            //Clean up using Delete call
            _resp = await flurlClient.Request("/decks/3").DeleteAsync();
            _resp.IsSuccessStatusCode.Should().BeTrue("Failed to delete deck id 3");

        }
    }
}
