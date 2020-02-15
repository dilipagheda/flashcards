using System;
using FluentAssertions;
using web_flashcards_dotnet_mvc.Services;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public async void LoginSuccess()
        {
            var client = new FlashcardClient("https://localhost:5001");
            var user = await client.Login("dilip@yahoo.com", "Pa$$w0rd");

            user.Should().NotBeNull();
            user.DisplayName.Should().Be("Dilip Agheda");
            user.Token.Should().NotBeNull();
        }

        [Fact]
        public async void LoginFailure()
        {
            var client = new FlashcardClient("https://localhost:5001");
            var user = await client.Login("dip@yahoo.com", "Pa$$w0rd");

            user.Should().BeNull();

        }


    }
}
