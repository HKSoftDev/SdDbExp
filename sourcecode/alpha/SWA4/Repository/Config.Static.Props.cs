// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.Static.Props.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks />
public partial class Config //Static Properties
{
	#region Fields

	private static string activationDate=DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"), deactivationDate=DateTime.Today.ToString("yyyy-MM-dd"), effectiveDate = @"&EffectiveDate="+DateTime.Today.ToString("yyyy-MM-dd"), institutionIdentifier=institutionIdentifierBase+"NO";

	#endregion

	#region Properties

	/// <remarks />
	public static string ConnectionString { get; } = Resources.ConnectionString;

	/// <remarks />
	public static DateOnly FutureDate { get; } = DateOnly.Parse(Resources.FutureDate);

	#region G

	/// <remarks />
	public static string GetDepartmentAction { get; } = Resources.GetDepartmentAction;

	/// <remarks />
	public static string GetEmploymentAction { get; } = Resources.GetEmploymentAction;

	/// <remarks />
	public static string GetEmploymentChangedAction { get; } = Resources.GetEmploymentChangedAction;

	/// <remarks />
	public static string GetEmploymentChangedAtDateAction { get; } = Resources.GetEmploymentChangedAtDateAction;

	/// <remarks />
	public static string GetInstitutionAction { get; } = Resources.GetInstitutionAction;

	/// <remarks />
	public static string GetOrganizationAction { get; } = Resources.GetOrganizationAction;

	/// <remarks />
	public static string GetPersonAction { get; } = Resources.GetPersonAction;

	/// <remarks />
	public static string GetPersonChangedAtDateAction { get; } = Resources.GetPersonChangedAtDateAction;

	/// <remarks />
	public static string GetProfessionAction { get; } = Resources.GetProfessionAction;

	#endregion

	/// <remarks/>
	public static List<string> InstitutionIdentifierList { get; } = new List<string> { "HB", "HI", "HW" };

	/// <remarks />
	public static DateOnly OldDate { get; } = DateOnly.Parse(Resources.OldDate);

	/// <remarks />
	public static DateOnly OneMonthAgo { get; } = DateOnly.FromDateTime(DateTime.Today.AddDays(-30));

	/// <remarks />
	public static List<string> SdApiList { get; } = new() { "GetDepartment", "GetEmployment", "GetEmploymentChanged", "GetEmploymentChangedAtDate", "GetInstitution", "GetOrganization", "GetPerson", "GetPersonChangedAtDate", "GetProfession" };

	#region T

	/// <remarks />
	public static List<string> TargetList = new() { "log", "console" };

	/// <remarks />
	public static DateOnly Today { get; } = DateOnly.FromDateTime(DateTime.Today);

	/// <remarks />
	public static DateOnly Tomorrow { get; } = DateOnly.FromDateTime(DateTime.Today.AddDays(1));

	/// <remarks />
	public static DateOnly TwelweMonthsAgo { get; } = DateOnly.FromDateTime(DateTime.Today.AddMonths(-12));

	#endregion

	/// <remarks />
	public static string UserName { get; } = Environment.UserName;

	#region V

	/// <remarks />
	public static string[] ValidSdApisDependencyDataClone = { "GetDepartment","GetInstitution", "GetOrganization", "GetProfession" };

	/// <remarks />
	public static string[] ValidSdApisDependencyDataUpdate = { "GetDepartment","GetInstitution", "GetOrganization", "GetProfession" };

	/// <remarks />
	public static string[] ValidSdApisPersonDataClone = { "GetEmployment","GetEmploymentChanged","GetPerson" };

	/// <remarks />
	public static string[] ValidSdApisPersonDataUpdate = { "GetEmploymentChangedAtDate","GetPersonChangedAtDate" };

	#endregion

	/// <remarks />
	public static string WorkingDirectoryPath { get; } = Directory.GetCurrentDirectory();

	/// <remarks />
	public static DateOnly Yesterday { get; } = DateOnly.FromDateTime(DateTime.Today.AddDays(-1));

	#endregion

}
