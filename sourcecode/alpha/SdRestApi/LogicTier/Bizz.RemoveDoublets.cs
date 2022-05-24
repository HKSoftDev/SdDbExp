// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.RemoveDoublets.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Remove Doublets
{

	#region Methods

	/// <remarks/>
	public void RemoveDoublets() { Config.AllDoubletsRemoved=true; RemoveDoubletsFromContactInformationList(); RemoveDoubletsFromEmploymentStatusList(); RemoveDoubletsFromDepartmentList(); 
		RemoveDoubletsFromDepartmentReferenceList(); RemoveDoubletsFromDepartmentLevelReferenceListList(); RemoveDoubletsFromEmploymentList(); RemoveDoubletsFromEmploymentProfessionList();
		RemoveDoubletsFromEmploymentStatusList(); RemoveDoubletsFromInstitutionList(); RemoveDoubletsFromOrganizationList(); RemoveDoubletsFromOrganizationStructureList();
		RemoveDoubletsFromPersonList(); RemoveDoubletsFromPostalAddressList(); RemoveDoubletsFromProfessionList(); RemoveDoubletsFromSalaryAgreementList();
		RemoveDoubletsFromSalaryCodeGroupList(); RemoveDoubletsFromWorkingTimeList(); }

	/// <remarks/>
	protected void RemoveDoubletsFromContactInformationList() { this.Config.ContactInformationDoubletsRemoved=true; Dictionary<string,ContactInformation> dict=new();
		foreach (ContactInformation entity in GetList<ContactInformation>()) { if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); 
			else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break; case 1: DeleteDoubletFromDatabase(dict[entity.TKey]); dict[entity.TKey]=entity; break;
					case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromDepartmentList() { this.Config.DepartmentDoubletsRemoved=true; Dictionary<string,Department> dict=new(); foreach (Department entity in GetList<Department>()) {
		if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break;
			case 1: DeleteDoubletFromDatabase(dict[entity.TKey]); dict[entity.TKey]=entity; break; case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromDepartmentLevelReferenceListList() { this.Config.DepartmentLevelReferenceDoubletsRemoved=true; Dictionary<string,DepartmentLevelReference> dict=new();
		foreach (DepartmentLevelReference entity in GetList<DepartmentLevelReference>()) {  if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); 
			else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break; case 1: DeleteDoubletFromDatabase(dict[entity.TKey]); dict[entity.TKey]=entity; break;
				case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromDepartmentReferenceList() { this.Config.DepartmentReferenceDoubletsRemoved=true; Dictionary<string,DepartmentReference> dict=new(); foreach (DepartmentReference entity in
		GetList<DepartmentReference>()) { if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) {
			case 0: DeleteDoubletFromDatabase(entity); break; case 1: DeleteDoubletFromDatabase(dict[entity.TKey]); dict[entity.TKey]=entity; break; case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromEmploymentList() { this.Config.EmploymentDoubletsRemoved=true; Dictionary<string,Employment> dict=new(); foreach (Employment entity in  GetList<Employment>()) {
		if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break;
			case 1: DeleteDoubletFromDatabase(dict[entity.TKey]);dict[entity.TKey]=entity; break; case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromEmploymentProfessionList() { this.Config.EmploymentProfessionDoubletsRemoved=true; Dictionary<string,EmploymentProfession> dict=new(); foreach (EmploymentProfession entity in GetList<EmploymentProfession>()) {
		if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break;
			case 1: DeleteDoubletFromDatabase(dict[entity.TKey]); dict[entity.TKey]=entity; break; case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromEmploymentStatusList() { this.Config.EmploymentStatusDoubletsRemoved=true; Dictionary<string,EmploymentStatus> dict=new(); foreach (EmploymentStatus entity in GetList<EmploymentStatus>()) {
		if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break;
			case 1: DeleteDoubletFromDatabase(dict[entity.TKey]); dict[entity.TKey]=entity; break; case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromInstitutionList() { this.Config.InstitutionDoubletsRemoved=true; Dictionary<string,Institution> dict=new(); foreach (Institution entity in GetList<Institution>()) {
		if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break;
			case 1: DeleteDoubletFromDatabase(dict[entity.TKey]);dict[entity.TKey]=entity; break; case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromOrganizationList() { this.Config.OrganizationDoubletsRemoved=true; Dictionary<string,Organization> dict=new(); foreach (Organization entity in GetList<Organization>()) {
		if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break;
			case 1: DeleteDoubletFromDatabase(dict[entity.TKey]); dict[entity.TKey]=entity; break; case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromOrganizationStructureList() { this.Config.OrganizationStructureDoubletsRemoved=true; Dictionary<string,OrganizationStructure> dict=new(); foreach (OrganizationStructure entity in
		GetList<OrganizationStructure>()) { if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break;
			case 1: DeleteDoubletFromDatabase(dict[entity.TKey]); dict[entity.TKey]=entity; break; case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromPersonList() { this.Config.PersonDoubletsRemoved=true; Dictionary<string,Person> dict=new(); foreach (Person entity in GetList<Person>()) { if (!dict.ContainsKey(entity.TKey)) dict.Add(
		entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break;case 1: DeleteDoubletFromDatabase(dict[entity.TKey]);dict[entity.TKey]=entity; break;
			case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromPostalAddressList() { this.Config.PostalAddressDoubletsRemoved=true; Dictionary<string,PostalAddress> dict=new(); foreach (PostalAddress entity in GetList<PostalAddress>()) {
		if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break;
			case 1: DeleteDoubletFromDatabase(dict[entity.TKey]); dict[entity.TKey]=entity; break; case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromProfessionList() { this.Config.ProfessionDoubletsRemoved=true; Dictionary<string,Profession> dict=new(); foreach (Profession entity in GetList<Profession>()) {
		if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break;
			case 1: DeleteDoubletFromDatabase(dict[entity.TKey]); dict[entity.TKey]=entity; break; case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromSalaryAgreementList() { this.Config.SalaryAgreementDoubletsRemoved=true; Dictionary<string,SalaryAgreement> dict=new(); foreach (SalaryAgreement entity in GetList<SalaryAgreement>()) {
		if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break;
			case 1: DeleteDoubletFromDatabase(dict[entity.TKey]); dict[entity.TKey]=entity; break; case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromSalaryCodeGroupList() { this.Config.SalaryCodeGroupDoubletsRemoved=true; Dictionary<string,SalaryCodeGroup> dict=new(); foreach (SalaryCodeGroup entity in GetList<SalaryCodeGroup>()) {
		if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break;
			case 1: DeleteDoubletFromDatabase(dict[entity.TKey]); dict[entity.TKey]=entity; break; case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	/// <remarks/>
	protected void RemoveDoubletsFromWorkingTimeList() { this.Config.WorkingTimeDoubletsRemoved=true; Dictionary<string,WorkingTime> dict=new(); foreach (WorkingTime entity in GetList<WorkingTime>()) {
		if (!dict.ContainsKey(entity.TKey)) dict.Add(entity.TKey,entity); else switch (RetrieveOldest(dict[entity.TKey],entity)) { case 0: DeleteDoubletFromDatabase(entity); break;
			case 1: DeleteDoubletFromDatabase(dict[entity.TKey]); dict[entity.TKey]=entity; break; case 2: DeleteDoubletFromDatabase(entity); break; default: break; } } }

	#endregion

}
