using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevQuiz.Core.Models.TransportModels
{
    public class PossibleAnswer
    {
        public int PossibleAnswerId { get; set; }
        public string Text { get; set; }
        public bool IsReallyCorrectAnswer { get; set; }
        public bool MarkedByPlayerAsCorrectAnswer { get; set; }
    }
}
