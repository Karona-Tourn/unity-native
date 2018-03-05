#if !UNITY_EDITOR && (UNITY_IOS || UNITY_IPHONE)
using UnityEngine;

namespace TK.NativePlatformUtilities
{

	public class RatingDialog : RatingDialogBase
	{
		public RatingDialog ( string packageName )
		{
		}

		public override void Show ()
		{
			throw new System.NotImplementedException ();
		}

		public override void ShowIfNeeded ()
		{
			throw new System.NotImplementedException ();
		}
	}

}
#endif