using System;
using web_flashcards_dotnet_mvc.Services.Models.ErrorHandling;

namespace web_flashcards_dotnet_mvc.Services.Models
{
    public class CreateCardResponse
    {
        public bool IsSuccess { get; set; }
        public Errors Errors { get; set; }
    }
}
