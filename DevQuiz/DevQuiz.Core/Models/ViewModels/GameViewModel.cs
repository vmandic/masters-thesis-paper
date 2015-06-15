using DevQuiz.Core.Models.ApplicationModels;
using DevQuiz.Core.Models.TransportModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevQuiz.Core.Models.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public const uint NUMBER_OF_QUESTIONS = 5;

        public DateTime StartTime { get; set; }
        public DifficultyEnum CurrentDifficulty { get; set; }
        public int CurrentQuestionNumber { get; set; }
        public IEnumerable<Question> CurrentQuestions { get; set; }

        private int _correctAnswers = 0;

        public int CorrectAnswers
        {
            get
            {
                return _correctAnswers;
            }
        }
        public int WrongAnswers
        {
            get
            {
                return (int)NUMBER_OF_QUESTIONS - CorrectAnswers;
            }
        }

        public int Score
        {
            get
            {
                return CorrectAnswers * 1000;
            }
        }

        public Question CurrentQuestion { get { return CurrentQuestions.ElementAt(CurrentQuestionNumber - 1); } }

        public async Task LoadQuestions()
        {
            IsBussy = true;
            try
            {
                CurrentQuestions = await GameService.GetQuestions(CurrentDifficulty, 5);
                CurrentQuestionNumber = 1;
            }
            catch (Exception ex)
            {
                // TODO: log error
            }
            finally
            {
                IsBussy = false;
            }
        }

        public void ResetAnswerCounter()
        {
            _correctAnswers = 0;
        }

        public void ConfirmAnswerAtIndex(int answerIndex)
        {
            var answer = CurrentQuestion.PossibleAnswers.ElementAt(answerIndex);
            answer.MarkedByPlayerAsCorrectAnswer = true;

            if (answer.IsReallyCorrectAnswer)
                _correctAnswers++;
        }

        public Question NextQuestion()
        {
            if (CurrentQuestionNumber <= NUMBER_OF_QUESTIONS)
            {
                var q = CurrentQuestions.ElementAt(CurrentQuestionNumber);
                CurrentQuestionNumber++;
                return q;
            }
            else
            {
                CurrentQuestionNumber = 1;
                ResetAnswerCounter();
                return CurrentQuestions.ElementAt(CurrentQuestionNumber);
            }
        }
    }
}
