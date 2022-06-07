// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Database.Main.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Database Main
{
	#region Methods

	/// <returns>Id as int</returns><typeparam name="T" /><param name="entity" /><exception cref="InvalidRefException" />
	public int CreateInDatabaseWithId<T>(T entity) where T : class => typeof(T).Name switch { "ContactInformation" => CreateContactInformationInDatabaseWithId(entity as ContactInformation),
		"Department" => CreateDepartmentInDatabaseWithId(entity as Department), "DepartmentLevelReference" => CreateDepartmentLevelReferenceInDatabaseWithId(entity as DepartmentLevelReference),
		"DepartmentReference" => CreateDepartmentReferenceInDatabaseWithId(entity as DepartmentReference), "Employment" => CreateEmploymentInDatabaseWithId(entity as Employment),
		"EmploymentProfession" => CreateEmploymentProfessionInDatabaseWithId(entity as EmploymentProfession), "EmploymentStatus" => CreateEmploymentStatusInDatabaseWithId(entity as EmploymentStatus),
		"Institution" => CreateInstitutionInDatabaseWithId(entity as Institution), "Organization" => CreateOrganizationInDatabaseWithId(entity as Organization),
		"OrganizationStructure" => CreateOrganizationStructureInDatabaseWithId(entity as OrganizationStructure), "Person" => CreatePersonInDatabaseWithId(entity as Person),
		"PostalAddress" => CreatePostalAddressInDatabaseWithId(entity as PostalAddress), "Profession" => CreateProfessionInDatabaseWithId(entity as Profession),
		"SalaryAgreement" => CreateSalaryAgreementInDatabaseWithId(entity as SalaryAgreement), "SalaryCodeGroup" => CreateSalaryCodeGroupInDatabaseWithId(entity as SalaryCodeGroup),
		"SuccessfulRun" => CreateSuccessfulRunInDatabaseWithId(entity as SuccessfulRun), "WorkingTime" => CreateWorkingTimeInDatabaseWithId(entity as WorkingTime),
		_ => throw new InvalidRefException(typeof(T).Name,typeof(T),typeof(T).Name+Error.InvTypeParam), };

	/// <remarks />
	public bool DeleteDoubletFromDatabase<T>(T entity) where T : class { try { EFExtension.DeleteFromDatabase(entity).Wait(); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+eex.ToErrorString()+Environment.NewLine+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine+Environment.NewLine); return false; } }

	/// <returns><paramref name="entity"/> updated or created into datatabase</returns><typeparam name="T" /><param name="entity" /><exception cref="InvalidRefException" />
	public bool UpdateOrCreateInDatabase<T>(T entity) where T : class { if (EFExtension.UpdateOrCreateInDatabase(entity)>=1) return true; else return false; }

	/// <returns>Result as bool</returns><param name="institutionId" /><param name="sdApi" />
	public bool UpdateSuccessfulRunInDatabase(string institutionId,string sdApi) { try { Dictionary<string,SuccessfulRun> dict=GetSuccessfulRunDict();
			if (!dict.ContainsKey(institutionId+"-"+sdApi)) return false; dict[institutionId+"-"+sdApi].RunDate=DateTime.Now.ToString("yyyy-MM-dd");
			return UpdateOrCreateInDatabase(dict[institutionId+"-"+sdApi]); }
		catch (ExpressionException eex) {WriteStringLineToLogFile(eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) {WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	#region Protected

	/// <returns>Result as Dictionary{string,ContactInformation} ordered after TKey</returns>
	protected Dictionary<string,ContactInformation> GetContactInformationDict() { Dictionary<string,ContactInformation> result = new();
		foreach (ContactInformation item in GetList<ContactInformation>()) if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,Department} ordered after TKey</returns>
	protected Dictionary<string,Department> GetDepartmentDict() { Dictionary<string,Department> result = new(); foreach (Department item in GetList<Department>())
		if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,DepartmentLevelReference> GetDepartmentLevelReferenceDict() { Dictionary<string,DepartmentLevelReference> result = new();
		foreach (DepartmentLevelReference item in GetList<DepartmentLevelReference>()) if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,DepartmentReference> GetDepartmentReferenceDict() { Dictionary<string,DepartmentReference> result = new();
		foreach (DepartmentReference item in GetList<DepartmentReference>()) if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,Employment> GetEmploymentDict() { Dictionary<string,Employment> result = new(); foreach (Employment item in GetList<Employment>())
		if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,EmploymentProfession> GetEmploymentProfessionDict() { Dictionary<string,EmploymentProfession> result = new();
		foreach (EmploymentProfession item in GetList<EmploymentProfession>()) if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,EmploymentStatus> GetEmploymentStatusDict() { Dictionary<string,EmploymentStatus> result = new();
		foreach (EmploymentStatus item in GetList<EmploymentStatus>()) if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{int,Institution} ordered after database Id</returns>
	protected Dictionary<int,T> GetIdDict<T>() where T : class { Dictionary<int,T> result = new(); switch(typeof(T).Name.ToLower()) {
		case "contactinformation": foreach (ContactInformation item in GetList<ContactInformation>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "department": foreach (Department item in GetList<Department>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "departmentlevelreference": foreach (DepartmentLevelReference item in GetList<DepartmentLevelReference>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "departmentreference": foreach (DepartmentReference item in GetList<DepartmentReference>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "employment": foreach (Employment item in GetList<Employment>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "employmentprofession": foreach (EmploymentProfession item in GetList<EmploymentProfession>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "employmentstatus": foreach (EmploymentStatus item in GetList<EmploymentStatus>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "institution": foreach (Institution item in GetList<Institution>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "organization": foreach (Organization item in GetList<Organization>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "organizationstructure": foreach (OrganizationStructure item in GetList<OrganizationStructure>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "person": foreach (Person item in GetList<Person>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "postaladdress": foreach (PostalAddress item in GetList<PostalAddress>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "profession": foreach (Profession item in GetList<Profession>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "salaryagreement": foreach (SalaryAgreement item in GetList<SalaryAgreement>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "salarycodegroup": foreach (SalaryCodeGroup item in GetList<SalaryCodeGroup>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "successfulrun": foreach (SuccessfulRun item in GetList<SuccessfulRun>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		case "workingtime": foreach (WorkingTime item in GetList<WorkingTime>()) if (!result.ContainsKey(item.Id)) result.Add(item.Id,item as T); break;
		default: throw new InvalidRefException(typeof(T).Name+Error.InvTypeParam);	} return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,Institution> GetInstitutionDict() { Dictionary<string,Institution> result = new(); foreach (Institution item in GetList<Institution>())
		if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,Institution} ordered after InstitutionIdentifier</returns>
	protected Dictionary<string,Institution> GetInstitutionIdDict() { Dictionary<string,Institution> result = new(); foreach (Institution item in GetList<Institution>()) if (!result.ContainsKey(item.InstitutionIdentifier))
		result.Add(item.InstitutionIdentifier,item); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,Organization> GetOrganizationDict() { Dictionary<string,Organization> result = new(); foreach (Organization item in GetList<Organization>())
		if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,OrganizationStructure> GetOrganizationStructureDict() { Dictionary<string,OrganizationStructure> result = new(); 
		foreach (OrganizationStructure item in GetList<OrganizationStructure>()) if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,Person> GetPersonDict() { Dictionary<string,Person> result = new(); foreach (Person item in GetList<Person>())
		if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,PostalAddress> GetPostalAddressDict() { Dictionary<string,PostalAddress> result = new(); 
		foreach (PostalAddress item in GetList<PostalAddress>()) if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,Profession> GetProfessionDict() { Dictionary<string,Profession> result = new(); foreach (Profession item in GetList<Profession>())
		if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,SalaryAgreement> GetSalaryAgreementDict() { Dictionary<string,SalaryAgreement> result = new();
		foreach (SalaryAgreement item in GetList<SalaryAgreement>()) if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,SalaryCodeGroup> GetSalaryCodeGroupDict() { Dictionary<string,SalaryCodeGroup> result = new(); 
		foreach (SalaryCodeGroup item in GetList<SalaryCodeGroup>()) if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,SuccessfulRun> GetSuccessfulRunDict() { Dictionary<string,SuccessfulRun> result = new(); foreach (SuccessfulRun item in GetList<SuccessfulRun>())
		if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,WorkingTime> GetWorkingTimeDict() { Dictionary<string,WorkingTime> result = new(); foreach (WorkingTime item in GetList<WorkingTime>())
		if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	/// <returns>Amount of entities in List{T} as int</returns>
	protected int GetListCount<T>() where T : class => GetList<T>().Count;

	/// <returns>Result as List{T}</returns>
	protected List<T> GetList<T>() where T : class => EFExtension.SelectListFromDatabase<T>();

	/// <returns>Result as List{T}</returns>
	protected static List<T> GetView<T>() where T : class => EFExtension.SelectViewFromDatabase<T>();

	#endregion

	#region Private

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateContactInformationInDatabaseWithId(ContactInformation entity) { if (!entity.ParentIdentifier.Equals("0101001234")&&!entity.ParentIdentifier.Equals("00000")&&
		!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity)) return RetrieveContactInformationId(entity); else return 0; }

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateDepartmentInDatabaseWithId(Department entity) { if (!entity.DepartmentIdentifier.Equals("0NONE")&&!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity))
			return RetrieveDepartmentId(entity); else return 0; }

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateDepartmentLevelReferenceInDatabaseWithId(DepartmentLevelReference entity) { if (!entity.OrganizationStructure.Equals("NO")&&UpdateOrCreateInDatabase(entity))
			return RetrieveDepartmentLevelReferenceId(entity); else return 0; }

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateDepartmentReferenceInDatabaseWithId(DepartmentReference entity) { if (!entity.Organization.Equals("NO")&&UpdateOrCreateInDatabase(entity)) return RetrieveDepartmentReferenceId(entity); else return 0; }

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateEmploymentInDatabaseWithId(Employment entity) { if (!entity.EmploymentIdentifier.Equals("00000")&&!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity))
			return RetrieveEmploymentId(entity); else return 0; }

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateEmploymentProfessionInDatabaseWithId(EmploymentProfession entity) { if (!entity.JobPositionIdentifier.Equals("00000")&&!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity))
			return RetrieveEmploymentProfessionId(entity); else return 0; }

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateEmploymentStatusInDatabaseWithId(EmploymentStatus entity) { if (!entity.EmploymentIdentifier.Equals("00000")&&!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity))
			return RetrieveEmploymentStatusId(entity); else return 0;}

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateInstitutionInDatabaseWithId(Institution entity) { if (!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity)) return RetrieveInstitutionId(entity); else return 0;}

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateOrganizationInDatabaseWithId(Organization entity) { if (!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity)) return RetrieveOrganizationId(entity); else return 0; }

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateOrganizationStructureInDatabaseWithId(OrganizationStructure entity) { if (!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity)) return RetrieveOrganizationStructureId(entity); else return 0; }

	/// <returns>Result as int</returns><param name="entity" />
	private int CreatePersonInDatabaseWithId(Person entity) { if (!entity.PersonCivilRegistrationIdentifier.Equals("0101001234")&&!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity))
			return RetrievePersonId(); else return 0; }

	/// <returns>Result as int</returns><param name="entity" />
	private int CreatePostalAddressInDatabaseWithId(PostalAddress entity) { if (!entity.ParentIdentifier.Equals("0101001234")&&!entity.ParentIdentifier.Equals("00000")&&!entity.InstitutionIdentifier.Equals("NO")&&
			UpdateOrCreateInDatabase(entity)) return RetrievePostalAddressId(entity); else return 0; }

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateProfessionInDatabaseWithId(Profession entity) { if (!entity.JobPositionIdentifier.Equals("00000")&&!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity))
			return RetrieveProfessionId(entity); else return 0; }

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateSalaryAgreementInDatabaseWithId(SalaryAgreement entity) { if (!entity.EmploymentIdentifier.Equals("00000")&&!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity))
			return RetrieveSalaryAgreementId(entity); else return 0;}

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateSalaryCodeGroupInDatabaseWithId(SalaryCodeGroup entity) { if (!entity.EmploymentIdentifier.Equals("00000")&&!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity))
			return RetrieveSalaryCodeGroupId(entity); else return 0;}

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateSuccessfulRunInDatabaseWithId(SuccessfulRun entity) { if (entity.SdApi.ToLower().Contains("get")&&!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity))
			return RetrieveSuccessfulRunId(entity); else return 0; }

	/// <returns>Result as int</returns><param name="entity" />
	private int CreateWorkingTimeInDatabaseWithId(WorkingTime entity) { if (!entity.EmploymentIdentifier.Equals("00000")&&!entity.InstitutionIdentifier.Equals("NO")&&UpdateOrCreateInDatabase(entity))
			return RetrieveWorkingTimeId(entity); else return 0;}

	#endregion

	#endregion

}
