using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevQuiz.Core.Models.TransportModels
{
    public class Question
    {
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
