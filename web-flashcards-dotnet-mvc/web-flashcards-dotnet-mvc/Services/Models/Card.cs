using System;
namespace web_flashcards_dotnet_mvc.Services.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string questionText { get; set; }
        public string answerText { get; set; }
    }
}
