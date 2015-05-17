using DevQuiz.Core.Models.TransportModels;
using DevQuiz.Core.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevQuiz.Core.Services.Implementation
{
    public class LocalGameWebService : IGameWebService
    {
        private List<Question> _easyQuestions, _mediumQuestions, _proQuestions;

        private Question _BuildNewQuestion(DifficultyEnum difficulty, string questionText, params KeyValuePair<string, bool>[] possibleAnswersKVPS)
        {
            var q = new Question(difficulty, questionText);
            var possibleAnswers = new List<PossibleAnswer>();

            foreach (var pa in possibleAnswersKVPS)
                possibleAnswers.Add(new PossibleAnswer(pa.Key, pa.Value));

            q.PossibleAnswers = possibleAnswers;
            return q;
        }

        public const int SLEEP_DURATION = 1000;

        private Task Sleep()
        {
            return Task.Delay(SLEEP_DURATION);
        }

        public async Task<IEnumerable<Question>> GetFiveEasyQuestions()
        {
            await Sleep();
            return _easyQuestions;
        }

        public async Task<IEnumerable<Question>> GetFiveMediumQuestions()
        {
            await Sleep();
            return _mediumQuestions;
        }

        public async Task<IEnumerable<Question>> GetFiveProQuestions()
        {
            await Sleep();
            return _proQuestions;
        }

        public async Task<IEnumerable<Question>> GetQuestions(DifficultyEnum difficulty, int numberOfQuestionsRequested)
        {
            await Sleep();
            switch (difficulty)
            {
                case DifficultyEnum.Easy: return _easyQuestions;
                case DifficultyEnum.Medium: return _mediumQuestions;
                case DifficultyEnum.Pro: return _proQuestions;
                default: return null;
            }
        }

        public LocalGameWebService()
        {
            _easyQuestions = _easyQuestions ?? (new List<Question> {
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.Easy,
                                                        "Which of the following utilities can be used to compile managed assemblies into processor-specific native code?",
                                                        new KeyValuePair<string, bool>("gacutil", false),
                                                        new KeyValuePair<string, bool>("ngen", false),
                                                        new KeyValuePair<string, bool>("sn", false),
                                                        new KeyValuePair<string, bool>("dumpbin", false)
                                                    )
												});

            _mediumQuestions = _mediumQuestions ?? (new List<Question> {
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.Medium,
                                                        "Which of the following utilities can be used to compile managed assemblies into processor-specific native code?",
                                                        new KeyValuePair<string, bool>("gacutil", false),
                                                        new KeyValuePair<string, bool>("ngen", false),
                                                        new KeyValuePair<string, bool>("sn", false),
                                                        new KeyValuePair<string, bool>("dumpbin", false)
                                                    )
												});

            _proQuestions = _proQuestions ?? (new List<Question> {
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.Pro,
                                                        "Which of the following utilities can be used to compile managed assemblies into processor-specific native code?",
                                                        new KeyValuePair<string, bool>("gacutil", false),
                                                        new KeyValuePair<string, bool>("ngen", false),
                                                        new KeyValuePair<string, bool>("sn", false),
                                                        new KeyValuePair<string, bool>("dumpbin", false)
                                                    )
												});
        }
    }
}