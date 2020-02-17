using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using web_flashcards_dotnet_mvc.Services.Models;

namespace web_flashcards_dotnet_mvc.ViewModels
{
    public class DeckViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public int TotalCards { get; set; }

        public List<Card> Cards { get; set; }
    }

}
