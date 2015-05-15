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
using Android.Util;
using DevQuiz.Core;
using DevQuiz.Core.Services.Interfaces;
using DevQuiz.Core.Services.Implementation;
using DevQuiz.Core.Models.ViewModels;

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
            base.OnCreate();
        }
    }
}