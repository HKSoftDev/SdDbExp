// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsContactInformation.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks/>
[JsonObject("ContactInformation")][XmlType("ContactInformation")][Serializable]
public partial class WsContactInformation
{

	#region Constructors
	/// <summary>Initializes an empty instance of WsContactInformation</summary>
	public WsContactInformation() {  }

	/// <summary>Initializes a new instance of <see cref="ContactInformation"/></summary><param name="telephoneNumbers" /><param name="emailAddresses" />
	public WsContactInformation(List<string> telephoneNumbers, List<string> emailAddresses) { this.TelephoneNumbers=telephoneNumbers; this.EmailAddresses=emailAddresses;}

	/// <summary>Initializes a new instance of WsContactInformation, that accepts data from existing ContactInformation</summary><param name="info" />
	public WsContactInformation(WsContactInformation info) { this.TelephoneNumbers=info.TelephoneNumbers; this.EmailAddresses=info.EmailAddresses; }

	#endregion

	#region Properties

	/// <remarks/>
	[JsonProperty("TelephoneNumberIdentifier")][XmlElement("TelephoneNumberIdentifier")]
	public List<string> TelephoneNumbers { get; set; } = new();

	/// <remarks/>
	[JsonProperty("EmailAddressIdentifier")][XmlElement("EmailAddressIdentifier")]
	public List<string> EmailAddresses { get; set; } = new();

	#endregion

	#region Methods

	/// <summary>Copies content from lists to respective fields</summary><param name="parentId" /><param name="institutionId" />
	public ContactInformation ToContactInformation(string parentId,string institutionId) { if(this==null) throw new NullReferenceException(); string phone1=string.Empty;	string phone2=string.Empty;	string mail1=string.Empty; string mail2=string.Empty;
		switch (this.TelephoneNumbers.Count) { case <=0: phone1="00000000"; phone2="00000000"; break; case 1: phone1=TelephoneNumbers[0]; phone2="00000000"; break; default: phone1=TelephoneNumbers[0];phone2=TelephoneNumbers[1]; break; }
		switch (this.EmailAddresses.Count) { case <=0: mail1="Empty@Empty.Com"; mail2="Empty@Empty.Com"; break; case 1: mail1=EmailAddresses[0]; mail2="Empty@Empty.Com"; break;
			default: mail1=EmailAddresses[0]; mail2=EmailAddresses[1]; break; } return new(parentId,institutionId,phone1,phone2,mail1,mail2); }                         

	/// <returns>Content as string</returns>
	public override string ToString() { if (this==null) return "null"; else return "TelephoneNumbers: "+this.TelephoneNumbers.Count+" - EmailAddresses: "+this.EmailAddresses.Count;  }

	#endregion

}

