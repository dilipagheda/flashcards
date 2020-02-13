using System;
using api_flashcards_dotnet.Models;

namespace api_flashcards_dotnet.Infrastructure
{
    public interface IJWTGenerator
    {
        string CreateToken(ApplicationUser user);
    }
}
