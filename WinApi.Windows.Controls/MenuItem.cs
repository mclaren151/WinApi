using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

using WinApi.User32;

namespace WinApi.Windows.Controls
{
    public class MenuItem
    {
        public delegate void OnClick(MenuItem item);
        public event OnClick OnClicked;

        IntPtr hMenu;
        const uint BASE_MENU_ID = 1000;
        static uint menuId = BASE_MENU_ID;
        readonly short id;
        bool isChecked = false;
        bool isEnabled = true;

        public string Name { get; private set; }
        public bool Enabled 
        { 
            get { return isEnabled; }
            set
            {
                MenuItemInfo info = new MenuItemInfo();
                info.Size = Marshal.SizeOf(info);
                info.Mask = (uint)MenuInfoMaskFlags.MIIM_STATE;

                info.State = 0;
                if (!value)
                    info.State |= (uint)(MenuInfoStateFlags.MFS_DISABLED);
                if (isChecked)
                    info.State |= (uint)MenuInfoStateFlags.MFS_CHECKED;

                if (User32Methods.SetMenuItemInfo(hMenu, (uint)id, false, ref info))
                    isEnabled = value;
            }
        }

        public bool Checked 
        { 
            get { return isChecked; }
            set
            {
                MenuItemInfo info = new MenuItemInfo();
                info.Size = Marshal.SizeOf(info);
                info.Mask = (uint)MenuInfoMaskFlags.MIIM_STATE;

                info.State = 0;
                if (!isEnabled)
                    info.State |= (uint)(MenuInfoStateFlags.MFS_DISABLED);
                if (value)
                    info.State |= (uint)MenuInfoStateFlags.MFS_CHECKED;

                if (User32Methods.SetMenuItemInfo(hMenu, (uint)id, false, ref info))
                    isChecked = value;
            }
        }

       
        public MenuItem(Menu menu, string name)
        {
            hMenu = menu.Handle;
            Name = name;
            User32Methods.AppendMenu(hMenu, (uint)MenuFlags.MF_STRING, menuId, name);
            id = (short)menuId;
            Enabled = true; // enabled and not checked
            Checked = false;
            menuId++;
        }

        internal bool CheckClicked(short id)
        {
            if (id == this.id)
            {
                OnClicked?.Invoke(this);
                return true;
            }

            return false;
        }
    }

    public class MenuSeperator
    {
        IntPtr hMenu;

        public MenuSeperator(Menu menu)
        {
            hMenu = menu.Handle;
            User32Methods.AppendMenu(hMenu, (uint)MenuFlags.MF_SEPERATOR, 0, "");
        }
    }

    [Flags]
    public enum MenuFlags : uint
    {
        MF_STRING = 0x00000000,
        MF_GRAYED = 0x00000001,
        MF_DISABLED = 0x00000002,
        MF_BITMAP = 0x00000004,
        MF_CHECKED = 0x00000008,
        MF_POPUP = 0x00000010,
        MF_MENUBARBREAK = 0x00000020,
        MF_MENUBREAK = 0x00000040,
        MF_OWNERDRAW = 0x00000100,
        MF_SEPERATOR = 0x00000800,
    }

    enum MenuInfoMaskFlags : uint
    {
        MIIM_BITMAP = 0x00000080,
        MIIM_CHECKMARKS = 0x00000008,
        MIIM_DATA = 0x00000020,
        MIIM_FTYPE = 0x00000100,
        MIIM_ID = 0x00000002,
        MIIM_STATE = 0x00000001,
        MIIM_STRING = 0x00000040,
        MIIM_SUBMENU = 0x00000004,
        MIIM_TYPE = 0x00000010
    }

    enum MenuInfoStateFlags : uint
    {
        MFS_CHECKED = 0x00000008,
        MFS_DEFAULT = 0x00001000,
        MFS_DISABLED = 0x00000003,
        MFS_ENABLED = 0x00000000,
        MFS_HILITE = 0x00000080
    }
}
