using System;
using Microsoft.AspNetCore.Identity;

namespace api_flashcards_dotnet.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
