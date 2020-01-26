using System;
using System.ComponentModel.DataAnnotations;

namespace api_flashcards_dotnet.Dtos
{
    public class CardRequest
    {
        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string QuestionText { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string AnswerText { get; set; }
    }
}
