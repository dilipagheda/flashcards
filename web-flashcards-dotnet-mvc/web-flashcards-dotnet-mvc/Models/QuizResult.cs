using System;
namespace web_flashcards_dotnet_mvc.Models
{
    public class QuizResult
    {
        public QuizResult()
        {
            TotalCorrect = 0;
            TotalQuestions = 0;
        }
        public int TotalCorrect { get; set; }
        public int TotalQuestions { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public int DeckId { get; set; }
    }
}
