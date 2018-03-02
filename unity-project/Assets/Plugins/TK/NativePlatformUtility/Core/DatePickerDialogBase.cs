namespace TK.NativePlatformUtilities
{

	public abstract class DatePickerDialogBase : IDatePickerDialog
	{
		protected DateSetEventHandler _handler = null;

		public void SetDateSetEventHandler ( DateSetEventHandler handler )
		{
			_handler = handler;
		}

		public abstract void Show ();

		public abstract void Close ();

		public abstract void Show ( int year, int month, int dayOfMonth );
	}

}