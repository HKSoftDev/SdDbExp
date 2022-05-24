// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.NonStatic.Strings.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks />
public partial class Config //Non-static Strings
{

	#region Properties

	#region A

	/// <remarks />
	public string Active { get; set; } = string.Empty;

	/// <remarks />
	public string ActivationDate { get => activationDate; set => SetActivationDate(value); }

	#region API

	/// <remarks />
	public string Api { get; set; } = string.Empty;

	/// <remarks />
	public string ApiDepartmentIdentifier { get; set; } = string.Empty;

	/// <remarks />
	public string ApiEmploymentIdentifier { get; set; } = string.Empty;

	/// <remarks />
	public string ApiInstitutionIdentifier { get; set; } = string.Empty;

	/// <remarks />
	public string ApiJobPositionIdentifier { get; set; } = string.Empty;

	/// <remarks />
	public string ApiOrganizationIdentifier { get; set; } = string.Empty;

	/// <remarks />
	public string ApiOrganizationStructureIdentifier { get; set; } = string.Empty;

	#endregion

	/// <remarks />
	public string AppName { get; } = RetrieveAppName();

	#endregion

	#region D

	/// <remarks />
	public string DataSetPath { get; set; } = string.Empty;

	/// <remarks />
	public string DeactivationDate { get => deactivationDate; set => SetDeactivationDate(value); }

	#endregion

	#region E

	/// <remarks />
	public string EffectiveDate { get => effectiveDate; set => SetActivationDate(value); }

	/// <remarks />
	public string ErrorPath { get; set; } = string.Empty;

	#endregion

	#region F

	/// <remarks />
	public string FilePath { get; set; } = string.Empty;

	/// <remarks />
	public string FileTimeStamp { get; set; } = string.Empty;

	/// <remarks />
	public string FileName { get; set; } = string.Empty;

	/// <remarks />
	public string Format { get; set; } = string.Empty;

	#endregion

	/// <remarks />
	public string InstitutionIdentifier { get => institutionIdentifier; set => SetInstitutionIdentifier(value); }

	#region L

	/// <remarks />
	public string LogFilePath { get; } = Resources.LogsPath+"Log_"+RetrieveAppName()+"_"+DateTime.Now.ToString("s").Replace(":", ".")+@".txt";

	/// <remarks />
	public string LogTimeStamp { get; set; } = string.Empty;

	#endregion

	/// <remarks />
	public string MacAddress { get; private set;}

	#region P

	/// <remarks />
	public string PassWord { get; set; } = string.Empty;

	/// <remarks />
	public string PageData { get; set; } = string.Empty;

	#endregion

	#region R

	/// <remarks />
	public string RequestString { get; set; } = string.Empty;

	/// <remarks />
	public string ResponseString { get; set; } = string.Empty;

	/// <remarks />
	public string Roles { get; set; } = string.Empty;

	/// <remarks />
	public string RunMode { get; set; } = string.Empty;

	#endregion

	#region S

	/// <remarks />
	public string Silo { get; set; } = string.Empty;

	/// <remarks />
	public string SoapResult { get; set; } = string.Empty;

	#endregion

	/// <remarks />
	public string User { get; set; } = string.Empty;

	#region W

	/// <remarks />
	public string WebServiceQueryString { get; set; } = string.Empty;

	/// <remarks />
	public string WebServiceActionUri { get; set; } = string.Empty;

	#endregion

	/// <remarks />
	public string XmlFilePath { get; set; } = string.Empty;

	#endregion

}
