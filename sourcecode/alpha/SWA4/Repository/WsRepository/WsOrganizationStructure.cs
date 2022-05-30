// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsOrganizationStructure.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <summary>Principally receives no data from SDWS, except related departmentreferencces</summary>
[JsonObject("OrganizationStructure")][XmlType("OrganizationStructure")][Serializable]
public class WsOrganizationStructure
{
	#region Constructors

	/// <summary>Initializes an empty instance of OrganizationStructure</summary>
	public WsOrganizationStructure() { }

	/// <summary>Initializes a new instance of OrganizationStructure</summary><param name="institutionId" /><param name="list" />
	public WsOrganizationStructure(string institutionId,List<WsDepartmentLevelReference>? list=null) {
		this.InstitutionIdentifier=institutionId; if (list!=null) this.WsDepartmentLevelReferences=list; }

	/// <summary>Initializes a new instance of OrganizationStructure, that accepts data from an existing OrganizationStructure</summary><param name="entity" />
	public WsOrganizationStructure(WsOrganizationStructure entity) { this.InstitutionIdentifier=entity.InstitutionIdentifier; this.WsDepartmentLevelReferences=entity.WsDepartmentLevelReferences; }

	#endregion

	#region Properties

	/// <remarks/>
	[JsonIgnore()][XmlIgnore]
	public string InstitutionIdentifier { get; set; } = "NO"; //Retrieved by InstitutionIdentifier/InstitutionUuidIdentifier in GetOrganization20111201

	/// <remarks/>
	[JsonProperty("DepartmentLevelReference")][XmlElement("DepartmentLevelReference")]
	public List<WsDepartmentLevelReference> WsDepartmentLevelReferences { get; set; } = new();

	#endregion

	#region Methods

	/// <returns>Trimmed copy of this OrganizationStructure</returns><exception cref="NullReferenceException" />
	public OrganizationStructure ToOrganizationStructure() { if(this==null) throw new NullReferenceException(); return new OrganizationStructure(this.InstitutionIdentifier); }

	#endregion

}

