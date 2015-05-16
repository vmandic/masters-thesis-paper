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
using DevQuiz.Core;
using Newtonsoft.Json;
using Android.Util;
using DevQuiz.Core.Services.Interfaces;
using DevQuiz.Core.Services.Implementation;

namespace DevQuiz.Android.Activities
{
    [Activity]
    public class BaseActivity<TViewModel> : Activity where TViewModel : BaseViewModel
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ActionBar.Hide();
            Window.AddFlags(WindowManagerFlags.Fullscreen);
            Window.ClearFlags(WindowManagerFlags.ForceNotFullscreen);

            Log.Info(GetType().FullName, "Activity OnCreate called.");

            // try restoring app state
            if (!ServiceContainer.HasInstance && bundle.ContainsKey(DevQuizApp.AppStateKeyName))
                ServiceContainer.SetInstance(bundle.GetString(DevQuizApp.AppStateKeyName));
            else
            {
                if (!ServiceContainer.HasInstance)
                {
                    // register services
                    ServiceContainer.Register<IGameWebService>(() => new LocalGameWebService());

                    // register view models
                    ServiceContainer.Register<GameViewModel>(() => new GameViewModel());
                    ServiceContainer.Register<AboutViewModel>(() => new AboutViewModel());
                    ServiceContainer.Register<MainViewModel>(() => new MainViewModel());
                }
            }
        }

        protected override void OnResume()
        {

            base.OnResume();
            Log.Info(GetType().FullName, "Activity OnResume called.");
        }

        protected override void OnDestroy()
        {

            base.OnDestroy();
            Log.Info(GetType().FullName, "Activity OnDestroy called.");
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            // perserve app state
            outState.PutString(DevQuizApp.AppStateKeyName, ServiceContainer.Instance.Serialize());
            base.OnSaveInstanceState(outState);
            Log.Info(GetType().FullName, "Activity OnSavedInstanceState called.");
        }
    }
}