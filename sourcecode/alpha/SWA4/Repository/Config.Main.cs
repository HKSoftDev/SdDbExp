// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.Main.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks />
public partial class Config // Main
{
	#region Constructors
	/// <summary>Initializes an empty instance of Config</summary>
	public Config() { this.MacAddress=RetrieveMacAddress(); }

	/// <summary>Initializes an instance of Config, that accepts data from an existing Config</summary><param name="config" />
	public Config(Config config) { this.MacAddress=RetrieveMacAddress(); FillFieldProps(config); }

	#endregion

	#region Methods

	/// <returns>Result as bool</returns><param name="s">'HB', 'HI', or'HW'</param>
	public static bool CheckInstitutionIdentifier(string s) { if (string.IsNullOrWhiteSpace(s)) return false;  foreach (string item in InstitutionIdentifierList) if (item.Equals(s)) return true; return false; }

	#region Reset Error Flags

	/// <summary>Resets DataRetrieved</summary><exception cref="NullReferenceException" />
	public void ResetDepartmentErrorFlags() { if (!DataRetrieved) DataRetrieved=true; if (!SomeDepartmentsUpdated) SomeDepartmentsUpdated=true; }

	/// <summary>Resets DataRetrieved</summary><exception cref="NullReferenceException" />
	public void ResetEmploymentErrorFlags() { if (!DataRetrieved) DataRetrieved=true; if (!SomeEmploymentsUpdated) SomeEmploymentsUpdated=true; }

	/// <summary>Resets DataRetrieved</summary><exception cref="NullReferenceException" />
	public void ResetEmploymentChangedErrorFlags() { if (!DataRetrieved) DataRetrieved=true; if (!SomeEmploymentsChangedUpdated) SomeEmploymentsChangedUpdated=true; }

	/// <summary>Resets DataRetrieved</summary><exception cref="NullReferenceException" />
	public void ResetEmploymentChangedAtDateErrorFlags() { if (!DataRetrieved) DataRetrieved=true; if (!SomeEmploymentsChangedAtDateUpdated) SomeEmploymentsChangedAtDateUpdated=true; }

	/// <summary>Resets DataRetrieved</summary><exception cref="NullReferenceException" />
	public void ResetInstitutionErrorFlags() { if (!DataRetrieved) DataRetrieved=true; if (!SomeInstitutionsUpdated) SomeInstitutionsUpdated=true; }

	/// <summary>Resets DataRetrieved</summary><exception cref="NullReferenceException" />
	public void ResetOrganizationErrorFlags() { if (!DataRetrieved) DataRetrieved=true; if (!SomeOrganizationsUpdated) SomeOrganizationsUpdated=true; }

	/// <summary>Resets DataRetrieved</summary><exception cref="NullReferenceException" />
	public void ResetOrganizationStructureErrorFlags() { if (!DataRetrieved) DataRetrieved=true; if (!SomeOrganizationStructuresUpdated) SomeOrganizationStructuresUpdated=true; }

	/// <summary>Resets DataRetrieved</summary><exception cref="NullReferenceException" />
	public void ResetPersonErrorFlags() { if (!DataRetrieved) DataRetrieved=true; if (!SomePersonsUpdated) SomePersonsUpdated=true; }

	/// <summary>Resets DataRetrieved</summary><exception cref="NullReferenceException" />
	public void ResetPersonChangedAtDateErrorFlags() { if (!DataRetrieved) DataRetrieved=true; if (!SomePersonsChangedAtDateUpdated) SomePersonsChangedAtDateUpdated=true; }

	/// <summary>Resets DataRetrieved</summary><exception cref="NullReferenceException" />
	public void ResetProfessionErrorFlags() { if (!DataRetrieved) DataRetrieved=true; if (!SomeProfessionsUpdated) SomeProfessionsUpdated=true; }

	#endregion

	/// <remarks/>
	public bool SdApiIsValid(string sdApi) { if (string.IsNullOrWhiteSpace(RunMode)) return false; return AppName.ToLower() switch{ "clonedependencydata" => Array.Exists(ValidSdApisDependencyDataClone,
		element => element == sdApi), "clonepersondata" => Array.Exists(ValidSdApisPersonDataUpdate,element => element == sdApi), "updatedependencydata" => Array.Exists(ValidSdApisDependencyDataUpdate,
		element => element == sdApi), "updatepersondata" => Array.Exists(ValidSdApisPersonDataUpdate,element => element == sdApi), _ => false }; }

	#region Set

	/// <summary>Sets WebServiceActionUri</summary><param name="sdApi" />
	public void SetActionUri(string sdApi) { this.WebServiceActionUri=sdApi.ToLower() switch { "getdepartment" => Resources.WebServiceUri+GetDepartmentAction, "getemployment" => Resources.WebServiceUri+GetEmploymentAction,
			"getemploymentchanged" => Resources.WebServiceUri+GetEmploymentChangedAction, "getemploymentchangedatdate" => Resources.WebServiceUri+GetEmploymentChangedAtDateAction,
			"getinstitution" => Resources.WebServiceUri+GetInstitutionAction, "getorganization" => Resources.WebServiceUri+GetOrganizationAction, "getperson" => Resources.WebServiceUri+GetPersonAction,
			"getpersonchangedatdate" => Resources.WebServiceUri+GetPersonChangedAtDateAction, "getprofession" => Resources.WebServiceUri+GetProfessionAction,
			_ => throw new ArgumentInvalidException(nameof(sdApi),sdApi,nameof(sdApi)+Error.UnkAPI), }; }

	/// <summary>Set FromDate and ToDate for full cloning</summary><param name="sdApi" /><exception cref="NullReferenceException" />
	public void SetDatesClone(string sdApi) { if (this==null) throw new NullReferenceException(); switch (sdApi.ToLower()) { case "getdepartment": SetQueryDates(FromDate,ToDate); break; case "getemployment": ValidDates=true; break;
		case "getinstitution": ValidDates=true; break; case "getorganization": SetQueryDates(FromDate, ToDate); break; case "getperson": ValidDates=true; break; case "getprofession": ValidDates=true; break; } }

	/// <summary>Set FromDate and ToDate for daily updates</summary><param name="sdApi" /><exception cref="NullReferenceException" />
	public void SetDatesDaily(string sdApi) { if (this==null) throw new NullReferenceException(); switch (sdApi.ToLower()) { case "getemploymentchanged": SetQueryDates(FromDate, ToDate); break;
		case "getemploymentchangedatdate": SetQueryDates(FromDate, ToDate); break; case "getpersonchangedatdate": SetQueryDates(FromDate, ToDate); break; } }

	/// <summary>Set from and to dates for the occasional updates</summary><param name="sdApi" /><exception cref="NullReferenceException" />
	public void SetDatesOccasionally(string sdApi) { if (this==null) throw new NullReferenceException(); switch (sdApi.ToLower()) { case "getdepartment": SetQueryDates(Yesterday, Today); break;
		case "getinstitution": ValidDates=true; break; case "getorganization": SetQueryDates(Today, Today); break; case "getprofession": ValidDates=true; break; } }

	#region Set Error Flags

	/// <summary>Sets UpdateError, DataRetrieved, and AllDataRetrieved</summary><exception cref="NullReferenceException" />
	public void SetDepartmentErrorFlags() { if (this==null) throw new NullReferenceException(); if (!UpdateError) UpdateError=true; if (DataRetrieved) DataRetrieved=false;
	if (AllDepartmentsUpdated) AllDepartmentsUpdated=false; if (AllDataRetrieved) AllDataRetrieved=false; }

	/// <summary>Sets UpdateError, DataRetrieved, and AllDataRetrieved</summary><exception cref="NullReferenceException" />
	public void SetEmploymentErrorFlags() { if (this==null) throw new NullReferenceException(); if (!UpdateError) UpdateError=true; if (DataRetrieved) DataRetrieved=false;
		if (AllEmploymentsUpdated) AllEmploymentsUpdated=false; if (AllDataRetrieved) AllDataRetrieved=false; }

	/// <summary>Sets UpdateError, DataRetrieved, and AllDataRetrieved</summary><exception cref="NullReferenceException" />
	public void SetEmploymentChangedErrorFlags() { if (this==null) throw new NullReferenceException(); if (!UpdateError) UpdateError=true; if (DataRetrieved) DataRetrieved=false;
		if (AllEmploymentsChangedUpdated) AllEmploymentsChangedUpdated=false; if (AllDataRetrieved) AllDataRetrieved=false; }

	/// <summary>Sets UpdateError, DataRetrieved, and AllDataRetrieved</summary><exception cref="NullReferenceException" />
	public void SetEmploymentChangedAtDateErrorFlags() { if (this==null) throw new NullReferenceException(); if (!UpdateError) UpdateError=true; if (DataRetrieved) DataRetrieved=false;
		if (AllEmploymentsChangedAtDateUpdated) AllEmploymentsChangedAtDateUpdated=false; if (AllDataRetrieved) AllDataRetrieved=false; }

	/// <summary>Sets UpdateError, DataRetrieved, and AllDataRetrieved</summary><exception cref="NullReferenceException" />
	public void SetErrorFlags() { if (this==null) throw new NullReferenceException(); if (!UpdateError) UpdateError=true; if (DataRetrieved) DataRetrieved=false; if (AllDataRetrieved) AllDataRetrieved=false; }

	/// <summary>Sets UpdateError, DataRetrieved, and AllDataRetrieved</summary><exception cref="NullReferenceException" />
	public void SetInstitutionErrorFlags() { if (this==null) throw new NullReferenceException(); if (!UpdateError) UpdateError=true; if (DataRetrieved) DataRetrieved=false;
		if (AllInstitutionsUpdated) AllInstitutionsUpdated=false; if (AllDataRetrieved) AllDataRetrieved=false; }

	/// <summary>Sets UpdateError, DataRetrieved, and AllDataRetrieved</summary><exception cref="NullReferenceException" />
	public void SetOrganizationErrorFlags() { if (this==null) throw new NullReferenceException(); if (!UpdateError) UpdateError=true;
		if (AllOrganizationsUpdated) AllOrganizationsUpdated=false; if (DataRetrieved) DataRetrieved=false; if (AllDataRetrieved) AllDataRetrieved=false; }

	/// <summary>Sets UpdateError, DataRetrieved, and AllDataRetrieved</summary><exception cref="NullReferenceException" />
	public void SetOrganizationStructureErrorFlags() { if (this==null) throw new NullReferenceException(); if (!UpdateError) UpdateError=true; if (DataRetrieved) DataRetrieved=false;
		if (AllOrganizationStructuresUpdated) AllOrganizationStructuresUpdated=false; if (AllDataRetrieved) AllDataRetrieved=false; }

	/// <summary>Sets UpdateError, DataRetrieved, and AllDataRetrieved</summary><exception cref="NullReferenceException" />
	public void SetPersonErrorFlags() { if (this==null) throw new NullReferenceException(); if (!UpdateError) UpdateError=true; if (DataRetrieved) DataRetrieved=false;
		if (AllPersonsUpdated) AllPersonsUpdated=false; if (AllDataRetrieved) AllDataRetrieved=false; }

	/// <summary>Sets UpdateError, DataRetrieved, and AllDataRetrieved</summary><exception cref="NullReferenceException" />
	public void SetPersonChangedAtDateErrorFlags() { if (this==null) throw new NullReferenceException(); if (!UpdateError) UpdateError=true; if (DataRetrieved) DataRetrieved=false;
		if (AllPersonsChangedAtDateUpdated) AllPersonsChangedAtDateUpdated=false; if (AllDataRetrieved) AllDataRetrieved=false; }

	/// <summary>Sets UpdateError, DataRetrieved, and AllDataRetrieved</summary><exception cref="NullReferenceException" />
	public void SetProfessionErrorFlags() { if (this==null) throw new NullReferenceException(); if (!UpdateError) UpdateError=true; if (DataRetrieved) DataRetrieved=false;
		if (AllProfessionsUpdated) AllProfessionsUpdated=false; if (AllDataRetrieved) AllDataRetrieved=false; }

	#endregion

	#endregion

	#region Protected

	/// <returns>date with hyphens as string</returns><param name="date" />
	protected static string AddHyphensToStringDate(string date) { string result = string.Empty; int i = 0; string tempDate = string.Empty;
		foreach (char character in date) { tempDate+=character; if (i.Equals(3)||i.Equals(5)) tempDate+="-"; i++; } return result; }

	/// <returns>Result as bool</returns><param name="target">'log' or 'console'</param>
	protected static bool CheckTarget(string target) { foreach (string item in TargetList) { if (target==item) return true; } return false; }

	/// <returns>AppName as string</returns>
	protected static string RetrieveAppName() { string result = AppDomain.CurrentDomain.FriendlyName; while (result.Contains(Convert.ToChar("_"))) { result=result.Remove(result.IndexOf('_')); }
		while (result.Contains(Convert.ToChar("."))) { result=result.Remove(result.IndexOf('.')); } return result; }

	/// <returns>Result as bool</returns><param name="sdApi" />
	protected bool CheckSdApi(string sdApi) { if (this==null) throw new NullReferenceException(); if (string.IsNullOrWhiteSpace(sdApi)) foreach (string api in SdApiList) if (api.Equals(sdApi)) return true; return false; }

	/// <returns>Validated date as string</returns><param name="date" /><param name="deactDate" />
	protected DateOnly CheckDate(DateOnly date, bool deactDate = false) { if (date.Equals(DateOnly.Parse("2010-01-01"))||date.Equals(DateOnly.Parse("9999-12-31"))) { if (deactDate) return Tomorrow; else return OldDate; } else return date; }

	/// <summary>Adds data from <paramref name="config"/> to this Config</summary><param name="config" />
	protected void FillFieldProps(Config config) { this.InstitutionIdentifier=config.InstitutionIdentifier; this.ActivationDate=config.ActivationDate; this.DeactivationDate=config.DeactivationDate;
		effectiveDate=config.EffectiveDate; this.FromDate=config.FromDate; this.ToDate=config.ToDate; this.UserList=new(config.UserList); this.DataSetPath=config.DataSetPath; this.ErrorPath=config.ErrorPath;
		this.FilePath=config.FilePath; this.FileTimeStamp=config.FileTimeStamp; this.LogTimeStamp=config.LogTimeStamp; this.All=config.All; this.AllDatabaseUpdated=config.AllDatabaseUpdated; 
		this.AllDataCleaned=config.AllDataCleaned; this.AllDataDeserialized=config.AllDataDeserialized; this.AllDataRetrieved=config.AllDataRetrieved; this.Authorized=config.Authorized;
		this.CioInfoUpdated=config.CioInfoUpdated; this.ContentInterpreted=config.ContentInterpreted; this.ContentProcessed=config.ContentProcessed; this.DataBaseUpdated=config.DataBaseUpdated;
		this.DataCleaned=config.DataCleaned; this.DataDeserialized=config.DataDeserialized; this.DataRetrieved=config.DataRetrieved; this.InfosUpdated=config.InfosUpdated; this.NewDataRetrieved=config.NewDataRetrieved;
		this.OldDataretrieved=config.OldDataretrieved; this.RequestContainsData=config.RequestContainsData; this.ResponseContainsData=config.ResponseContainsData; this.ResponseSaved=config.ResponseSaved;
		this.UnsupportedMedia=config.UnsupportedMedia; this.UpdateError=config.UpdateError; this.UseCachedDownloadList=config.UseCachedDownloadList; this.Uuid=config.Uuid; this.ValidDates=config.ValidDates;
		this.ValidFilePath=config.ValidFilePath; this.ValidQuery=config.ValidQuery; this.ValidRequest=config.ValidRequest; this.ValidResponse=config.ValidResponse; this.ValidSdApi=config.ValidSdApi;
		this.XmlDataDeserialized=config.XmlDataDeserialized; this.XmlDataRetrieved=config.XmlDataRetrieved; this.XmRetrieved=config.XmRetrieved; this.Active=config.Active; this.Api=config.Api;
		this.FileName=config.FileName; this.Format=config.Format; this.RequestString=config.RequestString; this.ResponseString=config.ResponseString; this.RunMode=config.RunMode; this.Silo=config.Silo;
		this.WebServiceQueryString=config.WebServiceQueryString; this.WebServiceActionUri=config.WebServiceActionUri; }

	/// <summary>Retrieves MacAddress of this environment</summary>
	protected string RetrieveMacAddress() { try { return NetworkInterface.GetAllNetworkInterfaces().Where(nic => nic.OperationalStatus==OperationalStatus.Up&&nic.NetworkInterfaceType!=
		NetworkInterfaceType.Loopback).Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault()??string.Empty; } catch (Exception ex) {
			Console.WriteLine(ExpressionException.ToErrorString(ex)); MacAddressSet=false; return string.Empty; } }

	/// <summary>Set ActivationDate</summary>
	protected void SetActivationDate(string date) { activationDate=activationDateBase+date; }

	/// <summary>Set DeactivationDate</summary>
	protected void SetDeactivationDate(string date) { deactivationDate=deactivationDateBase+date; }

	/// <summary>Set EffectiveDate</summary><exception cref="ArgumentInvalidException" />
	protected void SetEffectiveDate(DateOnly date) { effectiveDate=effectiveDateBase+date.ToString("yyyy-MM-dd"); }

	/// <summary>Set InstitutionIdentifier</summary><exception cref="ArgumentInvalidException" />
	protected void SetInstitutionIdentifier(string institutionId) { if (!CheckInstitutionIdentifier(institutionId)) throw new ArgumentInvalidException(nameof(institutionId),institutionId,
		institutionId+Error.InvId); else institutionIdentifier=institutionIdentifierBase+institutionId; }

	/// <summary>Sets ActivationDate and DeactivationDate</summary><param name="fromDate" /><param name="toDate" />
	protected void SetQueryDates(DateOnly fromDate, DateOnly toDate) { try { FromDate=fromDate; ToDate=toDate; ActivationDate=activationDateBase+FromDate.ToString("yyyy-MM-dd"); DeactivationDate=deactivationDateBase+ToDate.ToString("yyyy-MM-dd"); ValidDates=true; } catch (Exception) { ValidDates=false; } }

	/// <summary>Sets InstitutionIdentifier for SOAP</summary><param name="sdApi" /><param name="institutionId" />
	protected void SetQueryInstitutionIdentifier(string sdApi,string institutionId) { if (sdApi=="GetInstitution") InstitutionIdentifier="&"+institutionIdentifierBase+institutionId; else InstitutionIdentifier=institutionIdentifierBase+institutionId; }

	#endregion

	#endregion

}
