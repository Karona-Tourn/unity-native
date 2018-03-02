#if !UNITY_EDITOR && (UNITY_IOS || UNITY_IPHONE)
namespace TK.NativePlatformUtilities
{
	public class DatePickerDialog : DatePickerDialogBase
	{
		private DatePickerDialog ()
		{
		}

		public override void Close ()
		{
			throw new System.NotImplementedException ();
		}

		public override void Show ()
		{
			throw new System.NotImplementedException ();
		}

		public override void Show ( int year, int month, int dayOfMonth )
		{
			throw new System.NotImplementedException ();
		}

		static public IDatePickerDialog Create ()
		{
			return new DatePickerDialog ();
		}
	}
}
#endif