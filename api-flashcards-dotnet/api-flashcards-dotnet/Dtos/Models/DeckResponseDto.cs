using System;
namespace api_flashcards_dotnet.Dtos.Models
{
    public class DeckResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TotalCards { get; set; }

    }
}
