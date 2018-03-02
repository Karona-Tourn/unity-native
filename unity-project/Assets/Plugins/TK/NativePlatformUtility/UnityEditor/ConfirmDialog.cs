#if UNITY_EDITOR
using UnityEditor;

namespace TK.NativePlatformUtilities
{

	public class ConfirmDialog : ConfirmDialogBase
	{
		private ConfirmDialog () { }

		public override void Show ()
		{
			var dialogResult = EditorUtility.DisplayDialog(_title, _message, _positiveButton, _negativeButton);

			if ( _onClick == null ) return;

			_onClick ( dialogResult ? DialogResult.OK : DialogResult.Cancel );
		}

		public override void Close ()
		{
			throw new System.NotImplementedException ();
		}

		static public IConfirmDialog Create ()
		{
			return new ConfirmDialog ();
		}
	}

}
#endif