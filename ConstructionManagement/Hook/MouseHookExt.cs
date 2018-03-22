// /////////////////////////////////////////////////////////////
// File: MouseHookExt.cs	Class: PmSoft.Common.CommonClass.Hook.MouseHookExt
// Date: 2/25/2004			Author: Michael Kennedy
// Language: C#				Framework: .NET
//
// Copyright: Copyright (c) Michael Kennedy, 2004-2005
// /////////////////////////////////////////////////////////////
// License: See License.txt file included with application.
// Description: See compiled documentation (Managed Hooks.chm)
// /////////////////////////////////////////////////////////////

using System;
using System.Drawing;

namespace PmSoft.ConstructionManagement.Hook
{
    /// <include file='ManagedHooks.xml' path='Docs/MouseHookExt/Class/*'/>
    public class MouseHookExt : MouseHook
	{
        /// 返回ture表示截获该消息，不再传递下去
		/// <include file='ManagedHooks.xml' path='Docs/MouseHookExt/MouseEventHandlerExt/*'/>
		public delegate bool MouseEventHandlerExt(Point pt);

		/// <include file='ManagedHooks.xml' path='Docs/MouseHookExt/LeftButtonDown/*'/>
		public event MouseEventHandlerExt LeftButtonDown;
		/// <include file='ManagedHooks.xml' path='Docs/MouseHookExt/RightButtonDown/*'/>
		public event MouseEventHandlerExt RightButtonDown;
		/// <include file='ManagedHooks.xml' path='Docs/MouseHookExt/LeftButtonUp/*'/>
		public event MouseEventHandlerExt LeftButtonUp;
		/// <include file='ManagedHooks.xml' path='Docs/MouseHookExt/RightButtonUp/*'/>
		public event MouseEventHandlerExt RightButtonUp;
		/// <include file='ManagedHooks.xml' path='Docs/MouseHookExt/MouseWheel/*'/>
		public event MouseEventHandlerExt MouseWheel;
		/// <include file='ManagedHooks.xml' path='Docs/MouseHookExt/Move/*'/>
		public event MouseEventHandlerExt Move;

		/// <include file='ManagedHooks.xml' path='Docs/MouseHookExt/ctor/*'/>
		public MouseHookExt()
		{
			this.MouseEvent += new MouseEventHandler(MouseHookExt_MouseEvent);
		}

		/// <include file='ManagedHooks.xml' path='Docs/MouseHook/HookCallback/*'/>
		protected override bool HookCallback(int code, UIntPtr wparam, IntPtr lparam)
		{
			return base.HookCallback(code, wparam, lparam);
		}

		private bool MouseHookExt_MouseEvent(MouseEvents mEvent, System.Drawing.Point point)
		{
            bool ret = false;
			switch (mEvent)
			{
				case MouseEvents.LeftButtonUp:
					ret = Fire_LeftButtonUp(point);
					break;
				case MouseEvents.LeftButtonDown:
                    ret = Fire_LeftButtonDown(point);
					break;
				case MouseEvents.RightButtonUp:
                    ret = Fire_RightButtonUp(point);
					break;
				case MouseEvents.RightButtonDown:
                    ret = Fire_RightButtonDown(point);
					break;
				case MouseEvents.MouseWheel:
                    ret = Fire_MouseWheel(point);
					break;
				case MouseEvents.Move:
                    ret = Fire_Move(point);
					break;
			}
            return ret;
		}

        private bool Fire_LeftButtonDown(Point point)
		{
			if (LeftButtonDown != null)
			{
				return LeftButtonDown(point);
			}

            return false;
		}

        private bool Fire_LeftButtonUp(Point point)
		{
			if (LeftButtonUp != null)
			{
				return LeftButtonUp(point);
			}

            return false;
		}

        private bool Fire_RightButtonDown(Point point)
		{
			if (RightButtonDown != null)
			{
				return RightButtonDown(point);
			}

            return false;
		}

        private bool Fire_RightButtonUp(Point point)
		{
			if (RightButtonUp != null)
			{
				return RightButtonUp(point);
			}

            return false;
		}

        private bool Fire_Move(Point point)
		{
			if (Move != null)
			{
				return Move(point);
			}

            return false;
		}

        private bool Fire_MouseWheel(Point point)
		{
			if (MouseWheel != null)
			{
				return MouseWheel(point);
			}

            return false;
		}
	}
}
