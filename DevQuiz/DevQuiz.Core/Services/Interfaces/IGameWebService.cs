using DevQuiz.Core.Models.TransportModels;
//
//  IGameWebService.cs
//
//  Author:
//       Vedran Mandić <mandic.vedran@gmail.com>
//
//  Copyright (c) 2015 vmandic
//
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevQuiz.Core.Services.Interfaces
{
    public interface IGameWebService
    {
        Task<IEnumerable<Question>> GetFiveEasyQuestions();
        Task<IEnumerable<Question>> GetFiveMediumQuestions();
        Task<IEnumerable<Question>> GetFiveProQuestions();
        ÷Task<IEnumerable<Question>> GetQuestions(DifficultyEnum difficulty, int numberOfQuestionsRequested);
    }
}

