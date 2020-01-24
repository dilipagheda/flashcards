using System;
using System.ComponentModel.DataAnnotations;

namespace api_flashcards_dotnet.Dtos
{
    public class DeckRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
    }
}
