// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Organization.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public partial class Organization
{

	#region Fields

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public const string CsvHeader="Id;ActivationDate;DeactivationDate;InstitutionIdentifier\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of Organization</summary>
	public Organization() { }

	/// <summary>Initializes a new instance of Organization</summary><param name="activationDate" /><param name="deactivationDate" /><param name="institutionId" />
	public Organization(DateTime activationDate,DateTime deactivationDate,string institutionId) { this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.InstitutionIdentifier=institutionId; Validate(); }

	/// <summary>Initializes a new instance of Organization from SDWS</summary><param name="activationDate" /><param name="deactivationDate" /><param name="institutionId" />
	public Organization(string activationDate,string deactivationDate,string institutionId) { this.ActivationDate=DateTime.Parse(activationDate); this.DeactivationDate=DateTime.Parse(deactivationDate); this.InstitutionIdentifier=institutionId; Validate(); }

	/// <summary>Initializes an instance of Organization from database</summary><param name="id" /><param name="activationDate" /><param name="deactivationDate" /><param name="institutionId" />
	public Organization(int id, DateTime activationDate, DateTime deactivationDate,string institutionId) { this.Id=id; this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes a new instance of Organization from database</summary><param name="array" />
	public Organization(string[] array) { this.Id=int.Parse(array[0]); this.ActivationDate=Convert.ToDateTime(array[1]); this.DeactivationDate=Convert.ToDateTime(array[2]); this.InstitutionIdentifier=array[3]; }

	/// <summary>Initializes a new instance of Organization, that accepts data from an existing Organization</summary><param name="entity" />
	public Organization(Organization entity) { this.Id=entity.Id; this.ActivationDate=entity.ActivationDate; this.DeactivationDate=entity.DeactivationDate; this.InstitutionIdentifier=entity.InstitutionIdentifier; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	public int Id { get; set; } = 0;

	/// <remarks/>
	public DateTime ActivationDate { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks/>
	public DateTime DeactivationDate { get; set; } = DateTime.Parse("9999-12-31");

	/// <remarks/>
	public string InstitutionIdentifier { get; set; } = "NO";

	#endregion

	#region Other

	/// <remarks/>
	[NotMapped]
	public bool Active => IsActive();

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.ActivationDate.ToString("yyyy-MM-dd")+";"+this.DeactivationDate.ToString("yyyy-MM-dd")+";"+this.InstitutionIdentifier+"\r\n";

	/// <summary>Delete Organization SQL-query</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [dbo].[OrganizationList] WHERE [Id]="+this.Id+";\r\n";

	/// <summary>Insert Organization SQL-query</summary>
	[NotMapped]
	public string SqlInsertQuery => @"INSERT INTO [dbo].[OrganizationList]([ActivationDate],[DeactivationDate],[InstitutionIdentifier]) VALUES('"+this.ActivationDate.ToString("yyyy-MM-dd")+
		"','"+this.DeactivationDate.ToString("yyyy-MM-dd")+"','"+this.InstitutionIdentifier+"')\r\n";

	/// <summary>Select Organization SQL-query</summary>
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [dbo].[OrganizationList] WHERE [Id]="+this.Id+";\r\n";

	/// <summary>Update Organization SQL-query</summary>
	[NotMapped]
	public string SqlUpdateQuery => @"UPDATE [dbo].[OrganizationList] SET [ActivationDate]='"+this.ActivationDate.ToString("yyyy-MM-dd")+"',[DeactivationDate]='"+this.DeactivationDate.ToString("yyyy-MM-dd")+
		"',[InstitutionIdentifier]='"+this.InstitutionIdentifier+"' WHERE [Id]="+this.Id+"\r\n";

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this Organization to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(Organization entity) { if(this==null||entity==null) return false; if (!this.ActivationDate.Equals(entity.ActivationDate)) return false;
		else if (!this.DeactivationDate.Equals(entity.DeactivationDate)) return false; else if (!this.InstitutionIdentifier.Equals(entity.InstitutionIdentifier)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if(this==null) return true; Validate(); if (!this.InstitutionIdentifier.Equals("NO")) return false; else return true; }

	/// <summary>Check wether validation of this <see cref="Organization"/> cause changes, that must be updated in database</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsUpdated() { if(this==null) throw new NullReferenceException(); Organization valOrg=new(this.ActivationDate,this.DeactivationDate,this.InstitutionIdentifier) { Id=this.Id };
		if (!Equals(valOrg)) return true; else return false; }

	/// <remarks/>
	private bool IsActive() { if (this ==null) throw new NullReferenceException(); else if (ActivationDate <=DateTime.Today && DeactivationDate >=DateTime.Today) return true; else return false; }

	#endregion

	/// <returns>Content of this Organization as string</returns>
	public override string ToString() => this.InstitutionIdentifier+"("+this.ActivationDate+@"-"+this.DeactivationDate+")";

	/// <summary>Validates data in this Organization</summary><exception cref="NullReferenceException" />
	public void Validate() { if (string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) this.InstitutionIdentifier="NO";  }

	#endregion

}
