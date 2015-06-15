
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using DevQuiz.Core.Models.ViewModels;

namespace DevQuiz.Android.Activities
{
    [Activity]
    public class GameResultActivity : BaseActivity<GameViewModel>
    {
        TextView _tvDiff, _tvC, _tvW, _tvS;
        Button _btnEnd;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.GameResultView);

            _tvC = FindViewById<TextView>(Resource.Id.GameResultCorrect);
            _tvDiff = FindViewById<TextView>(Resource.Id.GameResultDifficulty);
            _tvW = FindViewById<TextView>(Resource.Id.GameResultWrong);
            _tvS = FindViewById<TextView>(Resource.Id.GameResultScore);
            _btnEnd = FindViewById<Button>(Resource.Id.GameResultTitleBtnFinish);

            _tvC.Text = viewModel.CorrectAnswers + "";
            _tvDiff.Text = viewModel.CurrentDifficulty.ToString() + "";
            _tvW.Text = viewModel.WrongAnswers + "";
            _tvS.Text = viewModel.Score + "";

            _btnEnd.Click += _btnEnd_Click;
        }

        void _btnEnd_Click(object sender, System.EventArgs e)
        {
            OnBackPressed();
        }

        public override void OnBackPressed()
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.ClearTop);
            StartActivity(intent);
        }
    }
}