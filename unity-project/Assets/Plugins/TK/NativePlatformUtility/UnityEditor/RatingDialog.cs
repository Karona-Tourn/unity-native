#if UNITY_EDITOR
using UnityEditor;

namespace TK.NativePlatformUtilities
{
	/// <summary>
	/// Base class of the rating dialog
	/// </summary>
	public class RatingDialog : RatingDialogBase
	{
		private AppRating appRating = null;

		public RatingDialog ( string packageName )
		{
			appRating = new AppRating ( packageName, 5 );
		}

		private void RateNow ()
		{
			appRating.RateNow ();
		}

		private void NeverRate ()
		{
			appRating.NeverRate ();
		}

		private void RateLater ()
		{
			appRating.RateLater ();
		}

		public override void Show ()
		{
			int resultIndex = EditorUtility.DisplayDialogComplex ( _title, _message, "RATE NOW", "NO, THANKS", "LATER" );

			switch ( resultIndex )
			{
				case 0:
					RateNow ();
					break;
				case 1:
					NeverRate ();
					break;
				case 2:
					RateLater ();
					break;
			}
		}

		public override void ShowIfNeeded ()
		{
			if ( !appRating.CanRate () ) return;
			Show ();
		}

		public override void Reset ()
		{
			appRating.Reset ();
		}
	}

}
#endif