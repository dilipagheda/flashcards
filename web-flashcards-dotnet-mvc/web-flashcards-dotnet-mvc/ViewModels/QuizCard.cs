using System;
namespace web_flashcards_dotnet_mvc.ViewModels
{
    public class QuizCard
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public int DeckId { get; set; }
        public int CardId { get; set; }
    }
}
