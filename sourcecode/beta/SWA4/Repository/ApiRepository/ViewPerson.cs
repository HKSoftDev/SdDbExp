// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewPersonList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewPerson
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;PersonCivilRegistrationIdentifier;PersonGivenName;PersonSurnameName;InstitutionIdentifier\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewPersonList</summary>
	public ViewPerson ()	{ }

	/// <summary>Initializes a new instance of ViewPersonList</summary><param name="id" /><param name="cpr" /><param name="givenName" /><param name="surName" /><param name="institutionId" />
	public ViewPerson(int id,string cpr,string givenName,string surName,string institutionId) {
		this.Id=id; this.PersonCivilRegistrationIdentifier=cpr;  this.PersonGivenName=givenName; this.PersonSurnameName=surName;this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes an instance of ViewPersonList, that accepts data from an existing ViewPersonList</summary><param name="entity" />
	public ViewPerson(ViewPerson entity) { this.Id=entity.Id; this.PersonCivilRegistrationIdentifier=entity.PersonCivilRegistrationIdentifier; 
		 this.PersonGivenName=entity.PersonGivenName; this.PersonSurnameName=entity.PersonSurnameName;this.InstitutionIdentifier=entity.InstitutionIdentifier; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Id")][XmlElement("Id")]
	public int Id { get; set; }

	/// <remarks />
	[JsonProperty("PersonCivilRegistrationIdentifier")][XmlElement("PersonCivilRegistrationIdentifier")]
	public string PersonCivilRegistrationIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("PersonGivenName")][XmlElement("PersonGivenName")]
	public string PersonGivenName { get; set; } = null!;

	/// <remarks />
	[JsonProperty("PersonSurnameName")][XmlElement("PersonSurnameName")]
	public string PersonSurnameName { get; set; } = null!;

	/// <remarks />
	[JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
	public string InstitutionIdentifier { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.PersonCivilRegistrationIdentifier+";"+this.PersonGivenName+";"+this.PersonSurnameName+";"+this.InstitutionIdentifier+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewPerson creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result += "    <PersonCivilRegistrationIdentifier>"+PersonCivilRegistrationIdentifier+"<\\PersonCivilRegistrationIdentifier>"+Environment.NewLine;
		result += "    <PersonGivenName>"+PersonGivenName+"<\\PersonGivenName>"+Environment.NewLine;
		result += "    <PersonSurnameName>"+PersonSurnameName+"<\\PersonSurnameName>"+Environment.NewLine;
		result += "    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine;
		result += "<\\ViewPerson>"+Environment.NewLine; return result; }

	#endregion

}
