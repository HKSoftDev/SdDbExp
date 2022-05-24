// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewContactInformationList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewContactInformation
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;ParentIdentifier;InstitutionIdentifier;TelephoneNumberIdentifier1;TelephoneNumberIdentifier2;EmailAddressIdentifier1;EmailAddressIdentifier2\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewContactInformationList</summary>
	public ViewContactInformation ()	{ }

	/// <summary>Initializes a new instance of ViewContactInformationList</summary><param name="id" /><param name="parentId" /><param name="institutionId" /><param name="tlf1" />
	/// <param name="tlf2" /><param name="email1" /><param name="email2" />
	public ViewContactInformation(int id,string parentId,string institutionId,string tlf1,string tlf2,string email1,string email2) {
		this.Id=id; this.ParentIdentifier=parentId; this.InstitutionIdentifier=institutionId; this.TelephoneNumberIdentifier1=tlf1;
		this.TelephoneNumberIdentifier2=tlf2; this.EmailAddressIdentifier1=email1; this.EmailAddressIdentifier2=email2; }

	/// <summary>Initializes an instance of ViewContactInformationList, that accepts data from an existing ViewContactInformationList</summary><param name="entity" />
	public ViewContactInformation(ViewContactInformation entity) { this.Id=entity.Id; this.ParentIdentifier=entity.ParentIdentifier; this.InstitutionIdentifier=entity.InstitutionIdentifier;
		this.TelephoneNumberIdentifier1=entity.TelephoneNumberIdentifier1; this.TelephoneNumberIdentifier2=entity.TelephoneNumberIdentifier2; this.EmailAddressIdentifier1=entity.EmailAddressIdentifier1;
		this.EmailAddressIdentifier2=entity.EmailAddressIdentifier2; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Id")][XmlElement("Id")]
	public int Id { get; set; }

	/// <remarks />
	[JsonProperty("ParentIdentifier")][XmlElement("ParentIdentifier")]
	public string ParentIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
	public string InstitutionIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("TelephoneNumberIdentifier1")][XmlElement("TelephoneNumberIdentifier1")]
	public string TelephoneNumberIdentifier1 { get; set; } = null!;

	/// <remarks />
	[JsonProperty("TelephoneNumberIdentifier2")][XmlElement("TelephoneNumberIdentifier2")]
	public string TelephoneNumberIdentifier2 { get; set; } = null!;

	/// <remarks />
	[JsonProperty("EmailAddressIdentifier1")][XmlElement("EmailAddressIdentifier1")]
	public string EmailAddressIdentifier1 { get; set; } = null!;

	/// <remarks />
	[JsonProperty("EmailAddressIdentifier2")][XmlElement("EmailAddressIdentifier2")]
	public string EmailAddressIdentifier2 { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.ParentIdentifier+";"+this.InstitutionIdentifier+";"+this.TelephoneNumberIdentifier1+";"+
		this.TelephoneNumberIdentifier2+";"+this.EmailAddressIdentifier1+";"+EmailAddressIdentifier2+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewContactInformation creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result += "    <ParentIdentifier>"+ParentIdentifier+"<\\ParentIdentifier>"+Environment.NewLine;
		result += "    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine;
		result += "    <TelephoneNumberIdentifier1>"+TelephoneNumberIdentifier1+"<\\TelephoneNumberIdentifier1>"+Environment.NewLine;
		result += "    <TelephoneNumberIdentifier2>"+TelephoneNumberIdentifier2+"<\\TelephoneNumberIdentifier2>"+Environment.NewLine;
		result += "    <EmailAddressIdentifier1>"+EmailAddressIdentifier1+"<\\EmailAddressIdentifier1>"+Environment.NewLine;
		result += "    <EmailAddressIdentifier2>"+EmailAddressIdentifier2+"<\\EmailAddressIdentifier2>"+Environment.NewLine;
		result += "<\\ViewContactInformation>"+Environment.NewLine; return result; }

	#endregion

}
