using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using DevQuiz.Android.Activities;
using DevQuiz.Core.Models.ViewModels;

namespace DevQuiz.Android
{
    [Activity(MainLauncher = true)]
    public class MainActivity : BaseActivity<MainViewModel>
    {
        Button _btnStart, _btnAbout;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // NOTE: set our view from the "main" layout resource
            SetContentView(Resource.Layout.StartView);

            // NOTE: fetch buttons
            _btnStart = FindViewById<Button>(Resource.Id.MainBtnStart);
            _btnAbout = FindViewById<Button>(Resource.Id.MainBtnAbout);

            _btnStart.Click += btnStart_Click;
            _btnAbout.Click += btnAbout_Click;
        }

        void btnAbout_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(AboutActivity)).SetFlags(ActivityFlags.ReorderToFront));
        }

        void btnStart_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(DifficultyChooserActivity)).SetFlags(ActivityFlags.ReorderToFront));
        }
    }
}


