// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="SalaryCodeGroup.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks />
public partial class SalaryCodeGroup
{

	#region Fields

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public const string CsvHeader="Id;EmploymentIdentifier;InstitutionIdentifier;ActivationDate;DeactivationDate;PensionCode\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of SalaryCodeGroup</summary>
	public SalaryCodeGroup() { }

	/// <summary>Initializes a new instance of SalaryCodeGroup</summary><param name="employmentId" /><param name="institutionId" /><param name="activationDate" /><param name="deactivationDate" /><param name="pensionCode" />
	public SalaryCodeGroup(string employmentId,string institutionId,DateTime activationDate,DateTime deactivationDate,string pensionCode) { 
		this.EmploymentIdentifier=employmentId; this.InstitutionIdentifier=institutionId; this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.PensionCode=pensionCode; Validate(); }

	/// <summary>Initializes a new instance of SalaryCodeGroup from SDWS</summary><param name="employmentId" /><param name="institutionId" /><param name="activationDate" /><param name="deactivationDate" /><param name="pensionCode" />
	public SalaryCodeGroup(string employmentId,string institutionId,string activationDate,string deactivationDate,string pensionCode) { this.EmploymentIdentifier=employmentId;
		this.InstitutionIdentifier=institutionId; this.ActivationDate=DateTime.Parse(activationDate); this.DeactivationDate=DateTime.Parse(deactivationDate); this.PensionCode=pensionCode; Validate(); }

	/// <summary>Initializes a new instance of SalaryCodeGroup from database</summary><param name="id" /><param name="employmentId" /><param name="institutionId" /><param name="activationDate" /><param name="deactivationDate" /><param name="pensionCode" />
	public SalaryCodeGroup(int id,string employmentId,string institutionId,DateTime activationDate,DateTime deactivationDate,string pensionCode) {  this.Id=id; this.EmploymentIdentifier=employmentId;
		this.InstitutionIdentifier=institutionId; this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.PensionCode=pensionCode; }

	/// <summary>Initializes a new instance of SalaryCodeGroup from database</summary><param name="array" /><exception cref="ArgumentNullException" />
	public SalaryCodeGroup(string[] array) { this.Id=int.Parse(array[0]); this.EmploymentIdentifier=array[1]; this.InstitutionIdentifier=array[2]; this.ActivationDate=DateTime.Parse(array[3]);
		this.DeactivationDate=DateTime.Parse(array[4]); this.PensionCode=array[5]; }

	/// <summary>Initializes a new instance of SalaryCodeGroup from database, that accepts data from existing SalaryCodeGroup</summary><param name="entity" />
	public SalaryCodeGroup(SalaryCodeGroup entity) { this.Id=entity.Id; this.EmploymentIdentifier=entity.EmploymentIdentifier; this.InstitutionIdentifier=
		entity.InstitutionIdentifier; this.ActivationDate=entity.ActivationDate; this.DeactivationDate=entity.DeactivationDate; this.PensionCode=entity.PensionCode; }

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
	public string PensionCode { get; set; } ="0";

	#endregion

	#region Other

	/// <remarks/>
	[NotMapped]
	public bool Active => IsActive();

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.EmploymentIdentifier+";"+this.InstitutionIdentifier+";"+this.ActivationDate.ToString("yyyy-MM-dd")+";"+this.DeactivationDate.ToString("yyyy-MM-dd")+";"+this.PensionCode+Environment.NewLine;

	/// <summary>DELETE FROM [dbo].[SalaryCodeGroupList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [dbo].[SalaryCodeGroupList] WHERE [Id]="+this.Id;

	/// <summary>SELECT * FROM [dbo].[SalaryCodeGroupList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [dbo].[SalaryCodeGroupList] WHERE [Id]="+this.Id;

	/// <summary>[SD].[dbo].[UpdateOrCreateSalaryCodeGroup] @emplId, @instId, @aactDate, @deactDate, @pensionCode</summary>
	[NotMapped]
	public string SqlUpdateOrCreateQuery => @"EXECUTE [SD].[dbo].[UpdateOrCreateSalaryCodeGroup] @emplId='"+EmploymentIdentifier+"', @instId='"+InstitutionIdentifier+
		"', @actDate='"+ActivationDate.ToString("yyyy-MM-dd")+"', @deactDate='"+DeactivationDate.ToString("yyyy-MM-dd")+"', @pensionCode='"+PensionCode+"'";

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier+"-"+this.EmploymentIdentifier;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this SalaryCodeGroup to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(SalaryCodeGroup entity) { if(this==null||entity==null) return false; if (!this.EmploymentIdentifier.Equals(entity.EmploymentIdentifier)) return false;
		else if (!this.InstitutionIdentifier.Equals(entity.InstitutionIdentifier)) return false; else if (!this.ActivationDate.Equals(entity.ActivationDate)) return false;
		else if (!this.DeactivationDate.Equals(entity.DeactivationDate)) return false; else if (!this.PensionCode.Equals(entity.PensionCode)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if(this==null) return true; Validate(); if (!this.EmploymentIdentifier.Equals("00000")&&!this.InstitutionIdentifier.Equals("NO")) return false; else return true; }

	/// <summary>Check wether validation of this SalaryCodeGroup cause changes, that must be updated in database</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsUpdated() { if(this==null) throw new NullReferenceException(); SalaryCodeGroup valGroup=new(this.EmploymentIdentifier,this.InstitutionIdentifier,this.ActivationDate,this.DeactivationDate,
		this.PensionCode) { Id=this.Id }; if (!Equals(valGroup)) return true; else return false; }

	/// <remarks/>
	private bool IsActive() { if (this ==null) throw new NullReferenceException(); else if (this.ActivationDate<=DateTime.Today&&this.DeactivationDate>=DateTime.Today) return true; else return false; }

	#endregion

	/// <returns>Content of SalaryCodeGroup as string</returns>
	public override string ToString() { if(this==null) return "null"; else return "PensionCode: "+this.PensionCode+" ("+this.ActivationDate.ToString("yyyy-MM-dd")+"-"+this.DeactivationDate.ToString("yyyy-MM-dd")+")"; }

	/// <summary>Validates data in this SalaryCodeGroup</summary><exception cref="NullReferenceException" />
	public void Validate() { if(this==null) throw new NullReferenceException(); if (string.IsNullOrWhiteSpace(this.EmploymentIdentifier)) this.EmploymentIdentifier="00000";if (string.IsNullOrWhiteSpace(this.InstitutionIdentifier))
		this.InstitutionIdentifier="NO"; if (string.IsNullOrWhiteSpace(this.PensionCode)) this.PensionCode="0"; }

	#endregion

}
