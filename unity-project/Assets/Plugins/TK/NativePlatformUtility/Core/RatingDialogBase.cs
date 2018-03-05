using System;
using UnityEngine;

namespace TK.NativePlatformUtilities
{
	public class AppRating : AppRating.ConditionTrigger
	{
		public enum RatingLinkFormat
		{
			ForWebPage,
			ForMobileApp
		}

		public interface ConditionTrigger
		{
			bool CanRate ();
		}

		private const string PrefNeverRate				= "never-rate";
		private const string PrefRated					= "rated";
		private const string PrefCheckTimes				= "check-times";
		private const string PrefFirstDateTimeTicks		= "first-datetime-ticks";

		private string              _packageName    = "";
		private ConditionTrigger    _condition      = null;
		private RatingLinkFormat    _linkFormat		= RatingLinkFormat.ForWebPage;
		private readonly int        _maxCheckTimes  = 1;

		private ConditionTrigger Condition
		{
			get
			{
				if ( _condition == null ) _condition = this;
				return _condition;
			}
		}

		public AppRating ( string packageName ) : this ( packageName, 1 )
		{
		}

		public AppRating ( string packageName, int maxCheckTimes )
		{
			_packageName = packageName;
			_maxCheckTimes = maxCheckTimes;
		}

		public void Reset ()
		{
			PlayerPrefs.SetInt ( PrefCheckTimes, 1 );
			PlayerPrefs.SetInt ( PrefNeverRate, 0 );
			PlayerPrefs.SetInt ( PrefRated, 0 );
			PlayerPrefs.SetFloat ( PrefFirstDateTimeTicks, DateTime.Now.Ticks );
		}

		public void RateNow ()
		{
			PlayerPrefs.SetInt ( PrefRated, 1 );
			OpenRateLink ();
		}

		public void RateLater ()
		{
			PlayerPrefs.SetInt ( PrefCheckTimes, 1 );
			PlayerPrefs.SetFloat ( PrefFirstDateTimeTicks, DateTime.Now.Ticks );
		}

		public void NeverRate ()
		{
			PlayerPrefs.SetInt ( PrefNeverRate, 1 );
		}

		public void SetRatingTarget ( RatingLinkFormat format )
		{
			_linkFormat = format;
		}

		public void SetConditionTrigger ( ConditionTrigger condition )
		{
			_condition = condition;
		}

		public bool CanRate ()
		{
			// Cannot show if rated once
			bool rated = PlayerPrefs.GetInt(PrefRated, 0) != 0;
			if ( rated ) return false;

			// Cannot show if confirmed never rate
			bool neverRate = PlayerPrefs.GetInt(PrefNeverRate, 0) != 0;
			if ( neverRate ) return false;

			int checkTimes = PlayerPrefs.GetInt(PrefCheckTimes, 1);
			if ( checkTimes > _maxCheckTimes ) return true;
			else PlayerPrefs.SetInt ( PrefCheckTimes, checkTimes + 1 );

			long firstDateTimeTicks = (long)PlayerPrefs.GetFloat(PrefFirstDateTimeTicks, DateTime.Now.Ticks);
			TimeSpan diffTimeSpan = DateTime.Now.Subtract(new DateTime(firstDateTimeTicks));
			if ( diffTimeSpan.Days > 1 ) return true;

			return false;
		}

		public void OpenRateLink ()
		{
			if ( string.IsNullOrEmpty ( _packageName ) )
			{
				Debug.LogWarning ( "Package name cannot be empty!" );
				return;
			}

			string link = string.Empty;

#if UNITY_ANDROID
			if(_linkFormat == RatingLinkFormat.ForWebPage) link = "http://play.google.com/store/apps/details?id=" + _packageName;
			else link = "market://details?id=" + _packageName;
#elif UNITY_IOS || UNITY_IPHONE
#endif

			if ( string.IsNullOrEmpty ( link ) ) return;

			Application.OpenURL ( link );
		}
	}

	public abstract class RatingDialogBase : IRatingDialog
	{
		protected string _title = "";
		protected string _message = "";

		public void SetMessage ( string message )
		{
			_message = message;
		}

		public void SetTitle ( string title )
		{
			_title = title;
		}

		public abstract void Show ();

		public abstract void ShowIfNeeded ();
	}

}