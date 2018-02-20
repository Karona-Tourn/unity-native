#if !UNITY_EDITOR && UNITY_ANDROID
using UnityEngine;

namespace TK.NativePlatformUtilities
{
	public class DatePickerDialog : DatePickerDialogBase
	{
		private class OnDateSetListener : AndroidJavaProxy
		{
			private DateSetEventHandler _handler = null;

			public OnDateSetListener ( DateSetEventHandler handler) : base ( "android.app.DatePickerDialog$OnDateSetListener" )
			{
				_handler = handler;
			}

			private void onDateSet ( AndroidJavaObject view, int year, int month, int dayOfMonth )
			{
				if ( _handler == null ) return;

				_handler ( year, month, dayOfMonth );
			}
		}

		static private AndroidJavaClass _dialogJavaClass    = null;

		private AndroidJavaObject       _dialogJavaObject   = null;

		private DatePickerDialog ()
		{
			if ( _dialogJavaClass == null ) _dialogJavaClass = new AndroidJavaClass ( "com.android.unitynative.UNDatePickerDialog" );
		}

		public override void Close ()
		{
			if ( _dialogJavaObject == null ) return;

			_dialogJavaObject.Call ( "close" );
		}

		public override void Show ()
		{
			_dialogJavaObject = _dialogJavaClass.CallStatic<AndroidJavaObject> ( "show", new OnDateSetListener ( _handler ) );
		}

		public override void Show ( int year, int month, int dayOfMonth )
		{
			_dialogJavaObject = _dialogJavaClass.CallStatic<AndroidJavaObject> ( "show", year, month, dayOfMonth, new OnDateSetListener ( _handler ) );
		}

		static public DatePickerDialog Create ()
		{
			return new DatePickerDialog ();
		}
	}
}
#endif