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

namespace UnitTests
{
    public class DecksControllerTests
    {

        [Fact]
        public async Task Get_Method_Returns_OkAsync()
        {
            //Arrange
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<List<DeckResponse>>(It.IsAny<List<Deck>>()))
                .Returns(GetFakeDecks());

            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.GetAllDecks()).Returns(Task.FromResult<List<Deck>>(new List<Deck>()));


            using (DecksController decksController = new DecksController(mockRepository.Object, mockMapper.Object))
            {
                //Act
                var result = await decksController.Get();

                //Assert
                var okObjectResult = Assert.IsType<OkObjectResult>(result);
                var returnDecks = Assert.IsType<List<DeckResponse>>(okObjectResult.Value);
                Assert.Equal(2, returnDecks.Count);
            }
        }

        [Fact]
        public async Task AddDeck_Adds_And_Returns_New_DeckAsync()
        {
            //Arrange
            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(x => x.Map<DeckResponse>(It.IsAny<Deck>())).Returns((Deck deck) =>
           {
               return new DeckResponse()
               {
                   Id = deck.Id,
                   Name = deck.Name
               };
           });

            DeckRequest newDeckRequest = new DeckRequest()
            {
                Name = "ASP.NET Core"
            };
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.AddDeck(newDeckRequest.Name)).Returns((string deckName) => {

                Deck deck = new Deck
                {
                    Id = GetFakeDecks().Count + 1,
                    Name = deckName
                };

                return Task.FromResult<Deck>(deck);
            });


            using (DecksController decksController = new DecksController(mockRepository.Object, mockMapper.Object))
            {
                //Act
                var result = await decksController.AddDeck(newDeckRequest);

                //Assert
                var okObjectResult = Assert.IsType<CreatedAtActionResult>(result);
                var returnDeck = Assert.IsType<DeckResponse>(okObjectResult.Value);
                Assert.Equal("ASP.NET Core", returnDeck.Name);
                Assert.IsType<int>(returnDeck.Id);
                Assert.True(returnDeck.Id > 0);
            }
        }

        private List<DeckResponse> GetFakeDecks()
        {
            return new List<DeckResponse>()
                {
                    new DeckResponse()
                    {
                        Id = 1,
                        Name = "JavaScript"
                    },
                    new DeckResponse()
                    {
                        Id = 2,
                        Name = "C#"
                    }
                };
        }
    }
}
