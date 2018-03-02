#if !UNITY_EDITOR && (UNITY_IOS || UNITY_IPHONE)
namespace TK.NativePlatformUtilities
{
	public class ToastMessage : IToastMessage
	{
		public void Show ( string message, bool longDuration )
		{
			throw new System.NotImplementedException ();
		}
	}
}
#endif