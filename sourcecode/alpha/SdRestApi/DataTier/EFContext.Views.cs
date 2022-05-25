// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EFContext.Views.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace DataTier;

/// <remarks />
public partial class EFContext : DbContext // Views
{
	#region Properties

	/// <remarks />
	public virtual DbSet<IntraNoteViewGetDepartmentUpDown> IntraNoteViewGetDepartmentUpDowns { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<IntraNoteViewGetUniquePersonEmail> IntraNoteViewGetUniquePersonEmails { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<View3in1Organization> View3in1Organizations { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<View3in1OrganizationStructure> View3in1OrganizationStructures { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<View3in1PermanentEmployment> View3in1PermanentEmployments { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<View3in1Person> View3in1Persons { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewActiveEmployment> ViewActiveEmployments { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewActiveWithoutMail> ViewActiveWithoutMails { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewContactInformation> ViewContactInformationList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewControl> ViewController { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewDepartmentLevelReference> ViewDepartmentLevelReferenceList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewDepartment> ViewDepartmentList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewDepartmentReference> ViewDepartmentReferenceList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewEmployment> ViewEmploymentList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewEmploymentProfession> ViewEmploymentProfessionList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewEmploymentStatus> ViewEmploymentStatusList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewEmploymentToday> ViewEmploymentTodays { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewFullProfession> ViewFullProfessions { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewInstitution> ViewInstitutionList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewKantine> ViewKantineList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewMoch> ViewMochs { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewOccupationRate> ViewOccupationRates { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewOrganization> ViewOrganizationList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewOrganizationStructure> ViewOrganizationStructureList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewPermanentEmployment> ViewPermanentEmployments { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewPermanentEmploymentSalaried> ViewPermanentEmploymentSalarieds { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewPerson> ViewPersonList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewPostalAddress> ViewPostalAddressList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewProfession> ViewProfessionList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewSalaryAgreement> ViewSalaryAgreementList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewSalaryCodeGroup> ViewSalaryCodeGroupList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewSelectDepartment> ViewSelectDepartments { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewSelectEmployeeWorkplace> ViewSelectEmployeeWorkplaces { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<ViewWorkingTime> ViewWorkingTimeList { get; set; } = null!;

	/// <remarks />
	public virtual DbSet<XmEmployment> ViewXmEmployments { get; set; } = null!;

	/// <remarks />
	public DbSet<TodoItem> TodoItems { get; set; } = null!;

	#endregion

}
