using UnityEngine.Events;

namespace TK.NativePlatformUtilities
{

	public interface ITimePickerDialog
	{
		void SetCallback ( UnityAction<int, int> callback);
		void Show();
	}

}