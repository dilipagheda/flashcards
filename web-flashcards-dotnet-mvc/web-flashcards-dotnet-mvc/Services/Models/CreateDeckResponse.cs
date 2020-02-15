using System;
using System.Collections.Generic;
using web_flashcards_dotnet_mvc.Services.Models.ErrorHandling;

namespace web_flashcards_dotnet_mvc.Services.Models
{
    public class CreateDeckResponse
    {
        public bool isSuccess { get; set; }
        public Errors Errors { get; set; }
    }
}

