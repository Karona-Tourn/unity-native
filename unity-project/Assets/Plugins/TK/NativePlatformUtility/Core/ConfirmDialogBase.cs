using UnityEngine.Events;

namespace TK.NativePlatformUtilities
{

	public abstract class ConfirmDialogBase : IConfirmDialog
	{
		protected string _title             = "";
		protected string _message           = "";
		protected string _positiveButton    = "OK";
		protected string _negativeButton    = "Cancel";

		protected UnityAction<DialogResult> _onClick = null;

		public void SetButton ( string name, UnityAction onClick )
		{
			throw new System.NotImplementedException ();
		}

		public void SetButtons ( string positiveButton, string negativeButton, UnityAction<DialogResult> onClick )
		{
			_positiveButton = positiveButton;
			_negativeButton = negativeButton;
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