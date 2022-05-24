// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="XmHandler.Main.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace DataTier;

/// <remarks />
public partial class XmlHandler // Main
{
	#region Methods

	/// <returns>Requested Url as string</returns><param name="fromDate" /><param name="institution" /><param name="sdApi" />
	public static string RetrieveActionUrl(string fromDate,string institution,string sdApi) => sdApi switch {
		"GetDepartment" => Resources.GetDepartment20111201ActionUriBase+institution+@"&ActivationDate="+fromDate+Resources.GetDepartment20111201ActionUriEnd,
		"GetEmployment" => Resources.GetEmployment20111201ActionUriBase+institution+@"&EffectiveDate="+DateTime.Today.ToString("yyyy-MM-dd")+Resources.GetEmployment20111201ActionUriEnd,
		"GetEmploymentChanged" => Resources.GetEmploymentChanged20111201ActionUriBase+institution+@"&ActivationDate="+fromDate+Resources.GetEmploymentChanged20111201ActionUriEnd,
		"GetEmploymentChangedAtDate" => Resources.GetEmploymentChangedAtDate20111201ActionUriBase+institution+@"&ActivationDate="+fromDate+Resources.GetEmploymentChangedAtDate20111201ActionUriEnd,
		"GetInstitution" => Resources.GetInstitution20111201ActionUri, "GetOrganization" => Resources.GetOrganization20111201ActionUriBase+institution+@"&ActivationDate="+fromDate+Resources.GetOrganization20111201ActionUriEnd,
		"GetPerson" => Resources.GetPerson20111201ActionUriBase+institution+@"&EffectiveDate="+DateTime.Today.ToString("yyyy-MM-dd")+Resources.GetPerson20111201ActionUriEnd,
		"GetPersonChangedAtDate" => Resources.GetPersonChangedAtDate20111201ActionUriBase+institution+@"&ActivationDate="+fromDate+Resources.GetPersonChangedAtDate20111201ActionUriEnd,
		"GetProfession" => Resources.GetProfession20080201ActionUriBase+institution+Resources.GetProfession20080201ActionUriEnd,_ => throw new ArgumentInvalidException(nameof(sdApi),sdApi,nameof(sdApi)+Error.UnkAPI), };

	/// <returns>SOAP request for Config.CurrentSdApi and Config.CurrentInstitytionIdentifier as string</returns><param name="institutionId" /><param name="sdApi" /><exception cref="ArgumentEmptyException" /><exception cref="ArgumentInvalidException" />
	public static string RetrieveSoapRequestString(string institutionId,string sdApi)
	{
		if (string.IsNullOrWhiteSpace(institutionId)) throw new ArgumentEmptyException(nameof(institutionId),nameof(institutionId)+Error.CantBeEmpty);
		if (string.IsNullOrWhiteSpace(sdApi)) throw new ArgumentEmptyException(nameof(sdApi),nameof(sdApi)+Error.CantBeEmpty);
		if (!sdApi.Equals("GetInstitution")) SetInstitutionIdentifier(institutionId); SetQueryDates(sdApi);
		return sdApi switch { "GetDepartment" => RetrieveGetDepartmentSoapRequest(), "GetEmployment" => RetrieveGetEmploymentSoapRequest(),
			"GetEmploymentChanged" => RetrieveGetEmploymentChangedSoapRequest(), "GetEmploymentChangedAtDate" => RetrieveGetEmploymentChangedAtDateSoapRequest(),
			"GetInstitution" => RetrieveGetInstitutionSoapRequest(), "GetOrganization" => RetrieveGetOrganisationSoapRequest(), "GetPerson" => RetrieveGetPersonSoapRequest(),
			"GetPersonChangedAtDate" => RetrieveGetPersonChangedAtDateSoapRequest(), "GetProfession" => RetrieveGetProfessionSoapRequest(),
			_ => throw new ArgumentInvalidException(nameof(sdApi),sdApi,nameof(sdApi)+Error.UnkAPI) }; }

	#region Private

	/// <summary>Checks wether FromDate and ToDate are valid</summary>
	private static void CheckFromDateAndToDate() { if (!DateTime.TryParse(FromDate,out DateTime fDate)||!DateTime.TryParse(ToDate,out DateTime tDate)) ValidDates=false; else ValidDates=true; }

	#region Retrieve

	/// <summary>Returns a SOAP request string for GetDepartment API</summary>
	private static string RetrieveGetDepartmentSoapRequest() => XmlHeader+GetDepartmentTag+InstitutionIdentifierLine+InstitutionUuidIdentifierLine+ActivationDateLine+DeactivationDateLine+ContactInformationIndicatorLine+DepartmentNameIndicatorLine+EmploymentDepartmentIndicatorLine+PostalAddressIndicatorLine+ProductionUnitIndicatorLine+UuidIndicatorLine+GetDepartmentEndTag+XmlFooter;

	/// <summary>Returns a SOAP request string for GetEmploymentChangedAtDate API</summary>
	private static string RetrieveGetEmploymentChangedAtDateSoapRequest() => XmlHeader+GetEmploymentChangedAtDateTag+InstitutionIdentifierLine+ActivationDateLine+ActivationTimeLine+DeactivationDateLine+DeactivationTimeLine+DepartmentIndicatorLine+EmploymentStatusIndicatorLine+ProfessionIndicatorLine+SalaryAgreementIndicatorLine+SalaryCodeGroupIndicatorLine+WorkingTimeIndicatorLine+UuidIndicatorLine+FutureInformationIndicatorLine+GetEmploymentChangedAtDateEndTag+XmlFooter;

	/// <summary>Returns a SOAP request string for GetEmploymentChanged API</summary>
	private static string RetrieveGetEmploymentChangedSoapRequest() =>XmlHeader+GetEmploymentChangedTag+InstitutionIdentifierLine+ActivationDateLine+DeactivationDateLine+DepartmentIndicatorLine+EmploymentStatusIndicatorLine+ProfessionIndicatorLine+SalaryAgreementIndicatorLine+SalaryCodeGroupIndicatorLine+WorkingTimeIndicatorLine+UuidIndicatorLine+GetEmploymentChangedEndTag+XmlFooter;

	/// <summary>Returns a SOAP request string for GetDepartment API</summary>
	private static string RetrieveGetEmploymentSoapRequest() => XmlHeader+GetEmploymentTag+InstitutionIdentifierLine+EffectiveDateLine+StatusActiveIndicatorLine+StatusPassiveIndicatorLine+DepartmentIndicatorLine+EmploymentStatusIndicatorLine+ProfessionIndicatorLine+SalaryAgreementIndicatorLine+SalaryCodeGroupIndicatorLine+WorkingTimeIndicatorLine+UuidIndicatorLine+GetEmploymentEndTag+XmlFooter;

	/// <summary>Returns a SOAP request string for GetInstitution API</summary>
	private static string RetrieveGetInstitutionSoapRequest() => XmlHeader+GetInstitutionTag+RegionIdentifierLine+UuidIndicatorLine+GetInstitutionEndTag+XmlFooter;

	/// <summary>Returns a SOAP request string for GetOrganisation API</summary>
	private static string RetrieveGetOrganisationSoapRequest() => XmlHeader+GetOrganizationTag+InstitutionIdentifierLine+InstitutionUuidIdentifierLine+ActivationDateLine+DeactivationDateLine+UuidIndicatorLine+GetOrganizationEndTag+XmlFooter;

	/// <summary>Returns a SOAP request string for GetPersonChangedAtDate API</summary>
	private static string RetrieveGetPersonChangedAtDateSoapRequest() => XmlHeader+GetPersonChangedAtDateTag+InstitutionIdentifierLine+ActivationDateLine+ActivationTimeLine+DeactivationDateLine+DeactivationTimeLine+ContactInformationIndicatorLine+PostalAddressIndicatorLine+GetPersonChangedAtDateEndTag+XmlFooter;

	/// <summary>Returns a SOAP request string for GetPerson API</summary>
	private static string RetrieveGetPersonSoapRequest() => XmlHeader+GetPersonTag+InstitutionIdentifierLine+EffectiveDateLine+StatusActiveIndicatorLine+StatusPassiveIndicatorLine+ContactInformationIndicatorLine+PostalAddressIndicatorLine+GetPersonEndTag+XmlFooter;

	/// <summary>Returns a SOAP request string for GetProfession API</summary>
	private static string RetrieveGetProfessionSoapRequest() => XmlHeader+GetProfessionTag+InstitutionIdentifierLine+GetProfessionEndTag+XmlFooter;

	#endregion

	#region Set

	/// <summary>Sets <see cref="ActivationDateLine"/> and <see cref="DeactivationDateLine"/></summary>
	private static void SetQueryDates(string sdApi) { switch (sdApi.ToLower()) { case "getemploymentchanged": if (DateTime.Parse(FromDate)<DateTime.Parse(AYearAgo)) FromDate=AYearAgo; break;
		case "getemploymentchangedatdate": if (DateTime.Parse(FromDate)<DateTime.Parse(AMonthAgo)) FromDate=AMonthAgo; break; case "getorganization": FromDate=Today; ToDate=Today; break;
		case "getperson": if (DateTime.Parse(FromDate)<DateTime.Parse(FiveYearsAgo)) FromDate=FiveYearsAgo; break; case "gepersonchangedatdate": if (DateTime.Parse(FromDate)<DateTime.Parse(FiveYearsAgo)) 
			FromDate=FiveYearsAgo; break; default: break; } CheckFromDateAndToDate(); if (ValidDates) { ActivationDateLine=@"      <ActivationDate>"+FromDate+@"</ActivationDate>"+Environment.NewLine;
				DeactivationDateLine=@"      <DeactivationDate>"+ToDate+@"</DeactivationDate>"+Environment.NewLine; } }

	/// <summary>Sets InstitutionIdentifierLine</summary><param name="instId">InstitutionIdentifier</param>
	private static void SetInstitutionIdentifier(string instId) => InstitutionIdentifierLine=@"      <InstitutionIdentifier>"+instId+@"</InstitutionIdentifier>"+Environment.NewLine;

	#endregion

	#endregion

	#endregion

}
