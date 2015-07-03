using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DevQuiz.iOS
{
	partial class AboutViewController : UIViewController
	{
		public AboutViewController (IntPtr handle) : base (handle)
		{

		}

        public override void ViewWillAppear(bool animated)
        {
            this.NavigationController.NavigationBar.Hidden = false;
            this.Title = "About";
            this.NavigationController.NavigationBar.Items[0].Title = "Back";
        }
	}
}
