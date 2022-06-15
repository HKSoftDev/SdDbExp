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

	private AsynchronousClient client;
	private static ManualResetEvent allDone=new(false);

	private const string currentMethod="LogicTier.Bizz";

	#endregion

	#region Constructors

	/// <remarks/>
	public Bizz() { this.client = new(this); }

	#endregion

	#region Properties

	///<remarks />
	public AsynchronousClient Client { get => client; set => client = value; }

	/// <remarks />
	public Config Config { get => config; set => config=value; }

	#endregion

}
