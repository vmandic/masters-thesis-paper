using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using DevQuiz.Core.Models.ViewModels;
using System;

namespace DevQuiz.Android.Activities
{
    [Activity]
    public class AboutActivity : BaseActivity<AboutViewModel>
    {
        Button _btnBack;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // NOTE: load AboutView
            SetContentView(Resource.Layout.AboutView);

            // NOTE: handle ActionBar back button
            _btnBack = FindViewById<Button>(Resource.Id.AboutBtnBack);
            _btnBack.Click += btnBack_Click;
        }

        void btnBack_Click(object sender, EventArgs e)
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