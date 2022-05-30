// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="XmlHandler.Lines.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace DataTier;

/// <remarks />
public partial class XmlHandler // Lines
{
	#region Fields

	/// <remarks />
	public static string AdministrationIndicatorLine => Resources.AdministrationIndicator+Environment.NewLine;

	/// <remarks />
	public static string ContactInformationIndicatorLine => Resources.ContactInformationIndicatorTrue+Environment.NewLine;

	/// <remarks />
	public static string DepartmentIdentifierLine => Resources.DepartmentIdentifier+Environment.NewLine;

	/// <remarks />
	public static string DepartmentIndicatorLine => Resources.DepartmentIndicator+Environment.NewLine;

	/// <remarks />
	public static string DepartmentLevelIdentifierLine => Resources.DepartmentLevelIdentifier+Environment.NewLine;

	/// <remarks />
	public static string DepartmentNameIndicatorLine => Resources.DepartmentNameIndicator+Environment.NewLine;

	/// <remarks />
	public static string DepartmentUuidIdentifierLine => Resources.DepartmentUUIDIdentifier+Environment.NewLine;

	/// <remarks />
	public static string EmploymentDepartmentIndicatorLine => Resources.EmploymentDepartmentIndicator+Environment.NewLine;

	/// <remarks />
	public static string EmploymentIdentifierLine => Resources.EmploymentIdentifier+Environment.NewLine;

	/// <remarks />
	public static string EmploymentStatusIndicatorLine => Resources.EmploymentStatusIndicator+Environment.NewLine;

	/// <remarks />
	public static string FutureInformationIndicatorLine => Resources.FutureInformationIndicator+Environment.NewLine;

	/// <remarks />
	public static string InstitutionIdentifierLine { get; set; } = string.Empty;

	/// <remarks />
	public static string InstitutionIdentifierLineGetInstitution => Resources.InstitutionIdentifierGetInstitution+Environment.NewLine;

	/// <remarks />
	public static string InstitutionUuidIdentifierLine => Resources.InstitutionUUIDIdentifier+Environment.NewLine;

	/// <remarks />
	public static string JobPositionIdentifierLine => Resources.JobPositionIdentifier+Environment.NewLine;

	/// <remarks />
	public static string PersonCivilRegistrationIdentifierLine => Resources.PersonCivilRegistrationIdentifier+Environment.NewLine;

	/// <remarks />
	public static string PostalAddressIndicatorLine => Resources.PostalAddressIndicatorTrue+Environment.NewLine;

	/// <remarks />
	public static string ProductionUnitIndicatorLine => Resources.ProductionUnitIndicator+Environment.NewLine;

	/// <remarks />
	public static string ProfessionIndicatorLine => Resources.ProfessionIndicator+Environment.NewLine;

	/// <remarks />
	public static string RegionIdentifierLine => Resources.RegionIdentifier+Environment.NewLine;

	/// <remarks />
	public static string RegionUuidIdentifierLine => Resources.RegionUUIDIdentifier+Environment.NewLine;

	/// <remarks />
	public static string SalaryAgreementIndicatorLine => Resources.SalaryAgreementIndicator+Environment.NewLine;

	/// <remarks />
	public static string SalaryCodeGroupIndicatorLine => Resources.SalaryCodeGroupIndicator+Environment.NewLine;

	/// <remarks />
	public static string StatusActiveIndicatorLine => Resources.StatusActiveIndicator+Environment.NewLine;

	/// <remarks />
	public static string StatusPassiveIndicatorLine => Resources.StatusPassiveIndicator+Environment.NewLine;

	/// <remarks />
	public static string UuidIndicatorLine => Resources.UUIDIndicatorLine+Environment.NewLine;

	/// <remarks />
	public static string WorkingTimeIndicatorLine => Resources.WorkingTimeIndicator+Environment.NewLine;

	#region Private

	private static string ActivationDateLine { get; set; } =string.Empty;
	private static string ActivationTimeLine => Resources.ActivationTime+Environment.NewLine;

	private static string DeactivationDateLine { get; set; } =string.Empty;
	private static string DeactivationTimeLine => Resources.DeactivationTime+Environment.NewLine;

	private static string EffectiveDateLine => Resources.EffectiveDateBaseTag+DateTime.Today.ToString("yyyy-MM-dd")+Resources.EffectiveDateEndTag+Environment.NewLine;

	private static string XmlHeader { get; } = Resources.XmlTag+Environment.NewLine+Resources.SoapEnvelopeBaseTag+Environment.NewLine+Resources.SoapBodyBaseTag+Environment.NewLine;
	private static string XmlFooter { get; } = Resources.SoapBodyEndTag+Environment.NewLine+Resources.SoapEnvelopeEndTag+Environment.NewLine;

	#endregion

	#endregion

}
