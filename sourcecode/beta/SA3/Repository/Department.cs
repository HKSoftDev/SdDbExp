// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Department.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public partial class Department
{

	#region Fields

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public const string CsvHeader="Id;ActivationDate;DeactivationDate;DepartmentUuidIdentifier;DepartmentIdentifier;DepartmentLevelIdentifier;DepartmentName;ProductionUnitIdentifier;InstitutionIdentifier\r\n";

	private string departmentIdentifier="0NONE", departmentLevelIdentifier="NY0-niveau", departmentName="None";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of Department</summary>
	public Department() { }

	/// <summary>Initializes a new instance of Department from database</summary><param name="activationDate" /><param name="deactivationDate" /><param name="departmentUuid" />
	/// <param name="departmentId" /><param name="departmentLevelId" /><param name="departmentName" /><param name="productionUnitId" /><param name="institutionId" />
	public Department(DateTime activationDate,DateTime deactivationDate,string departmentUuid,string departmentId,string departmentLevelId,string departmentName,string productionUnitId,string institutionId) {
		this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.DepartmentUuidIdentifier=departmentUuid; this.departmentIdentifier=departmentId.Replace("'","′"); this.departmentLevelIdentifier=
			departmentLevelId.Replace("'","′"); this.departmentName=departmentName.Replace("'","′"); this.ProductionUnitIdentifier=productionUnitId; this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes a new instance of Department from database</summary><param name="activationDate" /><param name="deactivationDate" /><param name="departmentUuid" />
	/// <param name="departmentId" /><param name="departmentLevelId" /><param name="departmentName" /><param name="productionUnitId" /><param name="institutionId" />
	public Department(string activationDate,string deactivationDate,string departmentUuid,string departmentId,string departmentLevelId,string departmentName,string productionUnitId,string institutionId) {
		this.ActivationDate=DateTime.Parse(activationDate); this.DeactivationDate=DateTime.Parse(deactivationDate); this.DepartmentUuidIdentifier=departmentUuid; this.departmentIdentifier=departmentId.Replace("'","′");
		this.departmentLevelIdentifier=departmentLevelId.Replace("'","′"); this.departmentName=departmentName.Replace("'","′"); this.ProductionUnitIdentifier=productionUnitId; this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes a new instance of Department from database</summary><param name="id" /><param name="activationDate" /><param name="deactivationDate" /><param name="departmentUuid" />
	/// <param name="departmentId" /><param name="departmentLevelId" /><param name="departmentName" /><param name="productionUnitId" /><param name="institutionId" />
	public Department(int id,DateTime activationDate, DateTime deactivationDate, string departmentUuid, string departmentId, string departmentLevelId, string departmentName, string productionUnitId, string institutionId) {
		this.Id=id; this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.DepartmentUuidIdentifier=departmentUuid; this.departmentIdentifier=departmentId.Replace("'", "′");
		this.departmentLevelIdentifier=departmentLevelId.Replace("'", "′"); this.departmentName=departmentName.Replace("'", "′"); this.ProductionUnitIdentifier=productionUnitId; this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes a new instance of Department from database</summary><param name="id" /><param name="activationDate" /><param name="deactivationDate" /><param name="departmentUuid" />
	/// <param name="departmentId" /><param name="departmentLevelId" /><param name="departmentName" /><param name="productionUnitId" /><param name="institutionId" />
	public Department(string id, string activationDate, string deactivationDate, string departmentUuid, string departmentId, string departmentLevelId, string departmentName, string productionUnitId, string institutionId) {
		this.Id=int.Parse(id); this.ActivationDate=DateTime.Parse(activationDate); this.DeactivationDate=DateTime.Parse(deactivationDate); this.DepartmentUuidIdentifier=departmentUuid;
		this.departmentIdentifier=departmentId.Replace("'", "′"); this.departmentLevelIdentifier=departmentLevelId.Replace("'", "′"); this.departmentName=departmentName.Replace("'", "′"); 
		this.ProductionUnitIdentifier=productionUnitId; this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes a new instance of Department,that accepts data from existing Department</summary><param name="dept" />
	public Department(Department dept) { this.ActivationDate=dept.ActivationDate; this.DeactivationDate=dept.DeactivationDate; this.DepartmentUuidIdentifier=dept.DepartmentUuidIdentifier;
		this.departmentIdentifier=dept.DepartmentIdentifier; this.departmentLevelIdentifier=dept.DepartmentLevelIdentifier; this.departmentName=dept.DepartmentName; this.ProductionUnitIdentifier=
			dept.ProductionUnitIdentifier;this.InstitutionIdentifier=dept.InstitutionIdentifier; }

	/// <summary>Initializes a new instance of EmploymentDepartment from database</summary><param name="array" />
	public Department(string[] array) { this.Id=int.Parse(array[0]); this.ActivationDate=DateTime.Parse(array[1]); this.DeactivationDate=DateTime.Parse(array[2]); this.DepartmentUuidIdentifier=array[3];
		this.DepartmentIdentifier=array[4]; this.DepartmentLevelIdentifier=array[5]; this.DepartmentName=array[6]; this.ProductionUnitIdentifier =array[7]; this.InstitutionIdentifier=array[8]; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	public int Id { get; set; }=0;

	/// <remarks />
	public DateTime ActivationDate { get; set; }=DateTime.Parse("2010-01-01");

	/// <remarks />
	public DateTime DeactivationDate { get; set; }=DateTime.Parse("9999-12-31");

	/// <remarks />
	public string DepartmentUuidIdentifier { get; set; }="00000000-0000-0000-0000-000000000000";

	/// <remarks />
	public string DepartmentIdentifier { get => departmentIdentifier; set => departmentIdentifier=value.Replace("'","′"); }

	/// <remarks />
	public string DepartmentLevelIdentifier { get => departmentLevelIdentifier; set => departmentLevelIdentifier=value.Replace("'","′"); }

	/// <remarks />
	public string DepartmentName { get => departmentName; set => departmentName=value.Replace("'","′"); }

	/// <remarks />
	public string ProductionUnitIdentifier { get; set; }="1000000000";

	/// <remarks/>
	public string InstitutionIdentifier { get; set; }="NO";

	#endregion

	#region Other

	/// <remarks />
	[NotMapped]
	public bool Active => IsActive();

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.ActivationDate.ToString("yyyy-MM-dd")+";"+this.DeactivationDate.ToString("yyyy-MM-dd")+";"+this.DepartmentUuidIdentifier+";"+this.departmentIdentifier+";" +
		this.departmentLevelIdentifier+";"+this.departmentName+";"+this.ProductionUnitIdentifier+";"+this.InstitutionIdentifier+";"+Environment.NewLine;

	/// <summary>Delete Department SQL-query</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [SD].[dbo].[DepartmentList] WHERE [Id]=" + this.Id+";"+Environment.NewLine;

	/// <summary>Insert Department SQL-query</summary>
	[NotMapped]
	public string SqlInsertQuery => @"INSERT INTO [SD].[dbo].[DepartmentList]([ActivationDate],[DeactivationDate],[DepartmentUuidIdentifier],[DepartmentIdentifier],[DepartmentLevelIdentifier]," +
		"[DepartmentName],[ProductionUnitIdentifier],[InstitutionIdentifier]) VALUES('"+this.ActivationDate.ToString("yyyy-MM-dd")+@"','"+this.DeactivationDate.ToString("yyyy-MM-dd")+@"','"+this.DepartmentUuidIdentifier +
		@"','"+this.DepartmentIdentifier+@"','"+this.DepartmentLevelIdentifier+@"','"+this.DepartmentName+@"','"+this.ProductionUnitIdentifier+@"','"+this.InstitutionIdentifier+@"')";

	/// <summary>Select Department SQL-query</summary>
	[NotMapped]
	public string SqlSelectQuery => @"DELETE FROM [SD].[dbo].[DepartmentList] WHERE [Id]=" + this.Id+";"+Environment.NewLine;

	/// <summary>Update Department SQL-query</summary>
	[NotMapped]
	public string SqlUpdateQuery => @"UPDATE [SD].[dbo].[DepartmentList] SET [ActivationDate]='"+this.ActivationDate.ToString("yyyy-MM-dd")+@"',[DeactivationDate]='"+this.DeactivationDate.ToString("yyyy-MM-dd") +
		"',[DepartmentUuidIdentifier]='"+this.DepartmentUuidIdentifier+@"',[DepartmentIdentifier]='"+this.DepartmentIdentifier.Replace("'", "′")+@"',[DepartmentLevelIdentifier]='"+this.DepartmentLevelIdentifier.Replace("'", "′")+
		@"',[DepartmentName]='"+this.DepartmentName.Replace("'", "′")+@"',[ProductionUnitIdentifier]='"+this.ProductionUnitIdentifier+@"',[InstitutionIdentifier]='"+this.InstitutionIdentifier+@"' WHERE [Id]="+this.Id;

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier+"-"+this.DepartmentIdentifier;

	#endregion

	#endregion

	#region Methods
	/// <summary>Compares this Department to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(Department entity) { if(this==null||entity==null) return false; if (!this.ActivationDate.Equals(entity.ActivationDate)) return false;
		else if (!this.DeactivationDate.Equals(entity.DeactivationDate)) return false; else if (!this.DepartmentUuidIdentifier.Equals(entity.DepartmentUuidIdentifier)) return false;
		else if (!this.departmentIdentifier.Equals(entity.DepartmentIdentifier)) return false; else if (!this.departmentLevelIdentifier.Equals(entity.DepartmentLevelIdentifier)) return false;
		else if (!this.departmentName.Equals(entity.DepartmentName)) return false; else if (!this.ProductionUnitIdentifier.Equals(entity.ProductionUnitIdentifier)) return false;
		else if (!this.InstitutionIdentifier.Equals(entity.InstitutionIdentifier)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if (this ==null) throw new NullReferenceException(); Validate(); if (!this.DepartmentUuidIdentifier.Equals("00000000-0000-0000-0000-000000000000")&&
		!this.DepartmentIdentifier.Equals("0NONE")&&!this.InstitutionIdentifier.Equals("NO")) return false; else return true; }

	/// <summary>Check wether validation of this Department cause changes,that must be updated in database</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsUpdated() { if (this ==null) throw new NullReferenceException(); Department valDept =new(this.ActivationDate, this.DeactivationDate, this.DepartmentUuidIdentifier, this.departmentIdentifier,
		this.departmentLevelIdentifier, this.departmentName, this.ProductionUnitIdentifier, this.InstitutionIdentifier) { Id =this.Id }; if (!Equals(valDept)) return true; else return false; }

	/// <remarks/>
	private bool IsActive() { if (this ==null) throw new NullReferenceException(); else if (ActivationDate <=DateTime.Today && DeactivationDate >=DateTime.Today) return true; else return false; }

	#endregion

	/// <returns>Content of this Department as string</returns>
	public override string ToString() { if(this==null) return "null"; else return this.departmentName+" ("+this.InstitutionIdentifier+"-"+this.departmentIdentifier+")"; }

	/// <summary>Validates data in this Department</summary><exception cref="NullReferenceException" />
	public virtual void Validate() { if(this==null) throw new NullReferenceException(); 
		if (string.IsNullOrWhiteSpace(this.DepartmentUuidIdentifier)) this.DepartmentUuidIdentifier="00000000-0000-0000-0000-000000000000";
		if (string.IsNullOrWhiteSpace(this.departmentIdentifier)) this.departmentIdentifier="0None"; else this.departmentIdentifier=this.departmentIdentifier.Replace("'","′");
		if (string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) this.InstitutionIdentifier="NO"; }

	#endregion

}
