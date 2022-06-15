// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewProfessionList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewProfession
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;JobPositionIdentifier;JobPositionName;JobPositionLevelCode;InstitutionIdentifier\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewProfessionList</summary>
	public ViewProfession ()	{ }

	/// <summary>Initializes a new instance of ViewProfessionList</summary><param name="id" /><param name="jobPositionId" /><param name="jobPositionName" /><param name="jobPositionLevelCode" /><param name="institutionId" />
	public ViewProfession(int id,string jobPositionId,string jobPositionName,string jobPositionLevelCode,string institutionId) { this.Id=id; this.JobPositionIdentifier=
		jobPositionId; this.JobPositionName=jobPositionName; this.JobPositionLevelCode=jobPositionLevelCode; this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes an instance of ViewProfessionList, that accepts data from an existing ViewProfessionList</summary><param name="entity" />
	public ViewProfession(ViewProfession entity) { this.Id=entity.Id; this.JobPositionIdentifier=entity.JobPositionIdentifier; this.JobPositionName=
		entity.JobPositionName; this.JobPositionLevelCode=entity.JobPositionLevelCode; this.InstitutionIdentifier=entity.InstitutionIdentifier; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Id")][XmlElement("Id")]
	public int Id { get; set; }

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

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.JobPositionIdentifier+";"+this.JobPositionName+";"+this.JobPositionLevelCode+";"+this.InstitutionIdentifier+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewProfession creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine+"    <JobPositionIdentifier>"+JobPositionIdentifier+"<\\JobPositionIdentifier>"+Environment.NewLine;
		result += "    <JobPositionName>"+JobPositionName+"<\\JobPositionName>"+Environment.NewLine+"    <JobPositionLevelCode>"+JobPositionLevelCode+"<\\JobPositionLevelCode>"+Environment.NewLine;
		result += "    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine+"<\\ViewProfession>"+Environment.NewLine; return result; }

	#endregion

}
