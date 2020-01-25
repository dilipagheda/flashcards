using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using api_flashcards_dotnet.Dtos.Models;

namespace api_flashcards_dotnet.Dtos
{
    public class DeckRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Name { get; set; }
    }
}
