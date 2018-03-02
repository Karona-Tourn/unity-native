#if UNITY_EDITOR || !(UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE)
using UnityEngine;

namespace TK.NativePlatformUtilities
{
	public class TimePickerDialog : TimePickerDialogBase
	{
		private readonly string _exceptionMessage = null;

		private TimePickerDialog ()
		{
			_exceptionMessage = "Time picker dialog does not support for platform " + Application.platform;
		}

		public override void Close ()
		{
			throw new System.NotImplementedException ( _exceptionMessage );
		}

		public override void Show ()
		{
			throw new System.NotImplementedException ( _exceptionMessage );
		}

		public override void Show ( int hour, int minute )
		{
			throw new System.NotImplementedException ( _exceptionMessage );
		}

		static public ITimePickerDialog Create ()
		{
			return new TimePickerDialog ();
		}
	}
}
#endif