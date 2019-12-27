using System;
using System.ComponentModel.DataAnnotations;

namespace web_flashcards_dotnet_mvc.Models
{
    public class Card
    {
        public int Id { get; set; }
        public int DeckId { get; set; }
        [Required, StringLength(200)]
        public string Question { get; set; }
        [Required, StringLength(200)]
        public string Answer { get; set; }
    }
}
