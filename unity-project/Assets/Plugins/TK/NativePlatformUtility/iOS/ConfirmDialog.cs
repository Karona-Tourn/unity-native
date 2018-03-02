#if !UNITY_EDITOR && (UNITY_IOS || UNITY_IPHONE)
using System;

namespace TK.NativePlatformUtilities
{
	public class ConfirmDialog : ConfirmDialogBase
	{
		private ConfirmDialog ()
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

		static public IConfirmDialog Create ()
		{
			return new ConfirmDialog ();
		}
	}
}
#endif