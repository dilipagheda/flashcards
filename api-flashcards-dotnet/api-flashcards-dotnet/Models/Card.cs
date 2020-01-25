using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace api_flashcards_dotnet.Models
{
    public class Card
    {
        public int Id { get; set; }
        [Required]
        [StringLength(150, MinimumLength = 5)]
        public string Name { get; set; }
        public int DeckId { get; set; }
        public Deck Deck { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string QuestionText { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string AnswerText { get; set; }
    }
}
