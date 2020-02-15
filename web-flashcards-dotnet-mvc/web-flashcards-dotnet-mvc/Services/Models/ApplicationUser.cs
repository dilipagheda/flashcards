using System;
using Microsoft.AspNetCore.Identity;

namespace web_flashcards_dotnet_mvc.Services.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Token { get; set; }
    }
}
