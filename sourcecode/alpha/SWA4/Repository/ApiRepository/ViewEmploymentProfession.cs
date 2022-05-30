// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewEmploymentProfessionList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewEmploymentProfession
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;ActivationDate;DeactivationDate;JobPositionIdentifier;InstitutionIdentifier;EmploymentName;AppointmentCode\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewEmploymentProfessionList</summary>
	public ViewEmploymentProfession ()	{ }

	/// <summary>Initializes a new instance of ViewEmploymentProfessionList</summary><param name="id" /><param name="activationDate" /><param name="deactivationDate" /><param name="jobPositionId" />
	/// <param name="institutionId" /><param name="employmentName" /><param name="appointmentCode" />
	public ViewEmploymentProfession(int id,DateTime activationDate,DateTime deactivationDate,string jobPositionId,string institutionId,string employmentName,string appointmentCode) {
		this.Id=id; this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.JobPositionIdentifier=jobPositionId;
		this.InstitutionIdentifier=institutionId; this.EmploymentName=employmentName; this.AppointmentCode=appointmentCode; }

	/// <summary>Initializes an instance of ViewEmploymentProfessionList, that accepts data from an existing ViewEmploymentProfessionList</summary><param name="entity" />
	public ViewEmploymentProfession(ViewEmploymentProfession entity) { this.Id=entity.Id; this.ActivationDate=entity.ActivationDate; this.DeactivationDate=entity.DeactivationDate;
		this.JobPositionIdentifier=entity.JobPositionIdentifier; this.InstitutionIdentifier=entity.InstitutionIdentifier; this.EmploymentName=entity.EmploymentName; this.AppointmentCode=entity.AppointmentCode; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Id")][XmlElement("Id")]
	public int Id { get; set; }

	/// <remarks />
	[JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
	public DateTime ActivationDate { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks />
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public DateTime DeactivationDate { get; set; } = DateTime.Parse("9999-12-31");

	/// <remarks />
	[JsonProperty("JobPositionIdentifier")][XmlElement("JobPositionIdentifier")]
	public string JobPositionIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
	public string InstitutionIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("EmploymentName")][XmlElement("EmploymentName")]
	public string EmploymentName { get; set; } = null!;

	/// <remarks />
	[JsonProperty("AppointmentCode")][XmlElement("AppointmentCode")]
	public string AppointmentCode { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.ActivationDate.ToString("yyyy-MM-dd")+";"+this.DeactivationDate.ToString("yyyy-MM-dd")+";"+this.JobPositionIdentifier+";"+
		this.InstitutionIdentifier+";"+this.EmploymentName+";"+AppointmentCode+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewEmploymentProfession creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result += "    <ActivationDate>"+ActivationDate.ToString("yyyy-MM-dd")+"<\\ActivationDate>"+Environment.NewLine;
		result += "    <DeactivationDate>"+DeactivationDate.ToString("yyyy-MM-dd")+"<\\DeactivationDate>"+Environment.NewLine;
		result += "    <JobPositionIdentifier>"+JobPositionIdentifier+"<\\JobPositionIdentifier>"+Environment.NewLine;
		result += "    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine;
		result += "    <EmploymentName>"+EmploymentName+"<\\EmploymentName>"+Environment.NewLine;
		result += "    <AppointmentCode>"+AppointmentCode+"<\\AppointmentCode>"+Environment.NewLine;
		result += "<\\ViewEmploymentProfession>"+Environment.NewLine; return result; }

	#endregion

}
