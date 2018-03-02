using UnityEngine.Events;

namespace TK.NativePlatformUtilities
{
	public abstract class AlertDialogBase : IAlertDialog
	{
		protected string _title     = "";
		protected string _message   = "";
		protected string _button    = "OK";

		protected UnityAction _onClick = null;

		public void SetButton ( string name, UnityAction onClick )
		{
			_button = name;
			_onClick = onClick;
		}

		public void SetMessage ( string message )
		{
			_message = message;
		}

		public void SetTitle ( string title )
		{
			_title = title;
		}

		public abstract void Show ();

		public abstract void Close ();
	}
}
