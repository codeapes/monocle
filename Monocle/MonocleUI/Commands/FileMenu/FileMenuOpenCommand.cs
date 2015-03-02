namespace MonocleUI
{
	using System;
	using Eto.Forms;

	public class FileMenuOpenCommand : Command
	{
		public FileMenuOpenCommand ()
		{
			MenuText = "&Open File";
			ToolBarText = "Open a file";
			ToolTip = "Will open a file for you.";
			Shortcut = Application.Instance.CommonModifier | Keys.O;
		}

		protected override void OnExecuted(EventArgs e)
		{
			base.OnExecuted(e);

			MessageBox.Show(Application.Instance.MainForm, "You clicked me!", "Tutorial 2", MessageBoxButtons.OK);
		}
	}
}

