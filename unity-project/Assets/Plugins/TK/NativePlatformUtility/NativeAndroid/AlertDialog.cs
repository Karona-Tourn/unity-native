#if !UNITY_EDITOR && UNITY_ANDROID
using UnityEngine;
using UnityEngine.Events;

namespace TK.NativePlatformUtilities
{
	public class AlertDialog : AlertDialogBase
	{
		private class ClickCallback : AndroidJavaProxy
		{
			private UnityAction _callback = null;

			public ClickCallback ( UnityAction callback ) : base ( "android.content.DialogInterface$OnClickListener" )
			{
				_callback = callback;
			}

			void onClick ( AndroidJavaObject dialog, int which )
			{
				if ( _callback != null ) _callback ();
			}
		}

		static private AndroidJavaClass	_alertDialogJavaClass   = null;

		private AndroidJavaObject		_dialogJavaObject       = null;

		private AlertDialog ()
		{
			if ( _alertDialogJavaClass == null )
			{
				_alertDialogJavaClass = new AndroidJavaClass ( NativePlatformUtility.GetFullJavaClassName ( "UNAlertDialog" ) );
			}
		}

		public override void Show ()
		{
			if ( _alertDialogJavaClass == null ) return;

			_dialogJavaObject = _alertDialogJavaClass.CallStatic<AndroidJavaObject> ( "show", _title, _message, _button, new ClickCallback ( _onClick ) );
		}

		public override void Close ()
		{
			if ( _dialogJavaObject == null ) return;

			_dialogJavaObject.Call ( "close" );
		}

		static public IAlertDialog Create ()
		{
			return new AlertDialog ();
		}
	}

}
#endif