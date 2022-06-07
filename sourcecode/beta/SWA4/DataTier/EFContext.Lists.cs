// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EFContext.Lists.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace DataTier;

/// <remarks />
public partial class EFContext : DbContext // Lists
{

	#region Properties

	/// <remarks />
	public virtual DbSet<ContactInformation> ContactInformationList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<DepartmentLevelReference> DepartmentLevelReferenceList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<Department> DepartmentList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<DepartmentReference> DepartmentReferenceList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<Employment> EmploymentList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<EmploymentProfession> EmploymentProfessionList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<EmploymentStatus> EmploymentStatusList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<Institution> InstitutionList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<Organization> OrganizationList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<OrganizationStructure> OrganizationStructureList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<Person> PersonList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<PostalAddress> PostalAddressList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<Profession> ProfessionList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<SalaryAgreement> SalaryAgreementList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<SalaryCodeGroup> SalaryCodeGroupList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<SuccessfulRun> SuccessfulRunList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<WorkingTime> WorkingTimeList { get; set; } = null!;

	#endregion

}
