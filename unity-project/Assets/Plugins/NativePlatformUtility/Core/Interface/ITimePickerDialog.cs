namespace TK.NativePlatformUtilities
{
	public delegate void TimeSetEventHandler ( int hour, int minute );

	public interface ITimePickerDialog
	{
		void SetTimeSetEventHandler ( TimeSetEventHandler handler );
		void Show ();
		void Show ( int hour, int minute );
		void Close ();
	}

}