// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsPerson.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks/>
[JsonObject("Person")][XmlType("Person")][Serializable]
public class WsPerson
{
	#region Constructors

	/// <summary>Initializes an empty instance of WsPerson</summary>
	public WsPerson() { }

	/// <summary>Initializes a new instance of WsPerson</summary><param name="personCivilRegistrationId" /><param name="givenName">personGivenName</param>
	/// <param name="surName">personSurnameName</param><param name="institutionId" /><param name="postalAddress" /><param name="contactInformation" /><param name="list" />
	public WsPerson(string personCivilRegistrationId,string givenName,string surName,string institutionId,List<WsEmployment> list,WsPostalAddress? postalAddress=null,WsContactInformation? contactInformation=null) { 
		this.PersonCivilRegistrationIdentifier=personCivilRegistrationId;this.PersonGivenName=givenName;this.PersonSurnameName=surName;this.InstitutionIdentifier=institutionId;this.PostalAddress=postalAddress;
		this.ContactInformation=contactInformation; WsEmployments=list; }

	/// <summary>Initializes a new instance of WsPerson, that accepts data from an existing WsPerson</summary><param name="pers"></param>
	public WsPerson(WsPerson pers) { this.PersonCivilRegistrationIdentifier=pers.PersonCivilRegistrationIdentifier; this.PersonGivenName=pers.PersonGivenName; this.PersonSurnameName=pers.PersonSurnameName; 
		this.InstitutionIdentifier=pers.InstitutionIdentifier; this.PostalAddress=pers.PostalAddress; this.ContactInformation=pers.ContactInformation; this.WsEmployments=pers.WsEmployments;}

	#endregion

	#region Properties

	/// <remarks/>
	[JsonProperty("PersonCivilRegistrationIdentifier")][XmlElement("PersonCivilRegistrationIdentifier")]
	public string PersonCivilRegistrationIdentifier { get; set; } ="0101001234";

	/// <remarks/>
	[JsonProperty("PersonGivenName")][XmlElement("PersonGivenName")]
	public string PersonGivenName { get; set; } = "Sine";

	/// <remarks/>
	[JsonProperty("PersonSurnameName")][XmlElement("PersonSurnameName")]
	public string PersonSurnameName { get; set; } = "Nomine";

	/// <remarks/>
	[JsonIgnore()][XmlIgnore]
	public string InstitutionIdentifier { get; set; } = "NO";

	/// <remarks/>
	[JsonProperty("PostalAddress")][XmlElement("PostalAddress")]
	public WsPostalAddress? PostalAddress { get; set; } = null;

	/// <remarks/>
	[JsonProperty("ContactInformation")][XmlElement("ContactInformation")]
	public WsContactInformation? ContactInformation { get; set; } = null;

	/// <remarks/>
	[XmlElement("Employment")]
	public List<WsEmployment> WsEmployments { get; set; } = new();

	#endregion

	#region Method

	/// <returns>This WsPerson.WsContactInformation as ContactInformation</returns><exception cref="NullReferenceException" />
	public ContactInformation ToContactInformation() { if (this==null||this.ContactInformation==null) throw new NullReferenceException(); return this.ContactInformation.ToContactInformation(this.PersonCivilRegistrationIdentifier,
			this.InstitutionIdentifier); }

	/// <returns>This WsPerson as Person</returns><exception cref="NullReferenceException" /><exception cref="NullReferenceException" />
	public Person ToPerson() => new(this.PersonCivilRegistrationIdentifier,this.PersonGivenName,this.PersonSurnameName,this.InstitutionIdentifier);

	/// <returns>This WsPerson.WsPostalAddress as PostalAddress</returns><exception cref="NullReferenceException" />
	public PostalAddress ToPostalAddress() { if (this==null||this.PostalAddress==null) throw new NullReferenceException(); return this.PostalAddress.ToPostalAddress(this.PersonCivilRegistrationIdentifier,
		this.InstitutionIdentifier); }

	/// <returns>Content of Person as string</returns>
	public override string ToString() { if(this==null) return "null"; else return this.PersonGivenName+" "+this.PersonSurnameName+" ("+this.InstitutionIdentifier+"-"+this.PersonCivilRegistrationIdentifier+")"; }

	#endregion

}
