// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="StateObject.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
using System.Net.Sockets;

namespace LogicTier;

/// <remarks />
public class StateObject
{
	#region Constructors
	/// <summary>Initializes an instance of StateObject</summary>
	public StateObject() { }

	#endregion

	#region Properties
	/// <remarks />
	public byte[] Buffer { get; set; } = new byte[BufferSize];

	/// <remarks />
	public static int BufferSize { get; } = 1024;

	/// <remarks />
	public StringBuilder Sb { get; set; } = new();

	/// <remarks />
	public Socket? WorkSocket { get; set; }

	#endregion

}
