// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EmploymentProfession.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public partial class EmploymentProfession
{
	#region Fields

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public const string CsvHeader="Id;EmploymentIdentifier;InstitutionIdentifier;JobPositionIdentifier;ActivationDate;DeactivationDate;EmploymentName;AppointmentCode,\r\n";

	private string employmentName="None";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of Profession</summary>
	public EmploymentProfession() { }

	/// <summary>Initializes a new instance of EmploymentProfession</summary><param name="employmentId" /><param name="institutionId" /><param name="jobPositionId" />
	/// <param name="activationDate" /><param name="deactivationDate" /><param name="employmentName" /><param name="appointmentCode" />
	public EmploymentProfession(string employmentId,string institutionId,string jobPositionId,DateTime activationDate,DateTime deactivationDate,string employmentName,string appointmentCode) {
		this.EmploymentIdentifier=employmentId; this.InstitutionIdentifier=institutionId; this.JobPositionIdentifier=jobPositionId; this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate;
		this.EmploymentName=employmentName; this.AppointmentCode=appointmentCode; Validate(); }

	/// <summary>Initializes a new instance of EmploymentProfession from SDWS</summary><param name="employmentId" /><param name="institutionId" /><param name="jobPositionId" />
	/// <param name="activationDate" /><param name="deactivationDate" /><param name="employmentName" /><param name="appointmentCode" />
	public EmploymentProfession(string employmentId,string institutionId,string jobPositionId,string activationDate,string deactivationDate,string employmentName,string appointmentCode) {
		this.EmploymentIdentifier=employmentId; this.InstitutionIdentifier=institutionId; this.JobPositionIdentifier=jobPositionId; this.ActivationDate=DateTime.Parse(activationDate);
		this.DeactivationDate=DateTime.Parse(deactivationDate); this.employmentName=employmentName.Replace("'", "′"); this.AppointmentCode=appointmentCode; Validate(); }

	/// <summary>Initializes a new instance of EmploymentProfession from database</summary><param name="id" /><param name="employmentId" /><param name="institutionId" /><param name="jobPositionId" />
	/// <param name="activationDate" /><param name="deactivationDate" /><param name="employmentName" /><param name="appointmentCode" />
	public EmploymentProfession(int id,string employmentId,string institutionId,string jobPositionId,DateTime activationDate,DateTime deactivationDate,string employmentName,string appointmentCode) { this.Id=id;
		this.EmploymentIdentifier=employmentId; this.InstitutionIdentifier=institutionId; this.JobPositionIdentifier=jobPositionId; this.ActivationDate=activationDate;
		this.DeactivationDate=deactivationDate; this.employmentName=employmentName; this.AppointmentCode=appointmentCode; }

	/// <summary>Initializes a new instance of EmploymentProfession from database</summary><param name="array" />
	public EmploymentProfession(string[] array) { this.Id = int.Parse(array[0]); this.EmploymentIdentifier = array[1]; this.InstitutionIdentifier = array[2]; this.JobPositionIdentifier = array[3];
		this.ActivationDate = DateTime.Parse(array[4]); this.DeactivationDate = DateTime.Parse(array[5]); this.employmentName = array[6]; this.AppointmentCode = array[7]; }

	/// <summary>Initializes a new instance of EmploymentProfession, that accepts data from existing EmploymentProfession</summary><param name="entity" />
	public EmploymentProfession(EmploymentProfession entity) { this.Id= entity.Id; this.EmploymentIdentifier=entity.EmploymentIdentifier; this.InstitutionIdentifier=entity.InstitutionIdentifier;
		this.JobPositionIdentifier=entity.JobPositionIdentifier; this.ActivationDate=entity.ActivationDate; this.DeactivationDate=entity.DeactivationDate; 
		this.employmentName= entity.EmploymentName; this.AppointmentCode= entity.AppointmentCode; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	public int Id { get; set; }=0;

	/// <remarks/>
	public string EmploymentIdentifier { get; set; }="00000";

	/// <remarks/>
	public string InstitutionIdentifier { get; set; }="NO";

	/// <remarks/>
	public string JobPositionIdentifier { get; set; }="0000";

	/// <remarks/>
	public DateTime ActivationDate { get; set; }=DateTime.Parse("2010-01-01");

	/// <remarks/>
	public DateTime DeactivationDate { get; set; }=DateTime.Parse("9999-12-31");

	/// <remarks/>
	public string EmploymentName { get => employmentName; set => employmentName=value.Replace("'", "′"); }

	/// <remarks/>
	public string AppointmentCode { get; set; }="0";

	#endregion

	#region Other

	/// <remarks />
	[NotMapped]
	public bool Active => IsActive();

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.EmploymentIdentifier+";"+this.InstitutionIdentifier+";"+this.JobPositionIdentifier+";"+this.ActivationDate.ToString("yyyy-MM-dd")+";"+
		this.DeactivationDate.ToString("yyyy-MM-dd")+";"+this.EmploymentName+";"+this.AppointmentCode+"\r\n";

	/// <summary>DELETE FROM [SD].[dbo].[EmploymentProfessionList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [SD].[dbo].[EmploymentProfessionList] WHERE [Id]="+this.Id;

	/// <summary>@"INSERT INTO [SD].[dbo].[EmploymentProfessionList]([EmploymentIdentifier],[InstitutionIdentifier],[JobPositionIdentifier],[ActivationDate],[DeactivationDate],[EmploymentName],[AppointmentCode])
	/// VALUES('EmploymentIdentifier','InstitutionIdentifier','JobPositionIdentifier','ActivationDate','DeactivationDate','EmploymentName','AppointmentCode')</summary>
	[NotMapped]
	public string SqlInsertQuery => @"INSERT INTO [SD].[dbo].[EmploymentProfessionList]([EmploymentIdentifier],[InstitutionIdentifier],[JobPositionIdentifier],[ActivationDate],[DeactivationDate],[EmploymentName],"+
		"[AppointmentCode]) VALUES('"+this.EmploymentIdentifier+"','"+this.InstitutionIdentifier+"','"+this.JobPositionIdentifier+"','"+this.ActivationDate.ToString("yyyy-MM-dd")+"','"+
		this.DeactivationDate.ToString("yyyy-MM-dd")+"','"+this.EmploymentName.Replace("'", "′")+"','"+this.AppointmentCode+"')";

	/// <summary>Select FROM [SD].[dbo].[EmploymentProfessionList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlSelectQuery => @"Select FROM [SD].[dbo].[EmploymentProfessionList] WHERE [Id]="+this.Id;

	/// <summary>UPDATE [SD].[dbo].[EmploymentProfessionList] SET [EmploymentIdentifier]='.InstitutionIdentifier',[InstitutionIdentifier]='.InstitutionIdentifier',[JobPositionIdentifier]='JobPositionIdentifier',
	/// [ActivationDate]='ActivationDate',[DeactivationDate]='DeactivationDate',[EmploymentName]='EmploymentName',[AppointmentCode]='AppointmentCode' WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlUpdateQuery => @"UPDATE [SD].[dbo].[EmploymentProfessionList] SET [EmploymentIdentifier]='"+this.EmploymentIdentifier+"',[InstitutionIdentifier]='"+this.InstitutionIdentifier+"',[JobPositionIdentifier]='"+
		this.JobPositionIdentifier+"',[ActivationDate]='" + this.ActivationDate.ToString("yyyy-MM-dd")+"',[DeactivationDate]='"+this.DeactivationDate.ToString("yyyy-MM-dd")+"',[EmploymentName]='"+
		this.EmploymentName.Replace("'", "′")+"',[AppointmentCode]='"+this.AppointmentCode+"' WHERE [Id]="+this.Id;

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier+"-"+this.EmploymentIdentifier+"-"+this.JobPositionIdentifier;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this EmploymentProfession to <paramref name="prof"/></summary><param name="prof" /><returns>Result as bool</returns>
	public bool Equals(EmploymentProfession prof) { if(this==null) return false; if (!this.EmploymentIdentifier.Equals(prof.EmploymentIdentifier)) return false;
		else if (!this.InstitutionIdentifier.Equals(prof.InstitutionIdentifier)) return false; else if (!this.JobPositionIdentifier.Equals(prof.JobPositionIdentifier)) return false;
		else if (!this.ActivationDate.Equals(prof.ActivationDate)) return false; else if (!this.DeactivationDate.Equals(prof.DeactivationDate)) return false;
		else if (!this.EmploymentName.Equals(prof.EmploymentName)) return false; else if (!this.AppointmentCode.Equals(prof.AppointmentCode)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if(this==null) throw new NullReferenceException(); Validate(); if (!this.JobPositionIdentifier.Equals("00000")&&!this.InstitutionIdentifier.Equals("NO")) return false; else return true; }

	/// <summary> Check wether validation of this Profession cause changes, that must be updated in database</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsUpdated() { if(this==null) throw new NullReferenceException(); EmploymentProfession valProf =new(this.EmploymentIdentifier,this.InstitutionIdentifier,this.JobPositionIdentifier,this.ActivationDate,
		this.DeactivationDate, this.employmentName,this.AppointmentCode) { Id=this.Id }; if (!Equals(valProf)) return true; else return false; }

	/// <remarks/>
	private bool IsActive() { if (this == null) throw new NullReferenceException(); else if (ActivationDate <= DateTime.Today && DeactivationDate >= DateTime.Today) return true; else return false; }

	#endregion

	#region To something

	/// <returns>Content of this Profession as a long string</returns>
	public string ToLongString() { if(this==null) return "null"; else return "EmploymentName: "+this.employmentName+" ("+this.EmploymentIdentifier+"-"+this.InstitutionIdentifier+"-"+JobPositionIdentifier+"-"+ActivationDate+"-"+DeactivationDate+")"; }

	/// <returns>Content of this Profession as string</returns>
	public override string ToString() { if(this==null) return "null"; else return this.EmploymentIdentifier+"-"+this.InstitutionIdentifier+"-"+this.JobPositionIdentifier; }

	#endregion

	/// <summary>Validates data in this EmploymentProfession</summary><exception cref="NullReferenceException" />
	public void Validate() { if(this==null) throw new NullReferenceException(); if (string.IsNullOrWhiteSpace(this.EmploymentIdentifier)) this.EmploymentIdentifier="00000";
		if (string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) this.InstitutionIdentifier="NO"; if (string.IsNullOrWhiteSpace(this.JobPositionIdentifier)) this.JobPositionIdentifier="0000";
		if (string.IsNullOrWhiteSpace(this.AppointmentCode)) this.AppointmentCode="0";  if (string.IsNullOrWhiteSpace(this.employmentName)) this.employmentName="None";
		else this.employmentName=this.employmentName.Replace("'", "′"); }

	#endregion

}
