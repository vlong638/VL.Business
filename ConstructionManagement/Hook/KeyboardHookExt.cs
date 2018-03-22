// /////////////////////////////////////////////////////////////
// File: KeyboardHookExt.cs	Class: PmSoft.Common.CommonClass.Hook.KeyboardHookExt
// Date: 2/25/2004			Author: Michael Kennedy
// Language: C#				Framework: .NET
//
// Copyright: Copyright (c) Michael Kennedy, 2004-2005
// /////////////////////////////////////////////////////////////
// License: See License.txt file included with application.
// Description: See compiled documentation (Managed Hooks.chm)
// /////////////////////////////////////////////////////////////


namespace PmSoft.ConstructionManagement.Hook
{
    /// <include file='ManagedHooks.xml' path='Docs/KeyboardHookExt/Class/*'/>
    public class KeyboardHookExt : KeyboardHook
	{
        /// 返回ture表示截获该消息，不再传递下去
		/// <include file='ManagedHooks.xml' path='Docs/KeyboardHookExt/KeyboardEventHandlerExt/*'/>
		public delegate bool KeyboardEventHandlerExt(System.Windows.Forms.Keys key);

		/// <include file='ManagedHooks.xml' path='Docs/KeyboardHookExt/KeyDown/*'/>
		public event KeyboardEventHandlerExt KeyDown;
		/// <include file='ManagedHooks.xml' path='Docs/KeyboardHookExt/KeyUp/*'/>
		public event KeyboardEventHandlerExt KeyUp;
		/// <include file='ManagedHooks.xml' path='Docs/KeyboardHookExt/SystemKeyDown/*'/>
		public event KeyboardEventHandlerExt SystemKeyDown;
		/// <include file='ManagedHooks.xml' path='Docs/KeyboardHookExt/SystemKeyUp/*'/>
		public event KeyboardEventHandlerExt SystemKeyUp;

		/// <include file='ManagedHooks.xml' path='Docs/KeyboardHookExt/ctor/*'/>
		public KeyboardHookExt()
		{
			this.KeyboardEvent += new KeyboardEventHandler(KeyboardHookExt_KeyboardEvent);
		}

		private bool KeyboardHookExt_KeyboardEvent(KeyboardEvents kEvent, System.Windows.Forms.Keys key)
		{
            bool ret = false;
			switch (kEvent)
			{
				case KeyboardEvents.KeyDown:
					ret = OnKeyDown(key);
					break;
				case KeyboardEvents.KeyUp:
                    ret = OnKeyUp(key);
					break;
				case KeyboardEvents.SystemKeyDown:
                    ret = OnSysKeyDown(key);
					break;
				case KeyboardEvents.SystemKeyUp:
                    ret = OnSysKeyUp(key);
					break;
			}

            return ret;
		}

		/// <include file='ManagedHooks.xml' path='Docs/KeyboardHookExt/OnKeyDown/*'/>
		protected virtual bool OnKeyDown(System.Windows.Forms.Keys key)
		{
			return Fire_KeyDown(key);
		}

		/// <include file='ManagedHooks.xml' path='Docs/KeyboardHookExt/OnKeyUp/*'/>
		protected virtual bool OnKeyUp(System.Windows.Forms.Keys key)
		{
			return Fire_KeyUp(key);
		}

		/// <include file='ManagedHooks.xml' path='Docs/KeyboardHookExt/OnSysKeyDown/*'/>
		protected virtual bool OnSysKeyDown(System.Windows.Forms.Keys key)
		{
			return Fire_SystemKeyDown(key);
		}

		/// <include file='ManagedHooks.xml' path='Docs/KeyboardHookExt/OnSysKeyUp/*'/>
		protected virtual bool OnSysKeyUp(System.Windows.Forms.Keys key)
		{
			return Fire_SystemKeyUp(key);
		}

        private bool Fire_KeyDown(System.Windows.Forms.Keys key)
		{
			if (KeyDown != null)
			{
				return KeyDown(key);
			}

            return false;
		}

        private bool Fire_KeyUp(System.Windows.Forms.Keys key)
		{
			if (KeyUp != null)
			{
				return KeyUp(key);
			}

            return false;
		}

        private bool Fire_SystemKeyDown(System.Windows.Forms.Keys key)
		{
			if (SystemKeyDown != null)
			{
				return SystemKeyDown(key);
			}

            return false;
		}

        private bool Fire_SystemKeyUp(System.Windows.Forms.Keys key)
		{
			if (SystemKeyUp != null)
			{
				return SystemKeyUp(key);
			}

            return false;
		}

	}
}
