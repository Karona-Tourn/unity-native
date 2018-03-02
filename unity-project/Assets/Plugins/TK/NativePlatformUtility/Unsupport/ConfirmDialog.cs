#if !(UNITY_EDITOR || UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE)
using System;
using UnityEngine;

namespace TK.NativePlatformUtilities
{
	public class ConfirmDialog : ConfirmDialogBase
	{
		private readonly string _exceptionMessage = null;

		private ConfirmDialog ()
		{
			_exceptionMessage = "Confirm dialog does not support for platform " + Application.platform;
		}

		public override void Close ()
		{
			throw new NotImplementedException ( _exceptionMessage );
		}

		public override void Show ()
		{
			throw new NotImplementedException ( _exceptionMessage );
		}

		static public IConfirmDialog Create ()
		{
			return new ConfirmDialog ();
		}
	}
}
#endif