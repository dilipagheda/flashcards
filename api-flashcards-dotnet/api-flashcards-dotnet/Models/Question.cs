using System;
using System.ComponentModel.DataAnnotations;

namespace api_flashcards_dotnet.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string QuestionText { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string AnswerText { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }   
}
