using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DevQuiz.Core.Models.TransportModels;
using DevQuiz.Core.Models.ViewModels;
using DevQuiz.Core;

namespace DevQuiz.Android.Adapters
{
    public class QuestionAnswersAdapter : BaseAdapter<PossibleAnswer>
    {
        private readonly GameViewModel _gameViewModel = ServiceContainer.Resolve<GameViewModel>();
        private readonly LayoutInflater _inflater;

        public QuestionAnswersAdapter(Context context)
        {
            _inflater = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
        }

        public override long GetItemId(int position)
        {
            return _gameViewModel.CurrentQuestion.PossibleAnswers.ElementAt(position).PossibleAnswerId;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            if (convertView == null)
                convertView = _inflater.Inflate(Resource.Layout.QuestionAnswerListItem, null);

            var tbAnswerNumber = convertView.FindViewById<TextView>(Resource.Id.QuestionAnswerListItemTvAnswerNumber);
            var tbAnswerText = convertView.FindViewById<TextView>(Resource.Id.QuestionAnswerListItemTvAnswerText);

            var question = this[position];

            tbAnswerNumber.Text = (position + 1).ToString();
            tbAnswerText.Text = question.Text;

            return convertView;
        }

        public override PossibleAnswer this[int position]
        {
            get { return _gameViewModel.CurrentQuestion.PossibleAnswers.ElementAt(position); }
        }

        public override int Count
        {
            get { return _gameViewModel.CurrentQuestion.PossibleAnswers.Count(); }
        }
    }
}