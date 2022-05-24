// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsOrganization.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks/>
[JsonObject("Organization")][XmlType("Organization")][Serializable]
public class WsOrganization
{

	#region Constructors

	/// <summary>Initializes an empty instance of Organization</summary>
	public WsOrganization() { }

	/// <summary>Initializes a new instance of Organization</summary><param name="activationDate" /><param name="deactivationDate" /><param name="institutionId" /><param name="list"></param>
	public WsOrganization(string activationDate,string deactivationDate,List<WsDepartmentReference> list,string institutionId="NO") {
		this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.InstitutionIdentifier=institutionId; this.WsDepartmentReferences=list; }

	/// <summary>Initializes a new instance of Organization, that accepts data from <paramref name="entity"/></summary><param name="entity" />
	public WsOrganization(WsOrganization entity) { this.ActivationDate=entity.ActivationDate; this.DeactivationDate=entity.DeactivationDate;this.InstitutionIdentifier=entity.InstitutionIdentifier; this.WsDepartmentReferences=entity.WsDepartmentReferences; }

	#endregion

	#region Properties

	/// <remarks/>
	[JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
	public string ActivationDate { get; set; } = "2010-01-01";

	/// <remarks/>
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public string DeactivationDate { get; set; } = "9999-12-31";

	/// <remarks/>
	[JsonIgnore()][XmlIgnore]
	public string InstitutionIdentifier { get; set; } = "NO"; // Based on InstitutionIdentifier in GetOrganization20111201

	/// <remarks/>
	[JsonProperty("DepartmentReference")][XmlElement("DepartmentReference")]
	public List<WsDepartmentReference> WsDepartmentReferences { get; set; } = new();

	#endregion

	#region Methods

	/// <returns>This WsOrganizatio as Organization</returns>
	public Organization ToOrganization() => new(this.ActivationDate,this.DeactivationDate,this.InstitutionIdentifier);

	/// <returns>Content of this DepartmentReference as string</returns>
	public override string ToString() { if (this==null) return "null"; else return this.InstitutionIdentifier; }

	#endregion



}

