#if !(UNITY_EDITOR || UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE)
using UnityEngine;

namespace TK.NativePlatformUtilities
{

	public class RatingDialog : RatingDialogBase
	{
		private readonly string _exceptionMessage = null;

		public RatingDialog ( string packageName )
		{
			_exceptionMessage = "Rating dialog does not support for platform " + Application.platform;
		}

		public override void Show ()
		{
			throw new System.NotImplementedException ( _exceptionMessage );
		}

		public override void ShowIfNeeded ()
		{
			throw new System.NotImplementedException ( _exceptionMessage );
		}

		public override void Reset ()
		{
			throw new System.NotImplementedException ( _exceptionMessage );
		}
	}

}
#endif