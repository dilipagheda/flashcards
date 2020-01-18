using System;
using System.Collections.Generic;

namespace api_flashcards_dotnet.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DeckId { get; set; }
        public Deck Deck { get; set; }
        public List<Question> Questions { get; set; }
    }
}
