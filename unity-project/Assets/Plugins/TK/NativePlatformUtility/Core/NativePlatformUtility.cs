using UnityEngine;
using UnityEngine.Events;

namespace TK.NativePlatformUtilities
{
	public class NativePlatformUtility : MonoBehaviour
	{
#if !UNITY_EDITOR && UNITY_ANDROID
		public const string Package = "com.android.unitynative";

		static public string GetFullJavaClassName ( string className )
		{
			return Package + '.' + className;
		}
#endif

		private void Awake ()
		{
			DontDestroyOnLoad ( gameObject );
		}

		static public void ShowToast ( string message, bool longDuration = false )
		{
			IToastMessage toast = new ToastMessage();
			toast.Show ( message, longDuration );
		}

		static public IAlertDialog ShowAlert ( string title, string message, string button = "OK", UnityAction onClick = null )
		{
			IAlertDialog dialog = AlertDialog.Create();
			dialog.SetTitle ( title );
			dialog.SetMessage ( message );
			dialog.SetButton ( button, onClick );
			dialog.Show ();
			return dialog;
		}

		static public IConfirmDialog ShowConfirm ( string title, string message, string buttonOK, string buttonCancel, UnityAction<DialogResult> onClick = null )
		{
			IConfirmDialog dialog = ConfirmDialog.Create();
			dialog.SetTitle ( title );
			dialog.SetMessage ( message );
			dialog.SetButtons ( buttonOK, buttonCancel, onClick );
			dialog.Show ();
			return dialog;
		}

		static public IConfirmDialog ShowConfirm ( string title, string message, string buttonOK, string buttonCancel, string buttonAlt, UnityAction<DialogResult> onClick = null )
		{
			IConfirmDialog dialog = ConfirmDialog.Create();
			dialog.SetTitle ( title );
			dialog.SetMessage ( message );
			dialog.SetButtons ( buttonOK, buttonCancel, buttonAlt, onClick );
			dialog.Show ();
			return dialog;
		}

		static public ITimePickerDialog ShowTimePicker ( TimeSetEventHandler handler )
		{
			ITimePickerDialog dialog = TimePickerDialog.Create();
			dialog.SetTimeSetEventHandler ( handler );
			dialog.Show ();
			return dialog;
		}

		static public ITimePickerDialog ShowTimePicker ( int startHour, int startMinute, TimeSetEventHandler handler )
		{
			ITimePickerDialog dialog = TimePickerDialog.Create();
			dialog.SetTimeSetEventHandler ( handler );
			dialog.Show ( startHour, startMinute );
			return dialog;
		}

		static public IDatePickerDialog ShowDatePicker ( DateSetEventHandler handler )
		{
			IDatePickerDialog dialog = DatePickerDialog.Create();
			dialog.SetDateSetEventHandler ( handler );
			dialog.Show ();
			return dialog;
		}

		static public IDatePickerDialog ShowDatePicker ( int startYear, int startMonth, int startDayOfMonth, DateSetEventHandler handler )
		{
			IDatePickerDialog dialog = DatePickerDialog.Create();
			dialog.SetDateSetEventHandler ( handler );
			dialog.Show ( startYear, startMonth, startDayOfMonth );
			return dialog;
		}

		static public IRatingDialog ShowRating ( string title, string message, string packageName = "", bool ifNeeded = true )
		{
			IRatingDialog dialog = new RatingDialog(packageName);
			dialog.SetTitle ( title );
			dialog.SetMessage ( message );
			if ( ifNeeded ) dialog.ShowIfNeeded ();
			else dialog.Show ();
			return dialog;
		}

	}
}
