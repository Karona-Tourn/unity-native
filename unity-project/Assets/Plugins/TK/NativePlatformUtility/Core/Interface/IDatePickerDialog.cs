namespace TK.NativePlatformUtilities
{
	public delegate void DateSetEventHandler (int year, int month, int dayOfMonth);

	public interface IDatePickerDialog
	{
		void SetDateSetEventHandler ( DateSetEventHandler handler );
		void Show ();
		void Show ( int year, int month, int dayOfMonth );
		void Close ();
	}

}