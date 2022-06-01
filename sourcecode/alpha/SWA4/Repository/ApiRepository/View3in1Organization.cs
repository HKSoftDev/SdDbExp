// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Api3in1Organization.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks/>
public class View3in1Organization
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Silo;Organisation;Aktiveringsdato;Deaktiveringsdato;AfdelingsId;AfdelingsUuid;Afdelingsniveau;Overordnet\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of <see cref="View3in1Organization"/></summary>
	public View3in1Organization ()	{ }

	/// <summary>Initializes a new instance of View3in1Organization</summary><param name="silo" /><param name="organisation" /><param name="aktiveringsdato" /><param name="deaktiveringsdato" />
	/// <param name="afdelingsid" /><param name="afdelingsuuid" /><param name="afdelingsniveau" /><param name="overordnet" />
	public View3in1Organization(string silo,string organisation,DateTime aktiveringsdato,DateTime deaktiveringsdato,string afdelingsid,string afdelingsuuid,string afdelingsniveau,string overordnet) {
		this.Silo=silo; this.Organisation=organisation; this.Aktiveringsdato=aktiveringsdato; this.Deaktiveringsdato=deaktiveringsdato;
		this.AfdelingsId=afdelingsid; this.AfdelingsUuid=afdelingsuuid; this.Afdelingsniveau=afdelingsniveau; this.Overordnet=overordnet; }

	/// <summary>Initializes an instance of View3in1Organization, that accepts data from an existing View3in1Organization</summary><param name="entity" />
	public View3in1Organization(View3in1Organization entity) { this.Silo=entity.Silo; this.Organisation=entity.Organisation; this.Aktiveringsdato=entity.Aktiveringsdato; this.Deaktiveringsdato=entity.Deaktiveringsdato;
		this.AfdelingsId=entity.AfdelingsId; this.AfdelingsUuid=entity.AfdelingsUuid; this.Afdelingsniveau=entity.Afdelingsniveau; this.Overordnet=entity.Overordnet; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	[JsonProperty("Silo")][XmlElement("Silo")]
	public string Silo { get; set; } = "NO";

	/// <remarks/>
	[JsonProperty("Organisation")][XmlElement("Organisation")]
	public string Organisation { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Aktiveringsdato")][XmlElement("Aktiveringsdato")]
	public DateTime Aktiveringsdato { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks/>
	[JsonProperty("Deaktiveringsdato")][XmlElement("Deaktiveringsdato")]
	public DateTime Deaktiveringsdato { get; set; } = DateTime.Parse("9999-12-31");

	/// <remarks/>
	[JsonProperty("AfdelingsId")][XmlElement("AfdelingsId")]
	public string AfdelingsId { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("AfdelingsUuid")][XmlElement("AfdelingsUuid")]
	public string AfdelingsUuid { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Afdelingsniveau")][XmlElement("Afdelingsniveau")]
	public string Afdelingsniveau { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Overordnet")][XmlElement("Overordnet")]
	public string Overordnet { get; set; } = string.Empty;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Silo+";"+this.Organisation+";"+this.Aktiveringsdato.ToString("yyyy-MM-dd")+";"+this.Deaktiveringsdato.ToString("yyyy-MM-dd")+";"+
		this.AfdelingsId+";"+this.AfdelingsUuid+";"+this.Afdelingsniveau+";"+Overordnet+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<View3in1Organization creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Silo>"+Silo+"<\\Silo>"+Environment.NewLine;
		result += "    <Organisation>"+Organisation+"<\\Organisation>"+Environment.NewLine;
		result += "    <Aktiveringsdato>"+Aktiveringsdato.ToString("yyyy-MM-dd")+"<\\Aktiveringsdato>"+Environment.NewLine;
		result += "    <Deaktiveringsdato>"+Deaktiveringsdato.ToString("yyyy-MM-dd")+"<\\Deaktiveringsdato>"+Environment.NewLine;
		result += "    <AfdelingsId>"+AfdelingsId+"<\\AfdelingsId>"+Environment.NewLine;
		result += "    <AfdelingsUuid>"+AfdelingsUuid+"<\\AfdelingsUuid>"+Environment.NewLine;
		result += "    <Afdelingsniveau>"+Afdelingsniveau+"<\\Afdelingsniveau>"+Environment.NewLine;
		result += "    <Overordnet>"+Overordnet+"<\\Overordnet>"+Environment.NewLine;
		result += "<\\View3in1Organization>"+Environment.NewLine; return result; }

	#endregion

}
