// Copyright (c) Gywerd. All Rights reserved.
// Copyright (c) Haderslev Kommune. All Rights reserved.
// Licenced under Proprietary License. See License.txt

namespace Repository;

/// <remarks />
public class Dictionaries
{
	#region Properties

	/// <remarks/>
	public Dictionary<string,DepartmentLevelReference> TempBasicDepartmentLevelReferenceDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,DepartmentReference> TempBasicDepartmentReferenceDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,ContactInformation> TempContactInformationDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,Department> TempDepartmentDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,DepartmentLevelReference> TempDepartmentLevelReferenceDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,DepartmentReference> TempDepartmentReferenceDict { get; set; } = new();

	/// <remarks />
	public Dictionary<string, DownloadPath> TempDownloadPathDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,Employment> TempEmploymentDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,EmploymentStatus> TempEmploymentStatusDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,Institution> TempInstitutionDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,DepartmentLevelReference> TempLevel1DepartmentLevelReferenceDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,DepartmentLevelReference> TempLevel2DepartmentLevelReferenceDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,DepartmentLevelReference> TempLevel3DepartmentLevelReferenceDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,DepartmentLevelReference> TempLevel4DepartmentLevelReferenceDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,DepartmentLevelReference> TempLevel5DepartmentLevelReferenceDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,DepartmentReference> TempLevel1DepartmentReferenceDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,DepartmentReference> TempLevel2DepartmentReferenceDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,DepartmentReference> TempLevel3DepartmentReferenceDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,DepartmentReference> TempLevel4DepartmentReferenceDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,DepartmentReference> TempLevel5DepartmentReferenceDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,Organization> TempOrganizationDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,OrganizationStructure> TempOrganizationStructureDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,Person> TempPersonDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,PostalAddress> TempPostalAddressDict { get; set; } = new();
	/// <remarks/>
	public Dictionary<string,Profession> TempProfessionDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,SalaryAgreement> TempSalaryAgreementDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,SalaryCodeGroup> TempSalaryCodeGroupDict { get; set; } = new();

	/// <remarks />
	public Dictionary<int, SuccessfulRun> TempSuccessfulRunDict { get; set; } = new();

	/// <remarks/>
	public Dictionary<string,WorkingTime> TempWorkingTimeDict { get; set; } = new();

	#endregion

}
