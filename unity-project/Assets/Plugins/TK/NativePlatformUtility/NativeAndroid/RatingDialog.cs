#if !UNITY_EDITOR && UNITY_ANDROID

using UnityEngine;
using System.Collections;

namespace TK.NativePlatformUtilities
{

	public class RatingDialog : RatingDialogBase
	{
		public RatingDialog ( string packageName )
		{
		}

		public override void Show ()
		{
		}

		public override void ShowIfNeeded ()
		{
		}
	}

}

#endif