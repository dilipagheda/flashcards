using System;
using System.Collections.Generic;

namespace web_flashcards_dotnet_mvc.Services.Models
{
    public class DeleteCardResponse
    {
        public bool IsSuccess { get; set; }
        public List<string> Errors;
    }
}
