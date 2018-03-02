#if UNITY_EDITOR
using UnityEditor;

namespace TK.NativePlatformUtilities
{

	public class ConfirmDialog : ConfirmDialogBase
	{
		private ConfirmDialog () { }

		public override void Show ()
		{
			DialogResult dialogResult = DialogResult.OK;

			if ( HasNeutralButton )
			{
				int index = EditorUtility.DisplayDialogComplex ( _title, _message, _positiveButton, _negativeButton, _neutralButton );
				dialogResult = index == 0 ? DialogResult.OK : index == 1 ? DialogResult.Cancel : DialogResult.Alternate;
			}
			else
			{
				var yes = EditorUtility.DisplayDialog(_title, _message, _positiveButton, _negativeButton);
				dialogResult = yes ? DialogResult.OK : DialogResult.Cancel;
			}

			if ( _onClick == null ) return;

			_onClick ( dialogResult );
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