#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

namespace TK.NativePlatformUtilities
{

	public class ToastMessage : IToastMessage
	{
		/// <summary>
		/// Show native toast
		/// </summary>
		public void Show(string message, bool longDuration)
		{
			var guiContent = new GUIContent(message);
			EditorWindow.focusedWindow.ShowNotification(guiContent);
		}
	}

}
#endif