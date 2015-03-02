// Copyright: codeapes
using System.Collections.Generic;


namespace MonocleUI
{
	using System;
	using System.Linq;
	using Eto.Forms;

	public class SolutionFileChooserDialog : OpenFileDialog
	{
		private List<IFileDialogFilter> filters = new List<IFileDialogFilter> ();
		private IFileDialogFilter solutionFilter = new FileDialogFilter ("Solution", "*.sln");

		public SolutionFileChooserDialog ()
		{
			filters.Add (solutionFilter);
			Filters = filters;
			CheckFileExists = true;
			CurrentFilterIndex = 0;
			MultiSelect = false;
		}

		public void ShowFileChooser(Window parent) {
			var result = ShowDialog (parent);
			switch (result) {
			case DialogResult.Ok:
				return;
			case DialogResult.Cancel:
				Dispose ();
				return;
			default:
				throw new ArgumentOutOfRangeException (result.ToString ());
			}
		}
	}
}