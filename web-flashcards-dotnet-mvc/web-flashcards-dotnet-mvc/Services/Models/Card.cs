using System;
namespace web_flashcards_dotnet_mvc.Services.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
    }
}
