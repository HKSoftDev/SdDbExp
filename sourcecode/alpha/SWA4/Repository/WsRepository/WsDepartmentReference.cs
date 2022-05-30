// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsDepartmentReference.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks/>
[JsonObject("DepartmentReference")][XmlType("DepartmentReference")][Serializable]
public class WsDepartmentReference
{
	#region Constructors
	/// <summary>Initializes an empty instance of WsDepartmentReference</summary>
	public WsDepartmentReference() { }

	/// <summary>Initializes a new instance of WsDepartmentReference</summary><param name="departmentId" /><param name="departmentUuid"></param><param name="departmentLevelId" /><param name="list" />
	public WsDepartmentReference(string departmentId,string departmentUuid,string departmentLevelId,List<WsDepartmentReference> list) { this.DepartmentIdentifier=departmentId; 
		this.DepartmentUuidIdentifier=departmentUuid; this.DepartmentLevelIdentifier=departmentLevelId; this.WsDepartmentReferences=list; }

	/// <summary>Initializes a new instance of WsDepartmentReference, that accepts data from an existing DepartmentReference</summary><param name="entity" />
	public WsDepartmentReference(WsDepartmentReference entity) { this.DepartmentIdentifier=entity.DepartmentIdentifier; this.DepartmentUuidIdentifier=entity.DepartmentUuidIdentifier; 
		this.DepartmentLevelIdentifier=entity.DepartmentLevelIdentifier; this.WsDepartmentReferences=entity.WsDepartmentReferences; }


	#endregion

	#region Properties

	/// <remarks/>
	[JsonProperty("DepartmentIdentifier")][XmlElement("DepartmentIdentifier")]
	public string DepartmentIdentifier { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("DepartmentUUIDIdentifier")][XmlElement("DepartmentUUIDIdentifier")]
	public string DepartmentUuidIdentifier { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("DepartmentLevelIdentifier")][XmlElement("DepartmentLevelIdentifier")]
	public string DepartmentLevelIdentifier { get; set; } = string.Empty;

	/// <summary>Aka. InstitutionIdentifier</summary>
	[JsonIgnore()][XmlIgnore]
	public string Organization { get; set; } = "NO";

	/// <summary>Aka. DepartmentUuidIdentifierIdentifier</summary>
	[JsonIgnore()][XmlIgnore]
	public string SeniorDepartmentReference = string.Empty;

	/// <remarks/>
	[JsonProperty("DepartmentReference")][XmlElement("DepartmentReference")]
	public List<WsDepartmentReference> WsDepartmentReferences { get; set; } = new();

	#endregion

	#region Methods

	/// <returns>Result as DepartmentReference</returns>
	public DepartmentReference ToDepartmentReference() => new(this.DepartmentIdentifier,this.DepartmentUuidIdentifier,this.DepartmentLevelIdentifier,this.Organization,this.SeniorDepartmentReference);

	/// <returns>Content of this DepartmentReference as string</returns>
	public override string ToString() { if (this==null) return "null"; else return this.DepartmentIdentifier+"-"+this.DepartmentUuidIdentifier+"-"+this.DepartmentLevelIdentifier+"DepartmentReferences: "+this.WsDepartmentReferences.Count; }

	#endregion

}

