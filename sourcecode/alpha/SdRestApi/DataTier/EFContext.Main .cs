// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EFContext.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace DataTier;

/// <remarks />
public partial class EFContext : DbContext //Main
{
	#region Constructors
	
	/// <remarks />
	public EFContext() : base(RetrieveOptions()) { }

	/// <remarks />
	public EFContext(DbContextOptions<EFContext> options) : base(options) { }

	#endregion

	#region Events

	/// <remarks />
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { if (!optionsBuilder.IsConfigured) optionsBuilder.UseSqlServer(Resources.ConnectionString); }

	/// <remarks />
	protected override void OnModelCreating(ModelBuilder modelBuilder) { modelBuilder.HasDefaultSchema("sbo");	
		modelBuilder.Entity<ContactInformation>(entity => { entity.ToTable("ContactInformationList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.ParentIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.TelephoneNumberIdentifier1).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.TelephoneNumberIdentifier2).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.EmailAddressIdentifier1).HasColumnType("nvarchar(MAX)").IsRequired(); 
			entity.Property(e => e.EmailAddressIdentifier2).HasColumnType("nvarchar(MAX)").IsRequired(); });

		modelBuilder.Entity<Department>(entity => { entity.ToTable("DepartmentList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.ActivationDate).HasColumnType("date").IsRequired();
			entity.Property(e => e.DeactivationDate).HasColumnType("date").IsRequired(); entity.Property(e => e.DepartmentUuidIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.DepartmentIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.DepartmentLevelIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.DepartmentName).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.ProductionUnitIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); });

		modelBuilder.Entity<DepartmentLevelReference>(entity => { entity.ToTable("DepartmentLevelReferenceList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.DepartmentLevelIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.OrganizationStructure).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.SeniorDepartmentLevelReference).HasColumnType("nvarchar(MAX)").IsRequired(); });

		modelBuilder.Entity<DepartmentReference>(entity => { entity.ToTable("DepartmentReferenceList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.DepartmentIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.DepartmentUuidIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.DepartmentLevelIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.Organization).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.SeniorDepartmentReference).HasColumnType("nvarchar(MAX)").IsRequired(); });

		modelBuilder.Entity<Employment>(entity => { entity.ToTable("EmploymentList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.EmploymentIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.AnniversaryDate).HasColumnType("date").IsRequired(); entity.Property(e => e.EmploymentDate).HasColumnType("date").IsRequired();
			entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.Employee).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.EmploymentDepartment).HasColumnType("nvarchar(MAX)"); entity.Property(e => e.EmploymentProfession).HasColumnType("nvarchar(MAX)"); });

		modelBuilder.Entity<EmploymentProfession>(entity => { entity.ToTable("EmploymentProfessionList", "dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.ActivationDate).HasColumnType("date");
			entity.Property(e => e.DeactivationDate).HasColumnType("date").IsRequired(); entity.Property(e => e.JobPositionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.EmploymentName).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.AppointmentCode).HasColumnType("nvarchar(MAX)").IsRequired(); });

		modelBuilder.Entity<EmploymentStatus>(entity => { entity.ToTable("EmploymentStatusList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.EmploymentIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.ActivationDate).HasColumnType("date").IsRequired();
			entity.Property(e => e.DeactivationDate).HasColumnType("date").IsRequired(); entity.Property(e => e.EmploymentStatusCode).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.MarkedForDeletion).HasColumnType("bit").IsRequired(); });

		modelBuilder.Entity<Institution>(entity => { entity.ToTable("InstitutionList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.InstitutionUuidIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.InstitutionName).HasColumnType("nvarchar(MAX)").IsRequired(); });

		modelBuilder.Entity<Organization>(entity => { entity.ToTable("OrganizationList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.ActivationDate).HasColumnType("date").IsRequired();
			entity.Property(e => e.DeactivationDate).HasColumnType("date").IsRequired(); entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); });

		modelBuilder.Entity<OrganizationStructure>(entity => { entity.ToTable("OrganizationStructureList","dbo"); entity.HasKey(e => e.Id);
			entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); });

		modelBuilder.Entity<Person>(entity => { entity.ToTable("PersonList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.PersonCivilRegistrationIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); 
			entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();entity.Property(e => e.PersonGivenName).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.PersonSurnameName).HasColumnType("nvarchar(MAX)").IsRequired();  });

		modelBuilder.Entity<PostalAddress>(entity => { entity.ToTable("PostalAddressList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.ParentIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.StandardAddressIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.PostalCode).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.DistrictName).HasColumnType("nvarchar(MAX)").IsRequired(); 
			entity.Property(e => e.MunicipalityCode).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.CountryIdentificationCode).HasColumnType("nvarchar(MAX)").IsRequired(); });

		modelBuilder.Entity<Profession>(entity => { entity.ToTable("ProfessionList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.ActivationDate).HasColumnType("date");
			entity.Property(e => e.DeactivationDate).HasColumnType("date").IsRequired(); entity.Property(e => e.JobPositionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.JobPositionName).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.JobPositionLevelCode).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); });

		modelBuilder.Entity<SalaryAgreement>(entity => { entity.ToTable("SalaryAgreementList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.EmploymentIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.ActivationDate).HasColumnType("date").IsRequired();
			entity.Property(e => e.DeactivationDate).HasColumnType("date"); entity.Property(e => e.SalaryAgreementIdentifier).HasColumnType("nvarchar(MAX)");
			entity.Property(e => e.SalaryClassIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.SalaryScaleIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.PrepaidIndicator).HasColumnType("bit").IsRequired(); entity.Property(e => e.SeniorityDate).HasColumnType("date").IsRequired(); });

		modelBuilder.Entity<SalaryCodeGroup>(entity => { entity.ToTable("SalaryCodeGroupList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.EmploymentIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.ActivationDate).HasColumnType("date").IsRequired();
			entity.Property(e => e.DeactivationDate).HasColumnType("date").IsRequired();entity.Property(e => e.PensionCode).HasColumnType("nvarchar(MAX)").IsRequired(); });

		modelBuilder.Entity<SuccessfulRun>(entity => { entity.ToTable("SuccessfulRunList","dbo"); entity.Property(e => e.Id).ValueGeneratedNever(); entity.Property(e => e.InstitutionIdentifier).
			HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.SdApi).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.RunDate).HasColumnType("nvarchar(MAX)").IsRequired(); });

		modelBuilder.Entity<WorkingTime>(entity => { entity.ToTable("WorkingTimeList","dbo"); entity.HasKey(e => e.Id); entity.Property(e => e.EmploymentIdentifier).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.InstitutionIdentifier).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.ActivationDate).HasColumnType("date").IsRequired();
			entity.Property(e => e.DeactivationDate).HasColumnType("date").IsRequired(); entity.Property(e => e.OccupationRate).HasColumnType("nvarchar(MAX)").IsRequired();
			entity.Property(e => e.SalaryRate).HasColumnType("nvarchar(MAX)").IsRequired(); entity.Property(e => e.SalariedIndicator).HasColumnType("bit").IsRequired();
			entity.Property(e => e.AutomaticRaiseIndicator).HasColumnType("bit").IsRequired(); entity.Property(e => e.FullTimeIndicator).HasColumnType("bit").IsRequired(); });

		modelBuilder.Entity<IntraNoteViewGetDepartmentUpDown>(entity => { entity.HasNoKey(); entity.ToView("IntraNote_View_GetDepartment_UpDown","dbo"); entity.Property(e => e.DepartmentReferencesId).HasColumnName("DepartmentReferences_Id"); });
		modelBuilder.Entity<IntraNoteViewGetUniquePersonEmail>(entity => { entity.HasNoKey(); entity.ToView("IntraNote_View_GetUniquePerson_Email","dbo"); entity.Property(e => e.EmploymentId).HasColumnName("Employment_Id"); });

		modelBuilder.Entity<View3in1Organization>(entity => { entity.HasNoKey(); entity.ToView("View3in1Organizations","dbo"); });
		modelBuilder.Entity<View3in1OrganizationStructure>(entity => { entity.HasNoKey(); entity.ToView("View3in1OrganizationStructure","dbo"); });

		modelBuilder.Entity<View3in1PermanentEmployment>(entity => { entity.HasNoKey(); entity.ToView("View_3IN1_Permanent_Employment","dbo");
			entity.Property(e => e.AfdelingsUuid).HasColumnName("AfdelingsUUID"); entity.Property(e => e.Cpr).HasColumnName("CPR"); });

		modelBuilder.Entity<View3in1Person>(entity => { entity.HasNoKey(); entity.ToView("View3in1Persons","dbo"); });

		modelBuilder.Entity<ViewActiveEmployment>(entity => { entity.HasNoKey(); entity.ToView("View_Active_Employments","dbo"); entity.Property(e => e.ActivationDate).HasColumnType("date");
			entity.Property(e => e.AnniversaryDate).HasColumnType("date"); entity.Property(e => e.DeactivationDate).HasColumnType("date");
			entity.Property(e => e.EmploymentId).HasColumnName("Employment_Id"); entity.Property(e => e.Hoursw).HasColumnType("decimal(21, 0)"); });

		modelBuilder.Entity<ViewActiveWithoutMail>(entity => { entity.HasNoKey(); entity.ToView("View_Active_without_mail","dbo"); entity.Property(e => e.Cpr).HasColumnName("CPR"); });
		modelBuilder.Entity<ViewContactInformation>(entity => { entity.HasNoKey(); entity.ToView("ViewContactInformationListHB","dbo"); });
		modelBuilder.Entity<ViewControl>(entity => { entity.HasNoKey(); entity.ToView("ViewController","dbo"); });
		modelBuilder.Entity<ViewDepartment>(entity => { entity.HasNoKey(); entity.ToView("ViewDepartmentListHB","dbo"); });
		modelBuilder.Entity<ViewDepartmentLevelReference>(entity => { entity.HasNoKey(); entity.ToView("ViewDepartmentLevelReferenceListHB","dbo"); });
		modelBuilder.Entity<ViewDepartmentReference>(entity => { entity.HasNoKey(); entity.ToView("ViewDepartmentReferenceListHB","dbo"); });
		modelBuilder.Entity<ViewEmployment>(entity => { entity.HasNoKey(); entity.ToView("ViewEmploymentListHB","dbo"); });
		modelBuilder.Entity<ViewEmploymentProfession>(entity => { entity.HasNoKey(); entity.ToView("ViewEmploymentProfessionListHB","dbo"); });
		modelBuilder.Entity<ViewEmploymentStatus>(entity => { entity.HasNoKey(); entity.ToView("ViewEmploymentStatusListHB","dbo"); });
		modelBuilder.Entity<ViewEmploymentToday>(entity => { entity.HasNoKey(); entity.ToView("View_Employment_Today","dbo"); entity.Property(e => e.DepartmentUuid).HasColumnName("DepartmentUUID"); });
		modelBuilder.Entity<ViewFullProfession>(entity => { entity.HasNoKey(); entity.ToView("ViewFullProfessions","dbo"); });
		modelBuilder.Entity<ViewInstitution>(entity => { entity.HasNoKey(); entity.ToView("ViewInstitutionListHB","dbo"); });
		modelBuilder.Entity<ViewKantine>(entity => { entity.HasNoKey(); entity.ToView("ViewKantineList","dbo"); });
		modelBuilder.Entity<ViewMoch>(entity => { entity.HasNoKey(); entity.ToView("View_MOCH","dbo"); });
		modelBuilder.Entity<ViewOccupationRate>(entity => { entity.HasNoKey(); entity.ToView("View_OccupationRates","dbo"); });
		modelBuilder.Entity<ViewOrganization>(entity => { entity.HasNoKey(); entity.ToView("ViewOrganizationListHB","dbo"); });
		modelBuilder.Entity<ViewOrganizationStructure>(entity => { entity.HasNoKey(); entity.ToView("ViewOrganizationStructureListHB", "dbo"); });
		modelBuilder.Entity<ViewPermanentEmployment>(entity => { entity.HasNoKey(); entity.ToView("View_Permanent_Employment","dbo"); entity.Property(e => e.DepartmentUuid).HasColumnName("DepartmentUUID"); });
		modelBuilder.Entity<ViewPermanentEmploymentSalaried>(entity => { entity.HasNoKey(); entity.ToView("View_Permanent_Employment_Salaried","dbo"); entity.Property(e => e.DepartmentUuid).HasColumnName("DepartmentUUID"); });
		modelBuilder.Entity<ViewPerson>(entity => { entity.HasNoKey(); entity.ToView("ViewPersonListHB","dbo"); });
		modelBuilder.Entity<ViewPostalAddress>(entity => { entity.HasNoKey(); entity.ToView("ViewPostalAddressListHB","dbo"); });
		modelBuilder.Entity<ViewProfession>(entity => { entity.HasNoKey(); entity.ToView("ViewProfessionListHB","dbo"); });
		modelBuilder.Entity<ViewSalaryAgreement>(entity => { entity.HasNoKey(); entity.ToView("ViewSalaryAgreementListHB","dbo"); });
		modelBuilder.Entity<ViewSalaryCodeGroup>(entity => { entity.HasNoKey(); entity.ToView("ViewSalaryCodeGroupListHB","dbo"); });
		modelBuilder.Entity<ViewSelectDepartment>(entity => { entity.HasNoKey(); entity.ToView("View_Select_Department","dbo"); entity.Property(e => e.DepartmentReferencesId).HasColumnName("DepartmentReferences_Id"); });
		modelBuilder.Entity<ViewSelectEmployeeWorkplace>(entity => { entity.HasNoKey(); entity.ToView("View_Select_Employee_Workplace","dbo"); entity.Property(e => e.EmploymentId).HasColumnName("Employment_Id"); });
		modelBuilder.Entity<ViewWorkingTime>(entity => { entity.HasNoKey(); entity.ToView("ViewWorkingTimeListHB","dbo"); });
		modelBuilder.Entity<XmEmployment>(entity => { entity.HasNoKey(); entity.ToView("ViewXmEmployments", "dbo"); });

		OnModelCreatingPartial(modelBuilder); }

	/// <remarks />
	partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

	#endregion

	#region Methods

	/// <remarks />
	private static DbContextOptions RetrieveOptions() { DbContextOptionsBuilder<EFContext> optionsBuilder = new(); optionsBuilder.UseSqlServer(Resources.ConnectionString); return optionsBuilder.Options; }

	#endregion

}
