#if !UNITY_EDITOR && UNITY_ANDROID

using UnityEngine;

namespace TK.NativePlatformUtilities
{

	public class RatingDialog : RatingDialogBase
	{
		private AndroidJavaObject ratingDialog = null;

		public RatingDialog ( string packageName )
		{
			ratingDialog = new AndroidJavaObject ( "com.android.unitynative.UNRatingDialog", packageName, 5 );
		}

		~RatingDialog ()
		{
			ratingDialog.Dispose ();
		}

		public override void Show ()
		{
			ratingDialog.Call ( "setTitle", _title );
			ratingDialog.Call ( "setMessage", _message );
			ratingDialog.Call ( "show" );
		}

		public override void ShowIfNeeded ()
		{
			ratingDialog.Call ( "setTitle", _title );
			ratingDialog.Call ( "setMessage", _message );
			ratingDialog.Call ( "showIfNeeded" );
		}
	}

}

#endif