
using Android.App;
using Android.OS;
using DevQuiz.Core.Models.ViewModels;

namespace DevQuiz.Android.Activities
{
    [Activity]
    public class GameResultActivity : BaseActivity<GameViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(Resource.Layout.GameResultView);
        }
    }
}