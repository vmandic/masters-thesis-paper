using Android.App;
using Android.Runtime;
using Android.Util;
using DevQuiz.Core;
using System;

namespace DevQuiz.Android
{
    [Application(Theme = "@android:style/Theme.Holo.Light")]
    public class DevQuizApp : Application
    {
        public const string AppStateKeyName = "DevQuizAppState";

        public DevQuizApp(IntPtr javaRef, JniHandleOwnership transfer)
            : base(javaRef, transfer)
        {

        }

        public override void OnCreate()
        {
            Log.Info(GetType().FullName, "Application OnCreate called.");
            ServiceContainer.Initialize();
            Log.Info(GetType().FullName, "Service Container initialized.");

            base.OnCreate();
        }
    }
}