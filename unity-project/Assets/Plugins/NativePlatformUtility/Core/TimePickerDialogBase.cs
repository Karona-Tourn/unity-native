using UnityEngine;
using UnityEngine.Events;

namespace TK.NativePlatformUtilities
{
	public abstract class TimePickerDialogBase : ITimePickerDialog
	{
		protected UnityAction<int, int> _callback = null;

		public void SetCallback ( UnityAction<int, int> callback )
		{
			_callback = callback;
		}

		public abstract void Show ();
	}
}