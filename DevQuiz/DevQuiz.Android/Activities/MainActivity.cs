using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using DevQuiz.Android.Activities;
using DevQuiz.Core.Models.ViewModels;
using System;

namespace DevQuiz.Android
{
    [Activity(MainLauncher = true, LaunchMode = LaunchMode.SingleInstance)]
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
            StartActivity(typeof(AboutActivity));
        }

        void btnStart_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(DifficultyChooserActivity));
        }
    }
}


