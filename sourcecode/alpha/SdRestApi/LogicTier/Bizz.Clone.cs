// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Clone.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Clone
{
	#region Methods

	/// <returns>Clone of <paramref name="obj"/> as T</returns><typeparam name="T" /><param name="obj" />
	public static T CloneEntity<T>(T obj) where T : class { Converter<object, object> _memberwiseClone=(Converter<object, object>)Delegate.CreateDelegate(typeof(Converter<object, object>), typeof(object).GetMethod("MemberwiseClone", BindingFlags.NonPublic | BindingFlags.Instance)); return (T)_memberwiseClone(obj); }

	/// <returns>Clone of <paramref name="list"/></returns><typeparam name="T" /><param name="list" />
	public static List<T> CloneList<T>(List<T> list) where T : class { List<T> result=new(); if (list.Any()) Parallel.ForEach(list,item => result.Add(CloneEntity<T>(item))); return result; }

	#region Clone Data

	/// <remarks />
	public void CloneDepartmentDataHB() { try { string xml=InitiateRetrieveXml("HB","GetDepartment"); CloneData(xml,"HB","GetDepartment"); CheckDepartmentDataError("HB"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void CloneDepartmentDataHI() { try { string xml=InitiateRetrieveXml("HI","GetDepartment"); CloneData(xml,"HI","GetDepartment"); CheckDepartmentDataError("HI"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void CloneDepartmentDataHW() { try { string xml=InitiateRetrieveXml("HW","GetDepartment"); CloneData(xml,"HW","GetDepartment"); CheckDepartmentDataError("HW"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void CloneEmploymentDataHB() { try { string xml=InitiateRetrieveXml("HB","GetEmployment"); CloneData(xml,"HB","GetEmployment"); CheckEmploymentDataError("HB"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void CloneEmploymentDataHI() { try { string xml=InitiateRetrieveXml("HI","GetEmployment"); CloneData(xml,"HI","GetEmployment"); CheckEmploymentDataError("HI"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void CloneEmploymentDataHW() { try { string xml=InitiateRetrieveXml("HW","GetEmployment"); CloneData(xml,"HW","GetEmployment"); CheckEmploymentDataError("HW"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void CloneInstitutionData() { try { string xml=InitiateRetrieveXml("HB","GetInstitution"); CloneData(xml,"HB","GetInstitution"); CheckInstitutionDataError(); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void CloneOrganizationDataHB() { try { string xml=InitiateRetrieveXml("HB","GetOrganization"); CloneData(xml,"HB","GetOrganization"); CheckOrganizationDataError("HB"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void CloneOrganizationDataHI() { try { string xml=InitiateRetrieveXml("HI","GetOrganization"); CloneData(xml,"HI","GetOrganization"); CheckOrganizationDataError("HI"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void CloneOrganizationDataHW() { try { string xml=InitiateRetrieveXml("HW","GetOrganization"); CloneData(xml,"HW","GetOrganization"); CheckOrganizationDataError("HW"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void ClonePersonDataHB() { try { string xml=InitiateRetrieveXml("HB","GetPerson"); CloneData(xml,"HB","GetPerson"); CheckPersonDataError("HB"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void ClonePersonDataHI() { try { string xml=InitiateRetrieveXml("HI","GetPerson"); CloneData(xml,"HI","GetPerson"); CheckPersonDataError("HI"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void ClonePersonDataHW() { try { string xml=InitiateRetrieveXml("HW","GetPerson"); CloneData(xml,"HW","GetPerson"); CheckPersonDataError("HW"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void CloneProfessionDataHB() { try { string xml=InitiateRetrieveXml("HB","GetProfession"); CloneData(xml,"HB","GetProfession"); CheckProfessionDataError("HB"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void CloneProfessionDataHI() { try { string xml=InitiateRetrieveXml("HI","GetProfession"); CloneData(xml,"HI","GetProfession"); CheckProfessionDataError("HI"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void CloneProfessionDataHW() { try { string xml=InitiateRetrieveXml("HW","GetProfession"); CloneData(xml,"HW","GetProfession"); CheckProfessionDataError("HW"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	#endregion

	#region Private

	#region Clone Data

	/// <summary>Cleans data - and updates database</summary><param name="xml" /><param name="institutionId" /><param name="sdApi" />
	protected void CloneData(string xml,string institutionId,string sdApi) { WriteStringLineToLogFile("- Preparing update of retrieved "+sdApi+" data for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine);
		switch (sdApi) { case "GetDepartment": CloneDepartmentData(xml,institutionId,sdApi); break; case "GetEmployment": CloneEmploymentData(xml,institutionId,sdApi); break;
			case "GetEmploymentChanged": CloneEmploymentData(xml,institutionId,sdApi); break; case "GetEmploymentChangedAtDate": CloneEmploymentData(xml,institutionId,sdApi); break;
			case "GetInstitution": CloneInstitutionData(xml,sdApi); break; case "GetOrganization": CloneOrganizationData(xml,institutionId,sdApi); break;
			case "GetPerson": ClonePersonData(xml,institutionId,sdApi); break; case "GetPersonChangedAtDate": ClonePersonData(xml,institutionId,sdApi); break;
			case "GetProfession": CloneProfessionData(xml,institutionId,sdApi); break; default: throw new ArgumentInvalidException(nameof(sdApi),sdApi,nameof(sdApi)+Error.UnkAPI); } }

	/// <summary>Updates <paramref name="xml"/> data into database</summary><param name="xml" /><param name="institutionId" /><param name="sdApi" />
	private void CloneDepartmentData(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: GetDepartment XML string for "+institutionId+" is empty - "+
			CurrentMethod()+" line "+CurrentLineNumber()); return; } if (institutionId.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: institutionId is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
		if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; } WriteStringLineToLogFile("- Updating departments for "+institutionId+
			" - "+CurrentMethod()+" line "+CurrentLineNumber()); try { InitiateDeserializeSoapClone(xml,institutionId,sdApi); Garbage.Collect(); WriteStringLineToLogFile("- "+GetListCount<Department>()+
				" departments in the database after update - "+CurrentMethod()+" line "+CurrentLineNumber()); }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating departments for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			eex.ToErrorString()+Environment.NewLine+Environment.NewLine); Garbage.Collect(); }
		catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating departments for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			ExpressionException.ToErrorString(ex)+Environment.NewLine+Environment.NewLine); Garbage.Collect(); } }

	/// <summary>Updates <paramref name="xml"/> data into database</summary><param name="xml" /><param name="institutionId" /><param name="sdApi" />
	private void CloneEmploymentData(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: GetEmployment XML string for "+institutionId+" is empty - "+
			CurrentMethod()+" line "+CurrentLineNumber()); return; } if (institutionId.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: institutionId is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
		if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; } WriteStringLineToLogFile("- Updating employments etc. for "+institutionId+
			" - "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine); try { InitiateDeserializeSoapClone(xml,institutionId,sdApi); Garbage.Collect(); WriteStringLineToLogFile("- "+GetListCount<Employment>()+
				" employments in the database after update - "+CurrentMethod()+" line "+CurrentLineNumber()); }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating employments etc. for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+
			Environment.NewLine+eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); }
		catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating employments etc. for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); } }

	/// <summary>Updates <paramref name="xml"/> data into database</summary><param name="xml" /><param name="sdApi" />
	private void CloneInstitutionData(string xml,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: GetInstitution XML string is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
		if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; } WriteStringLineToLogFile("- Updating institutions - "+CurrentMethod()+
			" line "+CurrentLineNumber()+Environment.NewLine); try { InitiateDeserializeSoapClone(xml,"HB",sdApi); Garbage.Collect(); WriteStringLineToLogFile("- "+GetListCount<Institution>()+" institutions in the database after update - "+
				CurrentMethod()+" line "+CurrentLineNumber()); }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating institutions - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); } catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating institutions - "+CurrentMethod()+" line "+
				CurrentLineNumber()+":"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine+"- "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine); Garbage.Collect(); } }

	/// <summary>Updates <paramref name="xml"/> data into database</summary><param name="xml" /><param name="institutionId" /><param name="sdApi" />
	private void CloneOrganizationData(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: GetOrganization XML string for "+institutionId+" is empty - "+
			CurrentMethod()+" line "+CurrentLineNumber()); return; } if (institutionId.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: institutionId is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
		if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; } WriteStringLineToLogFile("- Updating organizations etc. for "+
			institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()); 
		try { InitiateDeserializeSoapClone(xml,institutionId,sdApi); Garbage.Collect(); WriteStringLineToLogFile("- "+GetListCount<Organization>()+
				" organizations in the database after update"+Environment.NewLine+"- "+GetListCount<OrganizationStructure>()+" organization structures in the database after update"+Environment.NewLine+"- "+GetListCount<DepartmentLevelReference>()+
				" department level references in the database after update"+Environment.NewLine+"- "+GetListCount<DepartmentReference>()+" department references in the database after update - "+CurrentMethod()+" line "+CurrentLineNumber()); }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating organizations etc. for "+institutionId+"- "+CurrentMethod()+" line "+CurrentLineNumber()+":"+
			Environment.NewLine+eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); } catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating organizations etc. for "+
				institutionId+"- "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); } }

	/// <summary>Updates <paramref name="xml"/> data into database</summary><param name="xml" /><param name="institutionId" /><param name="sdApi" />
	private void ClonePersonData(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: GetPerson XML string for "+institutionId+" is empty - "+CurrentMethod()+
			" line "+CurrentLineNumber()); return; } if (institutionId.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: institutionId is empty - "+
			CurrentMethod()+" line "+CurrentLineNumber()); return; } if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
		WriteStringLineToLogFile("- Updating persons etc. for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()); try { InitiateDeserializeSoapClone(xml,institutionId,sdApi); Garbage.Collect();
		WriteStringLineToLogFile("- "+GetListCount<Person>()+" persons in the database after update - "+CurrentMethod()+" line "+CurrentLineNumber()); }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating persons etc. for "+institutionId+"- "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); } catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating persons etc. for "+institutionId+"- "+CurrentMethod()+
				" line "+CurrentLineNumber()+":"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); } }

	/// <summary>Updates <paramref name="xml"/> data into database</summary><param name="xml" /><param name="institutionId" /><param name="sdApi" />
	private void CloneProfessionData(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: GetProfession XML string for "+institutionId+" is empty - "+
			CurrentMethod()+" line "+CurrentLineNumber()); return; } if (institutionId.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: institutionId is empty - "+
			CurrentMethod()+" line "+CurrentLineNumber()); return; } if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
				WriteStringLineToLogFile("- Updating professions for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()); try { InitiateDeserializeSoapClone(xml,institutionId,sdApi); Garbage.Collect();
				WriteStringLineToLogFile("- "+GetListCount<Profession>()+" professions in the database after update - "+CurrentMethod()+" line "+CurrentLineNumber()); }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating professions etc. for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); } catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating professions etc. for "+institutionId+" - "+
				CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); } }

	#endregion

	#region Clone Entities

	/// <summary>Updates entities in <paramref name="entity"/> into database</summary><param name="entity" /><returns>Result as bool</returns>
	private bool CloneDepartments(GetDepartment20111201 entity) { string institutionId=entity.GetDepartmentRequestStructure.InstitutionIdentifier; try { if (entity.Departments.Count<1) return false;
		foreach (WsDepartment item in entity.Departments) { item.InstitutionIdentifier=institutionId; if (item.ContactInformation!=null) { ContactInformation info=item.ToContactInformation();
			CloneContactInformation(ref info,item.DepartmentUuidIdentifier,true); } if (item.PostalAddress!=null) { PostalAddress addr=item.ToPostalAddress(); ClonePostalAddress(ref addr,"",true); }
				Department dept=item.ToDepartment(); CloneDepartment(ref dept,institutionId,true); } WriteStringLineToLogFile("- "+this.Config.DepartmentsUpdated+" departments etc. for "+institutionId+" cloned into database");
			if (this.Config.DepartmentsNotUpdated>=1) WriteStringLineToLogFile("- "+this.Config.DepartmentsNotUpdated+" departments etc. for "+institutionId+" not cloned into database"); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- Some departments etc. for "+institutionId+" not cloned into database"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- Some departments etc. for "+institutionId+" not cloned into database"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <summary>Updates entities in <paramref name="entity"/> into database</summary><param name="entity" /><returns>Result as bool</returns>
	private bool CloneEmployments(GetEmployment20111201 entity) { string institutionId=entity.GetEmploymentRequestStructure.InstitutionIdentifier; try { if (entity.Persons.Count<1) return false;
			foreach (WsPerson item in entity.Persons) { foreach (WsEmployment empl in item.WsEmployments) { empl.InstitutionIdentifier=institutionId; empl.Employee=item.PersonCivilRegistrationIdentifier;
				EmploymentProfession prof=empl.ToEmploymentProfession(); 
				CloneEmploymentProfession(ref prof,true); EmploymentStatus status=empl.ToEmploymentStatus(); CloneEmploymentStatus(ref status,empl.EmploymentIdentifier,true);
				SalaryAgreement agree=empl.ToSalaryAgreement(); CloneSalaryAgreement(ref agree,empl.EmploymentIdentifier,true); SalaryCodeGroup group=empl.ToSalaryCodeGroup(); CloneSalaryCodeGroup(ref group,empl.EmploymentIdentifier,true); 
				WorkingTime time=empl.ToWorkingTime(); CloneWorkingTime(ref time,empl.EmploymentIdentifier,true);  Employment tempEmpl=empl.ToEmployment(); CloneEmployment(ref tempEmpl,true); }
				WriteStringLineToLogFile("- "+this.Config.EmploymentsUpdated+" employments etc. for "+institutionId+" cloned into database");
				if (this.Config.EmploymentsNotUpdated>=1) WriteStringLineToLogFile("- "+this.Config.EmploymentsNotUpdated+" employments etc. for "+institutionId+" not cloned into database"); } return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- Some employments etc. for "+institutionId+" not cloned into database"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- Some employments etc. for "+institutionId+" not cloned into database"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <summary>Updates entities in <paramref name="entity"/> into database</summary><param name="entity" /><returns>Result as bool</returns>
	private bool CloneInstitutions(GetInstitution20111201 entity) { if (entity.Region.Institutions.Count<1) return false; try { foreach (WsInstitution item in entity.Region.Institutions) { Institution inst=item.ToInstitution();
			CloneInstitution(ref inst,true); } WriteStringLineToLogFile("- "+this.Config.InstitutionsUpdated+" institutions cloned into database"); if (this.Config.InstitutionsNotUpdated>=1)
				WriteStringLineToLogFile("- "+this.Config.InstitutionsNotUpdated+" institutions not cloned into database"); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- Some institutions not cloned into database"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- Some institutions not added cloned into database"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <summary>Updates entities in <paramref name="entity"/> into database</summary><param name="entity" /><returns>Result as bool</returns>
	private bool ClonePersons(GetPerson20111201 entity) { try { foreach (WsPerson item in entity.Persons) { item.InstitutionIdentifier=entity.GetPersonRequestStructure.InstitutionIdentifier; 
		if (item.ContactInformation!=null) { ContactInformation info=item.ToContactInformation(); CloneContactInformation(ref info,"",true); }  if (item.PostalAddress!=null) { PostalAddress addr=item.ToPostalAddress();
			ClonePostalAddress(ref addr,"",true); } Person pers=item.ToPerson(); ClonePerson(ref pers,true); } WriteStringLineToLogFile("- "+this.Config.PersonsUpdated+" persons etc. cloned into database");
			if (this.Config.PersonsNotUpdated>=1) WriteStringLineToLogFile("- "+this.Config.PersonsNotUpdated+" persons not cloned into database"); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- Some persons not cloned into database"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- Some persons not updated cloned database"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <summary>Updates entities in <paramref name="entity"/> into database</summary><param name="entity" /><returns>Result as bool</returns>
	private bool CloneProfessions(GetProfession20080201 entity) { string institutionId=entity.RequestKey.InstitutionIdentifier; try { if (entity.Professions.Count<1) return false; foreach (WsProfession item in
			entity.Professions) { item.InstitutionIdentifier=institutionId; Profession prof=item.ToProfession(); CloneProfession(ref prof,true); } WriteStringLineToLogFile("- "+this.Config.ProfessionsUpdated+" professions for "+
				institutionId+" cloned into database"); if (this.Config.ProfessionsNotUpdated>=1) WriteStringLineToLogFile("- "+this.Config.ProfessionsNotUpdated+" persons not cloned into database"); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- Some professions for "+institutionId+" not cloned into database"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- Some professions for "+institutionId+" not cloned into database"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	#endregion

	#region Clone Entity

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneContactInformation(ref ContactInformation entity,string parent="",bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=CloneContactInformationNoCheck(ref entity,parent);
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { this.Config.ContactInformationsUpdated++; return true; } else { this.Config.ContactInformationsNotUpdated++; return false; } } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><returns>Result as bool</returns>
	protected bool CloneContactInformationNoCheck(ref ContactInformation entity,string parent="") { if (!parent.IsNullOrWhiteSpace()&&entity.ParentIdentifier.IsNullOrWhiteSpace())
			entity.ParentIdentifier=parent; if (entity.IsEmpty()) return false; bool updateFlag=false; if (CheckCioPhoneNumbers(ref entity)&&!updateFlag) updateFlag=true;  
			if (CheckCioEmailAdresses(ref entity)&&!updateFlag) updateFlag=true; if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="institutionId" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneDepartment(ref Department entity,string institutionId,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=CloneDepartmentNoCheck(ref entity,institutionId);
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { this.Config.DepartmentsUpdated++; return true; } else { this.Config.DepartmentsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="institutionId" /><returns>Result as bool</returns>
	protected bool CloneDepartmentNoCheck(ref Department entity,string institutionId) { if (institutionId.IsNullOrWhiteSpace()&&!institutionId.Equals("NO")&&(entity.InstitutionIdentifier.IsNullOrWhiteSpace()||
			entity.InstitutionIdentifier.Equals("NO"))) entity.InstitutionIdentifier=institutionId; if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneDepartmentLevelReference(ref DepartmentLevelReference entity,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=CloneDepartmentLevelReferenceNoCheck(ref entity);
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { this.Config.DepartmentLevelReferencesUpdated++; return true; } else { this.Config.DepartmentLevelReferencesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	protected bool CloneDepartmentLevelReferenceNoCheck(ref DepartmentLevelReference entity) { if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneDepartmentReference(ref DepartmentReference entity,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=CloneDepartmentReferenceNoCheck(ref entity);
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { this.Config.DepartmentReferencesUpdated++; return true; } else { this.Config.DepartmentReferencesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	protected bool CloneDepartmentReferenceNoCheck(ref DepartmentReference entity) { if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneEmployment(ref Employment entity,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=CloneEmploymentNoCheck(ref entity); if (updateInDatabase) {
		if (UpdateOrCreateInDatabase(entity)) { this.Config.EmploymentsUpdated++; return true; } else { this.Config.EmploymentsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	protected bool CloneEmploymentNoCheck(ref Employment entity) { if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneEmploymentProfession(ref EmploymentProfession entity,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=CloneEmploymentProfessionNoCheck(ref entity);
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { this.Config.EmploymentProfessionsUpdated++; return true; } else { this.Config.EmploymentProfessionsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	protected bool CloneEmploymentProfessionNoCheck(ref EmploymentProfession entity) { if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneEmploymentStatus(ref EmploymentStatus entity,string parent="",bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=CloneEmploymentStatusNoCheck(ref entity,parent);
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { this.Config.EmploymentStatusesUpdated++; return true; } else { this.Config.EmploymentStatusesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><returns>Result as bool</returns>
	protected bool CloneEmploymentStatusNoCheck(ref EmploymentStatus entity,string parent="") { if (!parent.IsNullOrWhiteSpace()&&entity.EmploymentIdentifier.IsNullOrWhiteSpace()) entity.EmploymentIdentifier=parent;
		if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneInstitution(ref Institution entity,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=CloneInstitutionNoCheck(ref entity); if (updateInDatabase) { 
		if (Config.CheckInstitutionIdentifier(entity.InstitutionIdentifier)&&UpdateOrCreateInDatabase(entity)) { this.Config.InstitutionsUpdated++; return true; } else { this.Config.InstitutionsNotUpdated++; return false; } } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	protected bool CloneInstitutionNoCheck(ref Institution entity) { if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates Organization and DepartmentReferences</summary><param name="entity" /><param name="institutionId" /><returns>Result as bool</returns>
	private bool CloneOrganization(WsOrganization entity,string institutionId) { if (!institutionId.IsNullOrWhiteSpace()&&!institutionId.Equals("NO")&&(entity.InstitutionIdentifier.IsNullOrWhiteSpace()||
		entity.InstitutionIdentifier.Equals("NO"))) entity.InstitutionIdentifier=institutionId; if (entity.WsDepartmentReferences.Count<1) return true; try { foreach (WsDepartmentReference item in entity.WsDepartmentReferences)
			AddOrganizationToDepartmentReferencesClone(item,entity.InstitutionIdentifier); Organization org=entity.ToOrganization(); return CloneOrganization(ref org,institutionId,true); } catch { return false; } }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="institutionId" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneOrganization(ref Organization entity,string institutionId,bool updateInDatabase=false) { if (!Config.CheckInstitutionIdentifier(institutionId)&&
			entity.InstitutionIdentifier.Equals("NO")) return false; if (entity.InstitutionIdentifier.Equals("NO")) entity.InstitutionIdentifier=institutionId; if (entity.IsEmpty()) return false; 
		bool updateFlag=CloneOrganizationNoCheck(ref entity,institutionId); if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) {  this.Config.OrganizationsUpdated++;
			return true; } else {this.Config.OrganizationsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="institutionId" /><returns>Result as bool</returns>
	protected bool CloneOrganizationNoCheck(ref Organization entity,string institutionId) { if (!institutionId.IsNullOrWhiteSpace()&&!institutionId.Equals("NO")&&(entity.InstitutionIdentifier.IsNullOrWhiteSpace()||
		entity.InstitutionIdentifier.Equals("NO"))) entity.InstitutionIdentifier=institutionId; if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates Organization and DepartmentReferences</summary><param name="entity" /><param name="institutionId" /><returns>Result as bool</returns>
	private bool CloneOrganizationStructure(WsOrganizationStructure entity,string institutionId) { if (institutionId.IsNullOrWhiteSpace()&&!institutionId.Equals("NO")&&
		(entity.InstitutionIdentifier.IsNullOrWhiteSpace()||entity.InstitutionIdentifier.Equals("NO"))) entity.InstitutionIdentifier=institutionId; if (entity.WsDepartmentLevelReferences.Count<1) return true; try {
			foreach (WsDepartmentLevelReference item in entity.WsDepartmentLevelReferences) AddOrganizationStructureToDepartmentLevelReferencesClone(item,institutionId);
				OrganizationStructure structure=entity.ToOrganizationStructure(); return CloneOrganizationStructure(ref structure,institutionId,true); }  catch { return false; } }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="institutionId" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneOrganizationStructure(ref OrganizationStructure entity,string institutionId,bool updateInDatabase=false) { if (!Config.CheckInstitutionIdentifier(institutionId)&&
			entity.InstitutionIdentifier.Equals("NO")) return false; if (entity.InstitutionIdentifier.Equals("NO")) entity.InstitutionIdentifier=institutionId; if (entity.IsEmpty()) return false;
		bool updateFlag=CloneOrganizationStructureNoCheck(ref entity); if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { this.Config.OrganizationStructuresUpdated++;
			return true; } else { this.Config.OrganizationStructuresNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	protected bool CloneOrganizationStructureNoCheck(ref OrganizationStructure entity) { if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool ClonePerson(ref Person entity,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=ClonePersonNoCheck(ref entity); if (updateInDatabase) {
		if (UpdateOrCreateInDatabase(entity)) { this.Config.PersonsUpdated++; return true; } else { this.Config.PersonsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	protected bool ClonePersonNoCheck(ref Person entity) { if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool ClonePostalAddress(ref PostalAddress entity,string parent="",bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=ClonePostalAddressNoCheck(ref entity,parent);
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { this.Config.PostalAddressesUpdated++; return true; } else { this.Config.PostalAddressesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates content of <paramref name="entity"/> in database</summary><param name="entity" /><param name="parent" /><returns>Result as bool</returns>
	protected bool ClonePostalAddressNoCheck(ref PostalAddress entity,string parent="") { if (parent.IsNullOrWhiteSpace()&&entity.ParentIdentifier.IsNullOrWhiteSpace())
		entity.ParentIdentifier=parent; if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneProfession(ref Profession entity,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=CloneProfessionNoCheck(ref entity); if (updateInDatabase) { 
		if (UpdateOrCreateInDatabase(entity)) { this.Config.ProfessionsUpdated++; return true; } else { this.Config.ProfessionsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	protected bool CloneProfessionNoCheck(ref Profession entity) { if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneSalaryAgreement(ref SalaryAgreement entity,string parent="",bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=CloneSalaryAgreementNoCheck(ref entity,parent);
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { this.Config.SalaryAgreementsUpdated++; return true; } else { this.Config.SalaryAgreementsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity"/><param name="parent" /><returns>Result as bool</returns>
	protected bool CloneSalaryAgreementNoCheck(ref SalaryAgreement entity,string parent="") { if (parent.IsNullOrWhiteSpace()&&entity.EmploymentIdentifier.IsNullOrWhiteSpace()) entity.EmploymentIdentifier=parent;
		if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneSalaryCodeGroup(ref SalaryCodeGroup entity,string parent="",bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=CloneSalaryCodeGroupNoCheck(ref entity,parent);
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { this.Config.SalaryCodeGroupsUpdated++; return true; } else { this.Config.SalaryCodeGroupsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><returns>Result as bool</returns>
	protected bool CloneSalaryCodeGroupNoCheck(ref SalaryCodeGroup entity,string parent="") { if (parent.IsNullOrWhiteSpace()&&entity.EmploymentIdentifier.IsNullOrWhiteSpace()) entity.EmploymentIdentifier=parent;
		if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="employment" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	protected bool CloneWorkingTime(ref WorkingTime entity,string employment="",bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=CloneWorkingTimeNoCheck(ref entity,employment);
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { this.Config.WorkingTimesUpdated++; return true; } else { this.Config.WorkingTimesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="employment" /><returns>Result as bool</returns>
	protected bool CloneWorkingTimeNoCheck(ref WorkingTime entity,string employment="") { if (employment.IsNullOrWhiteSpace()&&entity.EmploymentIdentifier.IsNullOrWhiteSpace())
		entity.EmploymentIdentifier=employment; if (entity.IsEmpty()) return false; if (entity.IsUpdated()) { entity.Validate(); return true; } return false; }

	#endregion

	#endregion

	#endregion

}
