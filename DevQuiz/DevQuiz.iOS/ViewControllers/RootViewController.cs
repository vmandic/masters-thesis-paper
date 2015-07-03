using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DevQuiz.iOS
{
	partial class RootViewController : UIViewController
	{
		public RootViewController (IntPtr handle) : base (handle)
		{

		}

      public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            this.Title = "DevQuiz";
            this.NavigationController.NavigationBar.Hidden = true;
        }
	}
}
