using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using DevQuiz.Core;
using DevQuiz.Core.Models.ViewModels;
using System;

namespace DevQuiz.Android.Activities
{
    [Activity]
    public class DifficultyChooserActivity : BaseActivity<GameViewModel>
    {
        Button _btnBack, _btnNext;
        ToggleButton _btnEasy, _btnMedium, _btnPro;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // NOTE: set DifficultyChooserView layout
            SetContentView(Resource.Layout.DifficultyChooserView);

            // NOTE: handle ActionBar back button
            _btnBack = FindViewById<Button>(Resource.Id.DifficultyChooserBtnBack);
            _btnBack.Click += btnBack_Click;

            // NOTE: handle difficulty buttons
            _btnEasy = FindViewById<ToggleButton>(Resource.Id.DifficultyChooserBtnEasy);
            _btnMedium = FindViewById<ToggleButton>(Resource.Id.DifficultyChooserBtnMedium);
            _btnPro = FindViewById<ToggleButton>(Resource.Id.DifficultyChooserBtnPro);
            _btnEasy.Click += _btnEasy_Click;
            _btnMedium.Click += _btnMedium_Click;
            _btnPro.Click += _btnPro_Click;

            // NOTE: handle next button
            _btnNext = FindViewById<Button>(Resource.Id.DifficultyChooserBtnForward);
            _btnNext.Click += _btnNext_Click;
        }

        void _btnNext_Click(object sender, EventArgs e)
        {
            // NOTE: show warning to select a difficulty first
            if (!_btnEasy.Checked && !_btnMedium.Checked && !_btnPro.Checked)
            {
                new AlertDialog.Builder(this)
                    .SetTitle(Resource.String.Warning)
                    .SetMessage(Resource.String.PleaseSelectADifficulty)
                    .SetPositiveButton("OK", (IDialogInterfaceOnClickListener)null)
                    .Show();
            }
            else
                StartActivity(typeof(GameLoopActivity));
        }

        void _btnPro_Click(object sender, EventArgs e)
        {
            viewModel.CurrentDifficulty = DifficultyEnum.PRO;
            _btnMedium.Checked = _btnEasy.Checked = false;
        }

        void _btnMedium_Click(object sender, EventArgs e)
        {
            viewModel.CurrentDifficulty = DifficultyEnum.GOOD;
            _btnPro.Checked = _btnEasy.Checked = false;
        }

        void _btnEasy_Click(object sender, EventArgs e)
        {
            viewModel.CurrentDifficulty = DifficultyEnum.EASY;
            _btnMedium.Checked = _btnPro.Checked = false;
        }

        void btnBack_Click(object sender, EventArgs e)
        {
            OnBackPressed();
        }
    }
}