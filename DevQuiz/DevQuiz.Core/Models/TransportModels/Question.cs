using System.Collections.Generic;
using System.Linq;

namespace DevQuiz.Core.Models.TransportModels
{
    public class Question
    {
        private static int idCounter = 0;

        public Question()
        {

        }

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

        public bool IsAnsweredCorrectly
        {
            get
            {
                return PossibleAnswers.Where(x => x.IsReallyCorrectAnswer).All(x => x.MarkedByPlayerAsCorrectAnswer);
            }
        }
    }
}
