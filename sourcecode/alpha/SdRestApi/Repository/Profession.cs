// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Profession.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public partial class Profession
{
	#region Fields

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public const string CsvHeader="Id;ActivationDate;DeactivationDate;JobPositionIdentifier;JobPositionName;JobPositionLevelCode;InstitutionIdentifier\r\n";

	private string jobPositionName="None";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of Profession</summary>
	public Profession() { }

	/// <summary>Initializes a new instance of Profession</summary><param name="activationDate" /><param name="deactivationDate" /><param name="jobPositionId" /><param name="jobPositionName" />
	/// <param name="jobPositionLevelCode" /><param name="institutionId" />
	public Profession(DateTime activationDate,DateTime deactivationDate,string jobPositionId,string jobPositionName,string jobPositionLevelCode,string institutionId) { 
		this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.JobPositionIdentifier=jobPositionId; this.jobPositionName=jobPositionName.Replace("'", "′");
		this.JobPositionLevelCode=jobPositionLevelCode; this.InstitutionIdentifier=institutionId; Validate(); }

	/// <summary>Initializes a new instance of Profession from SDWS</summary><param name="activationDate" /><param name="deactivationDate" /><param name="jobPositionId" /><param name="jobPositionName" />
	/// <param name="jobPositionLevelCode" /><param name="institutionId" />
	public Profession(string activationDate,string deactivationDate,string jobPositionId,string jobPositionName,string jobPositionLevelCode,string institutionId) { 
		this.ActivationDate=DateTime.Parse(activationDate); this.DeactivationDate=DateTime.Parse(deactivationDate); this.JobPositionIdentifier=jobPositionId;
		this.jobPositionName=jobPositionName.Replace("'", "′"); this.JobPositionLevelCode=jobPositionLevelCode; this.InstitutionIdentifier=institutionId; Validate(); }

	/// <summary>Initializes a new instance of Profession</summary><param name="id" /><param name="activationDate" /><param name="deactivationDate" /><param name="jobPositionId" /><param name="jobPositionName" />
	/// <param name="jobPositionLevelCode" /><param name="institutionId" />
	public Profession(int id,DateTime activationDate,DateTime deactivationDate,string jobPositionId,string jobPositionName,string jobPositionLevelCode,string institutionId) { 
		this.Id=id;this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.JobPositionIdentifier=jobPositionId; this.jobPositionName=jobPositionName.Replace("'", "′");
		this.JobPositionLevelCode=jobPositionLevelCode; this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes a new instance of Profession from SDWS</summary><param name="id" /><param name="activationDate" /><param name="deactivationDate" /><param name="jobPositionId" /><param name="jobPositionName" />
	/// <param name="jobPositionLevelCode" /><param name="institutionId" />
	public Profession(string id, string activationDate,string deactivationDate,string jobPositionId,string jobPositionName,string jobPositionLevelCode,string institutionId) { 
		this.Id=int.Parse(id); this.ActivationDate=DateTime.Parse(activationDate); this.DeactivationDate=DateTime.Parse(deactivationDate); this.JobPositionIdentifier=jobPositionId;
		this.jobPositionName=jobPositionName.Replace("'", "′"); this.JobPositionLevelCode=jobPositionLevelCode; this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes a new instance of Profession from existing database</summary><param name="array">Profession</param>
	public Profession(string[] array) { this.ActivationDate=DateTime.Parse(array[0]); this.DeactivationDate=DateTime.Parse(array[1]); this.JobPositionIdentifier=array[2]; this.jobPositionName=array[3]; this.JobPositionLevelCode=array[4];
		this.InstitutionIdentifier=array[5]; }

	/// <summary>Initializes a new instance of Profession, that accepts data from existing Profession</summary><param name="entity" />
	public Profession(Profession entity) { this.ActivationDate=entity.ActivationDate; this.DeactivationDate=entity.DeactivationDate; this.JobPositionIdentifier=entity.JobPositionIdentifier;
		this.jobPositionName=entity.JobPositionName; this.JobPositionLevelCode=entity.JobPositionLevelCode; this.InstitutionIdentifier=entity.InstitutionIdentifier; }

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
	public string JobPositionIdentifier { get; set; } = "0000";

	/// <remarks/>
	public string JobPositionName { get => jobPositionName; set => jobPositionName=value.Replace("'", "′"); }

	/// <remarks/>
	public string JobPositionLevelCode { get; set; } = "0";

	/// <remarks/>
	public string InstitutionIdentifier { get; set; } = "NO";

	#endregion

	#region Other

	/// <remarks />
	[NotMapped]
	public bool Active => IsActive();

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.ActivationDate.ToString("yyyy-MM-dd")+";"+this.DeactivationDate.ToString("yyyy-MM-dd")+";"+this.JobPositionIdentifier+";"+this.jobPositionName+";"+this.JobPositionLevelCode+";"+this.InstitutionIdentifier+"\r\n";

	/// <summary>Delete Profession SQL-query</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [dbo].[ProfessionList] WHERE [Id]="+this.Id+";\r\n";

	/// <summary>Select Profession SQL-query</summary>
	[NotMapped]
	public string SqlSelectQuery => @"Select FROM [dbo].[ProfessionList] WHERE [Id]="+this.Id+";\r\n";

	/// <summary>[SD].[dbo].[UpdateOrCreateProfession] @actDate, @deactDate, @jobPosId, @jobPosName, @jobPosLevel, @instId</summary>
	[NotMapped]
	public string SqlUpdateOrCreateQuery => @"EXECUTE [SD].[dbo].[UpdateOrCreateProfession] @actDate='"+ActivationDate.ToString("yyyy-MM-dd")+"', @deactDate='"+DeactivationDate.ToString("yyyy-MM-dd")+
		"', @jobPosId='"+JobPositionIdentifier+"', @jobPosName='"+JobPositionName+"', @jobPosLevel='"+JobPositionLevelCode+"', @instId='"+InstitutionIdentifier+"'";

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier+"-"+this.JobPositionIdentifier;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this Profession to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(Profession entity) { if(this==null) return false; if (!this.ActivationDate.Equals(entity.ActivationDate)) return false; else if (!this.DeactivationDate.Equals(entity.DeactivationDate)) return false;
		else if (!this.JobPositionIdentifier.Equals(entity.JobPositionIdentifier)) return false; else if (!this.jobPositionName.Equals(entity.JobPositionName)) return false;
		else if (!this.JobPositionLevelCode.Equals(entity.JobPositionLevelCode)) return false; else if (!this.InstitutionIdentifier.Equals(entity.InstitutionIdentifier)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public virtual bool IsEmpty() { if (this == null) return true; Validate(); if (!this.JobPositionIdentifier.Equals("00000")&&!this.InstitutionIdentifier.Equals("NO")) return false;  else return true; }

	/// <summary> Check wether validation of this Profession cause changes, that must be updated in database</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public virtual bool IsUpdated() { if (this == null) throw new NullReferenceException(); Profession valProf = new(this.ActivationDate,this.DeactivationDate,this.JobPositionIdentifier,
		this.jobPositionName,this.JobPositionLevelCode,this.InstitutionIdentifier) { Id = this.Id }; if (!Equals(valProf)) return true; else return false; }

	/// <remarks/>
	private bool IsActive() { if (this == null) throw new NullReferenceException(); else if (ActivationDate <= DateTime.Today && DeactivationDate >= DateTime.Today) return true; else return false; }

	#endregion

	#region To something

	/// <returns>Content of this Profession as a long string</returns>
	public virtual string ToLongString() { if(this==null) return "null"; return  "JobPositionName: "+this.jobPositionName+" ("+this.InstitutionIdentifier+
		"-"+JobPositionIdentifier+"-"+ActivationDate.ToString("yyyy.MM.dd")+"-"+DeactivationDate.ToString("yyyy.MM.dd")+")"; }

	/// <returns>Content of this Profession as string</returns>
	public override string ToString() { if(this==null) return "null"; else return this.jobPositionName+"("+this.InstitutionIdentifier+"-"+this.JobPositionIdentifier+")"; }

	#endregion

	/// <summary>Validates data in this <see cref="Profession"/></summary><exception cref="NullReferenceException" />
	public virtual void Validate() { if(this==null) throw new NullReferenceException(); if (string.IsNullOrWhiteSpace(this.JobPositionIdentifier)) this.JobPositionIdentifier="0000";
		if (string.IsNullOrWhiteSpace(this.JobPositionLevelCode)) this.JobPositionLevelCode="0"; if (string.IsNullOrWhiteSpace(this.jobPositionName)) this.jobPositionName="None"; 
			else this.jobPositionName=this.jobPositionName.Replace("'", "′"); if (string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) this.InstitutionIdentifier="NO"; }

	#endregion

}
