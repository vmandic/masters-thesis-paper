using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Views;
using DevQuiz.Core;
using DevQuiz.Core.Models.ViewModels;
using System;

namespace DevQuiz.Android.Activities
{
    [Activity]
    public class BaseActivity<TViewModel> : Activity where TViewModel : BaseViewModel
    {
        protected readonly TViewModel viewModel;
        protected ProgressDialog progressDialog;

        public BaseActivity()
        {
            viewModel = ServiceContainer.Resolve<TViewModel>();
            Log.Info(GetType().FullName, "BaseActivity constructor called.");
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // NOTE: remove titlebar always
            ActionBar.Hide();
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            // NOTE: setup loading dialog
            progressDialog = new ProgressDialog(this);
            progressDialog.SetCancelable(false);
            progressDialog.SetTitle(Resource.String.Loading);

            // NOTE: try restoring the app state
            if (bundle != null && bundle.ContainsKey(DevQuizApp.AppStateKeyName))
                ServiceContainer.SetInstance(bundle.GetString(DevQuizApp.AppStateKeyName));

            Log.Info(GetType().FullName, "Activity OnCreate called.");
        }

        protected override void OnResume()
        {
            base.OnResume();
            viewModel.OnBusyChanged += HandleViewModelOnBusyChanged;
            Log.Info(GetType().FullName, "Activity OnResume called.");
        }

        protected override void OnPause()
        {
            base.OnPause();
            viewModel.OnBusyChanged -= HandleViewModelOnBusyChanged;
            Log.Info(GetType().FullName, "Activity OnPause called.");
        }

        // NOTE: this method is overridable
        public virtual void HandleViewModelOnBusyChanged(object sender, EventArgs e)
        {
            if (viewModel.IsBussy)
                progressDialog.Show();
            else
                progressDialog.Hide();

            Log.Info(GetType().FullName, typeof(TViewModel).Name + " viewmodel on bussy changed handled, bussy was set to: " + (viewModel.IsBussy ? "TRUE" : "FALSE"));
        }

        protected override void OnDestroy()
        {

            base.OnDestroy();
            Log.Info(GetType().FullName, "Activity OnDestroy called.");
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            // NOTE: perserve app state
            outState.PutString(DevQuizApp.AppStateKeyName, ServiceContainer.Instance.Serialize());
            base.OnSaveInstanceState(outState);
            Log.Info(GetType().FullName, "Activity OnSavedInstanceState called.");
        }

        public void DisplayError(Exception ex)
        {
            new AlertDialog.Builder(this)
                .SetTitle(Resource.String.ErrorTitle)
                .SetMessage(ex.Message)
                .SetPositiveButton("OK", (IDialogInterfaceOnClickListener)null)
                .Show();
        }
    }
}