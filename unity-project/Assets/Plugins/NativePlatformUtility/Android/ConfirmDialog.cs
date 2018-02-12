#if !UNITY_EDITOR && UNITY_ANDROID
using UnityEngine;
using UnityEngine.Events;

namespace TK.NativePlatformUtilities
{
	public class ConfirmDialog : ConfirmDialogBase
	{
		private class ClickCallback : AndroidJavaProxy
		{
			private UnityAction<DialogResult> _callback = null;

			public ClickCallback ( UnityAction<DialogResult> callback ) : base ( "android.content.DialogInterface$OnClickListener" )
			{
				_callback = callback;
			}

			void onClick ( AndroidJavaObject dialog, int which )
			{
				if ( _callback != null ) _callback (which == -1 ? DialogResult.OK : which == -2 ? DialogResult.Cancel : DialogResult.Other);
			}
		}

		static private AndroidJavaClass _alertDialogJavaClass   = null;

		private AndroidJavaObject       _dialogJavaObject       = null;

		private ConfirmDialog ()
		{
			if ( _alertDialogJavaClass == null )
			{
				_alertDialogJavaClass = new AndroidJavaClass ( NativePlatformUtility.GetFullJavaClassName ( "UNConfirmDialog" ) );
			}
		}

		public override void Show ()
		{
			if ( _alertDialogJavaClass == null ) return;

			_dialogJavaObject = _alertDialogJavaClass.CallStatic<AndroidJavaObject> ( "show", _title, _message, _positiveButton, _negativeButton, new ClickCallback ( _onClick ) );
		}

		public override void Close ()
		{
			if ( _dialogJavaObject == null ) return;

			_dialogJavaObject.Call ( "close" );
		}

		static public ConfirmDialog Create ()
		{
			return new ConfirmDialog ();
		}
	}
}
#endif