// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Check.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Check
{
	#region Methods

	/// <returns>Result as bool</returns><typeparam name="T" /><param name="entity" />
	public bool CheckEntityExists<T>(T entity) where T : class => typeof(T).Name.ToLower() switch { 
		"contactinformation" => CheckContactInformationExist((entity as ContactInformation)??throw new ArgumentNullException(nameof(entity))),
		"department" => CheckDepartmentExist((entity as Department)??throw new ArgumentNullException(nameof(entity))), 
		"departmentlevelreference" => CheckDepartmentLevelReferenceExist((entity as DepartmentLevelReference)??throw new ArgumentNullException(nameof(entity))),
		"departmentreference" => CheckDepartmentReferenceExist((entity as DepartmentReference)??throw new ArgumentNullException(nameof(entity))), 
		"employment" => CheckEmploymentExist((entity as Employment)??throw new ArgumentNullException(nameof(entity))),
		"employmentprofession" => CheckEmploymentProfessionExist((entity as EmploymentProfession)??throw new ArgumentNullException(nameof(entity))),
		"employmentstatus" => CheckEmploymentStatusExist((entity as EmploymentStatus)??throw new ArgumentNullException(nameof(entity))),
		"institution" => CheckInstitutionExist((entity as Institution)??throw new ArgumentNullException(nameof(entity))),
		"organization" => CheckOrganizationExist((entity as Organization)??throw new ArgumentNullException(nameof(entity))),
		"organizationstructure" => CheckOrganizationStructureExist((entity as OrganizationStructure)??throw new ArgumentNullException(nameof(entity))),
		"person" => CheckPersonExist((entity as Person)??throw new ArgumentNullException(nameof(entity))), 
		"postaladdress" => CheckPostalAddressExist((entity as PostalAddress)??throw new ArgumentNullException(nameof(entity))), 
		"profession" => CheckProfessionExist((entity as Profession)??throw new ArgumentNullException(nameof(entity))),
		"salaryagreement" => CheckSalaryAgreementExist((entity as SalaryAgreement)??throw new ArgumentNullException(nameof(entity))),
		"salarycodegroup" => CheckSalaryCodeGroupExist((entity as SalaryCodeGroup)??throw new ArgumentNullException(nameof(entity))),
		"successfulrun" => CheckSuccessfulRunExist((entity as SuccessfulRun)??throw new ArgumentNullException(nameof(entity))), 
		"workingtime" => CheckWorkingTimeExist((entity as WorkingTime)??throw new ArgumentNullException(nameof(entity))), _ => false, };

	/// <summary>Checks error at end of run</summary>
	public void CheckDependencyDataError() { if (Config.DepartmentsNotUpdated<1&&Config.DepartmentLevelReferencesNotUpdated<1&&Config.DepartmentReferencesNotUpdated<1&&Config.InstitutionsNotUpdated<1&&
		Config.OrganizationsNotUpdated<1&&Config.OrganizationStructuresNotUpdated<1&&Config.ProfessionsNotUpdated<1) { WriteStringLineToLogFile("- Application executed without significant errors"+Environment.NewLine); 
			this.Config.ExitCode=(int)Enumerator.ExitCode.Success; } else { string content="Application executed with some errors:"+Environment.NewLine; this.Config.ExitCode=(int)Enumerator.ExitCode.NoSuccessfulRun;
				if (!Config.AllDataRetrieved) { content+="- Not all data was retrieved from Silkeborg Data"+Environment.NewLine; this.Config.ExitCode+=(int)Enumerator.ExitCode.NotAllDataRetrieved; }
				if (!Config.AllDataDeserialized) { content+="- Not all xml data was deserialized"+Environment.NewLine; this.Config.ExitCode+=(int)Enumerator.ExitCode.NotAllDataDeserialized; }
				if (!Config.AllDataCleaned) { content+="- Not all data was cleaned for database"+Environment.NewLine; this.Config.ExitCode+=(int)Enumerator.ExitCode.NotAllDataCleaned; } 
				if (!Config.AllDatabaseUpdated) { content+="Not all data was updated into database"+Environment.NewLine; this.Config.ExitCode+=(int)Enumerator.ExitCode.NotAllDatabaseUpdated; } 
				if (Config.DepartmentsNotUpdated>=1) { content+=Config.DepartmentsNotUpdated+" departments not updated"+Environment.NewLine; } 
				if (Config.InstitutionsNotUpdated>=1) { content+=Config.InstitutionsNotUpdated+" institutions not updated"+Environment.NewLine; } 
				if (Config.ProfessionsNotUpdated>=1) { content+=Config.ProfessionsNotUpdated+" professions not updated"+Environment.NewLine; } 
				if (Config.OrganizationsNotUpdated>=1) { content+=Config.OrganizationsNotUpdated+" organizations not updated"+Environment.NewLine; } 
				if (Config.OrganizationStructuresNotUpdated>=1) { content+=Config.OrganizationStructuresNotUpdated+" organization structures not updated"+Environment.NewLine; } 
				if (Config.DepartmentLevelReferencesNotUpdated>=1) { content+=Config.DepartmentLevelReferencesNotUpdated+" department level references not updated"+Environment.NewLine; } 
				if (Config.DepartmentReferencesNotUpdated>=1) { content+=Config.DepartmentReferencesNotUpdated+" department references not updated"+Environment.NewLine; } WriteStringLineToLogFile(content); MailError(content); } }

	/// <summary>Checks error at end of run</summary>
	public void CheckPersonDataError() { if (Config.EmploymentsNotUpdated<1&&Config.PersonsNotUpdated<1)  { WriteStringLineToLogFile("- Application executed without significant errors"+Environment.NewLine);
		this.Config.ExitCode=(int)Enumerator.ExitCode.Success; } else  { string content="- Application executed with some errors:"+Environment.NewLine; this.Config.ExitCode=(int)Enumerator.ExitCode.NoSuccessfulRun; 
			if (!Config.AllDataRetrieved) { content+="- Not all data was retrieved from Silkeborg Data"+Environment.NewLine; this.Config.ExitCode+=(int)Enumerator.ExitCode.NotAllDataRetrieved; }
			if (!Config.AllDataDeserialized) { content+="- Not all xml data was deserialized"+Environment.NewLine; this.Config.ExitCode+=(int)Enumerator.ExitCode.NotAllDataDeserialized; }
			if (!Config.AllDataCleaned) { content+="- Not all data was cleaned for database"+Environment.NewLine; this.Config.ExitCode+=(int)Enumerator.ExitCode.NotAllDataCleaned; }
			if (!Config.AllDatabaseUpdated) { content+="Not all data was updated into database"+Environment.NewLine; this.Config.ExitCode+=(int)Enumerator.ExitCode.NotAllDatabaseUpdated; }
			if (Config.EmploymentsNotUpdated>=1) { content+=Config.EmploymentsNotUpdated+" employments not updated"+Environment.NewLine; } 
			if (Config.PersonsNotUpdated>=1) { content+=Config.PersonsNotUpdated+" persons not updated"+Environment.NewLine; } WriteStringLineToLogFile(content); MailError(content);  } }

	#region Protected

	#region Check ContactInfo Optimization

	/// <summary>Checks order of email addresses in <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	protected bool CheckCioEmailAdresses(ref ContactInformation entity) { entity=new(entity??throw new ArgumentNullException(nameof(entity),nameof(entity)+Error.CantBeNull)); entity.Validate();
		if (entity.EmailAddressIdentifier1.ToLower().Contains("@empty.com")&&!entity.EmailAddressIdentifier2.ToLower().Contains("@empty.com")) { entity=EFExtension.SwapEmailAdresses(entity); return true; }
		else if (entity.ParentIdentifier.Length.Equals(10)&&entity.EmailAddressIdentifier1.ToLower().Contains("@haderslev.dk")&&entity.EmailAddressIdentifier2.ToLower().Contains("@haderslev.dk")&&
			entity.EmailAddressIdentifier2.Length<entity.EmailAddressIdentifier1.Length) { entity=EFExtension.SwapEmailAdresses(entity); return true; }
		else if (!entity.EmailAddressIdentifier1.ToLower().Contains("@haderslev.dk")&&entity.EmailAddressIdentifier2.ToLower().Contains("@haderslev.dk")) { entity=EFExtension.SwapEmailAdresses(entity); return true; }
		else if (!entity.EmailAddressIdentifier1.ToLower().Contains("@haderslev.dk")&&entity.EmailAddressIdentifier2.ToLower().Contains("@udcit.dk")) { entity=EFExtension.SwapEmailAdresses(entity); return true; }
		else if (!entity.EmailAddressIdentifier1.ToLower().Contains("@udcit.dk")&&entity.EmailAddressIdentifier2.ToLower().Contains("@udcit.dk")) { entity=EFExtension.SwapEmailAdresses(entity); return true; } return false; }

	/// <summary>Checks order of phone numbers in <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	protected bool CheckCioPhoneNumbers(ref ContactInformation entity) { if (entity.IsEmpty()) throw new ArgumentNullException(nameof(entity),nameof(entity)+Error.CantBeNull);
		if (entity.TelephoneNumberIdentifier1.Equals("00000000")&&!entity.TelephoneNumberIdentifier2.Equals("00000000")) { entity=EFExtension.SwapPhoneNumbers(entity); return true; }
		if (!CheckCioInternalPhoneNumber(entity.TelephoneNumberIdentifier1)&&CheckCioInternalPhoneNumber(entity.TelephoneNumberIdentifier2)) { entity=EFExtension.SwapPhoneNumbers(entity); return true; } return false; }

	/// <summary>Checks wether or not a phone number is internal</summary><param name="phone">Phone number</param><returns>Result as bool</returns>
	protected bool CheckCioInternalPhoneNumber(string phone) { switch (phone.Length) { case 5: return true; case 8: return phone.Remove(4) switch { "7334" => true,"7434" => true,_ => false,}; 
		case >8: phone=TrimCioPhoneNumber(phone); return phone.Remove(4) switch { "7334" => true,"7434" => true,_ => false,}; default: return false; } }

	///<remarks />
	protected void CheckCioResult() { switch (Config.CioInfoUpdated) { case true: WriteStringLineToLogFile("- Optimization of Contact Informations was completed."); break;
		default: WriteStringLineToLogFile("- Optimization of Contact Informations failed."); break; } switch (Config.AllDoubletsRemoved) { case false: WriteStringLineToLogFile(
					"- Some doublets were not removed:"); if (!Config.ContactInformationDoubletsRemoved) WriteStringLineToLogFile("- Some contact information doublets were not removed");
				if (!Config.DepartmentDoubletsRemoved) WriteStringLineToLogFile("- Some department doublets were not removed");
				if (!Config.DepartmentLevelReferenceDoubletsRemoved) WriteStringLineToLogFile("- Some department level reference doublets were not removed");
				if (!Config.DepartmentReferenceDoubletsRemoved) WriteStringLineToLogFile("- Some department reference doublets were not removed");
				if (!Config.EmploymentDoubletsRemoved) WriteStringLineToLogFile("- Some employment doublets were not removed");
				if (!Config.EmploymentStatusDoubletsRemoved) WriteStringLineToLogFile("- Some employment status doublets were not removed");
				if (!Config.InstitutionDoubletsRemoved) WriteStringLineToLogFile("- Some institution doublets were not removed");
				if (!Config.OrganizationDoubletsRemoved) WriteStringLineToLogFile("- Some organization doublets were not removed");
				if (!Config.OrganizationStructureDoubletsRemoved) WriteStringLineToLogFile("- Some organization structure doublets were not removed");
				if (!Config.PersonDoubletsRemoved) WriteStringLineToLogFile("- Some person doublets were not removed");
				if (!Config.PostalAddressDoubletsRemoved) WriteStringLineToLogFile("- Some postal address doublets were not removed");
				if (!Config.ProfessionDoubletsRemoved) WriteStringLineToLogFile("- Some profession doublets were not removed");
				if (!Config.SalaryAgreementDoubletsRemoved) WriteStringLineToLogFile("- Some salary agreement doublets were not removed");
				if (!Config.SalaryCodeGroupDoubletsRemoved) WriteStringLineToLogFile("- Some salary code group doublets were not removed");
				if (!Config.WorkingTimeDoubletsRemoved) WriteStringLineToLogFile("- Some working time doublets were not removed"); break;
			default: WriteStringLineToLogFile("- All Doublets were removed"); break; } }

	#endregion

	/// <summary>Checks content of<paramref name="info"/></summary><param name="user" /><param name="info" /><exception cref="ArgumentEmptyException" />
	protected void CheckContactInformation(ADUser user,ContactInformation info) { if (info.IsEmpty()) throw new ArgumentEmptyException(nameof(info),nameof(info)+Error.CantBeEmpty);
		CheckMail(user.Mail,info); CheckPhone(user.MobilePhone,info); }

	#region Check entity exist

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckContactInformationExist(ContactInformation entity) => GetContactInformationDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckDepartmentExist(Department entity) => GetDepartmentDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckDepartmentLevelReferenceExist(DepartmentLevelReference entity) => GetDepartmentLevelReferenceDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckDepartmentReferenceExist(DepartmentReference entity) => GetDepartmentReferenceDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckEmploymentExist(Employment entity) => GetEmploymentDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckEmploymentProfessionExist(EmploymentProfession entity) => GetEmploymentProfessionDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckEmploymentStatusExist(EmploymentStatus entity) => GetEmploymentStatusDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckInstitutionExist(Institution entity) => GetInstitutionDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckOrganizationExist(Organization entity) => GetOrganizationDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckOrganizationStructureExist(OrganizationStructure entity) => GetOrganizationStructureDict().ContainsKey(entity.InstitutionIdentifier);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckPersonExist(Person entity) => GetPersonDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckPostalAddressExist(PostalAddress entity) =>GetPostalAddressDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckProfessionExist(Profession entity) => GetProfessionDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckSalaryAgreementExist(SalaryAgreement entity) => GetSalaryAgreementDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckSalaryCodeGroupExist(SalaryCodeGroup entity) => GetSalaryCodeGroupDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckSuccessfulRunExist(SuccessfulRun entity) => GetSuccessfulRunDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckWorkingTimeExist(WorkingTime entity) => GetWorkingTimeDict().ContainsKey(entity.TKey);

	#endregion

	#region Check Error

	/// <summary>Checks error at end of cloning</summary><param name="institutionId" />
	protected void CheckDepartmentDataError(string institutionId) { bool run=false; if (Config.DepartmentsNotUpdated<1) run=UpdateSuccessfulRunInDatabase(institutionId,"GetDepartment");
		if (Config.DepartmentsNotUpdated>=1) WriteStringLineToLogFile($"- {Config.DepartmentsNotUpdated} departments not updated");
		if (run&&Config.DepartmentsNotUpdated<1) WriteStringLineToLogFile("- GetDepartment for "+institutionId+" executed without significant errors"+Environment.NewLine);
		else if (!run&&Config.DepartmentsNotUpdated<1) WriteStringLineToLogFile("- GetDepartment for "+institutionId+" executed without significant errors, but 'SuccessfulRun' could not be registered in database"+Environment.NewLine);
		else WriteStringLineToLogFile("- GetDepartment for "+institutionId+" executed with some errors"+Environment.NewLine); }

	/// <summary>Checks error at end of updating</summary><param name="institutionId" />
	protected void CheckEmploymentChangedAtDateDataError(string institutionId) { bool run=false; if (Config.EmploymentsNotUpdated<1) run=UpdateSuccessfulRunInDatabase(institutionId,"GetEmploymentChangedAtDate");
		if (Config.EmploymentsNotUpdated<1) WriteStringLineToLogFile($"- {Config.EmploymentsNotUpdated} employments not updated");
		if (run&&Config.EmploymentsNotUpdated<1) WriteStringLineToLogFile("- GetEmploymentChangedAtDate for "+institutionId+" executed without significant errors"+Environment.NewLine);
		else if (!run&&Config.EmploymentsNotUpdated<1) WriteStringLineToLogFile("- GetEmploymentChangedAtDate for "+institutionId+" executed without significant errors, but 'SuccessfulRun' could not be registered in database"+Environment.NewLine);
		else WriteStringLineToLogFile("- GetEmploymentChangedAtDate for "+institutionId+" executed with some errors"+Environment.NewLine); }

	/// <summary>Checks error at end of updating</summary><param name="institutionId" />
	protected void CheckEmploymentChangedDataError(string institutionId) { bool run=false; if (Config.EmploymentsNotUpdated<1) run=UpdateSuccessfulRunInDatabase(institutionId,"GetEmploymentChanged");
		if (Config.EmploymentsNotUpdated>=1) WriteStringLineToLogFile($"- {Config.EmploymentsNotUpdated} employments not updated");
		if (run&&Config.EmploymentsNotUpdated<1) WriteStringLineToLogFile("- GetEmploymentChanged for "+institutionId+" executed without significant errors"+Environment.NewLine);
		else if (!run&&Config.EmploymentsNotUpdated<1) WriteStringLineToLogFile("- GetEmploymentChanged for "+institutionId+" executed without significant errors, but 'SuccessfulRun' could not be registered in database"+Environment.NewLine);
		else WriteStringLineToLogFile("- GetEmploymentChanged for "+institutionId+" executed with some errors"+Environment.NewLine); }

	/// <summary>Checks error at end of cloning</summary><param name="institutionId" />
	protected void CheckEmploymentDataError(string institutionId) { bool run=false; if (Config.EmploymentsNotUpdated<1) run=UpdateSuccessfulRunInDatabase(institutionId,"GetEmployment");
		if (Config.EmploymentsNotUpdated>=1) WriteStringLineToLogFile($"- {Config.EmploymentsNotUpdated} employments not updated");
		if (run&&Config.EmploymentsNotUpdated<1) WriteStringLineToLogFile("- GetEmployment for "+institutionId+" executed without significant errors"+Environment.NewLine);
		else if (!run&&Config.EmploymentsNotUpdated<1) WriteStringLineToLogFile("- GetEmployment for "+institutionId+" executed without significant errors, but 'SuccessfulRun' could not be registered in database"+Environment.NewLine);
		else WriteStringLineToLogFile("- GetEmployment for "+institutionId+" executed without significant errors,but 'SuccessfulRun' could not be registered in database"+Environment.NewLine); }

	/// <summary>Checks error at end of cloning</summary>
	protected void CheckInstitutionDataError() { bool run=false; if (Config.InstitutionsNotUpdated<1) run=UpdateSuccessfulRunInDatabase("HB","GetInstitution");
		if (Config.InstitutionsNotUpdated>=1) WriteStringLineToLogFile($"- {Config.InstitutionsNotUpdated} institutions not updated");
		if (run&&Config.InstitutionsNotUpdated<1) WriteStringLineToLogFile("- GetInstitution executed without significant errors"+Environment.NewLine);
		else if (!run&&Config.InstitutionsNotUpdated<1) WriteStringLineToLogFile("- GetInstitution executed without significant errors, but 'SuccessfulRun' could not be registered in database"+Environment.NewLine);
		else WriteStringLineToLogFile("- GetInstitution executed with some errors"+Environment.NewLine); }

	/// <summary>Checks error at end of cloning</summary><param name="institutionId" />
	protected void CheckOrganizationDataError(string institutionId) { bool run=false; if (Config.OrganizationsNotUpdated<1&&Config.OrganizationStructuresNotUpdated<1) run=UpdateSuccessfulRunInDatabase(institutionId,"GetOrganization");
		if (Config.OrganizationsNotUpdated>=1) WriteStringLineToLogFile($"- {Config.OrganizationsNotUpdated} organizations not updated");
		if (Config.OrganizationStructuresNotUpdated>=1) WriteStringLineToLogFile($"- {Config.OrganizationStructuresNotUpdated} organization structures not updated");
		if (run&&Config.OrganizationsNotUpdated<1&&Config.OrganizationStructuresNotUpdated<1) WriteStringLineToLogFile("- GetOrganization for "+institutionId+" executed without significant errors"+Environment.NewLine);
		else if (!run&&Config.OrganizationsNotUpdated<1&&Config.OrganizationStructuresNotUpdated<1) WriteStringLineToLogFile("- GetOrganization for "+institutionId+" executed without significant errors, "+
			"but 'SuccessfulRun' could not be registered in database"+Environment.NewLine);
		else WriteStringLineToLogFile("- GetOrganization for "+institutionId+" executed with some errors"+Environment.NewLine); }

	/// <summary>Checks error at end of updating</summary><param name="institutionId" />
	protected void CheckPersonChangedAtDateDataError(string institutionId) { bool run=false; if (Config.PersonsNotUpdated<1) run=UpdateSuccessfulRunInDatabase(institutionId,"GetPersonChangedAtDate");
		if (Config.PersonsNotUpdated>=1) WriteStringLineToLogFile($"- {Config.PersonsNotUpdated} persons not updated");
		if (run&&Config.PersonsNotUpdated<1) WriteStringLineToLogFile("- GetPersonChangedAtDate for "+institutionId+" executed without significant errors"+Environment.NewLine);
		else if (!run&&Config.PersonsNotUpdated<1) WriteStringLineToLogFile("- GetPersonChangedAtDate for "+institutionId+" executed without significant errors,but 'SuccessfulRun' could not be registered in database"+Environment.NewLine);
		else WriteStringLineToLogFile("- GetPersonChangedAtDate for "+institutionId+" executed with some errors"+Environment.NewLine); }

	/// <summary>Checks error at end of cloning</summary><param name="institutionId" />
	protected void CheckPersonDataError(string institutionId) { bool run=false; if (Config.PersonsNotUpdated<1) run=UpdateSuccessfulRunInDatabase(institutionId,"GetPerson");
		if (Config.PersonsNotUpdated>=1) WriteStringLineToLogFile($"- {Config.PersonsNotUpdated} persons not updated");
		if (run&&Config.PersonsNotUpdated<1) WriteStringLineToLogFile("- GetPerson for "+institutionId+" executed without significant errors"+Environment.NewLine);
		else if (!run&&Config.PersonsNotUpdated<1) WriteStringLineToLogFile("- GetPerson for "+institutionId+" executed without significant errors, but 'SuccessfulRun' could not be registered in database"+Environment.NewLine);
		else WriteStringLineToLogFile("- GetPerson for "+institutionId+" executed with some errors"+Environment.NewLine); }

	/// <summary>Checks error at end of cloning</summary><param name="institutionId" />
	protected void CheckProfessionDataError(string institutionId) { bool run=false; if (Config.ProfessionsNotUpdated<1) run=UpdateSuccessfulRunInDatabase(institutionId,"GetProfession");
		if (Config.ProfessionsNotUpdated>=1) WriteStringLineToLogFile($"- {Config.ProfessionsNotUpdated} professions not updated");
		if (run&&Config.ProfessionsNotUpdated<1) WriteStringLineToLogFile("- GetProfession executed without significant errors"+Environment.NewLine);
		else if (!run&&Config.ProfessionsNotUpdated<1) WriteStringLineToLogFile("- GetProfession executed without significant errors, but 'SuccessfulRun' could not be registered in database"+Environment.NewLine);
		else WriteStringLineToLogFile("- GetProfession executed with some errors"+Environment.NewLine); }

	/// <summary>Check Errors if any error stores error message in PageData</summary>
	protected void CheckErrors() { if (!this.Config.Authorized) { this.Config.ResponseString = Config.Error401Data; } else if (!this.Config.ContentProcessed) { this.Config.ResponseString = Config.Error501Data; }
		else if (this.Config.UnsupportedMedia) { this.Config.ResponseString = Config.Error415Data; } }

	#endregion

	/// <summary>Compares users in <paramref name="list"/> against database and identifies data to enrich</summary><param name="list" />
	protected void CheckUsers(List<ADUser> list) { Dictionary<string,ContactInformation> dict=GetContactInformationDict();  WriteStringLineToLogFile("- Enriching contactinformations in database with data "+
		"from Active Directory - "+CurrentMethod()+" line "+CurrentLineNumber()); CheckADUserListForDoublets(ref list); Parallel.ForEach(list,item => AddADUserToList(ref dict,item));
		WriteStringLineToLogFile("- Finished enriching contact informations"+" in database - "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine); }

	/// <summary> Checks wether Employments in SdDatabase stub are or soon will become inactive</summary>
	protected void CheckXmEmploymentAlerts() { RetrieveXmEmployments(); if (this.Config.XmRetrieved&&this.Config.XmEmploymentList.Count>=1) SaveCsvList(); }

	/// <summary>Writes result of application run to log</summary>
	protected void CheckXmResult() { if (Config.XmRetrieved&&Config.XmListSaved&&Config.XmEmploymentList.Count>=1) { WriteStringLineToLogFile("- "+Config.XmEmploymentList.Count+" soon expiring employments was retrieved and saved") ; }
		else if (Config.XmRetrieved&&!Config.XmListSaved&&Config.XmEmploymentList.Count>=1) { WriteStringLineToLogFile("- "+Config.XmEmploymentList.Count+" soon expiring employments was retrieved,but could not be saved"); }
		else if (Config.XmRetrieved&&Config.XmEmploymentList.Count<1) { WriteStringLineToLogFile("- No soon expiring employments was retrieved"); }
		else { WriteStringLineToLogFile("- Soon expiring employments could not be retrieved from SD database stub"); } }

	#endregion

	#region Private

	/// <summary>Checks and removes doublet EmployeeIds from <paramref name="list"/></summary><param name="list" />
	private void CheckADUserListForDoublets(ref List<ADUser> list) { Dictionary<string, ADUser> dict = new(); List<string> emplList=new();
		foreach (ADUser item in list) { if (!dict.ContainsKey(item.EmployeeNumber)) dict.Add(item.EmployeeNumber, item); else emplList.Add(item.EmployeeNumber); } 
		if (emplList.Any()) WriteStringLineToLogFile("- ADUserlist contained multiple records for the following EmployeeIds:"+Environment.NewLine+"  "+
			CheckedEmployeeNumbersToString(emplList)); list.Clear(); foreach (KeyValuePair<string,ADUser> item in dict) list.Add(item.Value); }

	/// <returns>content of <paramref name="idList"/> as string</returns><param name="idList" />
	private string CheckedEmployeeNumbersToString(List<string> idList) { if (idList.Count==1) return idList[0]; string result=string.Empty; foreach (string item in idList) result+=item+", ";
		result=result.TrimEnd(' '); result=result.TrimEnd(','); return result; }

	/// <summary>Checks wether <paramref name="mail"/> exists in <paramref name="info"/></summary><param name="mail" /><param name="info" /><returns>Result as bool</returns>
	private void CheckMail(string mail,ContactInformation info) { if (info.IsEmpty()) return; if (mail.IsNullOrWhiteSpace()) return; if (!ContactInformation.IsEmail(mail)) return; bool updateFlag=false;
		if (!info.EmailAddressIdentifier1.Equals("Empty@Empty.Com")&&info.EmailAddressIdentifier2.Equals("Empty@Empty.Com")) { if (!info.EmailAddressIdentifier1.Equals(mail)) { info.EmailAddressIdentifier2=mail; updateFlag=true; } }
		else if (info.EmailAddressIdentifier1.Equals("Empty@Empty.Com")&&!info.EmailAddressIdentifier2.Equals("Empty@Empty.Com")) { if (!info.EmailAddressIdentifier2.Equals(mail)) { info.EmailAddressIdentifier1=mail;
			updateFlag=true; } else {info.EmailAddressIdentifier1=mail; info.EmailAddressIdentifier2="Empty@Empty.Com"; updateFlag=true; } }
		else { info.EmailAddressIdentifier1=mail; updateFlag=true; } if (updateFlag) UpdateOrCreateInDatabase(info); }

	/// <summary>Checks wether <paramref name="phone"/> exists in <paramref name="info"/></summary><param name="phone" /><param name="info" /><returns>Result as bool</returns>
	private void CheckPhone(string phone,ContactInformation info) { if (info.IsEmpty()) return; if (phone.IsNullOrWhiteSpace()) return; if (!ContactInformation.IsPhoneNumber(phone)) return; bool updateFlag=false; 
		if (!info.TelephoneNumberIdentifier1.Equals("00000000")&&info.TelephoneNumberIdentifier2.Equals("00000000")) { if (!info.TelephoneNumberIdentifier1.Equals(phone)) { info.TelephoneNumberIdentifier2=phone; updateFlag=true; } }
		else if (info.TelephoneNumberIdentifier1.Equals("00000000")&&!info.TelephoneNumberIdentifier2.Equals("00000000")) { if (!info.TelephoneNumberIdentifier2.Equals(phone)) {
			info.TelephoneNumberIdentifier1=phone; updateFlag=true; } else { info.TelephoneNumberIdentifier1=phone; info.TelephoneNumberIdentifier2="00000000"; updateFlag=true; } }
		else { info.TelephoneNumberIdentifier1=phone; updateFlag=true; } if (updateFlag) UpdateOrCreateInDatabase(info); }

	#endregion

	#endregion

}
