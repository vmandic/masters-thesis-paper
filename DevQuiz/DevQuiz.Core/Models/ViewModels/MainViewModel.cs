using DevQuiz.Core.Models.ApplicationModels;
using System.Collections.Generic;
using System.Linq;

namespace DevQuiz.Core.Models.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            this.Highscores = new List<GameScore>();
        }

        public GameScore LatestHighscore { get { return Highscores.OrderBy(x => x.Score).LastOrDefault(); } }

        public IEnumerable<GameScore> Highscores { get; set; }
    }
}
