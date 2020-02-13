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
using System.Net;
using Microsoft.AspNetCore.Http;

namespace UnitTests
{
    public class CardsControllerTests
    {
        private readonly IMapper iMapper;

        public CardsControllerTests()
        {
            //Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Card, CardResponseDto>();
                cfg.CreateMap<List<Card>, CardResponse>()
                    .ForMember(dest => dest.Cards, opt => opt.MapFrom(src => src));
            });
            iMapper = config.CreateMapper();

        }

        [Fact]
        public async Task Get_Method_Returns_Ok_DeckExists()
        {
            //Arrange
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.isDeckExist(1)).Returns( (int id) => Task.FromResult(true));
            mockRepository.Setup(x => x.GetCardsByDeckId(1)).Returns(Task.FromResult(GetFakeCards()));

            CardsController cardsController = new CardsController(mockRepository.Object, iMapper);

            //Act
            var result = await cardsController.Get(1);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var returnCards = Assert.IsType<CardResponse>(okObjectResult.Value);
            Assert.Equal(2, returnCards.Cards.Count);
        }

        [Fact]
        public async Task Get_Method_Returns_NotFound_DeckNotExist()
        {
            //Arrange
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.isDeckExist(1)).Returns((int id) => Task.FromResult(false));

            CardsController cardsController = new CardsController(mockRepository.Object, iMapper);

            //Act
            var result = await cardsController.Get(1);

            //Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            var errorResponse = Assert.IsType<ErrorResponse>(notFoundObjectResult.Value);
            Assert.Equal("Deck with Id 1 not found", errorResponse.Errors[0]);
        }

        [Fact]
        public async Task Post_Method_Returns_NotFound_DeckNotExist()
        {
            //Arrange
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.isDeckExist(1)).Returns((int id) => Task.FromResult(false));

            CardsController cardsController = new CardsController(mockRepository.Object, iMapper);
            CardRequest cardRequest = new CardRequest()
            {
                QuestionText = "q1",
                AnswerText = "a1"
            };
            //Act
            var result = await cardsController.Post(1,cardRequest);

            //Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            var errorResponse = Assert.IsType<ErrorResponse>(notFoundObjectResult.Value);
            Assert.Equal("Deck with Id 1 not found", errorResponse.Errors[0]);
        }

        [Fact]
        public async Task Post_Method_Returns_CreatedAtAction_DeckExists()
        {
            //Arrange
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.isDeckExist(1)).Returns((int id) => Task.FromResult(true));
            mockRepository.Setup(x => x.AddCardToDeck(1, "q1", "a1"))
                        .Returns( (int id, string questionText, string answerText) => Task.FromResult( new Card() { Id=id, QuestionText=questionText, AnswerText=answerText }  ));

            CardsController cardsController = new CardsController(mockRepository.Object, iMapper);
            CardRequest cardRequest = new CardRequest()
            {
                QuestionText = "q1",
                AnswerText = "a1"
            };
            //Act
            var result = await cardsController.Post(1, cardRequest);

            //Assert
            var createAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            var cardResponseDto = Assert.IsType<CardResponseDto>(createAtActionResult.Value);
            Assert.Equal(1, cardResponseDto.Id);
            Assert.Equal("q1", cardResponseDto.QuestionText);
            Assert.Equal("a1", cardResponseDto.AnswerText);
        }

        [Fact]
        public async Task GetCardFromDeckById_Method_Returns_NotFound_DeckNotExist()
        {
            //Arrange
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.isDeckExist(1)).Returns((int id) => Task.FromResult(false));

            CardsController cardsController = new CardsController(mockRepository.Object, iMapper);

            //Act
            var result = await cardsController.GetCardFromDeckById(1, 1);

            //Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            var errorResponse = Assert.IsType<ErrorResponse>(notFoundObjectResult.Value);
            Assert.Equal("Deck with Id 1 not found", errorResponse.Errors[0]);
        }

        [Fact]
        public async Task GetCardFromDeckById_Method_Returns_Ok_DeckExist()
        {
            //Arrange
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.isDeckExist(1)).Returns((int id) => Task.FromResult(true));
            mockRepository.Setup(x => x.GetCardFromDeckByCardId(1,1)).Returns((int id, int cardId) => Task.FromResult(new Card() { Id=cardId, DeckId=id, QuestionText="q1", AnswerText="a1" }));

            CardsController cardsController = new CardsController(mockRepository.Object, iMapper);

            //Act
            var result = await cardsController.GetCardFromDeckById(1, 1);

            //Assert
            var okObjectResult = Assert.IsType<OkObjectResult>(result);
            var cardResponseDto = Assert.IsType<CardResponseDto>(okObjectResult.Value);
            Assert.Equal(1, cardResponseDto.Id);
            Assert.Equal("q1", cardResponseDto.QuestionText);
            Assert.Equal("a1", cardResponseDto.AnswerText);
        }

        [Fact]
        public async Task DeleteCardFromDeckById_Method_Returns_NotFound_DeckNotExist()
        {
            //Arrange
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.isDeckExist(1)).Returns((int id) => Task.FromResult(false));

            CardsController cardsController = new CardsController(mockRepository.Object, iMapper);

            //Act
            var result = await cardsController.DeleteCardFromDeckById(1, 1);

            //Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            var errorResponse = Assert.IsType<ErrorResponse>(notFoundObjectResult.Value);
            Assert.Equal("Deck with Id 1 not found", errorResponse.Errors[0]);
        }

        [Fact]
        public async Task DeleteCardFromDeckById_Method_Returns_NotFound_DeckExist_CardNotExist()
        {
            //Arrange
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.isDeckExist(1)).Returns((int id) => Task.FromResult(true));
            mockRepository.Setup(x => x.DeleteCardFromDeckByCardId(1, 1)).Returns((int id, int cardId)=>Task.FromResult(false));

            CardsController cardsController = new CardsController(mockRepository.Object, iMapper);

            //Act
            var result = await cardsController.DeleteCardFromDeckById(1, 1);

            //Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            var errorResponse = Assert.IsType<ErrorResponse>(notFoundObjectResult.Value);
            Assert.Equal("Card with Id 1 not found", errorResponse.Errors[0]);
        }

        [Fact]
        public async Task DeleteCardFromDeckById_Method_Returns_NoContent_DeckExist_CardExist()
        {
            //Arrange
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.isDeckExist(1)).Returns((int id) => Task.FromResult(true));
            mockRepository.Setup(x => x.DeleteCardFromDeckByCardId(1, 1)).Returns((int id, int cardId) => Task.FromResult(true));

            CardsController cardsController = new CardsController(mockRepository.Object, iMapper);

            //Act
            var result = await cardsController.DeleteCardFromDeckById(1, 1);

            //Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, noContentResult.StatusCode);
            
        }

        [Fact]
        public async Task UpdateCardFromDeckById_Method_Returns_NotFound_DeckNotExist()
        {
            //Arrange
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.isDeckExist(1)).Returns((int id) => Task.FromResult(false));

            CardsController cardsController = new CardsController(mockRepository.Object, iMapper);
            Card card = new Card()
            {
                Id=1,
                DeckId=1,
                QuestionText="q1",
                AnswerText="a1"
            };
            //Act
            var result = await cardsController.UpdateCardFromDeckById(1, 1, card);

            //Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            var errorResponse = Assert.IsType<ErrorResponse>(notFoundObjectResult.Value);
            Assert.Equal("Deck with Id 1 not found", errorResponse.Errors[0]);
        }

        [Fact]
        public async Task UpdateCardFromDeckById_Method_Returns_NotFound_DeckExist_CardNotExist()
        {
            //Arrange
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.isDeckExist(1)).Returns((int id) => Task.FromResult(true));
            mockRepository.Setup(x => x.UpdateCardFromDeckByCardId(1, 1, "q1","a1"))
                .Returns((int id, int cardId, string questionText, string answerText) => Task.FromResult(false));

            CardsController cardsController = new CardsController(mockRepository.Object, iMapper);
            Card card = new Card()
            {
                Id = 1,
                DeckId = 1,
                QuestionText = "q1",
                AnswerText = "a1"
            };
            //Act
            var result = await cardsController.UpdateCardFromDeckById(1, 1,card);

            //Assert
            var notFoundObjectResult = Assert.IsType<NotFoundObjectResult>(result);
            var errorResponse = Assert.IsType<ErrorResponse>(notFoundObjectResult.Value);
            Assert.Equal("Card with Id 1 not found", errorResponse.Errors[0]);
        }

        [Fact]
        public async Task UpdateCardFromDeckById_Method_Returns_NoContent_DeckExist_CardExist()
        {
            //Arrange
            var mockRepository = new Mock<IFlashcardDataRepository>();
            mockRepository.Setup(x => x.isDeckExist(1)).Returns((int id) => Task.FromResult(true));
            mockRepository.Setup(x => x.UpdateCardFromDeckByCardId(1, 1, "q1", "a1"))
                .Returns((int id, int cardId, string questionText, string answerText) => Task.FromResult(true));

            CardsController cardsController = new CardsController(mockRepository.Object, iMapper);
            Card card = new Card()
            {
                Id = 1,
                DeckId = 1,
                QuestionText = "q1",
                AnswerText = "a1"
            };


            //Act
            var result = await cardsController.UpdateCardFromDeckById(1, 1,card);

            //Assert
            var noContentResult = Assert.IsType<NoContentResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, noContentResult.StatusCode);

        }

        //PRIVATE HELPER METHOD TO GET FAKE DECKS
        private List<Card> GetFakeCards()
        {
            return new List<Card>()
                {
                    new Card()
                    {
                        Id = 1,
                        DeckId = 1,
                        QuestionText = "q1",
                        AnswerText = "a1"
                    },
                    new Card()
                    {
                        Id = 2,
                        DeckId = 1,
                        QuestionText = "q2",
                        AnswerText = "a2"
                    }
                };
        }
    }
}
