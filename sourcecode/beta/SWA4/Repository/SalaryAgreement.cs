// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SalaryAgreement.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks />
public partial class SalaryAgreement
{

	#region Fields

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public const string CsvHeader="Id;EmploymentIdentifier;InstitutionIdentifier;ActivationDate;DeactivationDate;SalaryAgreementIdentifier;SalaryScaleIdentifier;SalaryClassIdentifier;PrepaidIndicator;SeniorityDate\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of SalaryAgreement</summary>
	public SalaryAgreement() { }

	/// <summary>Initializes a new instance of SalaryAgreement</summary><param name="employmentId" /><param name="institutionId" /><param name="activationDate" /><param name="deactivationDate" />
	/// <param name="salaryAgreementId" /><param name="salaryClassId" /><param name="salaryScaleId" /><param name="prepaidIndicator" /><param name="seniorityDate" />
	public SalaryAgreement(string employmentId,string institutionId,DateTime activationDate,DateTime deactivationDate,string salaryAgreementId,string salaryClassId,string salaryScaleId,
		bool prepaidIndicator,DateTime seniorityDate) { this.EmploymentIdentifier=employmentId; this.InstitutionIdentifier=institutionId; this.ActivationDate=activationDate;
		this.DeactivationDate=deactivationDate; this.SalaryAgreementIdentifier=salaryAgreementId; this.SalaryClassIdentifier=salaryClassId; this.SalaryScaleIdentifier=salaryScaleId;
		this.PrepaidIndicator=prepaidIndicator; this.SeniorityDate=seniorityDate; Validate(); }

	/// <summary>Initializes a new instance of SalaryAgreement from SDWS</summary><param name="employmentId" /><param name="institutionId" /><param name="activationDate" /><param name="deactivationDate" />
	/// <param name="salaryAgreementId" /><param name="salaryClassId" /><param name="salaryScaleId" /><param name="prepaidIndicator" /><param name="seniorityDate" />
	public SalaryAgreement(string employmentId,string institutionId,string activationDate,string deactivationDate,string salaryAgreementId,string salaryClassId,string salaryScaleId,
		string seniorityDate,string prepaidIndicator="false") { this.EmploymentIdentifier=employmentId; this.InstitutionIdentifier=institutionId; this.ActivationDate=DateTime.Parse(activationDate);
		this.DeactivationDate=DateTime.Parse(deactivationDate); this.SalaryAgreementIdentifier=salaryAgreementId; this.SalaryClassIdentifier=salaryClassId; this.SalaryScaleIdentifier=salaryScaleId;
		this.PrepaidIndicator=bool.Parse(prepaidIndicator); this.SeniorityDate=DateTime.Parse(seniorityDate); Validate(); }

	/// <summary>Initializes a new instance of SalaryAgreement from database</summary><param name="id" /><param name="employmentId" /><param name="institutionId" /><param name="activationDate" />
	/// <param name="deactivationDate" /><param name="salaryAgreementId" /><param name="salaryClassId" /><param name="salaryScaleId" /><param name="prepaidIndicator" /><param name="seniorityDate" />
	public SalaryAgreement(int id,string employmentId,string institutionId,DateTime activationDate,DateTime deactivationDate,string salaryAgreementId,string salaryClassId,string salaryScaleId,
		bool prepaidIndicator,string seniorityDate) { this.Id=id; this.EmploymentIdentifier=employmentId; this.InstitutionIdentifier=institutionId; this.ActivationDate=activationDate;
		this.DeactivationDate=deactivationDate; this.SalaryAgreementIdentifier=salaryAgreementId; this.SalaryClassIdentifier=salaryClassId; this.SalaryScaleIdentifier=salaryScaleId;
		this.PrepaidIndicator=prepaidIndicator; this.SeniorityDate=DateTime.Parse(seniorityDate); }

	/// <summary>Initializes a new instance of SalaryAgreement from database</summary><param name="array" />
	public SalaryAgreement(string[] array) { this.Id=int.Parse(array[0]); this.EmploymentIdentifier=array[1]; this.InstitutionIdentifier=array[2]; this.ActivationDate=DateTime.Parse(array[1]);
		this.DeactivationDate=DateTime.Parse(array[2]); this.SalaryAgreementIdentifier=array[3]; this.SalaryClassIdentifier=array[4]; this.SalaryScaleIdentifier=array[5];
		this.PrepaidIndicator=bool.Parse(array[6]); this.SeniorityDate=DateTime.Parse(array[7]); }

	/// <summary>Initializes a new instance of SalaryAgreement, that accepts data from an existing SalaryAgreement</summary><param name="entity" />
	public SalaryAgreement(SalaryAgreement entity) { this.Id=entity.Id; this.EmploymentIdentifier=entity.EmploymentIdentifier; this.InstitutionIdentifier=entity.InstitutionIdentifier; this.ActivationDate=
			entity.ActivationDate; this.DeactivationDate=entity.DeactivationDate; this.SalaryAgreementIdentifier=entity.SalaryAgreementIdentifier; this.SalaryClassIdentifier=entity.SalaryClassIdentifier;
		this.SalaryScaleIdentifier=entity.SalaryScaleIdentifier; this.PrepaidIndicator=entity.PrepaidIndicator; this.SeniorityDate=entity.SeniorityDate; }

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
	public string SalaryAgreementIdentifier { get; set; } = "0000";

	/// <remarks />
	public string SalaryClassIdentifier { get; set; } = "0.0000";

	/// <remarks />
	public string SalaryScaleIdentifier { get; set; } = "0.0000";

	/// <remarks />
	public bool PrepaidIndicator { get; set; } = false;

	/// <remarks />
	public DateTime SeniorityDate { get; set; } = DateTime.Parse("2010-01-01");

	#endregion

	#region Other

	/// <remarks/>
	[NotMapped]
	public bool Active => IsActive();

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.EmploymentIdentifier+";"+this.InstitutionIdentifier+";"+this.ActivationDate.ToString("yyyy-MM-dd")+";"+this.DeactivationDate.ToString("yyyy-MM-dd")+";"+
		this.SalaryAgreementIdentifier+";"+this.SalaryClassIdentifier+";"+this.SalaryScaleIdentifier+";"+this.PrepaidIndicator.ToString()+";"+this.SeniorityDate+";\r\n";

	/// <summary>DELETE FROM [dbo].[SalaryAgreementList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [dbo].[SalaryAgreementList] WHERE [Id]="+this.Id;

	/// <summary>SELECT * FROM [dbo].[SalaryAgreementList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [dbo].[SalaryAgreementList] WHERE [Id]="+this.Id;

	/// <summary>[SD].[dbo].[UpdateOrCreateSalaryAgreement] @emplId, @instId, @actDate, @deactAct, @agreeId, @classId, @scaleId, @prepaid, @senDate</summary>
	[NotMapped]
	public string SqlUpdateOrCreateQuery => @"EXECUTE [SD].[dbo].[UpdateOrCreateSalaryAgreement] @emplId='"+EmploymentIdentifier+"', @instId='"+InstitutionIdentifier+
		"', @actDate='"+ActivationDate.ToString("yyyy-MM-dd")+"', @deactAct='"+DeactivationDate.ToString("yyyy-MM-dd")+"', @agreeId='"+SalaryAgreementIdentifier+
		"', @classId='"+SalaryClassIdentifier+"', @scaleId='"+SalaryScaleIdentifier+"', @prepaid='"+PrepaidIndicator+"', @senDate='"+SeniorityDate.ToString("yyyy-MM-dd")+"'";

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier+"-"+this.EmploymentIdentifier;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this Department to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(SalaryAgreement entity) { if(this==null) return false; if (!this.EmploymentIdentifier.Equals(entity.EmploymentIdentifier)) return false; 
		else if (!this.InstitutionIdentifier.Equals(entity.InstitutionIdentifier)) return false; else if (!this.ActivationDate.Equals(entity.ActivationDate)) return false; 
		else if (!this.DeactivationDate.Equals(entity.DeactivationDate)) return false; else if (!this.SalaryAgreementIdentifier.Equals(entity.SalaryAgreementIdentifier)) return false;
		else if (!this.SalaryClassIdentifier.Equals(entity.SalaryClassIdentifier)) return false; else if (!this.SalaryScaleIdentifier.Equals(entity.SalaryScaleIdentifier)) return false;
		else if (!this.PrepaidIndicator.Equals(entity.PrepaidIndicator)) return false; else if (!this.SeniorityDate.Equals(entity.SeniorityDate)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if(this==null) return true; Validate(); if (!this.EmploymentIdentifier.Equals("00000")&&!this.InstitutionIdentifier.Equals("NO")) return false; else return true; }

	/// <summary>Checks wether validation of this SalaryAgreement cause changes, that must be updated in database</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsUpdated() { if(this==null) throw new NullReferenceException(); SalaryAgreement valAgree=new(this.EmploymentIdentifier,this.InstitutionIdentifier,this.ActivationDate,this.DeactivationDate,
		this.SalaryAgreementIdentifier,this.SalaryClassIdentifier,this.SalaryScaleIdentifier,PrepaidIndicator,this.SeniorityDate) { Id =this.Id }; if (!Equals(valAgree)) return true; else return false; }

	/// <remarks/>
	private bool IsActive() { if (this ==null) throw new NullReferenceException(); else if (this.ActivationDate<=DateTime.Today&&this.DeactivationDate>=DateTime.Today) return true; else return false; }

	#endregion

	#region To Something

	/// <returns>Content of SalaryAgreement as a long string</returns>
	public string ToLongString() { if(this==null) return "null"; else return "ActivationDate: "+this.ActivationDate.ToString("yyyy-MM-dd")+" - DeactivationDate: "+
		this.DeactivationDate.ToString("yyyy-MM-dd")+" - SalaryAgreementIdentifier: "+this.SalaryAgreementIdentifier+" - SalaryClassIdentifier: "+ this.SalaryClassIdentifier+
		" - SalaryScaleIdentifier: "+this.SalaryScaleIdentifier+" - PrepaidIndicator: "+this.PrepaidIndicator+" - SeniorityDate: "+this.SeniorityDate.ToString("yyyy-MM-dd"); }

	/// <returns>Content of SalaryAgreement as string</returns>
	public override string ToString() { if(this==null) return "null"; else return this.SalaryAgreementIdentifier+" ("+this.ActivationDate+"-"+this.DeactivationDate+")"; }

	#endregion

	/// <summary>Validates data in this SalaryAgreement</summary><exception cref="NullReferenceException" />
	public void Validate() { if(this==null) throw new NullReferenceException(); if (string.IsNullOrWhiteSpace(this.EmploymentIdentifier)) this.EmploymentIdentifier="00000";
		if (string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) this.InstitutionIdentifier="NO"; if (string.IsNullOrWhiteSpace(this.SalaryAgreementIdentifier))
			this.SalaryAgreementIdentifier="0000"; if (string.IsNullOrWhiteSpace(this.SalaryClassIdentifier)) this.SalaryClassIdentifier="0.0000"; if (string.IsNullOrWhiteSpace(
				this.SalaryScaleIdentifier)) this.SalaryScaleIdentifier="0.0000"; }

	#endregion

}
