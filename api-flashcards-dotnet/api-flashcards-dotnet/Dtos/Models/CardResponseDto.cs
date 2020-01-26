using System;
using System.Collections.Generic;

namespace api_flashcards_dotnet.Dtos.Models
{
    public class CardResponseDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
    }
}
