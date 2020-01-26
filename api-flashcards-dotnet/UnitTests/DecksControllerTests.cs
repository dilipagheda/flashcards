using System;
using api_flashcards_dotnet.Dtos;
using System.Collections.Generic;
using AutoMapper;
using Moq;
using Xunit;
using api_flashcards_dotnet.Models;
using api_flashcards_dotnet.Data;
using System.Threading.Tasks;
using api_flashcards_dotnet.Controllers;
using Microsoft.AspNetCore.Mvc;
using api_flashcards_dotnet.Dtos.Models;

namespace UnitTests
{
    public class DecksControllerTests
    {
        private readonly IMapper iMapper;

        public DecksControllerTests()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Deck, DeckResponseDto>();
                cfg.CreateMap<List<Deck>, DeckResponse>()
                    .ForMember(dest => dest.Decks, opt => opt.MapFrom(src => src));
            });
            iMapper = config.CreateMapper();

        }

        [Fact]
        public async Task Get_Method_Returns_Ok()
        {

            //Arrange
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.GetAllDecks()).Returns(Task.FromResult(GetFakeDecks()));

            DecksController decksController = new DecksController(mockRepository.Object, iMapper);

            //Act
            var result = await decksController.Get();

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnDecks = Assert.IsType<DeckResponse>(okObjectResult.Value);
            Assert.Equal(2, returnDecks.Decks.Count);
        }

        [Fact]
        public async Task AddDeck_Adds_And_Returns_New_Deck()
        {
            //Arrange


            DeckRequest newDeckRequest = new DeckRequest()
            {
                Name = "ASP.NET Core"
            };
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.AddDeck(newDeckRequest.Name)).Returns((string deckName) =>
            {

                Deck deck = new Deck
                {
                    Id = GetFakeDecks().Count + 1,
                    Name = deckName
                };

                return Task.FromResult<Deck>(deck);
            });


            DecksController decksController = new DecksController(mockRepository.Object, iMapper);
            //Act
            var result = await decksController.AddDeck(newDeckRequest);

            //Assert
            var okObjectResult = Assert.IsType<CreatedAtActionResult>(result);
            var returnDeck = Assert.IsType<DeckResponseDto>(okObjectResult.Value);
            Assert.Equal("ASP.NET Core", returnDeck.Name);
            Assert.IsType<int>(returnDeck.Id);
            Assert.True(returnDeck.Id > 0);
        }

        private List<Deck> GetFakeDecks()
        {
            return new List<Deck>()
                {
                    new Deck()
                    {
                        Id = 1,
                        Name = "JavaScript"
                    },
                    new Deck()
                    {
                        Id = 2,
                        Name = "C#"
                    }
                };
        }

    }
}
