
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Util;
using Android.Widget;
using DevQuiz.Android.Adapters;
using DevQuiz.Core.Models.TransportModels;
using DevQuiz.Core.Models.ViewModels;
using System;

namespace DevQuiz.Android.Activities
{
    [Activity]
    public class GameLoopActivity : BaseActivity<GameViewModel>
    {
        ListView _listView;
        QuestionAnswersAdapter _adapter;
        TextView _q, _qn;
        Button _btnNext;

        protected async override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            await viewModel.LoadQuestions();

            // Create your application here
            SetContentView(Resource.Layout.GameLoopView);
            _listView = FindViewById<ListView>(Resource.Id.GameLoopListview);
            _adapter = new QuestionAnswersAdapter(this);
            _listView.Adapter = _adapter;
            _listView.ItemClick += _listView_ItemClick;

            _q = FindViewById<TextView>(Resource.Id.GameLoopQuestion);
            _qn = FindViewById<TextView>(Resource.Id.GameLoopQuestionNumber);
            _btnNext = FindViewById<Button>(Resource.Id.GameLoopBtnForward);
            _btnNext.Click += _btnNext_Click;

            _qn.Text = viewModel.CurrentQuestionNumber + ". question";
            _q.Text = viewModel.CurrentQuestion.Text;
        }

        void _btnNext_Click(object sender, EventArgs e)
        {
            if (viewModel.CurrentQuestion.WasAnswered)
            {
                _ClearListItems();

                if (_btnNext.Text == "Finish")
                    StartActivity(typeof(GameResultActivity));
                else
                {
                    viewModel.NextQuestion();

                    if (viewModel.CurrentQuestionNumber == 5)
                        _btnNext.Text = "Finish";

                    // load new question and answers
                    _qn.Text = viewModel.CurrentQuestionNumber + ". question";
                    _q.Text = viewModel.CurrentQuestion.Text;
                    _adapter.NotifyDataSetInvalidated();
                }
            }
            else
            {
                new AlertDialog.Builder(this)
                   .SetTitle(Resource.String.Warning)
                   .SetMessage("Please answer first!")
                   .SetPositiveButton("OK", (IDialogInterfaceOnClickListener)null)
                   .Show();
            }
        }

        void _listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            _ClearListItems();
            viewModel.ConfirmAnswerAtIndex(e.Position);
            e.View.SetBackgroundColor(Color.GreenYellow);
        }

        private void _ClearListItems()
        {
            for (int i = 0; i < _adapter.Count; i++)
            {
                _listView.GetChildAt(i).SetBackgroundColor(Color.White);
                _adapter[i].MarkedByPlayerAsCorrectAnswer = false;
            }
        }

        protected async override void OnResume()
        {
            base.OnResume();
            try
            {
                await viewModel.LoadQuestions();
                _adapter.NotifyDataSetInvalidated();
            }
            catch (Exception ex)
            {
                DisplayError(ex);
            }
        }

        public override void OnBackPressed()
        {
            new AlertDialog.Builder(this)
                    .SetTitle(Resource.String.Warning)
                    .SetMessage("Goin' back to the start! :-)")
                    .SetPositiveButton("Game over", (IDialogInterfaceOnClickListener)null)
                    .Show();

            StartActivity(typeof(MainActivity));
        }
    }
}