// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EmploymentStatus.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public partial class EmploymentStatus
{

	#region Fields

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public const string CsvHeader="Id;EmploymentIdentifier;InstitutionIdentifier;ActivationDate;DeactivationDate;EmploymentStatusCode;MarkedForDeletion\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of EmploymentStatus</summary>
	public EmploymentStatus() { }

	/// <summary>Initializes a new instance of EmploymentStatus</summary><param name="employmentId" /><param name="institutionId" /><param name="activationDate" /><param name="deactivationDate" />
	/// <param name="employmentStatusCode" /><param name="markedForDeletion" />
	public EmploymentStatus(string employmentId,string institutionId,DateTime activationDate,DateTime deactivationDate,string employmentStatusCode,bool markedForDeletion=false) { this.EmploymentIdentifier=employmentId;
		this.InstitutionIdentifier=institutionId; this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.EmploymentStatusCode=employmentStatusCode; this.MarkedForDeletion=markedForDeletion; Validate(); }

	/// <summary>Initializes a new instance of EmploymentStatus from SDWS</summary><param name="employmentId" /><param name="institutionId" /><param name="activationDate" /><param name="deactivationDate" />
	/// <param name="employmentStatusCode" /><param name="markedForDeletion" />
	public EmploymentStatus(string employmentId,string institutionId,string activationDate,string deactivationDate,string employmentStatusCode,string markedForDeletion="false") { this.EmploymentIdentifier=employmentId;
		this.InstitutionIdentifier=institutionId; this.ActivationDate=DateTime.Parse(activationDate); this.DeactivationDate=DateTime.Parse(deactivationDate); this.EmploymentStatusCode=employmentStatusCode;
		this.MarkedForDeletion=bool.Parse(markedForDeletion); Validate(); }

	/// <summary>Initializes a new instance of EmploymentStatus from database</summary><param name="id" /><param name="employmentId" /><param name="institutionId" />
	/// <param name="activationDate" /><param name="deactivationDate" /><param name="employmentStatusCode" /><param name="markedForDeletion" />
	public EmploymentStatus(int id,string employmentId,string institutionId,DateTime activationDate,DateTime deactivationDate,string employmentStatusCode,bool markedForDeletion) { this.Id=id; this.EmploymentIdentifier=
		employmentId; this.InstitutionIdentifier=institutionId; this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.EmploymentStatusCode=employmentStatusCode; this.MarkedForDeletion=markedForDeletion; }

	/// <summary>Initializes a new instance of EmploymentStatus from database</summary><param name="array" />
	public EmploymentStatus(string[] array) { this.Id=int.Parse(array[0]); this.EmploymentIdentifier=array[1]; this.InstitutionIdentifier=array[2]; this.ActivationDate=DateTime.Parse(array[3]);
		this.DeactivationDate=DateTime.Parse(array[4]); this.EmploymentStatusCode=array[5]; this.MarkedForDeletion=bool.Parse(array[6]); }

	/// <summary>Initializes a new instance of EmploymentStatus, that accepts data from existing EmploymentStatus</summary><param name="entity" />
	public EmploymentStatus(EmploymentStatus entity) { this.Id=entity.Id; this.EmploymentIdentifier=entity.EmploymentIdentifier; this.InstitutionIdentifier=entity.InstitutionIdentifier;
		this.ActivationDate=entity.ActivationDate; this.DeactivationDate=entity.DeactivationDate; this.EmploymentStatusCode=entity.EmploymentStatusCode; this.MarkedForDeletion=entity.MarkedForDeletion; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	public int Id { get; set; } = 0;

	/// <remarks/>
	public string EmploymentIdentifier { get; set; } = "00000";

	/// <remarks/>
	public string InstitutionIdentifier { get; set; } = "NO";

	/// <remarks/>
	public DateTime ActivationDate { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks/>
	public DateTime DeactivationDate { get; set; } = DateTime.Parse("9999-12-31");

	/// <remarks/>
	public string EmploymentStatusCode { get; set; } = "0";

	/// <remarks/>
	public bool MarkedForDeletion { get; set; } = false;

	#endregion

	#region Other

	/// <remarks/>
	[NotMapped]
	public bool Active => IsActive();

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.EmploymentIdentifier+";"+this.InstitutionIdentifier+";"+this.ActivationDate.ToString("yyyy-MM-dd")+";"+
		this.DeactivationDate.ToString("yyyy-MM-dd")+";"+this.EmploymentStatusCode+";"+ this.MarkedForDeletion.ToString()+"\r\n";

	/// <summary>DELETE FROM [dbo].[EmploymentStatusList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [dbo].[EmploymentStatusList] WHERE [Id]="+this.Id;

	/// <summary>SELECT * FROM [dbo].[EmploymentStatusList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [dbo].[EmploymentStatusList] WHERE [Id]="+this.Id;

	/// <summary>EXECUTE [SD].[dbo].[UpdateOrCreateEmploymentStatus] @emplId, @instId, @actDate, @deactDate, @emplStatusCode, @markDel</summary>
	[NotMapped]
	public string SqlUpdateOrCreateQuery => @"EXECUTE [SD].[dbo].[UpdateOrCreateEmploymentStatus] @emplId='"+EmploymentIdentifier+"', @instId='"+InstitutionIdentifier+"', @actDate='"+ActivationDate.ToString("yyyy-MM-dd")+
		"', @deactDate='"+DeactivationDate.ToString("yyyy-MM-dd") + "', @emplStatusCode='"+EmploymentStatusCode+"', @markDel='"+MarkedForDeletion.ToString()+"'";

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier+"-"+this.EmploymentIdentifier;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this EmploymentStatus to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(EmploymentStatus entity) { if(this==null) return true; if (!this.EmploymentIdentifier.Equals(entity.EmploymentIdentifier)) return false;
		else if (!this.InstitutionIdentifier.Equals(entity.InstitutionIdentifier)) return false; else if (!this.ActivationDate.Equals(entity.ActivationDate)) return false;
		else if (!this.DeactivationDate.Equals(entity.DeactivationDate)) return false; else if (!this.EmploymentStatusCode.Equals(entity.EmploymentStatusCode)) return false;
		else if (!this.MarkedForDeletion.Equals(entity.MarkedForDeletion)) return false; else return true; }

	#region Is Something

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if(this==null) return true; Validate(); if (!this.EmploymentIdentifier.Equals("00000")&&!this.InstitutionIdentifier.Equals("NO")) return false; else return true; }

	/// <summary>Check wether validation of this EmploymentStatus cause changes, that must be updated in database</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsUpdated() { if(this==null) throw new NullReferenceException(); EmploymentStatus valStat=new(this.EmploymentIdentifier,this.InstitutionIdentifier,this.ActivationDate,this.DeactivationDate,this.EmploymentStatusCode,
		this.MarkedForDeletion) { Id=this.Id }; if (!Equals(valStat)) return true; else return false; }

	/// <remarks/>
	private bool IsActive() { if (this ==null) throw new NullReferenceException(); else if (this.ActivationDate<=DateTime.Today&&this.DeactivationDate>=DateTime.Today.AddDays(1)&&(this.EmploymentStatusCode.Equals("0")||
		this.EmploymentStatusCode.Equals("1")|| this.EmploymentStatusCode.Equals("3"))) return true; else return false; }

	#endregion

	#region To Something

	/// <returns>Content of this EmploymentStatus as a long string</returns>
	public string ToLongString() { if(this==null) return "null"; else return "ActivationDate: "+this.ActivationDate.ToString("yyyy-MM-dd")+" - DeactivationDate: "+
		this.DeactivationDate.ToString("yyyy-MM-dd")+" - EmploymentStatusCode: "+this.EmploymentStatusCode; }

	/// <returns>Content of this EmploymentStatus as a multi line string</returns>
	public string ToMultiLineString() { if(this==null) return "null"; else return "ActivationDate: "+this.ActivationDate.ToString("yyyy-MM-dd")+Environment.NewLine+"DeactivationDate: "+
		this.DeactivationDate.ToString("yyyy-MM-dd")+Environment.NewLine+"EmploymentStatusCode: "+this.EmploymentStatusCode; }

	/// <returns>Content of this EmploymentStatus as string</returns>
	public override string ToString() { if(this==null) return "null"; else return "EmploymentStatusCode: "+this.EmploymentStatusCode+" ("+this.ActivationDate+"-"+this.DeactivationDate+")"; }

	#endregion

	/// <summary>Validates data in this EmploymentStatus</summary><exception cref="NullReferenceException" />
	public void Validate() { if(this==null) throw new NullReferenceException(); if (string.IsNullOrWhiteSpace(this.EmploymentIdentifier)) this.EmploymentIdentifier="00000"; 
		if (string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) this.InstitutionIdentifier="NO"; if (string.IsNullOrWhiteSpace(this.EmploymentStatusCode)) this.EmploymentStatusCode="0";  }

	#endregion

}
