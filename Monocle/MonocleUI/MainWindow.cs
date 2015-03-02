namespace MonocleUI
{
	using Eto.Forms;
	using Eto.Drawing;

	public class MainWindow : Form
	{
		private string title;

		public MainWindow ()
		{
			Menu = new MenuBar ();
			SetTitle (null);
			ShowInTaskbar = true;
			Maximize ();
			AddFileMenuItem (new FileMenuOpenCommand ());
			AddFileMenuItem (new SolutionOpenCommand ());
			AddApplicationMenuItem (new SeparatorMenuItem());
		}

		public void AddApplicationMenuItem(MenuItem menuItem) 
		{
			Menu.ApplicationMenu.Items.Add (menuItem);
		}

		public void AddFileMenuItem(MenuItem menuItem)
		{
			((MenuItemCollection)Menu.Items).GetSubmenu("File",0,true,true).Items.Add(menuItem);
		}

		public void SetTitle(string title)
		{
			if (title != null) 
			{
				this.title = title;
				this.Title = "Monocle - " + this.title;
			} 
			else 
			{
				this.title = "Monocle";
				this.Title = this.title;
			}
		}

		public string GetCurrentTitle() 
		{
			return this.title;
		}
	}
}

