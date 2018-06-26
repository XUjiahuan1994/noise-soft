using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ps5000example
{
    class DotNetWin32
    {
        

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("user32.dll")]
        public static extern int GetClientRect(IntPtr hwnd, ref RECT rc);

        #region
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MoveWindow(IntPtr hWnd, int x, int y, int nWidth, int nHeight, bool BRePaint);

        public const int GWL_STYLE = -16;
        public const int WS_CAPTION = 0x00C00000;
        public const int WS_THICKFRAME = 0x00040000;
        public const int WS_SYSMENU = 0X00080000;


        [DllImport("user32")]
        public static extern int GetWindowLong(System.IntPtr hwnd, int nIndex);

        [DllImport("user32")]
        public static extern int SetWindowLong(System.IntPtr hwnd, int index, int newLong);
        [DllImport("user32")]
        public static extern int InvalidateRect(System.IntPtr hwnd, object rect, bool bErase);
        /// <summary>最大化窗口，最小化窗口，正常大小窗口
        /// nCmdShow:0隐藏,3最大化,6最小化，5正常显示
        /// </summary>
        [DllImport("user32.dll", EntryPoint = "ShowWindow")]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);
        #endregion
    }
}
