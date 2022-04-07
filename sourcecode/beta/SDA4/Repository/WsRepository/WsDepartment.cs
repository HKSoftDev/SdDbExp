// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsDepartment.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks/>
[JsonObject("Department")][XmlType("Department")][Serializable]
public class WsDepartment
{
	#region Constructors

	/// <summary>Initializes an empty instance of Department</summary>
	public WsDepartment() { }

	/// <summary>Initializes a new instance of Department</summary><param name="activationDate" /><param name="deactivationDate" /><param name="departmentUuid" />
	/// <param name="departmentId" /><param name="departmentLevelId" /><param name="departmentName" /><param name="productionUnitId" /><param name="institutionId" />
	/// <param name="postalAddress" /><param name="contactInfo" />
	public WsDepartment(string activationDate,string deactivationDate,string departmentUuid,string departmentId,string departmentLevelId,string departmentName,string productionUnitId,
		string institutionId,WsPostalAddress? postalAddress=null,WsContactInformation? contactInfo=null) { this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate;
		this.DepartmentUuidIdentifier=departmentUuid; this.DepartmentIdentifier=departmentId; this.DepartmentLevelIdentifier=departmentLevelId; this.DepartmentName=departmentName; 
		this.ProductionUnitIdentifier=productionUnitId; this.InstitutionIdentifier=institutionId; this.PostalAddress=postalAddress; this.ContactInformation=contactInfo; }

	/// <summary>Initializes a new instance of Department, that accepts data from existing Department</summary><param name="department" />
	public WsDepartment(WsDepartment department) { this.ActivationDate=department.ActivationDate; this.DeactivationDate=department.DeactivationDate; this.DepartmentUuidIdentifier=department.DepartmentUuidIdentifier; 
		this.DepartmentIdentifier=department.DepartmentIdentifier; this.DepartmentLevelIdentifier=department.DepartmentLevelIdentifier; this.DepartmentName=department.DepartmentName; this.ProductionUnitIdentifier=department.ProductionUnitIdentifier; 
		this.InstitutionIdentifier=department.InstitutionIdentifier; this.PostalAddress=department.PostalAddress; this.ContactInformation=department.ContactInformation; }

	#endregion

	#region Properties

	/// <remarks />
	[JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
	public string ActivationDate { get; set; } = "2010-01-01";

	/// <remarks />
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public string DeactivationDate { get; set; } = "9999-12-31";

	/// <remarks />
	[JsonProperty("DepartmentUUIDIdentifier")][XmlElement("DepartmentUUIDIdentifier")]
	public string DepartmentUuidIdentifier { get; set; } = "00000000-0000-0000-0000-000000000000";

	/// <remarks />
	[JsonProperty("DepartmentIdentifier")][XmlElement("DepartmentIdentifier")]
	public string DepartmentIdentifier { get; set; } = "0NONE";

	/// <remarks />
	[JsonProperty("DepartmentLevelIdentifier")][XmlElement("DepartmentLevelIdentifier")]
	public string DepartmentLevelIdentifier { get; set; } = "NY0-niveau";

	/// <remarks />
	[JsonProperty("DepartmentName")][XmlElement("DepartmentName")]
	public string DepartmentName { get; set; } = "NONE";

	/// <remarks />
	[JsonProperty("ProductionUnitIdentifier")][XmlElement("ProductionUnitIdentifier")]
	public string ProductionUnitIdentifier { get; set; } = "1000000000";

	/// <remarks/>
	[JsonIgnore()][XmlIgnore]
	public string InstitutionIdentifier { get; set; } = "NO"; //Retrieved from InstitutionIdentifier in GetDepartment20111201

	/// <remarks/>
	[JsonProperty("PostalAddress")][XmlElement("PostalAddress")]
	public WsPostalAddress? PostalAddress { get; set; }

	/// <remarks/>
	[JsonProperty("ContactInformation")][XmlElement("ContactInformation")]
	public WsContactInformation? ContactInformation { get; set; }

	#endregion

	#region Methods

	/// <returns>This WsDepartment.WsContactInformation as ContactInformation</returns><exception cref="NullReferenceException" />
	public virtual ContactInformation ToContactInformation() { if (this==null||this.ContactInformation==null) throw new NullReferenceException(); return this.ContactInformation.ToContactInformation(this.DepartmentIdentifier,
			this.InstitutionIdentifier); }

	/// <returns>This WsDepartment as Department</returns><exception cref="NullReferenceException" />
	public virtual Department ToDepartment() { if (this==null) throw new NullReferenceException(); return new(this.ActivationDate,this.DeactivationDate, this.DepartmentUuidIdentifier,
		this.DepartmentIdentifier,this.DepartmentLevelIdentifier,this.DepartmentName,this.ProductionUnitIdentifier,this.InstitutionIdentifier); }

	/// <returns>This WsDepartment as Department</returns><param name="institutionId" /><exception cref="NullReferenceException" />
	public virtual Department ToDepartment(string institutionId) { if (this==null) throw new NullReferenceException(); return new(this.ActivationDate,this.DeactivationDate, this.DepartmentUuidIdentifier,
		this.DepartmentIdentifier,this.DepartmentLevelIdentifier,this.DepartmentName,this.ProductionUnitIdentifier,institutionId); }

	/// <returns>This WsDepartment.WsPostalAddress as PostalAddress</returns><exception cref="NullReferenceException" />
	public virtual PostalAddress ToPostalAddress() { if (this==null||this.PostalAddress==null) throw new NullReferenceException(); return this.PostalAddress.ToPostalAddress(this.DepartmentIdentifier,
		this.InstitutionIdentifier); }

	/// <returns>Content of this Department as string</returns>
	public override string ToString() { if(this==null) return "null"; else return this.DepartmentName+" ("+this.InstitutionIdentifier+"-"+this.DepartmentIdentifier+")"; }

	#endregion

}

