// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EFExtension.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace DataTier;

/// <remarks/>
public class EFExtension
{

	#region Methods

	/// <summary>Deletes an entry from Database</summary><typeparam name="T" /><param name="entity" />
	public static async Task DeleteFromDatabase<T>(T entity) where T : class { string type=typeof(T).Name.ToLower(); using EFContext dbo=new(); switch (type) {
		case "contactinformation": await dbo.Database.ExecuteSqlRawAsync((entity as ContactInformation).SqlDeleteQuery); break;
		case "department": await dbo.Database.ExecuteSqlRawAsync((entity as Department).SqlDeleteQuery); break;
		case "departmentlevelreference": await dbo.Database.ExecuteSqlRawAsync((entity as DepartmentLevelReference).SqlDeleteQuery); break;
		case "departmentreference": await dbo.Database.ExecuteSqlRawAsync((entity as DepartmentReference).SqlDeleteQuery); break;
		case "employment": await dbo.Database.ExecuteSqlRawAsync((entity as Employment).SqlDeleteQuery); break;
		case "employmentprofession": await dbo.Database.ExecuteSqlRawAsync((entity as EmploymentProfession).SqlDeleteQuery); break;
		case "employmentstatus": await dbo.Database.ExecuteSqlRawAsync((entity as EmploymentStatus).SqlDeleteQuery); break;
		case "institution": await dbo.Database.ExecuteSqlRawAsync((entity as Institution).SqlDeleteQuery); break;
		case "organization": await dbo.Database.ExecuteSqlRawAsync((entity as Organization).SqlDeleteQuery); break;
		case "organizationstructure": await dbo.Database.ExecuteSqlRawAsync((entity as OrganizationStructure).SqlDeleteQuery); break;
		case "person": await dbo.Database.ExecuteSqlRawAsync((entity as Person).SqlDeleteQuery); break;
		case "postaladdress": await dbo.Database.ExecuteSqlRawAsync((entity as PostalAddress).SqlDeleteQuery); break;
		case "profession": await dbo.Database.ExecuteSqlRawAsync((entity as Profession).SqlDeleteQuery); break;
		case "salaryagreement": await dbo.Database.ExecuteSqlRawAsync((entity as SalaryAgreement).SqlDeleteQuery); break;
		case "salarycodegroup": await dbo.Database.ExecuteSqlRawAsync((entity as SalaryCodeGroup).SqlDeleteQuery); break;
		case "successfulrun": await dbo.Database.ExecuteSqlRawAsync((entity as SuccessfulRun).SqlDeleteQuery); break;
		case "workingtime": await dbo.Database.ExecuteSqlRawAsync((entity as WorkingTime).SqlDeleteQuery); break;
		default: throw new InvalidRefException(nameof(type),type,type+Error.InvTypeParam); } }

	#region Retrieve

	/// <returns>Entity type from a list name as string</returns><param name="list">string</param>
	public static string RetrieveEntityTypeFromListName(string list) => list switch { "ContactInformationList" => "ContactInformation", "DepartmentList" => "Department", "DepartmentLevelReferenceList" => "DepartmentLevelReference",
		"DepartmentReferenceList" => "DepartmentReference", "EmploymentList" => "Employment", "EmploymentProfessionList" => "EmploymentProfession", "EmploymentStatusList" => "EmploymentStatus", "InstitutionList" => "Institution",
		"OrganizationList" => "Organization", "OrganizationStructureList" => "OrganizationStructure", "PersonList" => "Person", "PostalAddressList" => "PostalAddress", "ProfessionList" => "Profession",
		"SalaryAgreementList" => "SalaryAgreement", "SalaryCodeGroupList" => "SalaryCodeGroup", "SdAdRelationList" => "SdAdRelation", "SuccessfulRunList" => "SuccessfulRun", "WorkingTimeList" => "WorkingTime",
		_ => throw new ArgumentInvalidException(nameof(list), list, nameof(list)+Error.UnkParam), };

	/// <returns>Amount of fields as int</returns><param name="list" />
	public static int RetrieveFieldAmount(string list) { return list switch { "ContactInformationList" => 7, "DepartmentList" => 9, "DepartmentLevelReferenceList" => 4,
		"DepartmentReferenceList" => 6, "EmploymentList" => 8, "EmploymentProfessionList" => 7, "EmploymentStatusList" => 7, "InstitutionList" => 4, "OrganizationList" => 4,
		"OrganizationStructureList" => 2, "PersonList" => 5, "PostalAddressList" => 8, "ProfessionList" => 7, "SalaryAgreementList" => 10, "SalaryCodeGroupList" => 6,
		"SuccessfulRunList" => 4, "WorkingTimeList" => 10, _ => throw new ArgumentInvalidException(nameof(list), list, nameof(list)+Error.UnkParam), }; }

	/// <returns>List name from an entity type as string</returns><param name="entityType" />
	public static string RetrieveListNameFromEntityType(string entityType) { return entityType switch { "ContactInformation" => "ContactInformationList", "Department" => "DepartmentList",
		"DepartmentLevelReference" => "DepartmentLevelReferenceList", "DepartmentReference" => "DepartmentReferenceList", "Employment" => "EmploymentList", "EmploymentProfession" => "EmploymentProfessionList",
		"EmploymentStatus" => "EmploymentStatusList", "Institution" => "InstitutionList", "Organization" => "OrganizationList", "OrganizationStructure" => "OrganizationStructureList", "Person" => "PersonList",
		"PostalAddress" => "PostalAddressList", "Profession" => "ProfessionList", "SalaryAgreement" => "SalaryAgreementList", "SalaryCodeGroup" => "SalaryCodeGroupList", "SdAdRelation" => "SdAdRelationList",
		"SuccessfulRun" => "SuccessfulRunList", "WorkingTime" => "WorkingTimeList", _ => throw new ArgumentInvalidException(nameof(entityType), entityType, nameof(entityType)+Error.UnkParam), }; }

	#endregion

	#region Select

	/// <summary>Deletes an entry from Database</summary><typeparam name="T" /><param name="entity" />
	public static T SelectEntityFromDatabase<T>(T entity) where T : class { string type=typeof(T).Name.ToLower(); T result=new object() as T; using EFContext dbo=new(); switch (type) {
		case "contactinformation": List<ContactInformation> infoList = dbo.ContactInformationList.FromSqlRaw((entity as ContactInformation).SqlSelectQuery).ToListAsync().Result;
			if (infoList.Count>=1) return infoList[0] as T; else throw new EmptyRefException(nameof(type),entity as ContactInformation,Error.DbNonExist);
		case "department": List<Department> deptList = dbo.DepartmentList.FromSqlRaw((entity as Department).SqlSelectQuery).ToListAsync().Result;
			if (deptList.Count>=1) return deptList[0] as T; else throw new EmptyRefException(nameof(type),entity as Department,Error.DbNonExist);
		case "departmentlevelreference": List<DepartmentLevelReference> dlrList = dbo.DepartmentLevelReferenceList.FromSqlRaw((entity as DepartmentLevelReference).SqlSelectQuery).ToListAsync().Result;
			if (dlrList.Count>=1) return dlrList[0] as T; else throw new EmptyRefException(nameof(type),entity as DepartmentLevelReference,Error.DbNonExist);
		case "departmentreference": List<DepartmentReference> drList = dbo.DepartmentReferenceList.FromSqlRaw((entity as DepartmentReference).SqlSelectQuery).ToListAsync().Result;
			if (drList.Count>=1) return drList[0] as T; else throw new EmptyRefException(nameof(type),entity as DepartmentReference,Error.DbNonExist);
		case "employment": List<Employment> empllist = dbo.EmploymentList.FromSqlRaw((entity as Employment).SqlSelectQuery).ToListAsync().Result;
			if (empllist.Count>=1) return empllist[0] as T; else throw new EmptyRefException(nameof(type),entity as Employment,Error.DbNonExist);
		case "employmentprofession": List<EmploymentProfession> emplproflist = dbo.EmploymentProfessionList.FromSqlRaw((entity as EmploymentProfession).SqlSelectQuery).ToListAsync().Result;
			if (emplproflist.Count>=1) return emplproflist[0] as T; else throw new EmptyRefException(nameof(type),entity as Employment,Error.DbNonExist);
		case "employmentstatus": List<EmploymentStatus> statusList = dbo.EmploymentStatusList.FromSqlRaw((entity as EmploymentStatus).SqlSelectQuery).ToListAsync().Result;
			if (statusList.Count>=1) return statusList[0] as T; else throw new EmptyRefException(nameof(type),entity as EmploymentStatus,Error.DbNonExist);
		case "institution": List<Institution> instList = dbo.InstitutionList.FromSqlRaw((entity as Institution).SqlSelectQuery).ToListAsync().Result;
			if (instList.Count>=1) return instList[0] as T; else throw new EmptyRefException(nameof(type),entity as Institution,Error.DbNonExist);
		case "organization": List<Organization> orgList = dbo.OrganizationList.FromSqlRaw((entity as Organization).SqlSelectQuery).ToListAsync().Result;
			if (orgList.Count>=1) return orgList[0] as T; else throw new EmptyRefException(nameof(type),entity as Organization,Error.DbNonExist);
		case "organizationstructure": List<OrganizationStructure> structureList = dbo.OrganizationStructureList.FromSqlRaw((entity as OrganizationStructure).SqlSelectQuery).ToListAsync().Result;
			if (structureList.Count>=1) return structureList[0] as T; else throw new EmptyRefException(nameof(type),entity as OrganizationStructure,Error.DbNonExist);
		case "person": List<Person> persList = dbo.PersonList.FromSqlRaw((entity as Person).SqlSelectQuery).ToListAsync().Result; if (persList.Count>=1) 
					return persList[0] as T; else throw new EmptyRefException(nameof(type),entity as Person,Error.DbNonExist);
		case "postaladdress": List<PostalAddress> addrList = dbo.PostalAddressList.FromSqlRaw((entity as PostalAddress).SqlSelectQuery).ToListAsync().Result;
			if (addrList.Count>=1) return addrList[0] as T; else throw new EmptyRefException(nameof(type),entity as PostalAddress,Error.DbNonExist);
		case "profession": List<Profession> profList = dbo.ProfessionList.FromSqlRaw((entity as Profession).SqlSelectQuery).ToListAsync().Result;
			if (profList.Count>=1) return profList[0] as T; else throw new EmptyRefException(nameof(type),entity as Profession,Error.DbNonExist);
		case "salaryagreement": List<SalaryAgreement> agreeList = dbo.SalaryAgreementList.FromSqlRaw((entity as SalaryAgreement).SqlSelectQuery).ToListAsync().Result;
			if (agreeList.Count>=1) return agreeList[0] as T; else throw new EmptyRefException(nameof(type),entity as SalaryAgreement,Error.DbNonExist);
		case "salarycodegroup": List<SalaryCodeGroup> groupList = dbo.SalaryCodeGroupList.FromSqlRaw((entity as SalaryCodeGroup).SqlSelectQuery).ToListAsync().Result;
			if (groupList.Count>=1) return groupList[0] as T; else throw new EmptyRefException(nameof(type),entity as SalaryCodeGroup,Error.DbNonExist);
		case "successfulrun": List<SuccessfulRun> runList = dbo.SuccessfulRunList.FromSqlRaw((entity as SuccessfulRun).SqlSelectQuery).ToListAsync().Result;
			if (runList.Count>=1) return runList[0] as T; else throw new EmptyRefException(nameof(type),entity as SuccessfulRun,Error.DbNonExist);
		case "workingtime": List<WorkingTime> timeList = dbo.WorkingTimeList.FromSqlRaw((entity as WorkingTime).SqlSelectQuery).ToListAsync().Result;
			if (timeList.Count>=1) return timeList[0] as T; else throw new EmptyRefException(nameof(type),entity as WorkingTime,Error.DbNonExist);
		default: throw new InvalidRefException(nameof(type),type,type+Error.InvTypeParam); } }

	/// <summary>Deletes an entry from Database</summary><typeparam name="T" />
	public static List<T> SelectListFromDatabase<T>() where T : class { using EFContext dbo=new(); return typeof(T).Name.ToLower() switch {
		"contactinformation" => dbo.ContactInformationList.ToListAsync().Result as List<T>, "department" => dbo.DepartmentList.ToListAsync().Result as List<T>,
		"departmentlevelreference" => dbo.DepartmentLevelReferenceList.ToListAsync().Result as List<T>, "departmentreference" => dbo.DepartmentReferenceList.ToListAsync().Result as List<T>,
		"employment" => dbo.EmploymentList.ToListAsync().Result as List<T>, "employmentprofession" => dbo.EmploymentProfessionList.ToListAsync().Result as List<T>,
		"employmentstatus" => dbo.EmploymentStatusList.ToListAsync().Result as List<T>, "institution" => dbo.InstitutionList.ToListAsync().Result as List<T>,
		"organization" => dbo.OrganizationList.ToListAsync().Result as List<T>, "organizationstructure" => dbo.OrganizationStructureList.ToListAsync().Result as List<T>,
		"person" => dbo.PersonList.ToListAsync().Result as List<T>, "postaladdress" => dbo.PostalAddressList.ToListAsync().Result as List<T>,
		"profession" => dbo.ProfessionList.ToListAsync().Result as List<T>, "salaryagreement" => dbo.SalaryAgreementList.ToListAsync().Result as List<T>,
		"salarycodegroup" => dbo.SalaryCodeGroupList.ToListAsync().Result as List<T>, "successfulrun" => dbo.SuccessfulRunList.ToListAsync().Result as List<T>,
		"workingtime" => dbo.WorkingTimeList.ToListAsync().Result as List<T>, _ => throw new InvalidRefException(typeof(T).Name+Error.InvTypeParam), }; }

	/// <summary>Deletes an entry from Database</summary><typeparam name="T" />
	public static List<T> SelectViewFromDatabase<T>() where T : class { using EFContext dbo=new(); return typeof(T).Name.ToLower() switch {
		"view3in1organization" => dbo.View3in1Organizations.FromSqlRaw("SELECT * FROM [SD].[dbo].[View3in1Organizations] ORDER BY Afdelingsid,Overordnet").ToListAsync().Result as List<T>,
		"view3in1organizationstructure" => dbo.View3in1OrganizationStructures.FromSqlRaw("SELECT * FROM [SD].[dbo].[View3in1OrganizationStructures] ORDER BY Afdelingsid,Overordnet").ToListAsync().Result as List<T>,
		"view3in1person" => dbo.View3in1Persons.FromSqlRaw("SELECT * FROM [SD].[dbo].[View3in1Persons] ORDER BY Cpr,Tjenestenummer").ToListAsync().Result as List<T>,
		"viewcontactinformation" => dbo.ViewContactInformationList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewContactInformationListHB]").ToListAsync().Result as List<T>,
		"viewcontroller" => dbo.ViewController.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewController]").ToListAsync().Result as List<T>,
		"viewdepartment" => dbo.ViewDepartmentList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewDepartmentListHB]").ToListAsync().Result as List<T>,
		"viewdepartmentlevelreference" => dbo.ViewDepartmentLevelReferenceList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewDepartmentLevelReferenceListHB]").ToListAsync().Result as List<T>,
		"viewdepartmentreference" => dbo.ViewDepartmentReferenceList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewDepartmentReferenceListHB]").ToListAsync().Result as List<T>,
		"viewemployment" => dbo.ViewEmploymentList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewEmploymentListHB]").ToListAsync().Result as List<T>,
		"viewemploymentprofession" => dbo.ViewEmploymentProfessionList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewEmploymentProfessionListHB]").ToListAsync().Result as List<T>,
		"viewemploymentstatus" => dbo.ViewEmploymentStatusList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewEmploymentstatusListHB]").ToListAsync().Result as List<T>,
		"viewfullprofession" => dbo.ViewFullProfessions.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewFullProfessions]").ToListAsync().Result as List<T>,
		"viewinstitution" => dbo.ViewInstitutionList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewInstitutionListHB]").ToListAsync().Result as List<T>,
		"viewkantin" => dbo.ViewKantineList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewKantineList] ORDER BY Cpr,Tjenestenummer,Afdelingkode,Beskæftigelsesdecimal DESC").ToListAsync().Result as List<T>,
		"vieworganization" => dbo.ViewOrganizationList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewOrganizationListHB]").ToListAsync().Result as List<T>,
		"vieworganizationstructure" => dbo.ViewOrganizationStructureList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewOrganizationStructureListHB]").ToListAsync().Result as List<T>,
		"viewperson" => dbo.ViewPersonList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewPersonListHB]").ToListAsync().Result as List<T>,
		"viewpostaladdress" => dbo.ViewPostalAddressList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewPostalAddressListHB]").ToListAsync().Result as List<T>,
		"viewprofession" => dbo.ViewProfessionList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewProfessionListHB]").ToListAsync().Result as List<T>,
		"viewsalaryagreement" => dbo.ViewSalaryAgreementList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewSalaryAgreementListHB]").ToListAsync().Result as List<T>,
		"viewsalarycodegroup" => dbo.ViewSalaryCodeGroupList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewSalaryCodeGroupListHB]").ToListAsync().Result as List<T>,
		"viewworkingtime" => dbo.ViewWorkingTimeList.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewWorkingTimeListHB]").ToListAsync().Result as List<T>,
		"xmemployment" => dbo.ViewXmEmployments.FromSqlRaw("SELECT * FROM [SD].[dbo].[ViewXmEmployments] ORDER BY Cpr,EmploymentId").ToListAsync().Result as List<T>,
		_ => throw new InvalidRefException(typeof(T).Name+Error.InvTypeParam), }; }

	/// <summary>Swaps content of <paramref name="info"/>.EmailAddressIdentifier1 and <paramref name="info"/>.EmailAddressIdentifier2</summary><param name="info" /><returns>Updated ContactInformation</returns>
	public static ContactInformation SwapEmailAdresses(ContactInformation info) => new(info.ParentIdentifier,info.InstitutionIdentifier,info.TelephoneNumberIdentifier1,info.TelephoneNumberIdentifier2,info.EmailAddressIdentifier2,info.EmailAddressIdentifier1);

	/// <summary>Swaps content of <paramref name="info"/>.TelephoneNumberIdentifier1 and <paramref name="info"/>.TelephoneNumberIdentifier2</summary><param name="info" /><returns>Updated ContactInformation</returns>
	public static ContactInformation SwapPhoneNumbers(ContactInformation info) => new(info.ParentIdentifier,info.InstitutionIdentifier,info.TelephoneNumberIdentifier2,info.TelephoneNumberIdentifier1,info.EmailAddressIdentifier1,info.EmailAddressIdentifier2);

	#endregion

	/// <remarks /><typeparam name="T" /><param name="entity" /><exception cref="InvalidRefException" />
	public static int UpdateOrCreateInDatabase<T>(T entity) where T : class { string type=typeof(T).Name; using EFContext dbo=new(); return type switch {
		"ContactInformation" => dbo.Database.ExecuteSqlRaw((entity as ContactInformation).SqlUpdateOrCreateQuery), "Department" => dbo.Database.ExecuteSqlRaw((entity as Department).SqlUpdateOrCreateQuery),
		"DepartmentLevelReference" => dbo.Database.ExecuteSqlRaw((entity as DepartmentLevelReference).SqlUpdateOrCreateQuery), "DepartmentReference" => dbo.Database.ExecuteSqlRaw((entity as DepartmentReference).SqlUpdateOrCreateQuery),
		"Employment" => dbo.Database.ExecuteSqlRaw((entity as Employment).SqlUpdateOrCreateQuery), "EmploymentProfession" => dbo.Database.ExecuteSqlRaw((entity as EmploymentProfession).SqlUpdateOrCreateQuery),
		"EmploymentStatus" => dbo.Database.ExecuteSqlRaw((entity as EmploymentStatus).SqlUpdateOrCreateQuery), "Institution" => dbo.Database.ExecuteSqlRaw((entity as Institution).SqlUpdateOrCreateQuery),
		"Organization" => dbo.Database.ExecuteSqlRaw((entity as Organization).SqlUpdateOrCreateQuery), "OrganizationStructure" => dbo.Database.ExecuteSqlRaw((entity as OrganizationStructure).SqlUpdateOrCreateQuery),
		"PostalAddress" => dbo.Database.ExecuteSqlRaw((entity as PostalAddress).SqlUpdateOrCreateQuery), "Profession" => dbo.Database.ExecuteSqlRaw((entity as Profession).SqlUpdateOrCreateQuery),
		"SalaryAgreement" => dbo.Database.ExecuteSqlRaw((entity as SalaryAgreement).SqlUpdateOrCreateQuery), "SalaryCodeGroup" => dbo.Database.ExecuteSqlRaw((entity as SalaryCodeGroup).SqlUpdateOrCreateQuery),
		"SuccessfulRun" => dbo.Database.ExecuteSqlRaw((entity as SuccessfulRun).SqlUpdateOrCreateQuery), "WorkingTime" => dbo.Database.ExecuteSqlRaw((entity as WorkingTime).SqlUpdateOrCreateQuery),
		_ => throw new InvalidRefException(nameof(type),type,type+Error.InvTypeParam), }; }

	#endregion

}
