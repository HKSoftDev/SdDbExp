// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewInstitutionList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewInstitution
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;InstitutionUuidIdentifier;InstitutionIdentifier;InstitutionName\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewInstitutionList</summary>
	public ViewInstitution ()	{ }

	/// <summary>Initializes a new instance of ViewInstitutionList</summary><param name="id" /><param name="institutionUuid" /><param name="institutionId" /><param name="institutionName" />
	public ViewInstitution(int id,string institutionUuid,string institutionId,string institutionName) {
		this.Id=id; this.InstitutionUuidIdentifier=institutionUuid; this.InstitutionIdentifier=institutionId; this.InstitutionName=institutionName; }

	/// <summary>Initializes an instance of ViewInstitutionList, that accepts data from an existing ViewInstitutionList</summary><param name="entity" />
	public ViewInstitution(ViewInstitution entity) { this.Id=entity.Id; this.InstitutionUuidIdentifier=entity.InstitutionUuidIdentifier; 
		this.InstitutionIdentifier=entity.InstitutionIdentifier; this.InstitutionName=entity.InstitutionName; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Id")][XmlElement("Id")]
	public int Id { get; set; }

	/// <remarks />
	[JsonProperty("InstitutionUuidIdentifier")][XmlElement("InstitutionUuidIdentifier")]
	public string InstitutionUuidIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
	public string InstitutionIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("InstitutionName")][XmlElement("InstitutionName")]
	public string InstitutionName { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.InstitutionUuidIdentifier+";"+this.InstitutionIdentifier+";"+this.InstitutionName+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewInstitution creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result += "    <InstitutionUuidIdentifier>"+InstitutionUuidIdentifier+"<\\InstitutionUuidIdentifier>"+Environment.NewLine;
		result += "    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine;
		result += "    <InstitutionName>"+InstitutionName+"<\\InstitutionName>"+Environment.NewLine;
		result += "<\\ViewInstitution>"+Environment.NewLine; return result; }

	#endregion

}
