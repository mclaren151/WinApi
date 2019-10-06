using System;
using System.Collections.Generic;
using System.Text;

using WinApi.User32;

namespace WinApi.Windows.Controls
{
    public class Menu
    {
        IntPtr hMenu;
        List<MenuItem> items = new List<MenuItem>();

        public IntPtr Handle { get { return hMenu; } }
        public string Name { get; private set; }

        public Menu(string name)
        {
            hMenu = User32Methods.CreateMenu();
            Name = name;
        }

        public MenuItem AddItem(string name)
        {
            MenuItem menuItem = new MenuItem(this, name);
            items.Add(menuItem);
            return menuItem;
        }

        public MenuSeperator AddSeperator()
        {
            return new MenuSeperator(this);
        }

        public bool CheckCommand(short id)
        {
            foreach (MenuItem item in items)
            {
                if (item.CheckClicked(id))
                    return true;
            }

            return false;
        }
    }
}
