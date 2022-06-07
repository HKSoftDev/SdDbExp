// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.FieldProps.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Fields and properties
{
	#region Fields

	/// <remarks />
	protected static Config config=new();

	private const string currentMethod="LogicTier.Bizz";

	private static ManualResetEvent allDone=new(false);

	#endregion

	#region Constructors

	/// <remarks/>
	public Bizz() { }

	#endregion

	#region Properties

	/// <remarks />
	public Config Config { get => config; set => config=value; }

	#endregion

}
