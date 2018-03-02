#if !UNITY_EDITOR && (UNITY_IOS || UNITY_IPHONE)
namespace TK.NativePlatformUtilities
{
	public class TimePickerDialog : TimePickerDialogBase
	{
		private TimePickerDialog ()
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

		public override void Show ( int hour, int minute )
		{
			throw new System.NotImplementedException ();
		}

		static public ITimePickerDialog Create ()
		{
			return new TimePickerDialog ();
		}
	}
}
#endif