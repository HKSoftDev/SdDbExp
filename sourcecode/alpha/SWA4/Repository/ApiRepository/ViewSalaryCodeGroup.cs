// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewSalaryCodeGroupList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewSalaryCodeGroup
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;EmploymentIdentifier;InstitutionIdentifier;ActivationDate;DeactivationDate;PensionCode\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewSalaryCodeGroupList</summary>
	public ViewSalaryCodeGroup ()	{ }

	/// <summary>Initializes a new instance of ViewSalaryCodeGroupList</summary><param name="id" /><param name="employmentId" /><param name="institutionId" />
	/// <param name="activationDate" /><param name="deactivationDate" /><param name="pensionCode" />
	public ViewSalaryCodeGroup(int id,string employmentId,string institutionId,DateTime activationDate,DateTime deactivationDate,string pensionCode) {
		this.Id=id; this.EmploymentIdentifier=employmentId; this.InstitutionIdentifier=institutionId; this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.PensionCode=pensionCode; }

	/// <summary>Initializes an instance of ViewSalaryCodeGroupList, that accepts data from an existing ViewSalaryCodeGroupList</summary><param name="entity" />
	public ViewSalaryCodeGroup(ViewSalaryCodeGroup entity) { this.Id=entity.Id; this.EmploymentIdentifier=entity.EmploymentIdentifier; 
		this.InstitutionIdentifier=entity.InstitutionIdentifier; this.ActivationDate=entity.ActivationDate; this.DeactivationDate=entity.DeactivationDate; this.PensionCode=entity.PensionCode; }

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
	[JsonProperty("PensionCode")][XmlElement("PensionCode")]
	public string PensionCode { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.EmploymentIdentifier+";"+this.InstitutionIdentifier+";"+this.ActivationDate.ToString("yyyy-MM-dd")+";"+this.DeactivationDate.ToString("yyyy-MM-dd")+";"+this.PensionCode+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewSalaryCodeGroup creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result += "    <EmploymentIdentifier>"+EmploymentIdentifier+"<\\EmploymentIdentifier>"+Environment.NewLine;
		result += "    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine;
		result += "    <ActivationDate>"+ActivationDate.ToString("yyyy-MM-dd")+"<\\ActivationDate>"+Environment.NewLine;
		result += "    <DeactivationDate>"+DeactivationDate.ToString("yyyy-MM-dd")+"<\\DeactivationDate>"+Environment.NewLine;
		result += "    <PensionCode>"+PensionCode+"<\\PensionCode>"+Environment.NewLine;
		result += "<\\ViewSalaryCodeGroup>"+Environment.NewLine; return result; }

	#endregion

}
