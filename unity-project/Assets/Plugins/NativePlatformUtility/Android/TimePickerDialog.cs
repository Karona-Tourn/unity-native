#if !UNITY_EDITOR && UNITY_ANDROID
using UnityEngine;
using UnityEngine.Events;

namespace TK.NativePlatformUtilities
{
	public class TimePickerDialog : TimePickerDialogBase
	{
		private class TimeSetCallback : AndroidJavaProxy
		{
			private UnityAction<int, int> _callback = null;

			public TimeSetCallback ( UnityAction<int, int> callback ) : base ( "android.app.TimePickerDialog$OnTimeSetListener" )
			{
				_callback = callback;
			}

			void onTimeSet ( AndroidJavaObject view, int hourOfDay, int minute )
			{
				if ( _callback == null ) return;

				_callback ( hourOfDay, minute );
			}
		}

		static private AndroidJavaClass _dialogJavaClass	= null;

		private AndroidJavaObject       _dialogJavaObject   = null;

		private TimePickerDialog ()
		{
			if ( _dialogJavaClass == null )
				_dialogJavaClass = new AndroidJavaClass ( NativePlatformUtility.GetFullJavaClassName ( "UNTimePickerDialog" ) );
		}

		public override void Close ()
		{
			if ( _dialogJavaObject == null ) return;

			_dialogJavaObject.Call ( "close" );
		}

		public override void Show ()
		{
			if ( _dialogJavaClass == null ) return;

			_dialogJavaObject = _dialogJavaClass.CallStatic<AndroidJavaObject> ( "show", new TimeSetCallback ( _callback ) );
		}

		static public TimePickerDialog Create ()
		{
			return new TimePickerDialog ();
		}
	}
}
#endif