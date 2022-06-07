// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SuccessfulRun.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks />
public partial class SuccessfulRun
{

	#region Fields

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public const string CsvHeader="Id;Institution;SdApi;RunDate\r\n";

	#endregion

	#region Constructors
	/// <summary>Initializes an empty instance of SuccessfulRun</summary>
	public SuccessfulRun() { }

/// <summary>Initializes a new instance of SuccessfulRun</summary><param name="institutionId" /><param name="sdApi" /><param name="runDate" />
	public SuccessfulRun(string institutionId, string sdApi,string runDate) { this.InstitutionIdentifier=institutionId; this.SdApi=sdApi; this.RunDate=runDate; }

	/// <summary>Initializes a new instance of SuccessfulRun from database</summary><param name="id" /><param name="institutionId" /><param name="sdApi" /><param name="runDate" />
	public SuccessfulRun(int id, string institutionId, string sdApi, string runDate) { this.Id=id; this.InstitutionIdentifier=institutionId; this.SdApi=sdApi; this.RunDate=runDate; }

	/// <summary>Initializes a new instance of SuccessfulRun from database</summary><param name="array" />
	public SuccessfulRun(string[] array) { this.Id=int.Parse(array[0]); this.InstitutionIdentifier=array[1]; this.SdApi=array[2]; this.RunDate=array[3]; }

	/// <summary>Initializes a new instance of SuccessfulRun, that accepts data from existing SuccessfulRun</summary><param name="entity" />
	public SuccessfulRun(SuccessfulRun entity) { this.Id=entity.Id; this.InstitutionIdentifier=entity.InstitutionIdentifier; this.SdApi=entity.SdApi; this.RunDate=entity.RunDate; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	public int Id { get; set; } = 0;

	/// <remarks />
	public string InstitutionIdentifier { get; set; } = "NO";

	/// <remarks />
	public string SdApi { get; set; } = string.Empty;

	/// <remarks />
	public string RunDate { get; set; } = "2010-01-01";

	#endregion

	#region Other

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.InstitutionIdentifier+";"+this.SdApi+";"+this.RunDate+Environment.NewLine;

	/// <summary>Delete SuccessfulRun SQL-query</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [dbo].[SuccessfulRunList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <summary>Select SuccessfulRun SQL-query</summary>
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [dbo].[SuccessfulRunList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <summary>[SD].[dbo].[UpdateOrCreateSuccessfulRun] @instId, @sdApi, @runDate</summary>
	[NotMapped]
	public string SqlUpdateOrCreateQuery => @"EXECUTE [SD].[dbo].[UpdateOrCreateSuccessfulRun] @instId='"+InstitutionIdentifier+"', @sdApi='"+SdApi+"', @runDate='"+RunDate+"'";

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier+"-"+this.SdApi;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this SuccessfulRun to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(SuccessfulRun entity) { if (this==null) return false; if (!Id.Equals(entity.Id)) return false; else if (!InstitutionIdentifier.Equals(entity.InstitutionIdentifier))
		return false; else if (!SdApi.Equals(entity.SdApi)) return false; else if (!RunDate.Equals(entity.RunDate)) return false; else return true; }

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if (this==null) throw new NullReferenceException(); if (this.Id>=1) return false; else if (!string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) return false;
		else if (!string.IsNullOrWhiteSpace(this.SdApi)) return false; else if (!this.RunDate.Equals(DateOnly.Parse("2010-01-01"))) return false; else return true; }

	/// <returns>Content of SuccessfulRun as a string</returns>
	public string ToLongString() { if(this==null) return "null"; else return "Successful Run: "+this.InstitutionIdentifier+"-"+this.SdApi+" ("+this.RunDate+")"; }

	/// <returns>Content of SuccessfulRun as a string</returns>
	public override string ToString() { if(this==null) return "null"; else return this.InstitutionIdentifier+"-"+this.SdApi+" ("+this.RunDate+")"; }

	#endregion

}
