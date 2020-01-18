using System;
namespace api_flashcards_dotnet.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }   
}
