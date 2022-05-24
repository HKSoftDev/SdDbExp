// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="StateObject.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks />
public class StateObject
{

	#region Properties

	/// <remarks />
	public static int BufferSize { get; } = 1024;

	/// <remarks />
	public byte[] Buffer { get; set; } = new byte[BufferSize];

	/// <remarks />
	public StringBuilder Sb { get; set; } = new();

	/// <remarks />
	public Socket? WorkSocket { get; set; }

	#endregion

}
