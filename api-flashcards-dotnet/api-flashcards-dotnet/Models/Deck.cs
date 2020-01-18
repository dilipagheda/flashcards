using System;
using System.Collections.Generic;

namespace api_flashcards_dotnet.Models
{
    public class Deck
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
    }
}
