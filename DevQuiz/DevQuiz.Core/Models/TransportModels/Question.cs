using System.Collections.Generic;
using System.Linq;

namespace DevQuiz.Core.Models.TransportModels
{
    public class Question
    {
        private static int idCounter = 0;

        public Question() { }

        public Question(DifficultyEnum difficulty, string questionText)
        {
            QuestionId = ++idCounter;
            Difficulty = difficulty;
            Text = questionText;
        }

        public int QuestionId { get; set; }
        public string Text { get; set; }
        public DifficultyEnum Difficulty { get; set; }
        public IEnumerable<PossibleAnswer> PossibleAnswers { get; set; }

        public bool WasAnswered
        {
            get
            {
                return PossibleAnswers.Any(x => x.MarkedByPlayerAsCorrectAnswer);
            }
        }

        public bool IsAnsweredCorrectly
        {
            get
            {
                var ca = PossibleAnswers.Where(x => x.IsReallyCorrectAnswer);
                return ca.Any(x => x.MarkedByPlayerAsCorrectAnswer);
            }
        }
    }
}
