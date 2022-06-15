// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DepartmentLevelReference.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public partial class DepartmentLevelReference
{
	#region Fields
	private string departmentLevelIdentifier="NY0-niveau";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of DepartmentLevelReference</summary>
	public DepartmentLevelReference() { }

	/// <summary>Initializes a new instance of DepartmentLevelReference</summary><param name="departmentLevelIdentifier" /><param name="organizationStructure" />
	/// <param name="seniorDepartmentLevelReference" />
	public DepartmentLevelReference(string departmentLevelIdentifier,string organizationStructure, string seniorDepartmentLevelReference="") {
		this.departmentLevelIdentifier=departmentLevelIdentifier.Replace("'", "′"); this.OrganizationStructure=organizationStructure; if (seniorDepartmentLevelReference!=null)
			this.SeniorDepartmentLevelReference=seniorDepartmentLevelReference; Validate(); }

	/// <summary>Initializes a new instance of DepartmentLevelReference from database</summary><param name="id" /><param name="departmentLevelIdentifier" />
	/// <param name="organizationStructure" /><param name="seniorDepartmentLevelReference" />
	public DepartmentLevelReference(int id, string departmentLevelIdentifier,string organizationStructure,string seniorDepartmentLevelReference="") {
		this.Id=id; this.departmentLevelIdentifier=departmentLevelIdentifier; this.OrganizationStructure=organizationStructure;
		if (seniorDepartmentLevelReference!=null) { this.SeniorDepartmentLevelReference=seniorDepartmentLevelReference; } }

	/// <summary>Initializes a new instance of DepartmentLevelReference from database</summary><param name="array" />
	public DepartmentLevelReference(string[] array) { this.Id=int.Parse(array[0]); this.departmentLevelIdentifier=array[1]; this.OrganizationStructure=array[2]; if (array[3]!=null) this.SeniorDepartmentLevelReference=array[3]; }

	/// <summary>Initializes a new instance of DepartmentLevelReference, that accepts data from an existing DepartmentLevelReference</summary><param name="entity" />
	public DepartmentLevelReference(DepartmentLevelReference entity) { this.Id=entity.Id; this.departmentLevelIdentifier=entity.DepartmentLevelIdentifier.Replace("'", "′");
		this.OrganizationStructure=entity.OrganizationStructure; this.SeniorDepartmentLevelReference=entity.SeniorDepartmentLevelReference; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	public int Id { get; set; } = 0;

	/// <remarks/>
	public string DepartmentLevelIdentifier { get => departmentLevelIdentifier; set => departmentLevelIdentifier=value.Replace("'", "′"); }

	/// <remarks/>
	public string OrganizationStructure { get; set; } = "NO";

	/// <remarks/>
	public string SeniorDepartmentLevelReference { get; set; } = string.Empty;

	#endregion

	#region Other

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public static string CsvHeader => "Id;DepartmentLevelIdentifier;OrganizationStructure;SeniorDepartmentLevelReference"+Environment.NewLine;

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.DepartmentLevelIdentifier+";"+this.OrganizationStructure+";"+this.SeniorDepartmentLevelReference??""+Environment.NewLine;

	/// <summary>Delete DepartmentLevelReference SQL-query</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [SD].[dbo].[DepartmentLevelReferenceList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <summary>Delete DepartmentLevelReference SQL-query</summary>
	[NotMapped]
	public string SqlInsertQuery => @"INSERT INTO [SD].[dbo].[DepartmentLevelReferenceList]([DepartmentLevelIdentifier],[OrganizationStructure],[SeniorDepartmentLevelReference]) VALUES('"+
		this.DepartmentLevelIdentifier+@"','"+this.OrganizationStructure+@"','"+this.SeniorDepartmentLevelReference+@"')";

	/// <summary>Select DepartmentLevelReference SQL-query</summary>
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [SD].[dbo].[DepartmentLevelReferenceList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <summary>Update DepartmentLevelReference SQL-query</summary>
	[NotMapped]
	public string SqlUpdateQuery => @"UPDATE [SD].[dbo].[DepartmentLevelReferenceList] SET [DepartmentLevelIdentifier]='"+this.DepartmentLevelIdentifier+@"',[OrganizationStructure]='"+
		this.OrganizationStructure+@"',[SeniorDepartmentLevelReference]='"+this.SeniorDepartmentLevelReference+@"' WHERE [Id]="+this.Id;

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.OrganizationStructure+"-"+this.DepartmentLevelIdentifier;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares DepartmentLevelReference to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(DepartmentLevelReference entity) { if(this==null) return false; if ((this.SeniorDepartmentLevelReference!=null&&entity.SeniorDepartmentLevelReference==null)||
			(this.SeniorDepartmentLevelReference==null&&entity.SeniorDepartmentLevelReference!=null)) return false; else if (this.SeniorDepartmentLevelReference!=null&&
				entity.SeniorDepartmentLevelReference!=null&&!this.SeniorDepartmentLevelReference.Equals(entity.SeniorDepartmentLevelReference)) return false;
		else if (!this.departmentLevelIdentifier.Equals(entity.DepartmentLevelIdentifier)) return false; else if (!this.OrganizationStructure.Equals(entity.OrganizationStructure)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns>
	public bool IsEmpty() { if(this==null) return true; Validate(); if (this.Id>=1) return false; if (!this.departmentLevelIdentifier.Equals("NY0-niveau")&&!this.OrganizationStructure.Equals("NO")) return false; else return true; }

	/// <summary>Check wether validation of this DepartmentLevelReference cause changes, that must be updated in database</summary><returns>Result as bool</returns>
	public bool IsUpdated() { DepartmentLevelReference valRef=new(this.departmentLevelIdentifier,this.OrganizationStructure,this.SeniorDepartmentLevelReference) { Id=this.Id };
		if (!Equals(valRef)) return true; else return false; }

	#endregion

	#region To something
	/// <returns>Content of this DepartmentLevelReference as a long string</returns>
	public string ToLongString() { if(this==null) return "null"; else return this.DepartmentLevelIdentifier+" ("+this.OrganizationStructure+") => "+this.SeniorDepartmentLevelReference??""; }

	/// <returns>Content of this DepartmentLevelReference as string</returns>
	public override string ToString() { if(this==null) return "null"; else return this.DepartmentLevelIdentifier; }

	#endregion

	/// <summary>Validates data in this DepartmentLevelReference</summary>
	public void Validate() { if(this==null) throw new NullReferenceException(); if (string.IsNullOrWhiteSpace(this.departmentLevelIdentifier)) this.departmentLevelIdentifier="NY0-niveau";
		else this.departmentLevelIdentifier=this.departmentLevelIdentifier.Replace("'", "′"); if (string.IsNullOrWhiteSpace(this.OrganizationStructure)) this.OrganizationStructure="NO"; }

	#endregion

}
