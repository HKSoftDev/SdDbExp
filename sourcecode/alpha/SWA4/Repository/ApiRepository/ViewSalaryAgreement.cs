// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewSalaryAgreementList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewSalaryAgreement
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;EmploymentIdentifier;InstitutionIdentifier;ActivationDate;DeactivationDate;SalaryAgreementIdentifier;SalaryClassIdentifier;SalaryScaleIdentifier;PrepaidIndicator;SeniorityDate\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewSalaryAgreementList</summary>
	public ViewSalaryAgreement ()	{ }

	/// <summary>Initializes a new instance of ViewSalaryAgreementList</summary><param name="id" /><param name="employmentId" /><param name="institutionId" /><param name="activationDate" /><param name="deactivationDate" />
	/// <param name="salaryAgreementIdentifier" /><param name="salaryClassIdentifier" /><param name="salaryScaleIdentifier" /><param name="prepaidIndicator" /><param name="seniorityDate" />
	public ViewSalaryAgreement(int id,string employmentId,string institutionId,DateTime activationDate,DateTime deactivationDate,string salaryAgreementIdentifier,string salaryClassIdentifier,
		string salaryScaleIdentifier,bool prepaidIndicator,DateTime seniorityDate) { this.Id=id; this.EmploymentIdentifier=employmentId; this.InstitutionIdentifier=institutionId; this.ActivationDate=activationDate;
		this.DeactivationDate=deactivationDate; this.SalaryAgreementIdentifier=salaryAgreementIdentifier; this.SalaryClassIdentifier=salaryClassIdentifier; this.SalaryScaleIdentifier=salaryScaleIdentifier;
		this.PrepaidIndicator=prepaidIndicator; this.SeniorityDate=seniorityDate; }

	/// <summary>Initializes an instance of ViewSalaryAgreementList, that accepts data from an existing ViewSalaryAgreementList</summary><param name="entity" />
	public ViewSalaryAgreement(ViewSalaryAgreement entity) { this.Id=entity.Id; this.EmploymentIdentifier=entity.EmploymentIdentifier; this.InstitutionIdentifier=entity.InstitutionIdentifier; 
		this.ActivationDate=entity.ActivationDate; this.DeactivationDate=entity.DeactivationDate; this.SalaryAgreementIdentifier=entity.SalaryAgreementIdentifier; this.SalaryClassIdentifier=entity.SalaryClassIdentifier;
		this.SalaryScaleIdentifier=entity.SalaryScaleIdentifier; this.PrepaidIndicator=entity.PrepaidIndicator; this.SeniorityDate=entity.SeniorityDate; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Id")][XmlElement("Id")]
	public int Id { get; set; }

	/// <remarks />
	[JsonProperty("EmploymentIdentifier")][XmlElement("EmploymentIdentifier")]
	public string EmploymentIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
	public string InstitutionIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
	public DateTime ActivationDate { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks />
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public DateTime DeactivationDate { get; set; } = DateTime.Parse("9999-12-31");

	/// <remarks />
	[JsonProperty("SalaryAgreementIdentifier")][XmlElement("SalaryAgreementIdentifier")]
	public string SalaryAgreementIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("SalaryClassIdentifier")][XmlElement("SalaryClassIdentifier")]
	public string SalaryClassIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("SalaryScaleIdentifier")][XmlElement("SalaryScaleIdentifier")]
	public string SalaryScaleIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("PrepaidIndicator")][XmlElement("PrepaidIndicator")]
	public bool PrepaidIndicator { get; set; }

	/// <remarks />
	[JsonProperty("SeniorityDate")][XmlElement("SeniorityDate")]
	public DateTime SeniorityDate { get; set; } = DateTime.Parse("2010-01-01");

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.EmploymentIdentifier+";"+this.InstitutionIdentifier+";"+this.ActivationDate.ToString("yyyy-MM-dd")+";"+this.DeactivationDate.ToString("yyyy-MM-dd")+";"+
		this.SalaryAgreementIdentifier+";"+this.SalaryClassIdentifier+";"+this.SalaryScaleIdentifier+";"+this.PrepaidIndicator.ToString()+";"+this.SeniorityDate+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewSalaryAgreement creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result += "    <EmploymentIdentifier>"+EmploymentIdentifier+"<\\EmploymentIdentifier>"+Environment.NewLine;
		result += "    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine;
		result += "    <ActivationDate>"+ActivationDate.ToString("yyyy-MM-dd")+"<\\ActivationDate>"+Environment.NewLine;
		result += "    <DeactivationDate>"+DeactivationDate.ToString("yyyy-MM-dd")+"<\\DeactivationDate>"+Environment.NewLine;
		result += "    <SalaryAgreementIdentifier>"+SalaryAgreementIdentifier+"<\\SalaryAgreementIdentifier>"+Environment.NewLine;
		result += "    <SalaryClassIdentifier>"+SalaryClassIdentifier+"<\\SalaryClassIdentifier>"+Environment.NewLine;
		result += "    <SalaryScaleIdentifier>"+SalaryScaleIdentifier+"<\\SalaryScaleIdentifier>"+Environment.NewLine;
		result += "    <PrepaidIndicator>"+PrepaidIndicator.ToString()+"<\\PrepaidIndicator>"+Environment.NewLine;
		result += "    <SeniorityDate>"+SeniorityDate.ToString("yyyy-MM-dd")+"<\\SeniorityDate>"+Environment.NewLine;
		result += "<\\ViewSalaryAgreement>"+Environment.NewLine; return result; }

	#endregion

}
