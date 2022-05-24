// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.NonStatic.Miscellaneous.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks />
public partial class Config //Non-Static Miscellaneous
{
	#region Properties

	/// <remarks />
	public DateOnly FromDate { get; set; } = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

	/// <remarks />
	public Dictionary<string, string> MediaTypes=new() { { "csv", "CSV-format" }, { "json", "JSON-format" }, { "xml", "XML-format" } };

	/// <remarks />
	public Dictionary<string, string> ParameterDictionary=new();

	/// <remarks />
	public  DateOnly ToDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);

	///<remarks />
	public List<ADUser> UserList { get; set; } = new();

	///<remarks />
	public List<XmEmployment> XmEmploymentList { get; set; } = new();

	#endregion

}
