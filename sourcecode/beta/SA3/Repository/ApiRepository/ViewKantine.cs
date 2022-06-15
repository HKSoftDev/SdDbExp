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
	[JsonIgnore][XmlIgnore]
	public const string CsvHeader="Tjenestenummer;Cpr;Fornavn;Efternavn;Titel;Afdeling;StartDato;SlutDato;P;Jubi;Afdelingskode\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewKantine</summary>
	public ViewKantine ()	{ }

	/// <summary>Initializes a new instance of ViewKantine</summary><param name="cpr" /><param name="tjenestenummer" /><param name="fornavn" /><param name="efternavn" /><param name="titel" />
	/// <param name="afdeling" /><param name="startDato" /><param name="slutDato" /><param name="beskæftigelsesdecimal" /><param name="jubi" /><param name="Afdelingskode" />
	public ViewKantine(string tjenestenummer,string cpr,string fornavn,string efternavn,string titel,string afdeling,DateTime startDato,DateTime slutDato,string beskæftigelsesdecimal,DateTime jubi,string Afdelingskode) {
		this.Tjenestenummer=tjenestenummer; this.Cpr=cpr; this.Fornavn=fornavn; this.Efternavn=efternavn; this.Titel=titel; this.Afdeling=afdeling; this.StartDato=startDato; this.SlutDato=slutDato;
		this.Beskæftigelsesdecimal=beskæftigelsesdecimal; this.Jubi=jubi; this.Afdelingskode=Afdelingskode; }

	/// <summary>Initializes an instance of ViewKantine, that accepts data from an existing ViewKantine</summary><param name="entity" />
	public ViewKantine(ViewKantine entity) { this.Tjenestenummer=entity.Tjenestenummer; this.Cpr=entity.Cpr; this.Fornavn=entity.Fornavn; this.Efternavn=entity.Efternavn; this.Titel=entity.Titel;
		this.Afdeling=entity.Afdeling; this.StartDato=entity.StartDato; this.SlutDato=entity.SlutDato;  this.Beskæftigelsesdecimal=entity.Beskæftigelsesdecimal; this.Jubi=entity.Jubi; this.Afdelingskode=entity.Afdelingskode; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Tjenestenummer")][XmlElement("Tjenestenummer")]
	public string Tjenestenummer { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Cpr")][XmlElement("Cpr")]
	public string Cpr { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Fornavn")][XmlElement("Fornavn")]
	public string Fornavn { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Efternavn")][XmlElement("Efternavn")]
	public string Efternavn { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Titel")][XmlElement("Titel")]
	public string Titel { get; set; } = null!;

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
	[JsonProperty("Beskæftigelsesdecimal")][XmlElement("Beskæftigelsesdecimal")]
	public string Beskæftigelsesdecimal { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Jubi")][XmlElement("Jubi")]
	public DateTime Jubi { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks />
	[JsonProperty("Afdelingskode")][XmlElement("Afdelingskode")]
	public string Afdelingskode { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	[JsonIgnore][XmlIgnore]
	public string CsvValue => this.Tjenestenummer+";"+this.Cpr+";"+this.Fornavn+";"+this.Efternavn+";"+this.Titel+";"+this.Afdeling+";"+this.StartDato.
		ToString("yyyy-MM-dd")+";"+this.SlutDato.ToString("yyyy-MM-dd")+";"+this.P+";"+this.Jubi.ToString("yyyy-MM-dd")+";"+this.Afdelingskode+"\r\n";

	/// <summary>Primary Occupation</summary>
	[JsonIgnore][XmlIgnore]
	public bool P { get; set; } = false;

	/// <summary>Primary Occupation</summary>
	[JsonIgnore][XmlIgnore]
	public string TKey => Tjenestenummer+"-"+Cpr;

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
