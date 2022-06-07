// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewPostalAddressList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewPostalAddress
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;ParentIdentifier;InstitutionIdentifier;StandardAddressIdentifier;PostalCode;DistrictName;MunicipalityCode;CountryIdentificationCode\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewPostalAddressList</summary>
	public ViewPostalAddress ()	{ }

	/// <summary>Initializes a new instance of ViewPostalAddressList</summary><param name="id" /><param name="parentIdentifier" /><param name="institutionId" /><param name="standardAddressIdentifier" />
	/// <param name="postalCode" /><param name="districtName" /><param name="municipalityCode" /><param name="countryIdCode" />
	public ViewPostalAddress(int id,string parentIdentifier,string institutionId,string standardAddressIdentifier,string postalCode,string districtName,string municipalityCode,string countryIdCode) {
		this.Id=id; this.ParentIdentifier=parentIdentifier; this.InstitutionIdentifier=institutionId; this.StandardAddressIdentifier=standardAddressIdentifier; this.PostalCode=postalCode; this.DistrictName=districtName;
		this.MunicipalityCode=municipalityCode; this.CountryIdentificationCode=countryIdCode; }

	/// <summary>Initializes an instance of ViewPostalAddressList, that accepts data from an existing ViewPostalAddressList</summary><param name="entity" />
	public ViewPostalAddress(ViewPostalAddress entity) { this.Id=entity.Id; this.ParentIdentifier=entity.ParentIdentifier; this.InstitutionIdentifier=entity.InstitutionIdentifier; this.StandardAddressIdentifier=
		entity.StandardAddressIdentifier; this.PostalCode=entity.PostalCode; this.DistrictName=entity.DistrictName; this.MunicipalityCode=entity.MunicipalityCode; this.CountryIdentificationCode=entity.CountryIdentificationCode; }

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
	[JsonProperty("StandardAddressIdentifier")][XmlElement("StandardAddressIdentifier")]
	public string StandardAddressIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("PostalCode")][XmlElement("PostalCode")]
	public string PostalCode { get; set; } = null!;

	/// <remarks />
	[JsonProperty("DistrictName")][XmlElement("DistrictName")]
	public string DistrictName { get; set; } = null!;

	/// <remarks />
	[JsonProperty("MunicipalityCode")][XmlElement("MunicipalityCode")]
	public string MunicipalityCode { get; set; } = null!;

	/// <remarks />
	[JsonProperty("CountryIdentificationCode")][XmlElement("CountryIdentificationCode")]
	public string CountryIdentificationCode { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.ParentIdentifier+";"+this.InstitutionIdentifier+";"+this.StandardAddressIdentifier+";"+this.PostalCode+";"+this.DistrictName+";"+this.MunicipalityCode+";"+this.CountryIdentificationCode+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewPostalAddress creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result += "    <ParentIdentifier>"+ParentIdentifier+"<\\ParentIdentifier>"+Environment.NewLine;
		result += "    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine;
		result += "    <StandardAddressIdentifier>"+StandardAddressIdentifier+"<\\StandardAddressIdentifier>"+Environment.NewLine;
		result += "    <PostalCode>"+PostalCode+"<\\PostalCode>"+Environment.NewLine;
		result += "    <DistrictName>"+DistrictName+"<\\DistrictName>"+Environment.NewLine;
		result += "    <MunicipalityCode>"+MunicipalityCode+"<\\MunicipalityCode>"+Environment.NewLine;
		result += "    <CountryIdentificationCode>"+CountryIdentificationCode+"<\\CountryIdentificationCode>"+Environment.NewLine;
		result += "<\\ViewPostalAddress>"+Environment.NewLine; return result; }

	#endregion

}
