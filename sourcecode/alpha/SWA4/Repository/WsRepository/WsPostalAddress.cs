// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsPostalAddress.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks/>
[JsonObject("PostalAddress")][XmlType("PostalAddress")][Serializable]
public class WsPostalAddress
{
	#region Constructors
	/// <summary>Initializes an empty instance of PostalAddress</summary>
	public WsPostalAddress() { }

	/// <summary>Initializes a new instance of PostalAddress</summary><param name="road">StandardAddressIdentifier</param><param name="zip">PostalCode</param><param name="town">DistrictName</param><param name="munic">MunicipalityCode</param><param name="country">CountryIdentificationCode</param>
	public WsPostalAddress(string road, string zip, string town, string munic, string country) { this.StandardAddressIdentifier=road.Replace("'", "′"); this.PostalCode=zip;
		this.DistrictName=town.Replace("'", "′"); this.MunicipalityCode=munic; this.CountryIdentificationCode=country; }

	/// <summary>Initializes a new instance of PostalAddress, that accepts data from existing PostalAddress</summary><param name="addr" />
	public WsPostalAddress(WsPostalAddress addr) { this.StandardAddressIdentifier=addr.StandardAddressIdentifier; this.PostalCode=addr.PostalCode;
		this.DistrictName=addr.DistrictName; this.MunicipalityCode=addr.MunicipalityCode; this.CountryIdentificationCode=addr.CountryIdentificationCode; }

	#endregion

	#region Properties

	/// <remarks/>
	[JsonProperty("StandardAddressIdentifier")][XmlElement("StandardAddressIdentifier")]
	public string StandardAddressIdentifier { get; set; } = "**adresse Ubekendt**";

	/// <remarks/>
	[JsonProperty("PostalCode")][XmlElement("PostalCode")]
	public string PostalCode { get; set; } = "9999";

	/// <remarks/>
	[JsonProperty("DistrictName")][XmlElement("DistrictName")]
	public string DistrictName { get; set; } = "Ukendt";

	/// <remarks/>
	[JsonProperty("MunicipalityCode")][XmlElement("MunicipalityCode")]
	public string MunicipalityCode { get; set; } = "0000";

	/// <remarks/>
	[JsonProperty("CountryIdentificationCode")][XmlElement("CountryIdentificationCode")]
	public string CountryIdentificationCode { get; set; } = null!;

	#endregion

	#region Methods

	/// <returns>This WsPostalAddress as PostalAddress</returns><param name="parentId" /><param name="institutionId" />
	public PostalAddress ToPostalAddress(string parentId,string institutionId) => new(parentId,institutionId,this.StandardAddressIdentifier,this.PostalCode,this.DistrictName,this.MunicipalityCode,this.CountryIdentificationCode);

	/// <returns>Content of this PostalAddress as string</returns>
	public override string ToString() { if(this==null) return string.Empty; return this.StandardAddressIdentifier+"-"+this.PostalCode+" "+this.DistrictName+" - Kommune: "+this.MunicipalityCode+" - Land: "+this.CountryIdentificationCode; }

	#endregion

}

