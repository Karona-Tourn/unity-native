using System;
using UnityEngine;
using UnityEngine.UI;
using TK.NativePlatformUtilities;

public class Demo : MonoBehaviour
{
	public enum NativeUI
	{
		Toast,
		AlertDialog,
		ConfirmDialog,
		TimePickerDialog,
		DatePickerDialog,
	}

	public Button itemSample = null;
	public Transform listContent = null;

	private void Start()
	{
		var nativeUIs = Enum.GetNames(typeof(NativeUI));
		for (int i = 0; i < nativeUIs.Length; i++)
		{
			var newItem = Instantiate(itemSample, listContent);
			newItem.name = nativeUIs[i];
			newItem.gameObject.SetActive(true);
			newItem.GetComponentInChildren<Text>().text = nativeUIs[i];
			newItem.onClick.AddListener(() => OnItemClicked(newItem));
		}
	}

	public void OnItemClicked(Button item)
	{
		switch ((NativeUI)Enum.Parse(typeof(NativeUI), item.name))
		{
			case NativeUI.Toast:
				NativePlatformUtility.ShowToast ( "I am Mr.Toast!", true );
				break;
			case NativeUI.AlertDialog:
				NativePlatformUtility.ShowAlert ( "Alert Dialog", "I am an alert dialog!", "OK", () =>
				{
					NativePlatformUtility.ShowToast ( "Clicked OK" );
				} );
				break;
			case NativeUI.ConfirmDialog:
				NativePlatformUtility.ShowConfirm ( "Confirm Dialog", "I am an confirm dialog!", "YES", "NO", ( result ) =>
				{
					if(result == DialogResult.OK)
						NativePlatformUtility.ShowToast ( "Clicked YES" );
					else
						NativePlatformUtility.ShowToast ( "Clicked NO" );
				} );
				break;
			case NativeUI.TimePickerDialog:
				NativePlatformUtility.ShowTimePicker ( ( hour, min ) =>
				{
					NativePlatformUtility.ShowToast ( string.Format ( "Hour: {0}, Min: {1}", hour, min ) );
				} );
				break;
			case NativeUI.DatePickerDialog:
				break;
		}
	}

}
