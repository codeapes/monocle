using System;
using Eto.Forms;
using MonocleUI.Resources.Menus;

namespace MonocleUI.Commands
{
    public class FileMenuCommand : Command
    {
        public FileMenuCommand ()
        {
            MenuText = MenuResources.FileMenuName;
        }
    }
}
