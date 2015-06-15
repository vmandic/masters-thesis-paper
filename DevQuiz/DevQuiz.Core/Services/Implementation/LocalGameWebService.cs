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

        public const int SLEEP_DURATION = 100;

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
                case DifficultyEnum.EASY: return _easyQuestions;
                case DifficultyEnum.GOOD: return _mediumQuestions;
                case DifficultyEnum.PRO: return _proQuestions;
                default: return null;
            }
        }

        public LocalGameWebService()
        {
            _easyQuestions = _easyQuestions ?? (new List<Question> {
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.EASY,
                                                        "Which of the following utilities can be used to compile managed assemblies into processor-specific native code?",
                                                        new KeyValuePair<string, bool>("gacutil", false),
                                                        new KeyValuePair<string, bool>("ngen", true),
                                                        new KeyValuePair<string, bool>("sn", false),
                                                        new KeyValuePair<string, bool>("dumpbin", false)
                                                    ),
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.EASY,
                                                        "Which of the following statements is correct?",
                                                        new KeyValuePair<string, bool>("Procedural Programming paradigm is different than structured programming paradigm.", false),
                                                        new KeyValuePair<string, bool>("Object Oriented Programming paradigm stresses on dividing the logic into smaller parts and writing procedures for each part.", false),
                                                        new KeyValuePair<string, bool>("Classes and objects are corner stones of structured programming paradigm.", false),
                                                        new KeyValuePair<string, bool>("Object Oriented Programming paradigm gives equal importance to data and the procedures that work on the data.", true)
                                                    ),
                                                     _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.EASY,
                                                        "Which of the following statements is correct about Managed Code?",
                                                        new KeyValuePair<string, bool>("Managed code is the code that is compiled by the JIT compilers.", false),
                                                        new KeyValuePair<string, bool>("Managed code is the code where resources are Garbage Collected.", false),
                                                        new KeyValuePair<string, bool>("Managed code is the code that runs on top of Windows.", false),
                                                        new KeyValuePair<string, bool>("Managed code is the code that is written to target the services of the CLR.", true)
                                                    ),
                                                     _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.EASY,
                                                        "Which of the following statements is correct about Interfaces used in C#.NET?",
                                                        new KeyValuePair<string, bool>("All interfaces are derived from an Object class.", false),
                                                        new KeyValuePair<string, bool>("Interfaces can be inherited.", true),
                                                        new KeyValuePair<string, bool>("All interfaces are derived from an Object interface.", false),
                                                        new KeyValuePair<string, bool>("Interfaces can contain only method declaration.", false)
                                                    ),
                                                     _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.EASY,
                                                        "Which of the following statements is correct?",
                                                        new KeyValuePair<string, bool>("Array elements can be of integer type only.", false),
                                                        new KeyValuePair<string, bool>("The rank of an Array is the total number of elements it can contain.", false),
                                                        new KeyValuePair<string, bool>("The length of an Array is the number of dimensions in the Array.", false),
                                                        new KeyValuePair<string, bool>("The default value of numeric array elements is zero.", true)
                                                    )
												});

            _mediumQuestions = _mediumQuestions ?? (new List<Question> {
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.GOOD,
                                                        "Which of the following statements is correct about constructors?",
                                                        new KeyValuePair<string, bool>("If we provide a one-argument constructor then the compiler still provides a zero-argument constructor.", false),
                                                        new KeyValuePair<string, bool>("Static constructors can use optional arguments.", false),
                                                        new KeyValuePair<string, bool>("Overloaded constructors cannot use optional arguments.", false),
                                                        new KeyValuePair<string, bool>("If we do not provide a constructor, then the compiler provides a zero-argument constructor.", true)
                                                    ),
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.GOOD,
                                                        "Which of the following is an 8-byte Integer?",
                                                        new KeyValuePair<string, bool>("Char", false),
                                                        new KeyValuePair<string, bool>("Long", true),
                                                        new KeyValuePair<string, bool>("Short", false),
                                                        new KeyValuePair<string, bool>("Integer", false)
                                                    ),
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.GOOD,
                                                        "Which of the following statements is correct?",
                                                        new KeyValuePair<string, bool>("Information is never lost during narrowing conversions.", false),
                                                        new KeyValuePair<string, bool>("The CInteger() function can be used to convert a Single to an Integer.", false),
                                                        new KeyValuePair<string, bool>("Widening conversions take place automatically.", true),
                                                        new KeyValuePair<string, bool>("3.14 can be treated as Decimal by using it in the form 3.14F.", false)
                                                    ),
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.GOOD,
                                                        "Which of the following statements is correct about classes and objects in C#.NET?",
                                                        new KeyValuePair<string, bool>("Class is a value type.", false),
                                                        new KeyValuePair<string, bool>("Since objects are typically big in size, they are created on the stack.", false),
                                                        new KeyValuePair<string, bool>("Objects of smaller size are created on the heap.", false),
                                                        new KeyValuePair<string, bool>("Objects are always nameless.", true)
                                                    ),
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.GOOD,
                                                        @"Which of the following statements are valid about generics in .NET Framework? 
1.) Generics is a language feature.
2.) We can create a generic class, however, we cannot create a generic interface in C#.NET.
3.) Generics delegates are not allowed in C#.NET.
4.) Generics are useful in collection classes in .NET framework.
5.) None of the above",
                                                        new KeyValuePair<string, bool>("1 and 2 Only", false),
                                                        new KeyValuePair<string, bool>("1, 2 and 3 Only", false),
                                                        new KeyValuePair<string, bool>("1 and 4 Only", true),
                                                        new KeyValuePair<string, bool>("All of the above", false)
                                                    )
												});

            _proQuestions = _proQuestions ?? (new List<Question> {
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.PRO,
                                                        "Which of the following statements is valid about generic procedures in C#.NET?",
                                                        new KeyValuePair<string, bool>("All procedures in a Generic class are generic.", false),
                                                        new KeyValuePair<string, bool>("Only those procedures labeled as Generic are generic.", false),
                                                        new KeyValuePair<string, bool>("Generic procedures can take at the most one generic parameter.", false),
                                                        new KeyValuePair<string, bool>("Generic procedures must take at least one type parameter.", true)
                                                    ),
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.PRO,
                                                        "Which of the following is NOT a namespace in the .NET Framework Class Library?",
                                                        new KeyValuePair<string, bool>("System.Process", true),
                                                        new KeyValuePair<string, bool>("System.Security", false),
                                                        new KeyValuePair<string, bool>("System.Threading", false),
                                                        new KeyValuePair<string, bool>("System.Drawing", false)
                                                    ),
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.PRO,
                                                        "Which of the following statements is correct about an interface?",
                                                        new KeyValuePair<string, bool>("One interface can be implemented in another interface.", false),
                                                        new KeyValuePair<string, bool>("An interface can be implemented by multiple classes in the same program.", false),
                                                        new KeyValuePair<string, bool>("A class that implements an interface can explicitly implement members of that interface.", true),
                                                        new KeyValuePair<string, bool>("The functions declared in an interface have a body.", false)
                                                    ),
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.PRO,
                                                        "The [Serializable()] attribute gets inspected at?",
                                                        new KeyValuePair<string, bool>("Compile-time", false),
                                                        new KeyValuePair<string, bool>("Run-time", false),
                                                        new KeyValuePair<string, bool>("Design-time", false),
                                                        new KeyValuePair<string, bool>("Linking-time", true)
                                                    ),
                                                    _BuildNewQuestion
                                                    (
                                                        DifficultyEnum.PRO,
                                                        "Which of the following statements are correct about Attributes used in C#.NET?",
                                                        new KeyValuePair<string, bool>("If there is a custom attribute BugFixAttribute then the compiler will look ONLY for the BugFix attribute in the code that uses this attribute.", false),
                                                        new KeyValuePair<string, bool>("To create a custom attribute we need to create a custom attribute structure and derive it from System.Attribute.", false),
                                                        new KeyValuePair<string, bool>("To create a custom attribute we need to create a class and implement IAttribute interface in it.", false),
                                                        new KeyValuePair<string, bool>("The CLR can change the behaviour of the code depending upon the attributes applied to it.", true)
                                                    )
												});
        }
    }
}