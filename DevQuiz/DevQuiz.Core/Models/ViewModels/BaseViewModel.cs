using DevQuiz.Core.Services.Interfaces;
//
//  BaseViewModel.cs
//
//  Author:
//       Vedran Mandić <mandic.vedran@gmail.com>
//
//  Copyright (c) 2015 vmandic
//
using System;

namespace DevQuiz.Core.Models.ViewModels
{
    public class BaseViewModel
    {
        protected readonly IGameWebService _service = ServiceContainer.Resolve<IGameWebService>();

        public delegate void Change(object sender, EventArgs e);
        public event Change IsBusyChanged = delegate { };

        private bool _isBussy;

        public bool IsBussy
        {
            get { return _isBussy; }
            set
            {
                _isBussy = value;
                IsBusyChanged(this, EventArgs.Empty);
            }
        }


        public BaseViewModel()
        {
        }
    }
}

