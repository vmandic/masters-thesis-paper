package md570fa50062c737815207a3a9848de1ca4;


public class DifficultyChooserActivity
	extends md570fa50062c737815207a3a9848de1ca4.BaseActivity_1
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("DevQuiz.Android.Activities.DifficultyChooserActivity, DevQuiz.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", DifficultyChooserActivity.class, __md_methods);
	}


	public DifficultyChooserActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == DifficultyChooserActivity.class)
			mono.android.TypeManager.Activate ("DevQuiz.Android.Activities.DifficultyChooserActivity, DevQuiz.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
