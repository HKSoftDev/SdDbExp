// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewEmploymentList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewEmployment
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;EmploymentIdentifier;EmploymentDate;AnniversaryDate;InstitutionIdentifier;Employee;EmploymentDepartment;EmploymentProfession\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewEmploymentList</summary>
	public ViewEmployment ()	{ }

	/// <summary>Initializes a new instance of ViewEmploymentList</summary><param name="id" /><param name="employmentId" /><param name="employmentDate" /><param name="anniversaryDate" />
	/// <param name="institutionId" /><param name="employee" /><param name="employmentDepartment" /><param name="employmentProfession" />
	public ViewEmployment(int id,string employmentId,DateTime employmentDate,DateTime anniversaryDate,string institutionId,string employee,string employmentDepartment,string employmentProfession) {
		this.Id=id; this.EmploymentIdentifier=employmentId; this.EmploymentDate=employmentDate; this.AnniversaryDate=anniversaryDate;this.InstitutionIdentifier=institutionId; this.Employee=employee;
		this.EmploymentDepartment=employmentDepartment; this.EmploymentProfession=employmentProfession; }

	/// <summary>Initializes an instance of ViewEmploymentList, that accepts data from an existing ViewEmploymentList</summary><param name="entity" />
	public ViewEmployment(ViewEmployment entity) { this.Id=entity.Id; this.EmploymentIdentifier=entity.EmploymentIdentifier; this.EmploymentDate=entity.EmploymentDate; this.AnniversaryDate=entity.AnniversaryDate;
		this.InstitutionIdentifier=entity.InstitutionIdentifier; this.Employee=entity.Employee; this.EmploymentDepartment=entity.EmploymentDepartment; this.EmploymentProfession=entity.EmploymentProfession; }

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
	[JsonProperty("EmploymentDate")][XmlElement("EmploymentDate")]
	public DateTime EmploymentDate { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks />
	[JsonProperty("AnniversaryDate")][XmlElement("AnniversaryDate")]
	public DateTime AnniversaryDate { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks />
	[JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
	public string InstitutionIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Employee")][XmlElement("Employee")]
	public string Employee { get; set; } = null!;

	/// <remarks />
	[JsonProperty("EmploymentDepartment")][XmlElement("EmploymentDepartment")]
	public string EmploymentDepartment { get; set; } = null!;

	/// <remarks />
	[JsonProperty("EmploymentProfession")][XmlElement("EmploymentProfession")]
	public string EmploymentProfession { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.EmploymentIdentifier+";"+this.EmploymentDate+";"+this.AnniversaryDate+";"+this.InstitutionIdentifier+";"+this.Employee+";"+this.EmploymentDepartment+";"+EmploymentProfession+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewEmployment creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result += "    <EmploymentIdentifier>"+EmploymentIdentifier+"<\\EmploymentIdentifier>"+Environment.NewLine;
		result += "    <EmploymentDate>"+EmploymentDate+"<\\EmploymentDate>"+Environment.NewLine;
		result += "    <AnniversaryDate>"+AnniversaryDate+"<\\AnniversaryDate>"+Environment.NewLine;
		result += "    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine;
		result += "    <Employee>"+Employee+"<\\Employee>"+Environment.NewLine;
		result += "    <EmploymentDepartment>"+EmploymentDepartment+"<\\EmploymentDepartment>"+Environment.NewLine;
		result += "    <EmploymentProfession>"+EmploymentProfession+"<\\EmploymentProfession>"+Environment.NewLine;
		result += "<\\ViewEmployment>"+Environment.NewLine; return result; }

	#endregion

}
