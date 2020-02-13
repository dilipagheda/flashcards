using System;
using System.ComponentModel.DataAnnotations;

namespace api_flashcards_dotnet.Dtos
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [MinLength(3), MaxLength(20)]
        public string DisplayName { get; set; }
    }
}
