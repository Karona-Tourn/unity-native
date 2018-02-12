using UnityEngine;
using UnityEngine.Events;

namespace TK.NativePlatformUtilities
{
	public class NativePlatformUtility : MonoBehaviour
	{
		public const string Package = "com.android.unitynative";

		private void Awake ()
		{
			DontDestroyOnLoad ( gameObject );
		}

		static public string GetFullJavaClassName ( string className )
		{
			return Package + '.' + className;
		}

		static public void ShowToast ( string message, bool longDuration = false )
		{
			IToast toast = new Toast();
			toast.Show ( message, longDuration );
		}

		static public void ShowAlert ( string title, string message, string button = "OK", UnityAction onClick = null )
		{
#if UNITY_EDITOR || UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE
			IAlertDialog dialog = AlertDialog.Create();
			dialog.SetTitle ( title );
			dialog.SetMessage ( message );
			dialog.SetButton ( button, onClick );
			dialog.Show ();
#else
			Debug.LogWarning ( "Showing alert does not support for platform " + Application.platform );
#endif
		}

		static public void ShowConfirm ( string title, string message, string buttonOK, string buttonCancel, UnityAction<DialogResult> onClick = null )
		{
#if UNITY_EDITOR || UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE
			IConfirmDialog dialog = ConfirmDialog.Create();
			dialog.SetTitle ( title );
			dialog.SetMessage ( message );
			dialog.SetButtons ( buttonOK, buttonCancel, onClick );
			dialog.Show ();
#else
			Debug.LogWarning ( "Showing confirm does not support for platform " + Application.platform );
#endif
		}

		static public void ShowTimePicker ( UnityAction<int, int> onTimeSet )
		{
#if !UNITY_EDITOR && (UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE)
			ITimePickerDialog dialog = TimePickerDialog.Create();
			dialog.SetCallback ( onTimeSet );
			dialog.Show ();
#else
			Debug.LogWarning ( "Showing a time picker does not support for platform " + Application.platform );
#endif
		}

	}
}
