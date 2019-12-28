using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace web_flashcards_dotnet_mvc.Models
{
    public class Deck
    {
        public int Id { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public QuizResult QuizResult { get; set; }
    }
}
