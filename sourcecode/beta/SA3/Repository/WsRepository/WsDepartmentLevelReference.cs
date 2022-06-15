// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsDepartmentLevelReference.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks/>
[JsonObject("DepartmentLevelReference")][XmlType("DepartmentLevelReference")][Serializable]
public partial class WsDepartmentLevelReference
{

	#region Constructors

	/// <summary>Initializes an empty instance of WsDepartmentLevelReference</summary>
	public WsDepartmentLevelReference() { }

	/// <summary>Initializes a new instance of WsDepartmentLevelReference</summary><param name="departmentLevelIdentifier" /><param name="organizationStructure" /><param name="list" /><param name="seniorDLR" />
	public WsDepartmentLevelReference(string departmentLevelIdentifier,string organizationStructure,string seniorDLR="",List<WsDepartmentLevelReference>? list=null) { this.DepartmentLevelIdentifier=
		departmentLevelIdentifier; this.OrganizationStructure=organizationStructure; this.SeniorDepartmentLevelReference=seniorDLR; if (list!=null) this.WsDepartmentLevelReferences=list; }

	/// <summary>Initializes a new instance of WsDepartmentLevelReference, that accepts data from an existing DepartmentLevelReference</summary><param name="entity" />
	public WsDepartmentLevelReference(WsDepartmentLevelReference entity) { this.DepartmentLevelIdentifier=entity.DepartmentLevelIdentifier; this.OrganizationStructure=entity.OrganizationStructure;
		this.SeniorDepartmentLevelReference=entity.SeniorDepartmentLevelReference; this.WsDepartmentLevelReferences=entity.WsDepartmentLevelReferences; }

	#endregion

	#region Properties

	/// <remarks/>
	[JsonProperty("DepartmentLevelIdentifier")][XmlElement("DepartmentLevelIdentifier")]
	public string DepartmentLevelIdentifier { get; set; } = "NY0-niveau";

	/// <summary>Aka. InstitutionIdentifier</summary>
	[JsonIgnore()][XmlIgnore]
	public string OrganizationStructure { get; set; } = "NO";

	/// <summary>Aka. DepartmentLevelIdentifier</summary>
	[JsonIgnore()][XmlIgnore]
	public string SeniorDepartmentLevelReference { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("DepartmentLevelReference")][XmlElement("DepartmentLevelReference")]
	public List<WsDepartmentLevelReference> WsDepartmentLevelReferences { get; set; } = new();

	#endregion

	#region Methods

	/// <returns>Trimmed copy of this DepartmentLevelReference</returns>
	public DepartmentLevelReference ToDepartmentLevelReference() => new DepartmentLevelReference(this.DepartmentLevelIdentifier,this.OrganizationStructure,this.SeniorDepartmentLevelReference);

	/// <returns>Content of this DepartmentLevelReference as string</returns>
	public override string ToString() { if(this==null) return "null"; else return "DepartmentLevelReferences: "+WsDepartmentLevelReferences.Count; }

	#endregion

}

