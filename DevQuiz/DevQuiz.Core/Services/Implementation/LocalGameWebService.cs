using DevQuiz.Core.Models.TransportModels;
using DevQuiz.Core.Services.Interfaces;
//
//  LocalGameWebService.cs
//
//  Author:
//       Vedran Mandić <mandic.vedran@gmail.com>
//
//  Copyright (c) 2015 vmandic
//
using System;
using System.Collections.Generic;

namespace DevQuiz.Core.Services.Implementation
{
    public class LocalGameWebService : IGameWebService
    {

        public LocalGameWebService()
        {
        }

        public System.Threading.Tasks.Task<IEnumerable<Question>> GetFiveEasyQuestions()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<IEnumerable<Question>> GetFiveMediumQuestions()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<IEnumerable<Question>> GetFiveProQuestions()
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task<IEnumerable<Question>> GetQuestions(DifficultyEnum difficulty, int numberOfQuestionsRequested)
        {
            throw new NotImplementedException();
        }
    }
}

