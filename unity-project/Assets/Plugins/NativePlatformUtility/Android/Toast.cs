#if !UNITY_EDITOR && UNITY_ANDROID
using UnityEngine;

namespace TK.NativePlatformUtilities
{

	public class Toast : IToast
	{
		static private AndroidJavaClass ajc = null;

		/// <summary>
		/// Show native toast
		/// </summary>
		public void Show(string message, bool longDuration)
		{
			if (ajc == null)
			{
				ajc = new AndroidJavaClass(NativePlatformUtility.GetFullJavaClassName("UNToast"));
			}

			ajc.CallStatic("show", message, longDuration);
		}
	}
}
#endif