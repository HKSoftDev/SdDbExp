// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.NonStatic.Miscellaneous.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using ApiRepository;

namespace Repository;

/// <remarks />
public partial class Config //Non-Static Miscellaneous
{
	#region Properties

	/// <remarks />
	public int ExitCode { get; set;} = 0;

	///<remarks />
	public List<ADUser> UserList { get; set; } = new();

	///<remarks />
	public List<XmEmployment> XmEmploymentList { get; set; } = new();

	#endregion

}
