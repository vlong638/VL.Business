using PmSoft.Common.MFCDll;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using PmSoft.Common.CommonClass;

namespace PmSoft.ConstructionManagement.Hook
{
    /// <summary>
    /// 主窗体句柄
    /// </summary>
    public class RevitHandle : IWin32Window
    {
        private IntPtr handle;

        public IntPtr Handle
        {
            get { return handle; }
        }

        public RevitHandle(IntPtr handle)
        {
            this.handle = handle;
        }
    }

    /// <summary>
    /// 获取文本框句柄
    /// </summary>
    public class TextBoxHandle
    {
        #region 属性

        private CWndManager mng;
        private IntPtr handle;
        private List<string> data;

        public CWndManager Mng
        {
            get { return mng; }
            set { mng = value; }
        }

        public IntPtr ParentHandle { get; set; }

        /// <summary>
        /// 文本框句句柄
        /// </summary>
        public IntPtr Handle
        {
            get { return handle; }
            set { handle = value; }
        }

        /// <summary>
        /// 文本
        /// </summary>
        public string Text { get; set; }

        #endregion

        public TextBoxHandle(IntPtr handle, string data)
        {
            this.Handle = handle;
            Text = data;
        }

        public TextBoxHandle(string handlTitle)
        {
            IntPtr mainHandle = Process.GetCurrentProcess().MainWindowHandle;
            this.mng = new CWndManager();
            IntPtr ptr = this.mng.SearchByTitle(mainHandle, handlTitle);
            if (ptr != IntPtr.Zero)
            {
                ParentHandle = ptr;
                this.handle = this.mng.SearchEditBox(ptr);
            }
        }




        /// <summary>
        /// <remarks>修改：郑海盛</remarks>
        /// 一个标题线有多相同控件根据索引获取
        /// </summary>
        /// <param name="handlTitle"></param>
        /// <param name="index"></param>
        public TextBoxHandle(string handlTitle, int index)
        {
            IntPtr mainHandle = Process.GetCurrentProcess().MainWindowHandle;
            this.mng = new CWndManager();
            IntPtr ptr = this.mng.SearchByTitle(mainHandle, handlTitle);
            if (ptr != IntPtr.Zero)
            {
                ParentHandle = ptr;
                this.handle = this.mng.SearchEditBox(ptr, index);
            }
        }


        /// <summary>
        /// 添加多个同名父对话框下的控件搜索
        /// </summary>
        /// <param name="titleParent">父类对话框控件的title</param>
        /// <param name="indexParent">同名对话框的序号</param>
        /// <param name="indexChild">对话框下控件的序号</param>
        public TextBoxHandle(string titleParent, int indexParent, int indexChild)
        {
            IntPtr mainHandle = Process.GetCurrentProcess().MainWindowHandle;
            this.mng = new CWndManager();
            IntPtr ptr = this.mng.SearchDialog(mainHandle, titleParent, indexParent);
            if (ptr != IntPtr.Zero)
            {
                IntPtr ptrComb = this.mng.SearchEditBox(ptr, indexChild);
                if (ptrComb != IntPtr.Zero)
                {
                    ParentHandle = ptr;
                    this.handle = ptrComb;
                }
            }
        }

    }

    /// <summary>
    /// 下拉框句柄
    /// </summary>
    public class ComboxHandle
    {
        #region 属性

        private CWndManager mng;
        private IntPtr m_parentHandle;
        private IntPtr handle;
        private List<string> data;

        public CWndManager Mng
        {
            get { return mng; }
            set { mng = value; }
        }

        /// <summary>
        /// 下拉框句柄
        /// </summary>
        public IntPtr Handle
        {
            get { return handle; }
            set { handle = value; }
        }

        /// <summary>
        /// 下拉框句柄
        /// </summary>
        public IntPtr ParentHandle
        {
            get { return m_parentHandle; }
            set { m_parentHandle = value; }
        }

        /// <summary>
        /// 下拉框数据
        /// </summary>
        public List<string> Data
        {
            get { return data; }
            set { data = value; }
        }

        #endregion

        public ComboxHandle(IntPtr handle, string[] data)
        {
            this.Handle = handle;
            foreach (string s in data)
            {
                this.Data.Add(s);
            }
        }

        /// <summary>
        /// 添加多个同名父对话框下的控件搜索
        /// <remarks>作者：zfy</remarks>
        /// </summary>
        /// <param name="titleParent">父类对话框控件的title</param>
        /// <param name="indexParent">同名对话框的序号</param>
        /// <param name="indexChild">对话框下控件的序号</param>
        public ComboxHandle(string titleParent, int indexParent, int indexChild)
        {
            IntPtr mainHandle = Process.GetCurrentProcess().MainWindowHandle;
            this.mng = new CWndManager();
            this.data = new List<string>();
            IntPtr ptr = this.mng.SearchDialog(mainHandle, titleParent, indexParent);
            if (ptr != IntPtr.Zero)
            {
                //父窗口id
                m_parentHandle = ptr;

                //
                IntPtr ptrComb = this.mng.SearchComboBox(ptr, indexChild);
                if (ptrComb != IntPtr.Zero)
                {
                    this.handle = ptrComb;
                    string[] arritem = null;
                    this.mng.GetComboBoxItemAll(ptrComb, ref arritem);

                    foreach (string s in arritem)
                    {
                        this.data.Add(s);
                    }
                }
            }
        }

        /// <summary>
        /// <remarks>修改：郑海盛</remarks>
        /// 新加构造函数用于有多个ComBox的时候
        /// </summary>
        /// <param name="handlTitle"></param>
        /// <param name="index"></param>
        public ComboxHandle(string titleParent, int indexChild)
        {
            IntPtr mainHandle = Process.GetCurrentProcess().MainWindowHandle;
            this.mng = new CWndManager();
            this.data = new List<string>();
            IntPtr ptr = this.mng.SearchByTitle(mainHandle, titleParent);
            if (ptr != IntPtr.Zero)
            {
                //父窗口id
                m_parentHandle = ptr;

                //
                IntPtr ptrComb = this.mng.SearchComboBox(ptr, indexChild);
                if (ptrComb != IntPtr.Zero)
                {
                    this.handle = ptrComb;
                    string[] arritem = null;
                    this.mng.GetComboBoxItemAll(ptrComb, ref arritem);

                    foreach (string s in arritem)
                    {
                        this.data.Add(s);
                    }
                }
            }
        }

        public ComboxHandle(string titleParent)
        {
            IntPtr mainHandle = Process.GetCurrentProcess().MainWindowHandle;
            this.mng = new CWndManager();
            this.data = new List<string>();
            IntPtr ptr = this.mng.SearchByTitle(mainHandle, titleParent);
            if (ptr != IntPtr.Zero)
            {
                //父窗口id
                m_parentHandle = ptr;

                //
                IntPtr ptrComb = this.mng.SearchComboBox(ptr);
                if (ptrComb != IntPtr.Zero)
                {
                    this.handle = ptrComb;
                    string[] arritem = null;
                    this.mng.GetComboBoxItemAll(ptrComb, ref arritem);

                    foreach (string s in arritem)
                    {
                        this.data.Add(s);
                    }
                }
            }
        }
    }

    /// <summary>
    /// 选择框句柄
    /// </summary>
    public class CheckBoxHandle
    {
        #region 属性

        private CWndManager mng;
        private IntPtr handle;
        private bool check;

        public CWndManager Mng
        {
            get { return mng; }
            set { mng = value; }
        }

        /// <summary>
        /// 选择框句柄
        /// </summary>
        public IntPtr Handle
        {
            get { return handle; }
            set { handle = value; }
        }

        /// <summary>
        /// 选择状态
        /// </summary>
        public bool Check
        {
            get
            {
                if (this.handle != null && this.handle != IntPtr.Zero)
                {
                    return mng.IsCheck(this.handle);
                }
                else
                {
                    return false;
                }
            }
            set
            {
                check = value;
                if (this.handle != null && this.handle != IntPtr.Zero)
                {
                    mng.SetCheck(this.handle, value);
                }
            }
        }

        #endregion

        public CheckBoxHandle(string handleTitle)
        {
            IntPtr mainHandle = Process.GetCurrentProcess().MainWindowHandle;
            this.mng = new CWndManager();
            IntPtr ptr = this.mng.SearchByTitle(mainHandle, handleTitle);
            if (ptr != IntPtr.Zero)
            {
                this.handle = mng.SearchCheckBox(ptr);
            }
        }

        /// <summary>
        /// <remarks>修改：郑海盛</remarks>
        /// 一个标题线有多相同控件根据索引获取
        /// </summary>
        /// <param name="handlTitle"></param>
        /// <param name="index"></param>
        public CheckBoxHandle(string handleTitle, int index)
        {
            IntPtr mainHandle = Process.GetCurrentProcess().MainWindowHandle;
            this.mng = new CWndManager();
            IntPtr ptr = this.mng.SearchByTitle(mainHandle, handleTitle);
            if (ptr != IntPtr.Zero)
            {
                this.handle = mng.SearchCheckBox(ptr, index);
            }
        }
    }

    public class ButtonNHandle
    {
        private IntPtr handle;

        public IntPtr Handle {
            get { return handle; }
        }
        public ButtonNHandle(string title, string buttonTitle)
        {
            GetButtonHandel(title, buttonTitle);
        }

        public void ButtonNClick()
        {
            if (handle != IntPtr.Zero && handle != null)
            {
                MethodForWin32.SendMessage(handle, 0xF5, (IntPtr)1, IntPtr.Zero);
                //MethodForWin32.SendMessage(handle, 0x201, (IntPtr)1, IntPtr.Zero);
                //MethodForWin32.SendMessage(handle, 0x202, (IntPtr)1, IntPtr.Zero);
                handle=IntPtr.Zero;
            }
        }

        private void GetButtonHandel(string title,string buttonTitle)
        {
            int loopNnb = 0;
            IntPtr mainHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            IntPtr controlBarHandle = IntPtr.Zero;
            IntPtr buttonHandle = IntPtr.Zero;
            
            try
            {
                //while (controlBarHandle == null || controlBarHandle == IntPtr.Zero)
                //{
                //    controlBarHandle = MethodForWin32.FindWindowEx(mainHandle, controlBarHandle, null, title);
                //    loopNnb++;
                //    if (loopNnb == 50)
                //        break;
                //}
                int j = MethodForWin32.EnumChildWindows(
                    mainHandle,
                    (h, l) =>
                    {
                        IntPtr f1 = MethodForWin32.FindWindowEx(h, IntPtr.Zero, null, title);
                        if (f1 == IntPtr.Zero)
                            return true;
                        else
                        {
                            controlBarHandle = f1;
                            return false;
                        }
                    },
                    0);
                handle = MethodForWin32.FindWindowEx(controlBarHandle, IntPtr.Zero, null, buttonTitle);

                //if (controlBarHandle != null && controlBarHandle != IntPtr.Zero)
                //{
                //    int i = MethodForWin32.EnumChildWindows(
                //    controlBarHandle,
                //    (h, l) =>
                //    {
                //        IntPtr lpString = Marshal.AllocHGlobal(200);
                //        IntPtr f1 = MethodForWin32.GetWindowText(h, lpString,200);
                //        if (f1 == IntPtr.Zero)
                //            return true;
                //        else
                //        {
                //            handle = f1;
                //            return false;
                //        }
                //    },
                //    0);

                //}

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }

    /// <summary>
    /// 多选元素时的选择按钮
    /// </summary>
    public class ButtonHandle
    {
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

        /// <summary>
        /// 查找窗体上控件句柄
        /// </summary>
        /// <param name="hwnd">父窗体句柄</param>
        /// <param name="lpszWindow">控件标题(Text)</param>
        /// <param name="bChild">设定是否在子窗体中查找</param>
        /// <returns>控件句柄，没找到返回IntPtr.Zero</returns>
        private IntPtr FindWindowEx(IntPtr hwnd, string lpszClass, string lpszWindow, bool bChild)
        {
            IntPtr iResult = IntPtr.Zero;
            // 首先在父窗体上查找控件
            iResult = FindWindowEx(hwnd, 0, lpszClass, lpszWindow);
            // 如果找到直接返回控件句柄
            if (iResult != IntPtr.Zero) return iResult;

            if (!bChild) return iResult;

            int i = EnumChildWindows(
            hwnd,
            (h, l) =>
            {
                IntPtr f1 = FindWindowEx(h, 0, lpszClass, lpszWindow);
                if (f1 == IntPtr.Zero)
                    return true;
                else
                {
                    iResult = f1;
                    return false;
                }
            },
            0);
            return iResult;
        }

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
            IntPtr mainHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            //IntPtr controlBarHandle = IntPtr.Zero;
            IntPtr buttonHandle = IntPtr.Zero;
            //for (int i = 0; i < 30; i++)
            {
//#if Revit2017
//                controlBarHandle = FindWindowEx(mainHandle, controlBarHandle, "Afx:ControlBar:347d0000:8:10003:10", null);
//#else
//                controlBarHandle = FindWindowEx(mainHandle, controlBarHandle, "Afx:ControlBar:40000000:8:10003:10", null);
//#endif
                //if (controlBarHandle == IntPtr.Zero) continue;
                //else
                {
                    //buttonHandle = FindWindowEx(controlBarHandle, "Button", buttonName, true);
                    IntPtr titleWIntPtr = new CWndManager().SearchByTitle(mainHandle, buttonName);
                    buttonHandle = titleWIntPtr;
                    //if (buttonHandle == IntPtr.Zero) continue;
                    //else
                    {
                        SendMessage(buttonHandle, 0x201, (IntPtr)1, null);
                        SendMessage(buttonHandle, 0x202, (IntPtr)1, null);
                        //break;
                    }
                }
            }
            return true;
        }

        public bool IsButtonExit(string buttonName)
        {
            IntPtr mainHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
            IntPtr buttonHandle = IntPtr.Zero;
                    buttonHandle = new CWndManager().SearchByTitle(mainHandle, "完成");
            if (buttonHandle == IntPtr.Zero) return false;
            else return true;
        }
    }
}
