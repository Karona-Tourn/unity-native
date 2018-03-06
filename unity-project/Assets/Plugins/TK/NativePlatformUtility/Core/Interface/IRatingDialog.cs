namespace TK.NativePlatformUtilities
{

	public interface IRatingDialog
	{
		void SetTitle (string title);
		void SetMessage ( string message );
		void Show ();
		void ShowIfNeeded ();
		void Reset ();
	}

}