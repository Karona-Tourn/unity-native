#if !UNITY_EDITOR && UNITY_ANDROID
using UnityEngine;

namespace TK.NativePlatformUtilities
{
	public class TimePickerDialog : TimePickerDialogBase
	{
		private class OnTimeSetListener : AndroidJavaProxy
		{
			private TimeSetEventHandler _handler = null;

			public OnTimeSetListener ( TimeSetEventHandler handler ) : base ( "android.app.TimePickerDialog$OnTimeSetListener" )
			{
				_handler = handler;
			}

			void onTimeSet ( AndroidJavaObject view, int hourOfDay, int minute )
			{
				if ( _handler == null ) return;

				_handler ( hourOfDay, minute );
			}
		}

		static private AndroidJavaClass _dialogJavaClass	= null;

		private AndroidJavaObject       _dialogJavaObject   = null;

		private TimePickerDialog ()
		{
			if ( _dialogJavaClass == null ) _dialogJavaClass = new AndroidJavaClass ( NativePlatformUtility.GetFullJavaClassName ( "UNTimePickerDialog" ) );
		}

		public override void Close ()
		{
			if ( _dialogJavaObject == null ) return;

			_dialogJavaObject.Call ( "close" );
		}

		public override void Show ()
		{
			_dialogJavaObject = _dialogJavaClass.CallStatic<AndroidJavaObject> ( "show", new OnTimeSetListener ( _handler ) );
		}

		public override void Show ( int hour, int minute )
		{
			_dialogJavaObject = _dialogJavaClass.CallStatic<AndroidJavaObject> ( "show", hour, minute, new OnTimeSetListener ( _handler ) );
		}

		static public TimePickerDialog Create ()
		{
			return new TimePickerDialog ();
		}
	}
}
#endif