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
    public class DifficultyChooserActivity : BaseActivity<GameViewModel>
    {
        Button _btnBack;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // NOTE: set DifficultyChooserView layout
            SetContentView(Resource.Layout.DifficultyChooserView);


            // NOTE: handle ActionBar back button
            _btnBack = FindViewById<Button>(Resource.Id.DifficultyChooserBtnBack);
            _btnBack.Click += btnBack_Click;
        }

        void btnBack_Click(object sender, EventArgs e)
        {
            StartActivity(new Intent(this, typeof(MainActivity)).SetFlags(ActivityFlags.ReorderToFront));
        }
    }
}