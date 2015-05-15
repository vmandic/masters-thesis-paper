using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevQuiz.Core.Models.ApplicationModels
{
    public class GameScore
    {
        public decimal Score { get; set; }
        public DateTime RecorededAt { get; set; }
    }
}
