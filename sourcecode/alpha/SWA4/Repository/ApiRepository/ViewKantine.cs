// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewKantine.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewKantine
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader= "Tjenestenummer;Cpr;Afdelingskode;Beskæftigelsesdecimal;Fornavn;Efternavn;Afdeling;StartDato;SlutDato;Jubi\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewKantine</summary>
	public ViewKantine ()	{ }

	/// <summary>Initializes a new instance of ViewKantine</summary><param name="cpr" /><param name="tjenestenummer" /><param name="afdelingskode" /><param name="beskæftigelsesdecimal" />
	/// <param name="fornavn" /><param name="efternavn" /><param name="afdeling" /><param name="startDato" /><param name="slutDato" /><param name="jubi" />
	public ViewKantine(string cpr,string tjenestenummer,string afdelingskode,string beskæftigelsesdecimal,string fornavn,string efternavn,string afdeling,DateTime startDato,DateTime slutDato,DateTime jubi) {
		this.Cpr=cpr; this.Tjenestenummer=tjenestenummer; this.Afdelingskode = afdelingskode; this.Beskæftigelsesdecimal=beskæftigelsesdecimal; this.Fornavn=fornavn; this.Efternavn=efternavn; this.Afdeling=afdeling;
		this.StartDato=startDato; this.SlutDato=slutDato; this.Jubi=jubi; }

	/// <summary>Initializes an instance of ViewKantine, that accepts data from an existing ViewKantine</summary><param name="entity" />
	public ViewKantine(ViewKantine entity) { this.Cpr=entity.Cpr; this.Tjenestenummer=entity.Tjenestenummer; this.Afdelingskode = entity.Afdelingskode; this.Beskæftigelsesdecimal=entity.Beskæftigelsesdecimal; 
		this.Fornavn=entity.Fornavn; this.Efternavn=entity.Efternavn; this.Afdeling=entity.Afdeling; this.StartDato=entity.StartDato; this.SlutDato=entity.SlutDato; this.Jubi=entity.Jubi; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Tjenestenummer")][XmlElement("Tjenestenummer")]
	public string Tjenestenummer { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Cpr")]
	[XmlElement("Cpr")]
	public string Cpr { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Afdelingskode")][XmlElement("Afdelingskode")]
	public string Afdelingskode { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Beskæftigelsesdecimal")][XmlElement("Beskæftigelsesdecimal")]
	public string Beskæftigelsesdecimal { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Fornavn")][XmlElement("Fornavn")]
	public string Fornavn { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Efternavn")][XmlElement("Efternavn")]
	public string Efternavn { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Afdeling")][XmlElement("Afdeling")]
	public string Afdeling { get; set; } = null!;

	/// <remarks />
	[JsonProperty("StartDato")][XmlElement("StartDato")]
	public DateTime StartDato { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks />
	[JsonProperty("SlutDato")][XmlElement("SlutDato")]
	public DateTime SlutDato { get; set; } = DateTime.Parse("9999-12-31");

	/// <remarks />
	[JsonProperty("Jubi")][XmlElement("Jubi")]
	public DateTime Jubi { get; set; } = DateTime.Parse("2010-01-01");

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Tjenestenummer+";"+ this.Cpr+";"+this.Afdelingskode+";"+this.Beskæftigelsesdecimal+";"+this.Fornavn+";"+this.Efternavn+";"+this.Afdeling+";"+
		this.StartDato.ToString("yyyy-MM-dd")+";"+this.SlutDato.ToString("yyyy-MM-dd")+";"+this.Jubi.ToString("yyyy-MM-dd")+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewKantine creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Cpr>"+Cpr+"<\\Cpr>"+Environment.NewLine;
		result += "    <Tjenestenummer>"+Tjenestenummer+"<\\Tjenestenummer>"+Environment.NewLine;
		result += "    <Afdelingskode>"+Afdelingskode+"<\\Afdelingskode>"+Environment.NewLine;
		result += "    <Beskæftigelsesdecimal>"+Beskæftigelsesdecimal+"<\\Beskæftigelsesdecimal>"+Environment.NewLine;
		result += "    <Fornavn>"+Fornavn+"<\\Fornavn>"+Environment.NewLine;
		result += "    <Efternavn>"+Efternavn+"<\\Efternavn>"+Environment.NewLine;
		result += "    <Afdeling>"+Afdeling+"<\\Afdeling>"+Environment.NewLine;
		result += "    <StartDato>"+StartDato.ToString("yyyy-MM-dd")+"<\\StartDato>"+Environment.NewLine;
		result += "    <SlutDato>"+SlutDato.ToString("yyyy-MM-dd")+"<\\SlutDato>"+Environment.NewLine;
		result += "    <Jubi>"+Jubi.ToString("yyyy-MM-dd")+"<\\Jubi>"+Environment.NewLine;
		result += "<\\ViewKantine>"+Environment.NewLine; return result; }

	#endregion

}
