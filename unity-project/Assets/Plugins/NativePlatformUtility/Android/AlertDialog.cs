#if !UNITY_EDITOR && UNITY_ANDROID
using UnityEngine;
using UnityEngine.Events;

namespace TK.NativePlatformUtilities
{

	//public class AlertDialog : MonoBehaviour, IAlertDialog
	//{
	//	private class NativeAlertDialog : AlertDialogBase
	//	{
	//		private AndroidJavaClass	_dialogJavaClass	= null;
	//		private AndroidJavaObject    _dialogJavaObject   = null;
	//		private AlertDialog			_callbackReceiver	= null;

	//		private NativeAlertDialog ( AlertDialog callbackReceiver )
	//		{
	//			_callbackReceiver = callbackReceiver;
	//		}

	//		private void Initialize ()
	//		{
	//			_dialogJavaClass = new AndroidJavaClass ( NativePlatformUtility.GetFullJavaClassName ( "UNAlertDialog" ) );
	//		}

	//		public override void Show ()
	//		{
	//			if ( _dialogJavaClass == null || _callbackReceiver == null ) return;

	//			_dialogJavaObject = _dialogJavaClass.CallStatic<AndroidJavaObject> ( "show", _title, _message, _button, _callbackReceiver.name, "NotifyClick" );
	//		}

	//		public override void Close ()
	//		{
	//			if ( _dialogJavaObject == null ) return;

	//			_dialogJavaObject.Call ( "close" );
	//		}

	//		public void NotifyClick ()
	//		{
	//			if ( _onClick == null ) return;

	//			_onClick ();
	//		}

	//		static public NativeAlertDialog Create ( AlertDialog callbackReceiver )
	//		{
	//			NativeAlertDialog dialog = new NativeAlertDialog(callbackReceiver);
	//			dialog.Initialize ();
	//			return dialog;
	//		}
	//	}

	//	private NativeAlertDialog _nativeAlertDialog = null;

	//	private void Awake ()
	//	{
	//		DontDestroyOnLoad ( gameObject );

	//		_nativeAlertDialog = NativeAlertDialog.Create ( this );
	//	}

	//	private void NotifyClick (string which)
	//	{
	//		_nativeAlertDialog.NotifyClick ();
	//		Destroy ( gameObject );
	//	}

	//	public void SetTitle ( string title )
	//	{
	//		_nativeAlertDialog.SetTitle ( title );
	//	}

	//	public void SetMessage ( string message )
	//	{
	//		_nativeAlertDialog.SetMessage ( message );
	//	}

	//	public void SetButton ( string name, UnityAction onClick )
	//	{
	//		_nativeAlertDialog.SetButton ( name, onClick );
	//	}

	//	public void Show ()
	//	{
	//		_nativeAlertDialog.Show ();
	//	}

	//	public void Close ()
	//	{
	//		_nativeAlertDialog.Close ();
	//	}

	//	static public AlertDialog Create ()
	//	{
	//		GameObject gameObject = new GameObject("AlertDialog");
	//		gameObject.name += gameObject.GetInstanceID ();
	//		AlertDialog dialog = gameObject.AddComponent<AlertDialog> ();
	//		return dialog;
	//	}
	//}

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

		static public AlertDialog Create ()
		{
			return new AlertDialog ();
		}
	}

}
#endif