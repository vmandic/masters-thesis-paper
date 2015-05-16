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