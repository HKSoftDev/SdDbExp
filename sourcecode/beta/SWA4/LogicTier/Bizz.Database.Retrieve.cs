// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Database.Retrieve.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Database Retrieve
{
	#region Methods

	#region Retrieve Entity

	/// <returns>Requested entity</returns><param name="entity" />
	protected ContactInformation RetrieveContactInformation(ContactInformation entity) { if (!entity.IsEmpty()) { Dictionary<string,ContactInformation> dict=GetContactInformationDict(); 
		if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected Department RetrieveDepartment(Department entity) { if (!entity.TKey.Equals("00000000-0000-0000-0000-000000000000")) { Dictionary<string,Department> dict=GetDepartmentDict(); 
		if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected DepartmentLevelReference RetrieveDepartmentLevelReference(DepartmentLevelReference entity) { if (!entity.DepartmentLevelIdentifier.Equals("NO-NY0-niveau")) {
		Dictionary<string,DepartmentLevelReference> dict=GetDepartmentLevelReferenceDict(); if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected DepartmentReference RetrieveDepartmentReference(DepartmentReference entity) { if (!entity.DepartmentIdentifier.Equals("0NONE")) {
		Dictionary<string,DepartmentReference> dict=GetDepartmentReferenceDict(); if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected Employment RetrieveEmployment(Employment entity) { if (!entity.TKey.Equals("NO-00000")) { Dictionary<string,Employment> dict=GetEmploymentDict();
		if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected EmploymentProfession RetrieveEmploymentProfession(EmploymentProfession entity) { if (!entity.TKey.Equals("NO-0000")) {
		Dictionary<string,EmploymentProfession> dict=GetEmploymentProfessionDict(); if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected EmploymentStatus RetrieveEmploymentStatus(EmploymentStatus entity) { if (!entity.IsEmpty()) { Dictionary<string,EmploymentStatus> dict=GetEmploymentStatusDict();
		if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected Institution RetrieveInstitution(Institution entity) { if (!entity.TKey.Equals("NO")) { Dictionary<string,Institution> dict=GetInstitutionDict();
		if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return entity; }

	/// <returns>Requested entity</returns><param name="entity" />
	protected Organization RetrieveOrganization(Organization entity) { if (!entity.TKey.Equals("NO")) { Dictionary<string,Organization> dict=GetOrganizationDict();
		if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected OrganizationStructure RetrieveOrganizationStructure(OrganizationStructure entity) { if (!entity.TKey.Equals("NO")) {
		Dictionary<string,OrganizationStructure> dict=GetOrganizationStructureDict(); if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected Person RetrievePerson(Person entity) { if (!entity.TKey.Equals("NO-0101001234")) { Dictionary<string,Person> dict=GetPersonDict(); if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected PostalAddress RetrievePostalAddress(PostalAddress entity) { if (!entity.IsEmpty()) { Dictionary<string,PostalAddress> dict=GetPostalAddressDict();
		if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected Profession RetrieveProfession(Profession entity) { if (!entity.TKey.Equals("NO-0000")) { Dictionary<string,Profession> dict=GetProfessionDict();
		if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected SalaryAgreement RetrieveSalaryAgreement(SalaryAgreement entity) { if (!entity.IsEmpty()) { Dictionary<string,SalaryAgreement> dict=GetSalaryAgreementDict();
		if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected SalaryCodeGroup RetrieveSalaryCodeGroup(SalaryCodeGroup entity) { if (!entity.IsEmpty()) { Dictionary<string,SalaryCodeGroup> dict=GetSalaryCodeGroupDict();
		if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected SuccessfulRun RetrieveSuccessfulRun(SuccessfulRun entity) { Dictionary<string,SuccessfulRun> dict=GetSuccessfulRunDict(); if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; return new(entity); }

	/// <returns>Requested entity</returns><param name="entity" />
	protected WorkingTime RetrieveWorkingTime(WorkingTime entity) { if (!entity.IsEmpty()) { Dictionary<string,WorkingTime> dict=GetWorkingTimeDict(); if (dict.ContainsKey(entity.TKey)) return dict[entity.TKey]; } return new(entity); }

	#endregion

	#region Retrieve Entity Id

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveContactInformationId() { Dictionary <string,ContactInformation> dict=new(); foreach (ContactInformation item in GetList<ContactInformation>()) if (!dict.ContainsKey(item.TelephoneNumberIdentifier1)) dict.Add(item.TelephoneNumberIdentifier1,item);
		if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveContactInformationId(ContactInformation entity) { if (entity.IsEmpty()) return 0; else return RetrieveContactInformation(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveDepartmentId() { Dictionary <string,Department> dict=new(); foreach (Department item in GetList<Department>()) if (!dict.ContainsKey(item.DepartmentIdentifier)) dict.Add(item.DepartmentIdentifier,item);
		if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveDepartmentId(Department entity) { if (entity.IsEmpty()) return 0; else return RetrieveDepartment(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveDepartmentLevelReferenceId() { Dictionary <string,DepartmentLevelReference> dict=new(); foreach (DepartmentLevelReference item in GetList<DepartmentLevelReference>()) if (!dict.ContainsKey(
		item.OrganizationStructure)) dict.Add(item.OrganizationStructure,item); if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveDepartmentLevelReferenceId(DepartmentLevelReference entity) { if (entity.IsEmpty()) return 0; else return RetrieveDepartmentLevelReference(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveDepartmentReferenceId() { Dictionary <string,DepartmentReference> dict=new(); foreach (DepartmentReference item in GetList<DepartmentReference>()) if (!dict.ContainsKey(item.Organization))
		dict.Add(item.Organization,item); if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveDepartmentReferenceId(DepartmentReference entity) { if (entity.IsEmpty()) return 0; else return RetrieveDepartmentReference(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveEmploymentId() { Dictionary <string,Employment> dict=new(); foreach (Employment item in GetList<Employment>()) if (!dict.ContainsKey(item.EmploymentIdentifier)) dict.Add(item.EmploymentIdentifier,item);
		if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveEmploymentId(Employment entity) { if (entity.IsEmpty()) return 0; else return RetrieveEmployment(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveEmploymentProfessionId() { Dictionary <string,EmploymentProfession> dict=new(); foreach (EmploymentProfession item in GetList<EmploymentProfession>()) if (!dict.ContainsKey(item.JobPositionIdentifier)) dict.Add(item.JobPositionIdentifier,item);
		if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveEmploymentProfessionId(EmploymentProfession entity) { if (entity.IsEmpty()) return 0; else return RetrieveEmploymentProfession(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveEmploymentStatusId() { Dictionary <string,EmploymentStatus> dict=new(); foreach (EmploymentStatus item in GetList<EmploymentStatus>()) if (!dict.ContainsKey(item.EmploymentIdentifier))
		dict.Add(item.EmploymentIdentifier,item); if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveEmploymentStatusId(EmploymentStatus entity) { if (entity.IsEmpty()) return 0; else return RetrieveEmploymentStatus(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveInstitutionId() { Dictionary <string,Institution> dict=new(); foreach (Institution item in GetList<Institution>()) if (!dict.ContainsKey(item.InstitutionIdentifier)) dict.Add(item.InstitutionIdentifier,item);
		if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveInstitutionId(Institution entity) { if (entity.IsEmpty()) return 0; else return RetrieveInstitution(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveOrganizationId() { Dictionary <string,Organization> dict=new(); foreach (Organization item in GetList<Organization>()) if (!dict.ContainsKey(item.InstitutionIdentifier)) dict.Add(item.InstitutionIdentifier,item);
		if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveOrganizationId(Organization entity) { if (entity.IsEmpty()) return 0; else return RetrieveOrganization(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveOrganizationStructureId() { Dictionary <string,OrganizationStructure> dict=new(); foreach (OrganizationStructure item in GetList<OrganizationStructure>()) if (!dict.ContainsKey(item.InstitutionIdentifier))
		dict.Add(item.InstitutionIdentifier,item); if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveOrganizationStructureId(OrganizationStructure entity) { if (entity.IsEmpty()) return 0; else return RetrieveOrganizationStructure(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrievePersonId() { Dictionary <string,Person> dict=new(); foreach (Person item in GetList<Person>()) if (!dict.ContainsKey(item.PersonCivilRegistrationIdentifier))
		dict.Add(item.PersonCivilRegistrationIdentifier,item); if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrievePersonId(Person entity) { if (entity.IsEmpty()) return 0; else return RetrievePerson(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrievePostalAddressId() { Dictionary <string,PostalAddress> dict=new(); foreach (PostalAddress item in GetList<PostalAddress>()) if (!dict.ContainsKey(item.StandardAddressIdentifier))
		dict.Add(item.StandardAddressIdentifier,item); if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrievePostalAddressId(PostalAddress entity) { if (entity.IsEmpty()) return 0; else return RetrievePostalAddress(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveProfessionId() { Dictionary <string,Profession> dict=new(); foreach (Profession item in GetList<Profession>()) if (!dict.ContainsKey(item.JobPositionIdentifier)) dict.Add(item.JobPositionIdentifier,item);
		if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveProfessionId(Profession entity) { if (entity.IsEmpty()) return 0; else return RetrieveProfession(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveSalaryAgreementId() { Dictionary <string,SalaryAgreement> dict=new(); foreach (SalaryAgreement item in GetList<SalaryAgreement>()) if (!dict.ContainsKey(item.EmploymentIdentifier))
		dict.Add(item.EmploymentIdentifier,item); if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveSalaryAgreementId(SalaryAgreement entity) { if (entity.IsEmpty()) return 0; else return RetrieveSalaryAgreement(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveSalaryCodeGroupId() { Dictionary <string,SalaryCodeGroup> dict=new(); foreach (SalaryCodeGroup item in GetList<SalaryCodeGroup>()) if (!dict.ContainsKey(item.EmploymentIdentifier))
		dict.Add(item.EmploymentIdentifier,item); if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveSalaryCodeGroupId(SalaryCodeGroup entity) { if (entity.IsEmpty()) return 0; else return RetrieveSalaryCodeGroup(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveSuccessfulRunId() { Dictionary <string,SuccessfulRun> dict=new(); foreach (SuccessfulRun item in GetList<SuccessfulRun>()) if (!dict.ContainsKey(item.SdApi)) dict.Add(item.SdApi,item);
		if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveSuccessfulRunId(SuccessfulRun entity) { if (entity.IsEmpty()) return 0; else return RetrieveSuccessfulRun(entity).Id; }

	/// <returns>Id of a recently created entity as int</returns>
	protected int RetrieveWorkingTimeId() { Dictionary <string,WorkingTime> dict=new(); foreach (WorkingTime item in GetList<WorkingTime>()) if (!dict.ContainsKey(item.EmploymentIdentifier)) dict.Add(item.EmploymentIdentifier,item);
		if (dict.ContainsKey(Config.MacAddress)) return dict[Config.MacAddress].Id; else return 0; }

	/// <returns>Id of <paramref name="entity"/> as int</returns><param name="entity" />
	protected int RetrieveWorkingTimeId(WorkingTime entity) { if (entity.IsEmpty()) return 0; else return RetrieveWorkingTime(entity).Id; }

	#endregion

	/// <summary>Retrieves content of Config.List.XmEmployments list</summary>
	protected void RetrieveXmEmployments() {  try { Config.XmEmploymentList=GetView<XmEmployment>(); this.Config.XmRetrieved=true; }
		catch (AggregateException) { this.Config.XmRetrieved=true; } catch { this.Config.XmRetrieved=false;} }

	#endregion

}
