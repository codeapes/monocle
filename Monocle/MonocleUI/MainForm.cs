using Eto.Forms;
using Eto.Drawing;
using MonocleUI.Commands;

namespace MonocleUI
{
    public class MainForm : Form
    {
        public MainForm()
        {
            Title = "Monocle";
            ClientSize = new Size(400, 350);

            // create menu
            Menu = new MenuBar
            {
                IncludeSystemItems = MenuBarSystemItems.Quit,
                Items =
                {
                    new FileMenuCommand()
                    // File submenu
                    // new ButtonMenuItem { Text = "&File", Items = { clickMe } },
                    // new ButtonMenuItem { Text = "&Edit", Items = { /* commands/items */ } },
                    // new ButtonMenuItem { Text = "&View", Items = { /* commands/items */ } },
                },
                ApplicationItems =
                {
                    // application (OS X) or file menu (others)
                    //new ButtonMenuItem { Text = "&Preferences..." },
                },
                //QuitItem = quitCommand,
                //AboutItem = aboutCommand
            };

            // create toolbar           
            //ToolBar = new ToolBar { Items = { clickMe } };
        }
    }
}
