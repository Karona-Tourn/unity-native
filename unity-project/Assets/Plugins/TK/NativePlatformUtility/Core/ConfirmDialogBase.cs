using UnityEngine.Events;

namespace TK.NativePlatformUtilities
{

	public abstract class ConfirmDialogBase : IConfirmDialog
	{
		protected string _title             = "";
		protected string _message           = "";
		protected string _positiveButton    = "Yes";
		protected string _negativeButton    = "No";
		protected string _neutralButton     = "Cancel";

		protected UnityAction<DialogResult> _onClick = null;

		protected bool HasNeutralButton { get { return !string.IsNullOrEmpty ( _neutralButton ); } }

		public void SetButton ( string name, UnityAction onClick )
		{
			throw new System.NotImplementedException ();
		}

		public void SetButtons ( string positiveButton, string negativeButton, UnityAction<DialogResult> onClick )
		{
			SetButtons (positiveButton, negativeButton, string.Empty, onClick);
		}

		public void SetButtons ( string positiveButton, string negativeButton, string neutralButton, UnityAction<DialogResult> onClick )
		{
			_positiveButton = positiveButton;
			_negativeButton = negativeButton;
			_neutralButton = neutralButton;
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