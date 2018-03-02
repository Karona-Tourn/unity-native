#if UNITY_EDITOR
using UnityEditor;

namespace TK.NativePlatformUtilities
{

	public class AlertDialog : AlertDialogBase
	{
		private AlertDialog () { }

		public override void Close ()
		{
			throw new System.NotImplementedException ();
		}

		public override void Show ()
		{
			var dialogResult = EditorUtility.DisplayDialog(_title, _message, _button);

			if ( dialogResult && _onClick != null )
			{
				_onClick ();
			}
		}

		static public IAlertDialog Create ()
		{
			return new AlertDialog ();
		}
	}

}
#endif