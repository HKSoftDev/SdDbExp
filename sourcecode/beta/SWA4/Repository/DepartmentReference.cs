// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentReference.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public partial class DepartmentReference
{
	#region Fields

	/// <remarks />
	[NotMapped]
	public const string CsvHeader="Id;DepartmentIdentifier;DepartmentUuidIdentifier;DepartmentLevelIdentifier;Organization;SeniorDepartmentReference\r\n";

	private string departmentIdentifier="0NONE", departmentLevelIdentifier="NY0-niveau";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of DepartmentReference</summary>
	public DepartmentReference() { }

	/// <summary>Initializes a new instance of DepartmentReference</summary><param name="departmentId" /><param name="departmentUuid"></param><param name="departmentLevelId" />
	/// <param name="organization" /><param name="seniorDepartmentReference" />
	public DepartmentReference(string departmentId, string departmentUuid, string departmentLevelId, string organization, string seniorDepartmentReference="") { 
		this.departmentIdentifier=departmentId.Replace("'", "′"); this.DepartmentUuidIdentifier=departmentUuid; this.departmentLevelIdentifier=departmentLevelId.Replace("'", "′"); 
		this.Organization=organization; if (!string.IsNullOrWhiteSpace(seniorDepartmentReference)) this.SeniorDepartmentReference=seniorDepartmentReference; Validate(); }

	/// <summary>Initializes a new instance of DepartmentReference from database</summary><param name="id" /><param name="departmentId" /><param name="departmentUuid" />
	/// <param name="departmentLevelId">DepartmentLevelIdentifier</param><param name="organization" /><param name="seniorDepartmentReference" />
	public DepartmentReference(int id,string departmentId,string departmentUuid,string departmentLevelId,string organization, string seniorDepartmentReference="") { this.Id=id;
		this.departmentIdentifier=departmentId; this.DepartmentUuidIdentifier=departmentUuid; this.departmentLevelIdentifier=departmentLevelId; this.Organization=organization; 
		if (!string.IsNullOrWhiteSpace(seniorDepartmentReference)) this.SeniorDepartmentReference=seniorDepartmentReference; }

	/// <summary>Initializes a new instance of DepartmentReference from database</summary><param name="array" />
	public DepartmentReference(string[] array) { this.Id=int.Parse(array[0]); this.departmentIdentifier=array[1]; this.DepartmentUuidIdentifier=array[2];
		this.departmentLevelIdentifier=array[3]; this.Organization=array[4]; if (string.IsNullOrWhiteSpace(array[5])) this.SeniorDepartmentReference=array[6]; }

	/// <summary>Initializes a new instance of DepartmentReference from database, that accepts data from an existing DepartmentReference</summary><param name="entity" />
	public DepartmentReference(DepartmentReference entity) { this.Id=entity.Id; this.departmentIdentifier=entity.DepartmentIdentifier; this.DepartmentUuidIdentifier=entity.DepartmentUuidIdentifier;
		this.departmentLevelIdentifier=entity.DepartmentLevelIdentifier; this.Organization=entity.Organization; this.SeniorDepartmentReference=entity.SeniorDepartmentReference; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	public int Id { get; set; } = 0;

	/// <remarks/>
	public string DepartmentIdentifier { get => departmentIdentifier; set => departmentIdentifier=value.Replace("'", "′"); }

	/// <remarks/>
	public string DepartmentUuidIdentifier { get; set; } = "00000000-0000-0000-0000-000000000000";

	/// <remarks/>
	public string DepartmentLevelIdentifier { get => departmentLevelIdentifier; set => departmentLevelIdentifier=value.Replace("'", "′"); }

	/// <remarks/>
	public string Organization { get; set; } = "NO";

	/// <remarks/>
	public string SeniorDepartmentReference { get; set; } = string.Empty;

	#endregion

	#region Other

	/// <remarks />
	[NotMapped]
	public string CsvValue => this.Id+";"+this.departmentIdentifier+";"+this.DepartmentUuidIdentifier+";"+this.DepartmentLevelIdentifier+";"+this.Organization+";"+this.SeniorDepartmentReference+"\r\n";

	/// <summary>DELETE FROM [dbo].[DepartmentReferenceList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [SD].[dbo].[DepartmentReferenceList] WHERE [Id]="+this.Id;

	/// <summary>SELECT * FROM [dbo].[DepartmentReferenceList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [SD].[dbo].[DepartmentReferenceList] WHERE [Id]="+this.Id;

	/// <summary>EXECUTE [SD].[dbo].[UpdateOrCreateDepartmentReference] @deptId, @deptUuid, @deptLevelId, @org, @senDeptRef</summary>
	[NotMapped]
	public string SqlUpdateOrCreateQuery => @"EXECUTE [SD].[dbo].[UpdateOrCreateDepartmentReference] @deptId'" + DepartmentIdentifier + "', @deptUuid'" + DepartmentUuidIdentifier + "', @deptLevelId'" + DepartmentLevelIdentifier + "', @org'" + Organization + "', @senDeptRef'" + SeniorDepartmentReference + "'";

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.Organization+"-"+this.DepartmentIdentifier;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this DepartmentReference to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(DepartmentReference entity) { if(this==null||entity==null) return false; if ((this.SeniorDepartmentReference!=null&&entity.SeniorDepartmentReference==null)||
			(this.SeniorDepartmentReference==null&& entity.SeniorDepartmentReference!=null)) return false; else if (this.SeniorDepartmentReference!=null&&
				entity.SeniorDepartmentReference!=null&&!this.SeniorDepartmentReference.Equals(entity.SeniorDepartmentReference)) return false;
		if (!this.departmentIdentifier.Equals(entity.DepartmentIdentifier)) return false; else if (!this.DepartmentUuidIdentifier.Equals(entity.DepartmentUuidIdentifier)) return false;
			else if (!this.departmentLevelIdentifier.Equals(entity.DepartmentLevelIdentifier)) return false; else if (!this.Organization.Equals(entity.Organization)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns>
	public bool IsEmpty() { if (this==null) return true; Validate(); if (!this.DepartmentIdentifier.Equals("0NONE")&&!this.DepartmentUuidIdentifier.Equals(
		"00000000-0000-0000-0000-000000000000")&&!this.Organization.Equals("NO")) return false; else return true; }

	/// <summary>Check wether validation of this DepartmentReference cause changes, that must be updated in database</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsUpdated() { if (this==null) throw new NullReferenceException(); DepartmentReference valRef=new(this.departmentIdentifier,this.DepartmentUuidIdentifier,
		this.departmentLevelIdentifier,this.Organization,this.SeniorDepartmentReference) { Id=this.Id }; if (!Equals(valRef)) return true; else return false; }

	#endregion

	#region To something

	/// <returns>Content of DepartmentReference as a long string</returns>
	public string ToLongString() { if (this==null) return "null"; return this.DepartmentIdentifier+"("+this.Organization+") => "+this.SeniorDepartmentReference??"null"; }

	/// <returns>Content of this DepartmentReference as string</returns>
	public override string ToString() { if (this==null) return "null"; else return this.departmentIdentifier; }

	#endregion

	/// <summary>Validates data in this <see cref="DepartmentReference"/></summary><exception cref="NullReferenceException" />
	public void Validate() { if (this==null) throw new NullReferenceException(); 
		if (string.IsNullOrWhiteSpace(this.departmentIdentifier)) this.departmentIdentifier="0None"; else this.departmentIdentifier=this.departmentIdentifier.Replace("'", "′");
		if (string.IsNullOrWhiteSpace(this.DepartmentUuidIdentifier)) this.DepartmentUuidIdentifier="00000000-0000-0000-0000-000000000000";
		if (string.IsNullOrWhiteSpace(this.departmentLevelIdentifier)) this.departmentLevelIdentifier="NY0-niveau"; else this.departmentIdentifier=this.departmentIdentifier.Replace("'", "′");
		if (string.IsNullOrWhiteSpace(this.Organization)) this.Organization="NO"; }

	#endregion

}
