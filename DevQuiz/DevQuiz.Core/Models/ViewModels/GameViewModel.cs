using DevQuiz.Core.Models.TransportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevQuiz.Core.Models.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public DateTime StartTime { get; set; }
        public DifficultyEnum CurrentDifficulty { get; set; }
        public int CurrentQuestionNumber { get; set; }
        public IEnumerable<Question> CurrentQuestions { get; set; }
    }
}
