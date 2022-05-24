// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Institution.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public partial class Institution
{
	#region Fields

	private string institutionName="None";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of Institution</summary>
	public Institution() { }

	/// <summary>Initializes a new instance of Institution</summary><param name="institutionUuid" /><param name="institutionId" /><param name="institutionName" />
	public Institution(string institutionUuid, string institutionId, string institutionName) { this.InstitutionUuidIdentifier=institutionUuid; this.InstitutionIdentifier=institutionId.Replace("'", "′");
		this.institutionName=institutionName.Replace("'", "′"); Validate(); }

	/// <summary>Initializes a new instance of Institution from database</summary><param name="id" /><param name="institutionUuid" /><param name="institutionId" /><param name="institutionName" />
	public Institution(int id, string institutionUuid, string institutionId, string institutionName) { this.Id=id; this.InstitutionUuidIdentifier=institutionUuid;
		this.InstitutionIdentifier=institutionId; this.institutionName=institutionName; }

	/// <summary>Initializes a new instance of Institution from database</summary><param name="array" />
	public Institution(string[] array) { this.Id=int.Parse(array[0]); this.InstitutionUuidIdentifier=array[1]; this.InstitutionIdentifier=array[2]; this.institutionName=array[3]; }

	/// <summary>Initializes a new instance of Institution, that accepts data from an existing Institution</summary><param name="entity" />
	public Institution(Institution entity) { this.Id=entity.Id; this.InstitutionUuidIdentifier=entity.InstitutionUuidIdentifier; this.InstitutionIdentifier=entity.InstitutionIdentifier; this.institutionName=entity.InstitutionName; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	public int Id { get; set; } = 0;

	/// <remarks />
	public string InstitutionUuidIdentifier { get; set; } = "00000000-0000-0000-0000-000000000000";

	/// <remarks />
	public string InstitutionIdentifier { get; set; } = "NO";

	/// <remarks />
	public string InstitutionName { get => institutionName; set => institutionName=value.Replace("'", "′"); }

	#endregion

	#region Other

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public static string CsvHeader => "Id;InstitutionUuidIdentifier;InstitutionIdentifier;InstitutionName;ProductionUnitIdentifier;PostalAddress;WorkingTime;ContactInformation"+Environment.NewLine;

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.InstitutionUuidIdentifier+";"+this.InstitutionIdentifier+";"+this.institutionName+Environment.NewLine;

	/// <summary>Delete Institution SQL-query</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [dbo].[InstitutionList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <summary>Select Institution SQL-query</summary>
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [dbo].[InstitutionList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <summary>Update Institution SQL-query </summary>
	[NotMapped]
	public string SqlUpdateOrCreateQuery => @"EXECUTE [SD].[dbo].[UpdateOrCreateInstitution] @instUuid='"+InstitutionUuidIdentifier+"', @instId='"+InstitutionIdentifier+"', @instName='"+InstitutionName+"'";

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this Institution to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool Equals(Institution entity) { if(this==null||entity==null) return false; if (!this.InstitutionUuidIdentifier.Equals(entity.InstitutionUuidIdentifier)) return false;
		else if (!this.InstitutionIdentifier.Equals(entity.InstitutionIdentifier)) return false; else if (!this.InstitutionName.Equals(entity.InstitutionName)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if(this==null) return true; Validate(); if (!this.InstitutionIdentifier.Equals("NO")&&!this.InstitutionUuidIdentifier.Equals("00000000-0000-0000-0000-000000000000")) return false; else return true; }

	/// <summary>Check wether validation of this Institution cause changes, that must be updated in database</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsUpdated() { if(this==null) throw new NullReferenceException(); Institution orgInst=new(this); Institution updInst=new(this.InstitutionUuidIdentifier, this.InstitutionIdentifier, this.InstitutionName) { Id = this.Id };
		if (!orgInst.Equals(updInst)) return true; else return false; }

	#endregion

	#region To something

	/// <returns>Content of this Institution as long string</returns>
	public string ToLongString() { if(this==null) return "null"; return "Id: "+this.Id+Environment.NewLine+"InstitutionUuidIdentifier: "+this.InstitutionUuidIdentifier+Environment.NewLine+
		"InstitutionIdentifier: "+this.InstitutionIdentifier+Environment.NewLine+"InstitutionName: "+this.InstitutionName+Environment.NewLine; }

	/// <returns>Content of this Institution as string</returns>
	public override string ToString() { if(this==null) return "null"; return this.InstitutionName+" ("+this.InstitutionIdentifier+")"; }

	/// <returns>This InstitutionIdentifier as two digit numeric string</returns><exception cref="NullReferenceException" />
	public string ToTwoDigitInstitutionIdentifier() { if(this==null) throw new NullReferenceException(); if(IsEmpty()) return "00"; if (string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) 
		return "00"; return this.InstitutionIdentifier switch { "HB" => "01", "HD" => "02", "HI" => "03", "HW" => "04", _ => "00", }; }

	#endregion

	/// <summary>Validates data in this Institution</summary><exception cref="NullReferenceException" />
	public void Validate() { if(this==null) throw new NullReferenceException(); if (string.IsNullOrWhiteSpace(this.InstitutionUuidIdentifier)) this.InstitutionUuidIdentifier="00000000-0000-0000-0000-000000000000";
		if (string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) this.InstitutionIdentifier="NO"; if (string.IsNullOrWhiteSpace(this.institutionName)) this.institutionName="None"; }

	#endregion

}
