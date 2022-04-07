// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="View3in1OrganizationStructure.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks/>
public class View3in1OrganizationStructure
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Silo;Organisationstruktur;Afdelingsid;Afdelingsuuid;Afdelingsniveau;Overordnet\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of View3in1OrganizationStructure</summary>
	public View3in1OrganizationStructure() { }

	/// <summary>Initializes a new instance of View3in1OrganizationStructure</summary><param name="silo" /><param name="organisationstruktur" /><param name="afdelingsid" /><param name="afdelingsuuid" />
	/// <param name="afdelingsniveau" /><param name="overordnet" />
	public View3in1OrganizationStructure(string silo,string organisationstruktur,string afdelingsid,string afdelingsuuid,string afdelingsniveau,string overordnet) { this.Silo=silo;
		this.Organisationstruktur=organisationstruktur; this.Afdelingsid=afdelingsid; this.Afdelingsuuid=afdelingsuuid; this.Afdelingsniveau=afdelingsniveau; this.Overordnet=overordnet; }

	/// <summary>Initializes an instance of View3in1OrganizationStructure, that accepts data from an existing View3in1OrganizationStructure</summary><param name="entity" />
	public View3in1OrganizationStructure(View3in1OrganizationStructure entity) { this.Silo=entity.Silo; this.Organisationstruktur=entity.Organisationstruktur;
		this.Afdelingsid=entity.Afdelingsid; this.Afdelingsuuid=entity.Afdelingsuuid; this.Afdelingsniveau=entity.Afdelingsniveau; this.Overordnet=entity.Overordnet; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	[JsonProperty("Silo")][XmlElement("Silo")]
	public string Silo { get; set; } = "NO";

	/// <remarks/>
	[JsonProperty("Organisationstruktur")][XmlElement("Organisationstruktur")]
	public string Organisationstruktur { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Afdelingsid")][XmlElement("Afdelingsid")]
	public string Afdelingsid { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Afdelingsuuid")][XmlElement("Afdelingsuuid")]
	public string Afdelingsuuid { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Afdelingsniveau")][XmlElement("Afdelingsniveau")]
	public string Afdelingsniveau { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Overordnet")][XmlElement("Overordnet")]
	public string Overordnet { get; set; } = string.Empty;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Silo+";"+this.Organisationstruktur+";"+this.Afdelingsid+";"+this.Afdelingsuuid+";"+this.Afdelingsniveau+";"+this.Overordnet+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<View3in1OrganizationStructure creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Silo>"+Silo+"<\\Silo>"+Environment.NewLine;
		result += "    <Organisationstruktur>"+Organisationstruktur+"<\\Organisationstruktur>"+Environment.NewLine;
		result += "    <Afdelingsid>"+Afdelingsid+"<\\Afdelingsid>"+Environment.NewLine;
		result += "    <Afdelingsuuid>"+Afdelingsuuid+"<\\Afdelingsuuid>"+Environment.NewLine;
		result += "    <Afdelingsniveau>"+Afdelingsniveau+"<\\Afdelingsniveau>"+Environment.NewLine;
		result += "    <Overordnet>"+Overordnet+"<\\Overordnet>"+Environment.NewLine;
		result += "<\\View3in1OrganizationStructure>"+Environment.NewLine; return result; }

	#endregion

}
