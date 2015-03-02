namespace MonocleUI
{
	using System;
	using Eto.Forms;

	public class Program
	{
		[STAThread]
		public static void Main (string[] args)
		{
			var application = new Application (Eto.Platforms.Mac);
			var mainWindow = new MainWindow ();
			application.Run (mainWindow);
		}
	}
}