// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WorkingTime.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks />
public partial class WorkingTime
{

	#region Fields

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public const string CsvHeader="Id;EmploymentIdentifier;ActivationDate;DeactivationDate;OccupationRate;SalaryRate;SalariedIndicator;AutomaticRaiseIndicator;FullTimeIndicator\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of WorkingTime</summary>
	public WorkingTime() { }

	/// <summary>Initializes a new instance of WorkingTime</summary><param name="employmentId" /><param name="institutionId" /><param name="activationDate" /><param name="deactivationDate" />
	/// <param name="occupationRate" /><param name="salaryRate" /><param name="salariedIndicator" /><param name="automaticRaiseIndicator" /><param name="fullTimeIndicator" />
	public WorkingTime(string employmentId,string institutionId,DateTime activationDate,DateTime deactivationDate,string occupationRate,string salaryRate,bool salariedIndicator=false,
		bool automaticRaiseIndicator=false,bool fullTimeIndicator=false) { this.EmploymentIdentifier=employmentId; this.InstitutionIdentifier=institutionId; this.ActivationDate=activationDate;
		this.DeactivationDate=deactivationDate; this.OccupationRate=occupationRate; this.SalaryRate=salaryRate; this.SalariedIndicator=salariedIndicator;
		this.AutomaticRaiseIndicator=automaticRaiseIndicator; this.FullTimeIndicator=fullTimeIndicator; Validate(); }

	/// <summary>Initializes a new instance of WorkingTime from SDWS</summary><param name="employmentId" /><param name="institutionId" /><param name="activationDate" /><param name="deactivationDate" />
	/// <param name="occupationRate" /><param name="salaryRate" /><param name="salariedIndicator" /><param name="automaticRaiseIndicator" /><param name="fullTimeIndicator" />
	public WorkingTime(string employmentId,string institutionId,string activationDate,string deactivationDate,string occupationRate,string salaryRate,string salariedIndicator="false",
		string automaticRaiseIndicator="false",string fullTimeIndicator="false") { this.EmploymentIdentifier=employmentId; this.InstitutionIdentifier=institutionId; this.ActivationDate=DateTime.Parse(activationDate);
		this.DeactivationDate=DateTime.Parse(deactivationDate); this.OccupationRate=occupationRate; this.SalaryRate=salaryRate; this.SalariedIndicator=bool.Parse(salariedIndicator);
		this.AutomaticRaiseIndicator=bool.Parse(automaticRaiseIndicator); this.FullTimeIndicator=bool.Parse(fullTimeIndicator); Validate(); }

	/// <summary>Initializes a new instance of WorkingTime from database</summary><param name="id">int</param><param name="employmentId" /><param name="institutionId" /><param name="activationDate" />
	/// <param name="deactivationDate" /><param name="occupationRate" /><param name="salaryRate" /><param name="salariedIndicator" /><param name="automaticRaiseIndicator" /><param name="fullTimeIndicator" />
	public WorkingTime(int id,string employmentId,string institutionId,DateTime activationDate,DateTime deactivationDate,string occupationRate,string salaryRate,bool salariedIndicator,
		bool automaticRaiseIndicator,bool fullTimeIndicator) { this.Id=id; this.EmploymentIdentifier=employmentId; this.InstitutionIdentifier=institutionId; this.ActivationDate=activationDate;
		this.DeactivationDate=deactivationDate;this.OccupationRate=occupationRate; this.SalaryRate=salaryRate; this.SalariedIndicator=salariedIndicator; this.AutomaticRaiseIndicator=
			automaticRaiseIndicator; this.FullTimeIndicator=fullTimeIndicator; }

	/// <summary>Initializes a new instance of WorkingTime from database</summary><param name="array" />
	public WorkingTime(string[] array) { this.Id=int.Parse(array[0]); this.EmploymentIdentifier=array[1]; this.InstitutionIdentifier=array[2]; this.ActivationDate=DateTime.Parse(array[3]);
		this.DeactivationDate=DateTime.Parse(array[4]); this.OccupationRate=array[5]; this.SalaryRate=array[6]; this.SalariedIndicator=bool.Parse(array[7]);
		this.AutomaticRaiseIndicator=bool.Parse(array[8]); this.FullTimeIndicator=bool.Parse(array[9]); }

	/// <summary>Initializes a new instance of WorkingTime,that accepts data from existing WorkingTime</summary><param name="entity" />
	public WorkingTime(WorkingTime entity) { this.Id=entity.Id; this.EmploymentIdentifier=entity.EmploymentIdentifier; this.InstitutionIdentifier=entity.InstitutionIdentifier; this.ActivationDate=entity.ActivationDate;
		this.DeactivationDate=entity.DeactivationDate; this.OccupationRate=entity.OccupationRate; this.SalaryRate=entity.SalaryRate;this.SalariedIndicator=entity.SalariedIndicator;
		this.AutomaticRaiseIndicator=entity.AutomaticRaiseIndicator; this.FullTimeIndicator=entity.FullTimeIndicator; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	public int Id { get; set; } = 0;

	/// <remarks/>
	public string EmploymentIdentifier { get; set; } = "00000";

	/// <remarks/>
	public string InstitutionIdentifier { get; set; } = "NO";

	/// <remarks />
	public DateTime ActivationDate { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks />
	public DateTime DeactivationDate { get; set; } = DateTime.Parse("9999-12-31");

	/// <remarks />
	public string OccupationRate { get; set; } = "0.0000";

	/// <remarks />
	public string SalaryRate { get; set; } = "0.0000";

	/// <remarks />
	public bool SalariedIndicator { get; set; } = false;

	/// <remarks />
	public bool AutomaticRaiseIndicator { get; set; } = false;

	/// <remarks />
	public bool FullTimeIndicator { get; set; } = false;

	#endregion

	#region Other

	/// <remarks/>
	[NotMapped]
	public bool Active => IsActive();

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.EmploymentIdentifier+";"+this.ActivationDate.ToString("yyyy-MM-dd")+";"+this.DeactivationDate.ToString("yyyy-MM-dd")+";"+this.OccupationRate+";"+
		this.SalaryRate+";"+this.SalariedIndicator.ToString()+";"+this.AutomaticRaiseIndicator.ToString()+";"+this.FullTimeIndicator.ToString()+Environment.NewLine;

	/// <summary>DELETE FROM [dbo].[WorkingTimeList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [dbo].[WorkingTimeList] WHERE [Id]="+this.Id;

	/// <summary>SELECT * FROM [dbo].[WorkingTimeList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [dbo].[WorkingTimeList] WHERE [Id]="+this.Id;

	/// <summary>[SD].[dbo].[UpdateOrCreateWorkingTime] @emplId, @instId, @actDate, @deactDate, @occuRate, @salaryRate, @salaried, @autoRaise, @fullTime</summary>
	[NotMapped]
	public string SqlUpdateOrCreateQuery => @"EXECUTE [SD].[dbo].[UpdateOrCreateWorkingTime] @emplId='"+EmploymentIdentifier+"', @instId='"+InstitutionIdentifier+"', @actDate='"+ActivationDate.ToString("yyyy-MM-dd")+
		"', @deactDate='"+DeactivationDate.ToString("yyyy-MM-dd") + "', @occuRate='"+OccupationRate+"', @salaryRate='"+SalaryRate+"', @salaried='"+SalariedIndicator.ToString()+
		"', @autoRaise='"+AutomaticRaiseIndicator.ToString()+"', @fullTime='"+FullTimeIndicator.ToString()+"'";

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey { get => this.InstitutionIdentifier+"-"+this.EmploymentIdentifier; }

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this WorkingTime to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(WorkingTime entity) { if(this==null||entity==null) return false; if (!this.EmploymentIdentifier.Equals(entity.EmploymentIdentifier)) return false; if (!entity.InstitutionIdentifier.Equals(
			entity.InstitutionIdentifier)) return false; if (!this.ActivationDate.Equals(entity.ActivationDate)) return false; if (!this.DeactivationDate.Equals(entity.DeactivationDate)) return false;
		if (!this.OccupationRate.Equals(entity.OccupationRate)) return false; if (!this.SalaryRate.Equals(entity.SalaryRate)) return false; if (!this.SalariedIndicator.Equals(entity.SalariedIndicator)) return false;
		if (!this.AutomaticRaiseIndicator.Equals(entity.AutomaticRaiseIndicator)) return false; if (!this.FullTimeIndicator.Equals(entity.FullTimeIndicator)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if(this==null) return true; Validate(); if (!this.EmploymentIdentifier.Equals("00000")&&!this.InstitutionIdentifier.Equals("NO")) return false; else return true; }

	/// <summary>Checks wether validation of this <see cref="WorkingTime"/> cause changes, that must be updated in database</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsUpdated() { if(this==null) throw new NullReferenceException(); WorkingTime valTime=new(this.EmploymentIdentifier,this.InstitutionIdentifier,this.ActivationDate,this.DeactivationDate,this.OccupationRate,
		this.SalaryRate,this.SalariedIndicator,this.AutomaticRaiseIndicator,this.FullTimeIndicator) { Id=this.Id } ; if (!Equals(valTime)) return true; else return false; }

	/// <remarks/>
	private bool IsActive() { if (this ==null) throw new NullReferenceException(); else if (this.ActivationDate<=DateTime.Today&&this.DeactivationDate>=DateTime.Today) return true; else return false; }

	#endregion

	#region To something

	/// <returns>Content of this WorkingTime as a long string</returns>
	public string ToLongString() { if(this==null) return "null"; else return "ActivationDate: "+this.ActivationDate.ToString("yyyy-MM-dd")+" - DeactivationDate: "+this.DeactivationDate.ToString("yyyy-MM-dd")+
		" - OccupationRate: "+this.OccupationRate+" - SalaryRate: "+this.SalaryRate+" - SalariedIndicator: "+this.SalariedIndicator+" - AutomaticRaiseIndicator: "+this.AutomaticRaiseIndicator+" - SalaryRate: "+this.FullTimeIndicator; }

	/// <returns>Content of this WorkingTime as string</returns>
	public override string ToString() { if(this==null) return "null"; else return "OccupationRate: "+this.OccupationRate+" - SalaryRate: "+this.SalaryRate+" ("+this.ActivationDate+"-"+this.DeactivationDate+")"; }

	#endregion

	/// <summary>Validates data in this WorkingTime</summary><exception cref="NullReferenceException" />
	public void Validate() { if (this==null) throw new NullReferenceException(); if (string.IsNullOrWhiteSpace(this.EmploymentIdentifier)) this.EmploymentIdentifier="00000"; if (string.IsNullOrWhiteSpace(this.InstitutionIdentifier))
		this.InstitutionIdentifier="NO"; if (string.IsNullOrWhiteSpace(this.OccupationRate)) this.OccupationRate="0.0000"; if (string.IsNullOrWhiteSpace(this.SalaryRate)) this.SalaryRate="0.0000"; }

	#endregion

}
