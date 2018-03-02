#if !UNITY_EDITOR && (UNITY_IOS || UNITY_IPHONE)
using System;

namespace TK.NativePlatformUtilities
{
	public class AlertDialog : AlertDialogBase
	{
		private AlertDialog ()
		{
		}

		public override void Close ()
		{
			throw new NotImplementedException ();
		}

		public override void Show ()
		{
			throw new NotImplementedException ();
		}

		static public IAlertDialog Create ()
		{
			return new AlertDialog ();
		}
	}
}
#endif