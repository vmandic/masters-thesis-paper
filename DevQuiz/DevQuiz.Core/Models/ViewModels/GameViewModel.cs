using DevQuiz.Core.Models.TransportModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevQuiz.Core.Models.ViewModels
{
    public class GameViewModel : BaseViewModel
    {
        public const uint NUMBER_OF_QUESTIONS = 5;

        public DateTime StartTime { get; set; }
        public DifficultyEnum CurrentDifficulty { get; set; }
        public int CurrentQuestionNumber { get; set; }
        public IEnumerable<Question> CurrentQuestions { get; set; }

        public Question CurrentQuestion { get { return CurrentQuestions.ElementAt(CurrentQuestionNumber - 1); } }

        public async void LoadQuestions()
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

        public void ConfirmAnswer(int answerNumber)
        {
            CurrentQuestion.PossibleAnswers.ElementAt(answerNumber - 1).MarkedByPlayerAsCorrectAnswer = true;
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
                return CurrentQuestions.ElementAt(CurrentQuestionNumber);
            }
        }
    }
}
