using System;
using System.ComponentModel.DataAnnotations;

namespace api_flashcards_dotnet.Dtos
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

    }
}
