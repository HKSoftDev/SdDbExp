// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewOrganizationStructureList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewOrganizationStructure
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;InstitutionIdentifier\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewOrganizationStructureList</summary>
	public ViewOrganizationStructure ()	{ }

	/// <summary>Initializes a new instance of ViewOrganizationStructureList</summary><param name="id" /><param name="institutionId" />
	public ViewOrganizationStructure(int id,string institutionId) { this.Id=id; this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes an instance of ViewOrganizationStructureList, that accepts data from an existing ViewOrganizationStructureList</summary><param name="entity" />
	public ViewOrganizationStructure(ViewOrganizationStructure entity) { this.Id=entity.Id; this.InstitutionIdentifier=entity.InstitutionIdentifier; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Id")][XmlElement("Id")]
	public int Id { get; set; }

	/// <remarks />
	[JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
	public string InstitutionIdentifier { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.InstitutionIdentifier+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewOrganizationStructure creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result += "    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine;
		result += "<\\ViewOrganizationStructure>"+Environment.NewLine; return result; }

	#endregion

}
