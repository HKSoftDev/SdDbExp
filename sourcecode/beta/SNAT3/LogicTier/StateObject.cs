// Copyright (c) Daniel Giversen. All Rights reserved.
// Copyright (c) Haderslev Kommune. All Rights reserved.
// Licenced under Proprietary License. See License.txt
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;

namespace LogicTier
{
	/// <remarks />  
	public class StateObject
	{
		#region Fields
		// Size of receive buffer.  
		private const int bufferSize = 256;

		#endregion

		#region Constructors
		/// <summary>
		/// Initiates an instance of <see cref="StateObject"/>.
		/// </summary>
		public StateObject() { }

		#endregion

		#region Properties
		/// <remarks />  
		public Socket WorkSocket { get; set; }
		// Size of receive buffer.  

		/// <remarks />  
		public static int BufferSize { get => bufferSize; }
		// Receive buffer.  

		/// <remarks />  
		public byte[] Buffer { get; set; } = new byte[BufferSize];
		// Received data string.  

		/// <remarks />  
		public StringBuilder Sb { get; set; } = new StringBuilder();

		#endregion

	}
}
