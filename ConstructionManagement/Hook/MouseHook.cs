// /////////////////////////////////////////////////////////////
// File: MouseHook.cs		Class: PmSoft.Common.CommonClass.Hook.MouseHook
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
    /// <include file='ManagedHooks.xml' path='Docs/MouseEvents/enum/*'/>
    public enum MouseEvents
	{
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		LeftButtonDown	= 0x0201,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		LeftButtonUp	= 0x0202,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		Move			= 0x0200,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		MouseWheel		= 0x020A,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		RightButtonDown = 0x0204,
		/// <include file='ManagedHooks.xml' path='Docs/General/Empty/*'/>
		RightButtonUp	= 0x0205
	}

	/// <include file='ManagedHooks.xml' path='Docs/MouseHook/Class/*'/>
	public class MouseHook : SystemHook
	{
        /// 返回ture表示截获该消息，不再传递下去
		/// <include file='ManagedHooks.xml' path='Docs/MouseHook/MouseEventHandler/*'/>
		public delegate bool MouseEventHandler(MouseEvents mEvent, Point point);

		/// <include file='ManagedHooks.xml' path='Docs/MouseHook/MouseEvent/*'/>
		public event MouseEventHandler MouseEvent;

		/// <include file='ManagedHooks.xml' path='Docs/MouseHook/ctor/*'/>
		public MouseHook() : base(HookTypes.MouseLL)
		{
		}

		/// <include file='ManagedHooks.xml' path='Docs/MouseHook/HookCallback/*'/>
		protected override bool HookCallback(int code, UIntPtr wparam, IntPtr lparam)
		{
			if (MouseEvent == null)
			{
				return false;
			}

			int x = 0, y = 0;
			MouseEvents mEvent = (MouseEvents)wparam.ToUInt32();

			switch(mEvent)
			{
				case MouseEvents.LeftButtonDown:
					GetMousePosition(wparam, lparam, ref x, ref y);
					break;
				case MouseEvents.LeftButtonUp:
					GetMousePosition(wparam, lparam, ref x, ref y);
					break;
				case MouseEvents.MouseWheel:
					break;
				case MouseEvents.Move:
					GetMousePosition(wparam, lparam, ref x, ref y);
					break;
				case MouseEvents.RightButtonDown:
					GetMousePosition(wparam, lparam, ref x, ref y);
					break;
				case MouseEvents.RightButtonUp:
					GetMousePosition(wparam, lparam, ref x, ref y);
					break;
				default:
					//System.Diagnostics.Trace.WriteLine("Unrecognized mouse event");
					break;
			}

			return MouseEvent(mEvent, new Point(x, y));
		}

        /// 过滤截获的消息类型：可以把需要截获的消息一个一个添加上去，默认全部消息都截获
		/// <include file='ManagedHooks.xml' path='Docs/MouseHook/FilterMessage/*'/>
		public void FilterMessage(MouseEvents eventType)
		{
			base.FilterMessage(this.HookType, (int)eventType);
		}

	}
}
