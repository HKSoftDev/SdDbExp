// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Database.Main.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Database Main
{

	#region Methods

	/// <returns><paramref name="entity"/> updated or created into datatabase</returns><typeparam name="T" /><param name="entity" /><exception cref="InvalidRefException" />
	public bool UpdateOrCreateInDatabase<T>(T entity) where T : class { try { if (CheckEntityExists(entity)&&EFExtension.UpdateInDatabase(entity)>=1) return true;
			else if (EFExtension.CreateInDatabase(entity)>=1) return true;  else return false; }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <returns>Result as bool</returns><param name="institutionId" /><param name="sdApi" />
	public bool UpdateSuccessfulRunInDatabase(string institutionId,string sdApi) { try { Dictionary<string,SuccessfulRun> dict=GetSuccessfulRunDict();
			if (!dict.ContainsKey(institutionId+"-"+sdApi)) return false; dict[institutionId+"-"+sdApi].RunDate=DateTime.Now.ToString("yyyy-MM-dd"); 
			if(EFExtension.UpdateInDatabase(dict[institutionId+"-"+sdApi])>=1) return true; else return false; }
		catch (ExpressionException eex) {WriteStringLineToLogFile(eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) {WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	#region Private

	#region Get Dict

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

	/// <returns>Result as Dictionary{string,ViewKantine} ordered after TKey</returns>
	protected Dictionary<string,ViewKantine> GetViewKantineDict() { Dictionary<string,ViewKantine> result=new(); List<ViewKantine> view=GetView<ViewKantine>(); foreach (ViewKantine item in view) {
		if (!result.ContainsKey(item.Cpr)) result.Add(item.Cpr,item); else if (float.Parse(item.Beskæftigelsesdecimal)>float.Parse(result[item.Cpr].Beskæftigelsesdecimal)) result[item.Cpr]=item; } return result; }

	/// <returns>Result as Dictionary{string,T} ordered after TKey</returns>
	protected Dictionary<string,WorkingTime> GetWorkingTimeDict() { Dictionary<string,WorkingTime> result = new(); foreach (WorkingTime item in GetList<WorkingTime>())
		if (!result.ContainsKey(item.TKey)) result.Add(item.TKey,item); Garbage.Collect(); return result; }

	#endregion

	/// <returns>Result as List{T}</returns>
	protected List<T> GetList<T>() where T : class => EFExtension.SelectListFromDatabase<T>();

	/// <returns>Result as List{T}</returns>
	protected List<T> GetView<T>() where T : class => EFExtension.SelectViewFromDatabase<T>();

	/// <returns>Result as List{T}</returns>
	protected List<ViewKantine> GetViewKantineList() { List<ViewKantine> result=new(); try { result=GetView<ViewKantine>(); Dictionary<string,ViewKantine> primaryDict=GetViewKantineDict();
			foreach (ViewKantine item in result)
			if (primaryDict.ContainsKey(item.Cpr)&&item.Tjenestenummer.Equals(primaryDict[item.Cpr].Tjenestenummer)) item.P=true; } 
		catch (Exception ex) { WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)+Environment.NewLine); } return result; }


	#endregion

	#endregion

}
