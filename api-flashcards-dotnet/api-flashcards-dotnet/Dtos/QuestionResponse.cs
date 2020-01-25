using System;
namespace api_flashcards_dotnet.Dtos
{
    public class QuestionResponse
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
    }
}
