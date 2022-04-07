// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DownloadPath.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public class DownloadPath
{
	#region Constructors
	/// <summary>Initializes an empty instance of DownloadPath</summary>
	public DownloadPath() { }

	/// <summary>Initializes a new instance of DownloadPath</summary><param name="instId">InstitutionIdentifier</param><param name="sdAapi" /><param name="path" /><param name="dTime">DownloadTime</param><param name="uTime">UpdateTime</param><param name="upd">Updated</param>
	public DownloadPath(string instId, string sdAapi, string path, string dTime="", string uTime="", bool upd=false) {
		this.InstitutionIdentifier=instId;this.SdApi=sdAapi; this.Path=path; this.DownloadTime=dTime; this.UpdateTime=uTime; this.Updated=upd; }

	/// <summary>Initializes an instance of DownloadPath from database</summary><param name="id" /><param name="instId">InstitutionIdentifier</param><param name="sdAapi" /><param name="path" /><param name="dTime">DownloadTime</param><param name="uTime">UpdateTime</param><param name="upd">Updated</param>
	public DownloadPath(int id, string instId, string sdAapi, string path, string dTime, string uTime, bool upd) { this.Id=id; this.InstitutionIdentifier=instId;
		this.SdApi=sdAapi; this.Path=path; this.DownloadTime=dTime; this.UpdateTime=uTime; this.Updated=upd; }

	/// <summary>Initializes a new instance of DownloadPath from database</summary><param name="array" />
	public DownloadPath(string[] array) { if (array.Length>=4) { this.Id=int.Parse(array[0]); this.InstitutionIdentifier=array[1]; this.SdApi=array[2]; this.Path=array[3]; }
		if (array.Length>=5) this.DownloadTime=array[4]; if (array.Length>=6)  this.UpdateTime=array[5]; if (array.Length>=7) this.Updated=bool.Parse(array[6]); }

	/// <summary>Initializes a new instance of DownloadPath, that accepts data from existing DownloadPath</summary><param name="path" /><exception cref="NullReferenceException" />
	public DownloadPath(DownloadPath path) { this.Id=path.Id; this.InstitutionIdentifier=path.InstitutionIdentifier; this.SdApi=path.SdApi;
		this.Path=path.Path; this.DownloadTime=path.DownloadTime; this.UpdateTime=path.UpdateTime; this.Updated=path.Updated; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	public int Id { get; set; } = 0;

	/// <remarks/>
	public string InstitutionIdentifier { get; set; } = "NO";

	/// <remarks/>
	public string SdApi { get; set; } = string.Empty;

	/// <remarks/>
	public string Path { get; set; } = string.Empty;

	/// <remarks/>
	public string DownloadTime { get; set; } = string.Empty;

	/// <remarks/>
	public string UpdateTime { get; set; } = string.Empty;

	/// <remarks/>
	public bool Updated { get; set; } = false;

	#endregion

	#region Other

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public static string CsvHeader => "Id;InstitutionIdentifier;SdApi;Path;DownloadTime;UpdateTime;Updated"+Environment.NewLine;

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.InstitutionIdentifier+";"+this.SdApi+";"+this.Path+";"+this.DownloadTime+";"+this.UpdateTime+";"+this.Updated.ToString()+Environment.NewLine;

	/// <remarks/>
	[NotMapped]
	public string PathIdentifier => InstitutionIdentifier+@"-"+SdApi+@"("+DownloadTime+@"-"+UpdateTime+@")";

	/// <summary>Delete DownloadPath SQL-query</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [dbo].[DownloadPathList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <summary>Insert DownloadPath SQL-query</summary>
	[NotMapped]
	public string SqlInsertQuery => @"INSERT INTO [dbo].[DownloadPathList]([Id],[InstitutionIdentifier],[Identifier],[Path],[DownloadTime],[UpdateTime],[Updated]) VALUES("+this.Id+@",'"+
		this.InstitutionIdentifier+@"','"+this.SdApi+@"','"+this.Path+@"',"+this.DownloadTime+@","+this.UpdateTime+@",'"+this.Updated.ToString()+"')";

	/// <summary>Select DownloadPath SQL-query</summary>
	[NotMapped]
	public string SqlSelectQuery => @"DELETE FROM [dbo].[DownloadPathList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <summary>Update DownloadPath SQL-query</summary>
	[NotMapped]
	public string SqlUpdateQuery => @"UPDATE [dbo].[DownloadPathList] SET [Path]='"+this.Path+@"',[DownloadTime]='"+this.DownloadTime+@"',[UpdateTime]='"+this.UpdateTime+@"',[Updated]='"+
		this.Updated.ToString()+@"' WHERE [Id]="+this.Id;

	/// <summary>Update DownloadPath ownloaded SQL-query</summary>
	[NotMapped]
	public string SqlUpdateDownloadedQuery => ToSqlUpdateDownloadedQuery();

	/// <summary>Update DownloadPath updated SQL-query</summary>
	[NotMapped]
	public string SqlUpdateUpdatedQuery => ToSqlUpdateUpdatedQuery();

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => InstitutionIdentifier+"-"+SdApi;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this DownloadPath to <paramref name="path"/></summary><param name="path" /><returns>Result as bool</returns>
	public bool Equals(DownloadPath path) { if(this==null) return false; if (!this.InstitutionIdentifier.Equals(path.InstitutionIdentifier)) return false;
		if (!this.SdApi.Equals(path.SdApi)) return false; if (!this.Path.Equals(path.Path)) return false; if (!this.DownloadTime.Equals(path.DownloadTime)) return false;
		if (!this.UpdateTime.Equals(path.UpdateTime)) return false; if (!this.Updated.Equals(path.Updated)) return false; else return true; }

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if(this==null) throw new NullReferenceException(); if (this.Id>=1) return false; if (!string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) return false;
		if (!string.IsNullOrWhiteSpace(this.SdApi)) return false; if (!string.IsNullOrWhiteSpace(this.Path)) return false; if (!string.IsNullOrWhiteSpace(this.DownloadTime)) return false;
		if (!string.IsNullOrWhiteSpace(this.UpdateTime)) return false; if (this.Updated.Equals(1)) return false; else return true; }

	#region Set

	/// <summary>Sets time, when file was downloaded to disc</summary>
	public void SetDownloadTime() => this.DownloadTime=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

	/// <summary>Sets time, when data was updated to database</summary>
	public void SetUpdateTime() => this.UpdateTime=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

	#endregion

	#region To something

	/// <returns>Content of this DownloadPath as a long string</returns>
	public string ToLongString() { if(this==null) return "null"; else return "InstitutionIdentifier: "+this.InstitutionIdentifier+" - SdApi: "+this.SdApi+
		" - Path: "+this.Path+" - DownloadTime: "+this.DownloadTime+" - UpdateTime: "+this.UpdateTime+" - Updated: "+this.Updated.ToString(); }

	/// <returns>Content of this DownloadPath as a multi line string</returns>
	public string ToMultiLineString() { if(this==null) return "null"; else return "InstitutionIdentifier: "+this.InstitutionIdentifier+Environment.NewLine+"SdApi: "+this.SdApi+Environment.NewLine+
		"Path: "+this.Path+Environment.NewLine+"DownloadTime: "+this.DownloadTime+Environment.NewLine+"UpdateTime: "+this.UpdateTime+Environment.NewLine+"Updated: "+this.Updated; }

	/// <returns>Content of this DownloadPath as string</returns>
	public override string ToString() { if(this==null) return "null"; else return "PathIdentifier: "+this.PathIdentifier+" Path: "+this.Path; }

	/// <returns>Update DownloadPath SQL-query as string</returns><exception cref="NullReferenceException" /><exception cref="EmptyRefException" /><exception cref="InvalidRefException" />
	private string ToSqlUpdateDownloadedQuery() { if(this==null) throw new NullReferenceException(); if (IsEmpty()) throw new EmptyRefException(GetType().Name,ToString(),GetType().Name+
		Error.CantBeEmpty); if (this.Id<1)throw new InvalidRefException(nameof(this.Id),this.Id,Error.InvUpdId);
		SetDownloadTime(); UpdateTime=string.Empty; Updated=false; return @"UPDATE [dbo].[DownloadPathList] SET [Path]='"+this.Path+@"',[DownloadTime]='"+this.DownloadTime+@"',[UpdateTime]='"+
			this.UpdateTime+@"',[Updated]='"+this.Updated.ToString()+@"' WHERE [Id]="+this.Id; }

	/// <returns>Update DownloadPath SQL-query as string</returns><exception cref="NullReferenceException" /><exception cref="EmptyRefException" /><exception cref="InvalidRefException" />
	private string ToSqlUpdateUpdatedQuery() { if(this==null) throw new NullReferenceException(); if (IsEmpty()) throw new EmptyRefException(GetType().Name,ToString(),GetType().Name+
		Error.CantBeEmpty); if (this.Id<1)throw new InvalidRefException(nameof(this.Id),this.Id,Error.InvUpdId); SetUpdateTime(); Updated=true; return @"UPDATE [dbo].[DownloadPathList] "+
			"SET [UpdateTime]='"+this.UpdateTime+@"',[Updated]='"+this.Updated.ToString()+@"' WHERE [Id]="+this.Id+Environment.NewLine; }

	#endregion

	#endregion

}
