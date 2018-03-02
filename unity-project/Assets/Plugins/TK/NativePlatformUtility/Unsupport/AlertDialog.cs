#if !(UNITY_EDITOR || UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE)
using System;
using UnityEngine;

namespace TK.NativePlatformUtilities
{
	public class AlertDialog : AlertDialogBase
	{
		private readonly string _exceptionMessage = null;

		private AlertDialog ()
		{
			_exceptionMessage = "Alert dialog does not support for platform " + Application.platform;
		}

		public override void Close ()
		{
			throw new NotImplementedException ( _exceptionMessage );
		}

		public override void Show ()
		{
			throw new NotImplementedException ( _exceptionMessage );
		}

		static public IAlertDialog Create ()
		{
			return new AlertDialog ();
		}
	}
}
#endif