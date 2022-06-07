// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewOrganizationList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewOrganization
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;ActivationDate;DeactivationDate;InstitutionIdentifier\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewOrganizationList</summary>
	public ViewOrganization ()	{ }

	/// <summary>Initializes a new instance of ViewOrganizationList</summary><param name="id" /><param name="activationDate" /><param name="deactivationDate" /><param name="institutionId" />
	public ViewOrganization(int id,DateTime activationDate,DateTime deactivationDate,string institutionId) { this.Id=id; this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes an instance of ViewOrganizationList, that accepts data from an existing ViewOrganizationList</summary><param name="entity" />
	public ViewOrganization(ViewOrganization entity) { this.Id=entity.Id; this.ActivationDate=entity.ActivationDate; this.DeactivationDate=entity.DeactivationDate; this.InstitutionIdentifier=entity.InstitutionIdentifier; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Id")][XmlElement("Id")]
	public int Id { get; set; }

	/// <remarks />
	[JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
	public DateTime ActivationDate { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks />
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public DateTime DeactivationDate { get; set; } = DateTime.Parse("9999-12-31");

	/// <remarks />
	[JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
	public string InstitutionIdentifier { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.ActivationDate.ToString("yyyy-MM-dd")+";"+this.DeactivationDate.ToString("yyyy-MM-dd")+";"+this.InstitutionIdentifier+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewOrganization creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result += "    <ActivationDate>"+ActivationDate.ToString("yyyy-MM-dd")+"<\\ActivationDate>"+Environment.NewLine;
		result += "    <DeactivationDate>"+DeactivationDate.ToString("yyyy-MM-dd")+"<\\DeactivationDate>"+Environment.NewLine;
		result += "    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine;
		result += "<\\ViewOrganization>"+Environment.NewLine; return result; }

	#endregion

}
