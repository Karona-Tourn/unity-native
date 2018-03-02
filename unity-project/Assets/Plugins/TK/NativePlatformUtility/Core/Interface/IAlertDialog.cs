using UnityEngine.Events;

namespace TK.NativePlatformUtilities
{

	public interface IAlertDialog
	{
		void SetTitle ( string title );
		void SetMessage ( string message );
		void SetButton ( string name, UnityAction onClick );
		void Show ();
		void Close ();
	}

}