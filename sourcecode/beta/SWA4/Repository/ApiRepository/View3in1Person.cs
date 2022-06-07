// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="View3in1Person.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace ApiRepository;

/// <remarks/>
public class View3in1Person
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Tjenestenummer;Silo;AfdelingsId;AfdelingsUuid;Afdelingsnavn;Cpr;Fornavn;Efternavn;Email1;Email2;Tlf1;Tlf2\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of View3in1Person</summary>
	public View3in1Person() { }

	/// <summary>Initializes a new instance of View3in1Person</summary><param name="tjenestenummer" /><param name="silo" /><param name="afdelingsId" /><param name="afdelingsUuid" /><param name="afdelingsnavn" />
	/// <param name="cpr" /><param name="fornavn" /><param name="efternavn" /><param name="email1" /><param name="email2" /><param name="tlf1" /><param name="tlf2" />
	public View3in1Person(string tjenestenummer,string silo,string afdelingsId,string afdelingsUuid, string afdelingsnavn,string cpr,string fornavn,string efternavn,string email1,string email2,string tlf1,string tlf2) {
		this.Tjenestenummer=tjenestenummer; this.Silo=silo; this.AfdelingsId = afdelingsId; this.AfdelingsUuid = afdelingsUuid; this.Afdelingsnavn=afdelingsnavn;
		this.Cpr=cpr; this.Fornavn=fornavn; this.Efternavn=efternavn; this.Email1=email1; this.Email2=email2; this.Tlf1=tlf1; this.Tlf2=tlf2; }

	/// <summary>Initializes an instance of View3in1Person, that accepts data from existing View3in1Person</summary><param name="entity" />
	public View3in1Person(View3in1Person entity) { this.Tjenestenummer=entity.Tjenestenummer; this.Silo=entity.Silo; this.AfdelingsId = entity.AfdelingsId; this.AfdelingsUuid = entity.AfdelingsUuid;
		this.Afdelingsnavn=entity.Afdelingsnavn; this.Cpr=entity.Cpr; this.Fornavn=entity.Fornavn; this.Efternavn=entity.Efternavn; this.Email1=entity.Email1;this.Email2=entity.Email2;
		this.Tlf1=entity.Tlf1; this.Tlf2=entity.Tlf2; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	[JsonProperty("Tjenestenummer")][XmlElement("Tjenestenummer")]
	public string Tjenestenummer { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Silo")][XmlElement("Silo")]
	public string Silo { get; set; } = "NO";

	/// <remarks/>
	[JsonProperty("AfdelingsId")][XmlElement("AfdelingsId")]
	public string AfdelingsId { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("AfdelingsUuid")][XmlElement("AfdelingsUuid")]
	public string AfdelingsUuid { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Afdelingsnavn")][XmlElement("Afdelingsnavn")]
	public string Afdelingsnavn { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Cpr")][XmlElement("Cpr")]
	public string Cpr { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Fornavn")][XmlElement("Fornavn")]
	public string Fornavn { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Efternavn")][XmlElement("Efternavn")]
	public string Efternavn { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Email1")][XmlElement("Email1")]
	public string? Email1 { get; set; } = "empty@empty.Com";

	/// <remarks/>
	[JsonProperty("Email2")][XmlElement("Email2")]
	public string? Email2 { get; set; } = "empty@empty.Com";

	/// <remarks/>
	[JsonProperty("Tlf1")][XmlElement("Tlf1")]
	public string? Tlf1 { get; set; } = "00000000";

	/// <remarks/>
	[JsonProperty("Tlf2")][XmlElement("Tlf2")]
	public string? Tlf2 { get; set; } = "00000000";

	#endregion

	#region Other
	/// <remarks/>
	public string CsvValue => this.Tjenestenummer+";"+this.Silo+";"+this.AfdelingsId+";"+this.AfdelingsUuid+";"+this.Afdelingsnavn+";"+
		this.Cpr+";"+this.Fornavn+";"+this.Efternavn+";"+this.Email1+";"+this.Email2+";"+this.Tlf1+";"+this.Tlf2+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<View3in1Person creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result+="    <Tjenestenummer>"+Tjenestenummer+"<\\Tjenestenummer>"+Environment.NewLine+"    <Silo>"+Silo+"<\\Silo>"+Environment.NewLine+"    <AfdelingsId>"+AfdelingsId+"<\\AfdelingsId>"+Environment.NewLine;
		result+="    <AfdelingsUuid>"+AfdelingsUuid+"<\\AfdelingsUuid>"+Environment.NewLine+"    <Afdelingsnavn>"+Afdelingsnavn+"<\\Afdelingsnavn>"+Environment.NewLine+"    <Cpr>"+Cpr+"<\\Cpr>"+Environment.NewLine;
		result+="    <Fornavn>"+Fornavn+"<\\Fornavn>"+Environment.NewLine+"    <Efternavn>"+Efternavn+"<\\Efternavn>"+Environment.NewLine;
		if (Email1!=null) result+="    <Email1>"+Email1+"<\\Email1>"+Environment.NewLine; else result+="    <Email1>empty@empty.Com<\\Email1>" + Environment.NewLine;
		if (Email2!=null) result+="    <Email2>"+Email2+"<\\Email2>"+Environment.NewLine; else result+="    <Email1>empty@empty.Com<\\Email1>" + Environment.NewLine;
		if (Tlf1!=null) result+="    <Tlf1>00000000<\\Phone1>" + Environment.NewLine; else result+="    <Tlf1>" + Email1 + "<\\Tlf1>" + Environment.NewLine;
		if (Tlf2!=null) result+="    <Tlf2>"+Tlf2+"<\\Tlf2>"+Environment.NewLine; else result+="    <Tlf2>00000000<\\Tlf2>" + Environment.NewLine;
		result+="<\\View3in1Person>"+Environment.NewLine; return result; }

	#endregion

}
