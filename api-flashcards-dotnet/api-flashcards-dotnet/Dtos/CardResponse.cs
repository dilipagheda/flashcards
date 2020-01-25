using System;
using System.Collections.Generic;
using api_flashcards_dotnet.Dtos.Models;

namespace api_flashcards_dotnet.Dtos
{
    public class CardResponse
    {
        public List<CardResponseDto> Cards { get; set; }
    }
}
