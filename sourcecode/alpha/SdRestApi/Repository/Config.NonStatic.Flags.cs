// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.NonStatic.Flags.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks />
public partial class Config //Non-static Flags
{
	#region Properties

	#region A

	/// <remarks />
	public bool All { get; set; }

	/// <remarks />
	public bool AllDataDeserialized { get; set; }

	/// <remarks />
	public bool AllDataRetrieved { get; set; }

	/// <remarks />
	public bool AllDatabaseUpdated { get; set; }

	/// <remarks />
	public bool AllDepartmentsUpdated { get; set; }

	/// <remarks />
	public bool AllDoubletsRemoved { get; set; }

	/// <remarks />
	public bool AllEmploymentsUpdated { get; set; }

	/// <remarks />
	public bool AllEmploymentsChangedUpdated { get; set; }

	/// <remarks />
	public bool AllEmploymentsChangedAtDateUpdated { get; set; }

	/// <remarks />
	public bool AllInstitutionsUpdated { get; set; }

	/// <remarks />
	public bool AllOrganizationsUpdated { get; set; }

	/// <remarks />
	public bool AllOrganizationStructuresUpdated { get; set; }

	/// <remarks />
	public bool AllPersonsUpdated { get; set; }

	/// <remarks />
	public bool AllPersonsChangedAtDateUpdated { get; set; }

	/// <remarks />
	public bool AllProfessionsUpdated { get; set; }

	/// <remarks />
	public bool AllDataCleaned { get; set; }

	#region API Indicators

	/// <remarks />
	public bool ApiContactInformationIndicator { get; set; }

	/// <remarks />
	public bool ApiDepartmentIndicator { get; set; }

	/// <remarks />
	public bool ApiDepartmentLevelReferenceIndicator { get; set; }

	/// <remarks />
	public bool ApiDepartmentReferenceIndicator { get; set; }

	/// <remarks />
	public bool ApiEmploymentStatusIndicator { get; set; }

	/// <remarks />
	public bool ApiPostalAddressIndicator { get; set; }

	/// <remarks />
	public bool ApiProfessionIndicator { get; set; }

	/// <remarks />
	public bool ApiSalaryAgreementIndicator { get; set; }

	/// <remarks />
	public bool ApiSalaryCodegroupIndicator { get; set; }

	/// <remarks />
	public bool ApiWorkingTimeIndicator { get; set; }

	#endregion

	/// <remarks />
	public bool Authorized { get; set; }

	#endregion

	#region C
	///<remarks />
	public bool CioInfoUpdated { get; set;}

	/// <remarks />
	public bool ContactInformationDoubletsRemoved { get; set; }

	/// <remarks />
	public bool ContentInterpreted { get; set; }

	/// <remarks />
	public bool ContentProcessed { get; set; }

	#endregion

	#region D
	/// <remarks/>
	public bool DataBaseUpdated { get; set; }

	/// <remarks/>
	public bool DataCleaned { get; set; }

	/// <remarks />
	public bool DataDeserialized { get; set; }

	/// <remarks />
	public bool DataRetrieved { get; set; }

	/// <remarks />
	public bool DepartmentDoubletsRemoved { get; set; }

	/// <remarks />
	public bool DepartmentLevelReferenceDoubletsRemoved { get; set; }

	/// <remarks />
	public bool DepartmentReferenceDoubletsRemoved { get; set; }

	/// <remarks />
	public bool DownloadPathDoubletsRemoved { get; set; }

	#endregion

	#region E

	/// <remarks />
	public bool EmploymentDoubletsRemoved { get; set; }

	/// <remarks />
	public bool EmploymentProfessionDoubletsRemoved { get; set; }

	/// <remarks />
	public bool EmploymentStatusDoubletsRemoved { get; set; }

	#endregion

	#region I

	///<remarks />
	public bool InfosUpdated { get; private set;}

	/// <remarks />
	public bool InstitutionDoubletsRemoved { get; set; }

	#endregion

	/// <remarks/>
	public static bool MacAddressSet { get; set; }

	/// <remarks/>
	public bool NewDataRetrieved { get; set; }

	#region O

	/// <remarks/>
	public bool OldDataretrieved { get; set; }

	/// <remarks />
	public bool OrganizationDoubletsRemoved { get; set; }

	/// <remarks />
	public bool OrganizationStructureDoubletsRemoved { get; set; }

	#endregion

	#region P

	/// <remarks />
	public bool PersonDoubletsRemoved { get; set; }

	/// <remarks />
	public bool PostalAddressDoubletsRemoved { get; set; }

	/// <remarks />
	public bool ProfessionDoubletsRemoved { get; set; }

	/// <remarks />
	public bool ProfessionsOptimized { get; set; }

	#endregion

	#region R

	/// <remarks />
	public bool RequestContainsData { get; set; }

	/// <remarks />
	public bool ResponseContainsData { get; set; }

	/// <remarks />
	public bool ResponseSaved { get; set; }

	/// <remarks />
	public bool RunServer { get; set; }

	#endregion

	#region S

	/// <remarks />
	public bool SalaryAgreementDoubletsRemoved { get; set; }

	/// <remarks />
	public bool SalaryCodeGroupDoubletsRemoved { get; set; }

	/// <remarks />
	public bool SomeDepartmentsUpdated { get; set; }

	/// <remarks />
	public bool SomeDoubletsRemoved { get; set; }

	/// <remarks />
	public bool SomeEmploymentsUpdated { get; set; }

	/// <remarks />
	public bool SomeEmploymentsChangedUpdated { get; set; }

	/// <remarks />
	public bool SomeEmploymentsChangedAtDateUpdated { get; set; }

	/// <remarks />
	public bool SomeInstitutionsUpdated { get; set; }

	/// <remarks />
	public bool SomeOrganizationsUpdated { get; set; }

	/// <remarks />
	public bool SomeOrganizationStructuresUpdated { get; set; }

	/// <remarks />
	public bool SomePersonsUpdated { get; set; }

	/// <remarks />
	public bool SomePersonsChangedAtDateUpdated { get; set; }

	/// <remarks />
	public bool SomeProfessionsUpdated { get; set; }

	/// <remarks />
	public bool SuccessfulRunDoubletsRemoved { get; set; }

	#endregion

	#region U
	/// <remarks />
	public bool UnsupportedMedia { get; set; }

	/// <remarks/>
	public bool UpdateError { get; set; }

	/// <remarks />
	public bool UserListSaved { get; set; }

	/// <remarks/>
	public bool UseCachedDownloadList { get; set; }

	/// <remarks />
	public bool Uuid { get; set; }

	#endregion

	#region V
	/// <remarks />
	public bool ValidDates { get; set; }

	/// <remarks/>
	public bool ValidFilePath { get; set; }

	/// <remarks />
	public bool ValidQuery { get; set; }

	/// <remarks />
	public bool ValidRequest { get; set; }

	/// <remarks />
	public bool ValidResponse { get; set; }

	/// <remarks />
	public bool ValidSdApi { get; set; }

	#endregion

	/// <remarks />
	public bool WorkingTimeDoubletsRemoved { get; set; }

	#region X
	/// <remarks/>
	public bool XmlDataDeserialized { get; set; }

	/// <remarks/>
	public bool XmlDataRetrieved { get; set; }

	/// <remarks />
	public bool XmListSaved { get; set; }

	/// <remarks />
	public bool XmRetrieved { get; set; }

	#endregion

	#endregion

}
