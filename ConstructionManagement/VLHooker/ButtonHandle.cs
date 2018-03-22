using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PmSoft.ConstructionManagement.VLHooker
{
    /// <summary>
    /// 多选元素时的选择按钮
    /// </summary>
    public class ButtonHandle
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern int FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, uint hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx", CharSet = CharSet.Auto)]
        extern static IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, string lParam);
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
        public static extern void SetForegroundWindow(IntPtr hwnd);
        [DllImport("user32.dll")]
        public static extern int EnumChildWindows(IntPtr hWndParent, CallBack lpfn, int lParam);
        public delegate bool CallBack(IntPtr hwnd, int lParam);

        public bool Mouse_RightButtonDown(System.Drawing.Point pt)
        {
            return SendMessageToButton("完成");
        }

        public bool Mouse_Cancle_RightButtonDown(System.Drawing.Point pt)
        {
            return SendMessageToButton("取消");
        }

        public bool SendMessageToButton(string buttonName)
        {
            IntPtr parent = Autodesk.Windows.ComponentManager.ApplicationWindow;
            var handle = FindWindowEx(parent, "完成");
            SendMessage(handle, 0x201, (IntPtr)1, null);
            SendMessage(handle, 0x202, (IntPtr)1, null);
            return true;
        }

        private IntPtr FindWindowEx(IntPtr parent, string lpszWindow)
        {
            IntPtr iResult = IntPtr.Zero;
            // 首先在父窗体上查找控件
            iResult = FindWindowEx(parent, IntPtr.Zero, null, lpszWindow);
            // 如果找到直接返回控件句柄
            if (iResult != IntPtr.Zero)
                return iResult;
            int i = EnumChildWindows(parent, (h, l) =>
            {
                IntPtr f1 = FindWindowEx(h, 0, null, lpszWindow);
                if (f1 == IntPtr.Zero)
                    return true;
                else
                {
                    iResult = f1;
                    return false;
                }
            }, 0);
            return iResult;
        }
    }
}
