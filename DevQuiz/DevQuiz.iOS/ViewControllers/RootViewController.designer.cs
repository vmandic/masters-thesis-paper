// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DevQuiz.iOS
{
	[Register ("MyRootViewController")]
	partial class RootViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIView RootViewControllerInstance { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (RootViewControllerInstance != null) {
				RootViewControllerInstance.Dispose ();
				RootViewControllerInstance = null;
			}
		}
	}
}
