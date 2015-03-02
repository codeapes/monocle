using System.Collections.Generic;

namespace MonocleUI
{
	using System;
	using Eto.Forms;

	public class SolutionOpenCommand : Command
	{
		public SolutionOpenCommand ()
		{
			MenuText = "Open &Solution";
			Shortcut = Application.Instance.CommonModifier | Application.Instance.AlternateModifier | Keys.O;
		}

		protected override void OnExecuted(EventArgs e) {
			var fileDialog = new SolutionFileChooserDialog ();
			fileDialog.ShowFileChooser (Application.Instance.MainForm);
			base.OnExecuted (e);
		}
	}
}

