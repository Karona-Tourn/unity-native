#if !(UNITY_EDITOR || UNITY_ANDROID || UNITY_IOS || UNITY_IPHONE)
namespace TK.NativePlatformUtilities
{
	public class ToastMessage : IToastMessage
	{
		public void Show ( string message, bool longDuration )
		{
			throw new System.NotImplementedException ( "Toast message does not support for platform " + UnityEngine.Application.platform );
		}
	}
}
#endif