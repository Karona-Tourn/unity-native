namespace TK.NativePlatformUtilities
{
	public abstract class TimePickerDialogBase : ITimePickerDialog
	{
		protected TimeSetEventHandler _handler = null;

		public void SetTimeSetEventHandler ( TimeSetEventHandler handler )
		{
			_handler = handler;
		}

		public abstract void Show ();

		public abstract void Show ( int hour, int minute );

		public abstract void Close ();
	}
}