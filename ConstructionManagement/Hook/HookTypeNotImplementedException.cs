// /////////////////////////////////////////////////////////////
// File: HookTypeNotImplementedException.cs	 Class: namespace PmSoft.ConstructionManagement.HookPmSoft.Common.CommonClass.Hook.HookTypeNotImplementedException
// Date: 2/25/2004							 Author: Michael Kennedy
// Language: C#								 Framework: .NET
//
// Copyright: Copyright (c) Michael Kennedy, 2004-2005
// /////////////////////////////////////////////////////////////
// License: See License.txt file included with application.
// Description: See compiled documentation (Managed Hooks.chm)
// /////////////////////////////////////////////////////////////

using System;

namespace PmSoft.ConstructionManagement.Hook
{
    /// <include file='ManagedHooks.xml' path='Docs/HookTypeNotImplementedException/Class/*'/>
    public class HookTypeNotImplementedException : ManagedHooksException
	{
		/// <include file='ManagedHooks.xml' path='Docs/ManagedHooksException/ctor/*'/>
		public HookTypeNotImplementedException()
		{
		}

		/// <include file='ManagedHooks.xml' path='Docs/ManagedHooksException/ctor_string/*'/>
		public HookTypeNotImplementedException(string message) : base(message) 
		{
		}

		/// <include file='ManagedHooks.xml' path='Docs/ManagedHooksException/ctor_string_exception/*'/>
		public HookTypeNotImplementedException(string message, Exception innerException) 
			: base(message, innerException) 
		{
		}
	}
}
