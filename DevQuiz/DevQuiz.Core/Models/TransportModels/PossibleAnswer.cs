
namespace DevQuiz.Core.Models.TransportModels
{
    public class PossibleAnswer
    {
        private static int idCounter = 0;

        public PossibleAnswer()
        {

        }

        public PossibleAnswer(string answerText, bool isCorrect)
        {
            PossibleAnswerId = ++idCounter;
            Text = answerText;
            IsReallyCorrectAnswer = isCorrect;
        }

        public int PossibleAnswerId { get; set; }
        public string Text { get; set; }
        public bool IsReallyCorrectAnswer { get; set; }
        public bool MarkedByPlayerAsCorrectAnswer { get; set; }
    }
}
