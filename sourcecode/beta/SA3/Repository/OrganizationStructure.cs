// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="OrganizationStructure.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public partial class OrganizationStructure
{
	#region Constructors

	/// <summary>Initializes an empty instance of OrganizationStructure</summary>
	public OrganizationStructure() { }

	/// <summary>Initializes a new instance of OrganizationStructure</summary><param name="institutionId" />
	public OrganizationStructure(string institutionId) { this.InstitutionIdentifier=institutionId; Validate(); }

	/// <summary>Initializes a new instance of OrganizationStructure from database</summary><param name="id" /><param name="institutionId" />
	public OrganizationStructure(int id,string institutionId) { this.Id=id; this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes a new instance of OrganizationStructure from database</summary><param name="array" />
	public OrganizationStructure(string[] array) { this.Id=int.Parse(array[0]); this.InstitutionIdentifier=array[2]; }

	/// <summary>Initializes a new instance of OrganizationStructure, that accepts data from an existing OrganizationStructure</summary><param name="entity" />
	public OrganizationStructure(OrganizationStructure entity) { this.Id=entity.Id; this.InstitutionIdentifier=entity.InstitutionIdentifier; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	public int Id { get; set; } = 0;

	/// <remarks/>
	public string InstitutionIdentifier { get; set; } = "NO";

	#endregion

	#region Other

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public static string CsvHeader => "Id;InstitutionIdentifier"+Environment.NewLine;

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.InstitutionIdentifier+Environment.NewLine;

	/// <returns>Delete OrganizationStructure SQL-query as string</returns><exception cref="NullReferenceException" /><exception cref="EmptyRefException" /><exception cref="InvalidRefException" />
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [dbo].[OrganizationStructureList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <returns>Insert OrganizationStructure SQL-query as string</returns><exception cref="NullReferenceException" /><exception cref="EmptyRefException" /><exception cref="InvalidRefException" />
	[NotMapped]
	public string SqlInsertQuery => @"INSERT INTO [dbo].[OrganizationStructureList]([InstitutionIdentifier]) VALUES('"+this.InstitutionIdentifier+"')"+Environment.NewLine;

	/// <returns>Select OrganizationStructure SQL-query as string</returns><exception cref="NullReferenceException" /><exception cref="EmptyRefException" /><exception cref="InvalidRefException" />
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [dbo].[OrganizationStructureList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <returns>Update OrganizationStructure SQL-query as string</returns><exception cref="NullReferenceException" /><exception cref="EmptyRefException" /><exception cref="InvalidRefException" />
	[NotMapped]
	public string SqlUpdateQuery => @"UPDATE [dbo].[OrganizationStructureList] SET [InstitutionIdentifier]='"+this.InstitutionIdentifier+@"' WHERE[Id]="+this.Id;

	/// <remarks/>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this OrganizationStructure to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(OrganizationStructure entity) { if(this==null||entity==null) return false; if (!this.InstitutionIdentifier.Equals(entity.InstitutionIdentifier)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if(this==null) return true; Validate(); if (!this.InstitutionIdentifier.Equals("NO")) return false; else return true; }

	/// <summary>Checks wether validation of this <see cref="OrganizationStructure"/> cause changes, that must be updated in database</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsUpdated() { if(this==null) throw new NullReferenceException(); OrganizationStructure valStruct=new(InstitutionIdentifier) { Id=this.Id}; if (!Equals(valStruct)) return true; else return false; }

	#endregion

	/// <returns>Content of OrganizationStructure as string</returns>
	public override string ToString() { if(this==null) return "null"; else return this.InstitutionIdentifier; }

	/// <summary>Validates data in this OrganizationStructure</summary><exception cref="NullReferenceException" />
	public void Validate() { if(this==null) throw new NullReferenceException(); if (string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) this.InstitutionIdentifier="NO"; }

	#endregion

}
