using UnityEngine.Events;

namespace TK.NativePlatformUtilities
{

	public interface IConfirmDialog : IAlertDialog
	{
		void SetButtons(string positiveButton, string negativeButton, UnityAction<DialogResult> onClick);
		void SetButtons ( string positiveButton, string negativeButton, string neutralButton, UnityAction<DialogResult> onClick );
	}

}