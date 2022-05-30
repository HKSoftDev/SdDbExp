// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsEmployment.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks/>
[JsonObject("Employment")][XmlType("Employment")][Serializable]
public class WsEmployment
{
	#region Constructors

	/// <summary>Initializes an empty instance of Employment</summary>
	public WsEmployment() { }

	/// <summary>Initializes a new instance of Employment from SDWS</summary><param name="employmentId" /><param name="employmentDate" /><param name="anniversaryDate" /><param name="institution" /><param name="employee" />
	/// <param name="employmentDepartment" /><param name="profession" /><param name="employmentStatus" /><param name="salaryAgreement" /><param name="salaryCodeGroup" /><param name="workingTime" />
	public WsEmployment(string employmentId,string employmentDate,string anniversaryDate,string institution,string employee, WsDepartment employmentDepartment, WsEmploymentProfession profession,
		WsEmploymentStatus? employmentStatus=null,WsSalaryAgreement? salaryAgreement=null,WsSalaryCodeGroup? salaryCodeGroup=null,WsWorkingTime? workingTime=null) { this.EmploymentIdentifier=employmentId; 
			this.EmploymentDate=employmentDate; this.AnniversaryDate=anniversaryDate; this.InstitutionIdentifier=institution; this.Employee=employee; this.EmploymentDepartment=employmentDepartment;
				this.Profession=profession; this.EmploymentStatus=employmentStatus; this.SalaryAgreement=salaryAgreement; this.SalaryCodeGroup=salaryCodeGroup; this.WorkingTime=workingTime; }

	/// <summary>Initializes a new instance of Employment, that accepts data from an existing Employment</summary><param name="employmentStatus" />
	public WsEmployment(WsEmployment employmentStatus) { this.EmploymentIdentifier=employmentStatus.EmploymentIdentifier; this.EmploymentDate=employmentStatus.EmploymentDate;
		this.AnniversaryDate=employmentStatus.AnniversaryDate; this.InstitutionIdentifier=employmentStatus.InstitutionIdentifier; this.Employee=employmentStatus.Employee; 
		this.EmploymentDepartment=employmentStatus.EmploymentDepartment; this.EmploymentStatus=employmentStatus.EmploymentStatus; this.Profession=employmentStatus.Profession;
		this.SalaryAgreement=employmentStatus.SalaryAgreement; this.SalaryCodeGroup=employmentStatus.SalaryCodeGroup; this.WorkingTime=employmentStatus.WorkingTime; }

	#endregion

	#region Properties

	/// <remarks/>
	[JsonProperty("EmploymentIdentifier")][XmlElement("EmploymentIdentifier")]
	public string EmploymentIdentifier { get; set; } = "00000";

	/// <remarks/>
	[JsonProperty("EmploymentDate")][XmlElement("EmploymentDate")]
	public string EmploymentDate { get; set; } = "2010-01-01";

	/// <remarks/>
	[JsonProperty("AnniversaryDate")][XmlElement("AnniversaryDate")]
	public string AnniversaryDate { get; set; } = "2010-01-01";

	/// <remarks/>
	[JsonIgnore()][XmlIgnore]
	public string InstitutionIdentifier { get; set; } = string.Empty;

	/// <remarks/>
	[JsonIgnore()][XmlIgnore]
	public string Employee { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("EmploymentDepartment")][XmlElement("EmploymentDepartment")]
	public WsDepartment EmploymentDepartment { get; set; } = new();

	/// <remarks/>
	[JsonProperty("Profession")][XmlElement("Profession")]
	public WsEmploymentProfession Profession { get; set; } = new();

	/// <remarks/>
	[JsonProperty("EmploymentStatus")][XmlElement("EmploymentStatus")]
	public WsEmploymentStatus? EmploymentStatus { get; set; }

	/// <remarks/>
	[JsonProperty("SalaryAgreement")][XmlElement("SalaryAgreement")]
	public WsSalaryAgreement? SalaryAgreement { get; set; }

	/// <remarks/>
	[JsonProperty("SalaryCodeGroup")][XmlElement("SalaryCodeGroup")]
	public WsSalaryCodeGroup? SalaryCodeGroup { get; set; }

	/// <remarks/>
	[JsonProperty("WorkingTime")][XmlElement("WorkingTime")]
	public WsWorkingTime? WorkingTime { get; set; }

	#endregion

	#region Methods

	/// <returns>Content of this Employment as string</returns>
	public override string ToString() { if (this==null) return "null"; else return this.InstitutionIdentifier+"-"+this.EmploymentIdentifier; }

	/// <remarks/>
	public Department ToDepartment() { if (this==null||this.EmploymentDepartment==null) throw new NullReferenceException(); return this.EmploymentDepartment.ToDepartment(this.InstitutionIdentifier); }

	/// <remarks/>
	public Employment ToEmployment() { if (this==null) throw new NullReferenceException(); return new(this.EmploymentIdentifier,DateTime.Parse(this.EmploymentDate),DateTime.Parse(this.AnniversaryDate),
			this.InstitutionIdentifier,this.Employee,this.EmploymentDepartment.DepartmentUuidIdentifier,this.Profession.JobPositionIdentifier); }

	/// <remarks/>
	public EmploymentStatus ToEmploymentStatus() { if (this==null||this.EmploymentStatus==null) return new(); return this.EmploymentStatus.ToEmploymentStatus(this.EmploymentIdentifier,this.InstitutionIdentifier); }

	/// <remarks/>
	public EmploymentProfession ToEmploymentProfession() { if (this==null||this.EmploymentStatus==null) return new(); return this.Profession.ToEmploymentProfession(this.EmploymentIdentifier,this.InstitutionIdentifier); }

	/// <remarks/>
	public SalaryAgreement ToSalaryAgreement() { if (this==null||this.SalaryAgreement==null) return new(); return this.SalaryAgreement.ToSalaryAgreement(this.EmploymentIdentifier,this.InstitutionIdentifier); }

	/// <remarks/>
	public SalaryCodeGroup ToSalaryCodeGroup() { if (this==null||this.SalaryCodeGroup==null) return new(); return this.SalaryCodeGroup.ToSalaryCodeGroup(this.EmploymentIdentifier,this.InstitutionIdentifier); }

	/// <remarks/>
	public WorkingTime ToWorkingTime() { if (this==null||this.WorkingTime==null) return new(); return this.WorkingTime.ToWorkingTime(this.EmploymentIdentifier,this.InstitutionIdentifier); }

	#endregion

}
