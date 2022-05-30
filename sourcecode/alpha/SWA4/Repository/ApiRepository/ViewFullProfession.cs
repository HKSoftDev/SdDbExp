// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewFullProfession.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace ApiRepository;

/// <remarks />
public partial class ViewFullProfession
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="ProfessionId;EmploymentProfessionId;ActivationDate;DeactivationDate;JobPositionIdentifier;JobPositionName;JobPositionLevelCode;InstitutionIdentifier;EmploymentName;AppointmentCode\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewFullProfession</summary>
	public ViewFullProfession ()	{ }

	/// <summary>Initializes a new instance of ViewFullProfession</summary><param name="professionId" /><param name="employmentProfessionId" /><param name="activationDate" /><param name="deactivationDate" />
	/// <param name="jobPositionIdentifier" /><param name="jobPositionName" /><param name="jobPositionLevelCode" /><param name="institutionIdentifier" /><param name="employmentName" /><param name="appointmentCode" />
	public ViewFullProfession(int professionId,int employmentProfessionId,DateTime activationDate,DateTime deactivationDate,string jobPositionIdentifier,string jobPositionName,string jobPositionLevelCode,
		string institutionIdentifier,string employmentName,string appointmentCode) {
		this.ProfessionId=professionId; this.EmploymentProfessionId=employmentProfessionId; this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.JobPositionIdentifier=jobPositionIdentifier;
		this.JobPositionName=jobPositionName; this.JobPositionLevelCode=jobPositionLevelCode; this.InstitutionIdentifier=institutionIdentifier; this.EmploymentName=employmentName; this.AppointmentCode=appointmentCode; }

	/// <summary>Initializes an instance of ViewFullProfession, that accepts data from an existing ViewFullProfession</summary><param name="entity" />
	public ViewFullProfession(ViewFullProfession entity) { this.ProfessionId=entity.ProfessionId; this.EmploymentProfessionId=entity.EmploymentProfessionId; this.ActivationDate=entity.ActivationDate;
		this.DeactivationDate=entity.DeactivationDate; this.JobPositionIdentifier=entity.JobPositionIdentifier; this.JobPositionName=entity.JobPositionName; this.JobPositionLevelCode=entity.JobPositionLevelCode;
		this.InstitutionIdentifier=entity.InstitutionIdentifier; this.EmploymentName=entity.EmploymentName; this.AppointmentCode=entity.AppointmentCode; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("ProfessionId")][XmlElement("ProfessionId")]
	public int ProfessionId { get; set; }

	/// <remarks />
	[JsonProperty("EmploymentProfessionId")][XmlElement("EmploymentProfessionId")]
	public int EmploymentProfessionId { get; set; }

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
	[JsonProperty("JobPositionName")][XmlElement("JobPositionName")]
	public string JobPositionName { get; set; } = null!;

	/// <remarks />
	[JsonProperty("JobPositionLevelCode")][XmlElement("JobPositionLevelCode")]
	public string JobPositionLevelCode { get; set; } = null!;

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
	public string CsvValue => this.ProfessionId+";"+this.EmploymentProfessionId+";"+this.ActivationDate+";"+this.DeactivationDate+";"+this.JobPositionIdentifier+";"+
		this.JobPositionName+";"+this.JobPositionLevelCode+";"+this.InstitutionIdentifier+";"+this.EmploymentName+";"+AppointmentCode+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewFullProfession creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <ProfessionId>"+ProfessionId+"<\\ProfessionId>"+Environment.NewLine;
		result += "    <EmploymentProfessionId>"+EmploymentProfessionId+"<\\EmploymentProfessionId>"+Environment.NewLine;
		result += "    <ActivationDate>"+ActivationDate+"<\\ActivationDate>"+Environment.NewLine;
		result += "    <DeactivationDate>"+DeactivationDate+"<\\DeactivationDate>"+Environment.NewLine;
		result += "    <JobPositionIdentifier>"+JobPositionIdentifier+"<\\JobPositionIdentifier>"+Environment.NewLine;
		result += "    <JobPositionName>"+JobPositionName+"<\\JobPositionName>"+Environment.NewLine;
		result += "    <JobPositionLevelCode>"+JobPositionLevelCode+"<\\JobPositionLevelCode>"+Environment.NewLine;
		result += "    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine;
		result += "    <EmploymentName>"+EmploymentName+"<\\EmploymentName>"+Environment.NewLine;
		result += "    <AppointmentCode>"+AppointmentCode+"<\\AppointmentCode>"+Environment.NewLine;
		result += "<\\ViewFullProfession>"+Environment.NewLine; return result; }

	#endregion

}
