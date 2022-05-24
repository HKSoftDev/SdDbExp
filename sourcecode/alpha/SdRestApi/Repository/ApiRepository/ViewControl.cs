// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewContactInformationList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewControl
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Cpr;Tjenestenummer;Beskæftigelsesrate;Silo;Afdeling;Fornavn;Efternavn;Email1;Email2;DI_User\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewContactInformationList</summary>
	public ViewControl ()	{ }

	/// <summary>Initializes a new instance of ViewContactInformationList</summary><param name="cpr" /><param name="tjenestenr" /><param name="beskæftigelsesrate" /><param name="silo" />
	/// <param name="afdeling" /><param name="fornavn" /><param name="efternavn" /><param name="email1" /><param name="email2" />
	public ViewControl(string cpr,string tjenestenr,string beskæftigelsesrate,string silo,string afdeling,string fornavn,string efternavn,string email1,string email2) { this.Cpr=cpr; this.Tjenestenummer=tjenestenr;
		this.Beskæftigelsesrate=beskæftigelsesrate; this.Silo=silo; this.Afdeling=afdeling; this.Fornavn=fornavn; this.Efternavn=efternavn; this.Email1=email1; this.Email2=email2; }

	/// <summary>Initializes an instance of ViewContactInformationList, that accepts data from an existing ViewContactInformationList</summary><param name="entity" />
	public ViewControl(ViewControl entity) { this.Cpr=entity.Cpr; this.Tjenestenummer=entity.Tjenestenummer; this.Beskæftigelsesrate=entity.Beskæftigelsesrate; this.Silo=entity.Silo;
		this.Afdeling=entity.Afdeling; this.Fornavn=entity.Fornavn; this.Efternavn=entity.Efternavn; this.Email1=entity.Email1; this.Email2=entity.Email2; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Cpr")][XmlElement("Cpr")]
	public string Cpr { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Tjenestenummer")][XmlElement("Tjenestenummer")]
	public string Tjenestenummer { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Beskæftigelsesrate")][XmlElement("Beskæftigelsesrate")]
	public string Beskæftigelsesrate { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Silo")][XmlElement("Silo")]
	public string Silo { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Afdeling")][XmlElement("Afdeling")]
	public string Afdeling { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Fornavn")][XmlElement("Fornavn")]
	public string Fornavn { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Efternavn")][XmlElement("Efternavn")]
	public string Efternavn { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Email1")][XmlElement("Email1")]
	public string Email1 { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Email2")][XmlElement("Email2")]
	public string Email2 { get; set; } = null!;

	/// <remarks />
	[JsonProperty("DI_User")][XmlElement("DI_User")]
	public string DI_User { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Cpr+";"+this.Tjenestenummer+";"+this.Afdeling+";"+this.Fornavn+";"+this.Efternavn+";"+this.Email1+";"+Email2+";"+DI_User+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewControl creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Cpr>"+Cpr+"<\\Cpr>"+Environment.NewLine;
		result += "    <Tjenestenummer>"+Tjenestenummer+"<\\Tjenestenummer>"+Environment.NewLine;
		result += "    <Beskæftigelsesrate>"+Beskæftigelsesrate+"<\\Beskæftigelsesrate>"+Environment.NewLine;
		result += "    <Silo>"+Silo+"<\\Silo>"+Environment.NewLine;
		result += "    <Afdeling>"+Afdeling+"<\\Afdeling>"+Environment.NewLine;
		result += "    <Fornavn>"+Fornavn+"<\\Fornavn>"+Environment.NewLine;
		result += "    <Efternavn>"+Efternavn+"<\\Efternavn>"+Environment.NewLine;
		result += "    <Email1>"+Email1+"<\\Email1>"+Environment.NewLine;
		result += "    <Email2>"+Email2+"<\\Email2>"+Environment.NewLine;
		result += "    <DI_User>"+DI_User+"<\\DI_User>"+Environment.NewLine;
		result += "<\\ViewControl>"+Environment.NewLine; return result; }

	#endregion

}
