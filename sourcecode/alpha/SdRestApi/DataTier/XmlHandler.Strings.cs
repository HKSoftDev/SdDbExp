// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlHandler.Strings.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace DataTier;

/// <remarks />
public partial class XmlHandler // Strings
{
	#region Properties

	/// <remarks />
	public static string AMonthAgo { get; set; } = DateTime.Today.AddDays(-30).ToString("yyyy-MM-dd");

	/// <remarks />
	public static string AYearAgo { get; set; } = DateTime.Today.AddYears(-1).ToString("yyyy-MM-dd");

	/// <remarks />
	public static string FiveYearsAgo { get; set; } = DateTime.Today.AddYears(-5).ToString("yyyy-MM-dd");

	/// <remarks />
	public static string FromDate { get; set; } = DateTime.Today.AddSeconds(-1).ToString("yyyy-MM-dd");

	/// <remarks />
	public static string RequestStructureEndTag => Resources.RequestStructureEndTag+Environment.NewLine;

	/// <remarks />
	public static string RequestStructureTag => Resources.RequestStructureBaseTag+Environment.NewLine;

	/// <remarks />
	public static string ToDate { get; set; } = DateTime.Today.ToString("yyyy-MM-dd");

	/// <remarks />
	public static string Today { get; set; } = DateTime.Today.ToString("yyyy-MM-dd");

	/// <remarks />
	public static bool ValidDates { get; set; }

	/// <remarks />
	public static string Yesterday { get; set; } = DateTime.Today.AddSeconds(-1).ToString("yyyy-MM-dd");

	#region Private

	private static string GetDepartmentEndTag => Resources.GetDepartmentEndTag+Environment.NewLine;
	private static string GetDepartmentTag => Resources.GetDepartmentBaseTag+Environment.NewLine;
	private static string GetEmploymentChangedAtDateEndTag => Resources.GetEmploymentChangedAtDateEndTag+Environment.NewLine;
	private static string GetEmploymentChangedAtDateTag => Resources.GetEmploymentChangedAtDateBaseTag+Environment.NewLine;
	private static string GetEmploymentChangedEndTag => Resources.GetEmploymentChangedEndTag+Environment.NewLine;
	private static string GetEmploymentChangedTag => Resources.GetEmploymentChangedBaseTag+Environment.NewLine;
	private static string GetEmploymentEndTag => Resources.GetEmploymentEndTag+Environment.NewLine;
	private static string GetEmploymentTag => Resources.GetEmploymentBaseTag+Environment.NewLine;
	private static string GetInstitutionEndTag => Resources.GetInstitutionEndTag+Environment.NewLine;
	private static string GetInstitutionTag => Resources.GetInstitutionBaseTag+Environment.NewLine;
	private static string GetOrganizationEndTag => Resources.GetOrganizationEndTag+Environment.NewLine;
	private static string GetOrganizationTag => Resources.GetOrganizationBaseTag+Environment.NewLine;
	private static string GetPersonChangedAtDateEndTag => Resources.GetPersonChangedAtDateEndTag+Environment.NewLine;
	private static string GetPersonChangedAtDateTag => Resources.GetPersonChangedAtDateBaseTag+Environment.NewLine;
	private static string GetPersonEndTag => Resources.GetPersonEndTag+Environment.NewLine;
	private static string GetPersonTag => Resources.GetPersonTag+Environment.NewLine;
	private static string GetProfessionEndTag => Resources.GetProfessionEndTag+Environment.NewLine;
	private static string GetProfessionTag => Resources.GetProfessionBaseTag+Environment.NewLine;

	#endregion

	#endregion

}
