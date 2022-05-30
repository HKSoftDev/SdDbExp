// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Update.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Update retrieved data into database
{
	#region Methods

	#region Update Data

	/// <remarks />
	public void UpdateDepartmentDataHB() { try { string xml=InitiateRetrieveXml("HB","GetDepartment"); UpdateData(xml,"HB","GetDepartment"); CheckDepartmentDataError("HB"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateDepartmentDataHI() { try { string xml=InitiateRetrieveXml("HI","GetDepartment"); UpdateData(xml,"HI","GetDepartment"); CheckDepartmentDataError("HI"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateDepartmentDataHW() { try { string xml=InitiateRetrieveXml("HW","GetDepartment"); UpdateData(xml,"HW","GetDepartment"); CheckDepartmentDataError("HW"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateEmploymentChangedDataHB() { try { string xml=InitiateRetrieveXml("HB","GetEmploymentChanged"); UpdateData(xml,"HB","GetEmploymentChanged"); CheckEmploymentChangedDataError("HB"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateEmploymentChangedDataHI() { try { string xml=InitiateRetrieveXml("HI","GetEmploymentChanged"); UpdateData(xml,"HI","GetEmploymentChanged"); CheckEmploymentChangedDataError("HB"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateEmploymentChangedDataHW() { try { string xml=InitiateRetrieveXml("HW","GetEmploymentChanged"); UpdateData(xml,"HW","GetEmploymentChanged"); CheckEmploymentChangedDataError("HB"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateEmploymentChangedAtDateDataHB() { try { string xml=InitiateRetrieveXml("HB","GetEmploymentChangedAtDate"); UpdateData(xml,"HB","GetEmploymentChangedAtDate"); CheckEmploymentChangedAtDateDataError("HB"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateEmploymentChangedAtDateDataHI() { try { string xml=InitiateRetrieveXml("HI","GetEmploymentChangedAtDate"); UpdateData(xml,"HI","GetEmploymentChangedAtDate"); CheckEmploymentChangedAtDateDataError("HI"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateEmploymentChangedAtDateDataHW() { try { string xml=InitiateRetrieveXml("HW","GetEmploymentChangedAtDate"); UpdateData(xml,"HW","GetEmploymentChangedAtDate"); CheckEmploymentChangedAtDateDataError("HW"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateInstitutionData() { try { string xml=InitiateRetrieveXml("HB","GetInstitution"); UpdateData(xml,"HB","GetInstitution"); CheckInstitutionDataError(); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateOrganizationDataHB() { try { string xml=InitiateRetrieveXml("HB","GetOrganization"); UpdateData(xml,"HB","GetOrganization"); CheckOrganizationDataError("HB"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateOrganizationDataHI() { try { string xml=InitiateRetrieveXml("HI","GetOrganization"); UpdateData(xml,"HI","GetOrganization"); CheckOrganizationDataError("HI"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateOrganizationDataHW() { try { string xml=InitiateRetrieveXml("HW","GetOrganization"); UpdateData(xml,"HW","GetOrganization"); CheckOrganizationDataError("HW"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdatePersonChangedAtDateDataHB() { try { string xml=InitiateRetrieveXml("HB","GetPersonChangedAtDate"); UpdateData(xml,"HB","GetPersonChangedAtDate"); CheckPersonChangedAtDateDataError("HB"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdatePersonChangedAtDateDataHI() { try { string xml=InitiateRetrieveXml("HI","GetPersonChangedAtDate"); UpdateData(xml,"HI","GetPersonChangedAtDate"); CheckPersonChangedAtDateDataError("HI"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdatePersonChangedAtDateDataHW() { try { string xml=InitiateRetrieveXml("HW","GetPersonChangedAtDate"); UpdateData(xml,"HW","GetPersonChangedAtDate"); CheckPersonChangedAtDateDataError("HW"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateProfessionDataHB() { try { string xml=InitiateRetrieveXml("HB","GetProfession"); UpdateData(xml,"HB","GetProfession"); CheckProfessionDataError("HB"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateProfessionDataHI() { try { string xml=InitiateRetrieveXml("HI","GetProfession"); UpdateData(xml,"HI","GetProfession"); CheckProfessionDataError("HI"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <remarks />
	public void UpdateProfessionDataHW() { try { string xml=InitiateRetrieveXml("HW","GetProfession"); UpdateData(xml,"HW","GetProfession"); CheckProfessionDataError("HW"); }
		catch (ExpressionException eex) { Config.SetErrorFlags(); WriteStringLineToLogFile(eex.ToErrorString()); }
		catch (Exception ex) { Config.SetErrorFlags(); WriteStringLineToLogFile(ExpressionException.ToErrorString(ex)); } }

	/// <summary>Cleans data - and updates database</summary><param name="xml" /><param name="institutionId" /><param name="sdApi" />
	protected void UpdateData(string xml,string institutionId,string sdApi) { WriteStringLineToLogFile("- Preparing update of retrieved "+sdApi+" data for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine);
		switch (sdApi) { case "GetDepartment": UpdateDepartmentData(xml,institutionId,sdApi); break; case "GetEmployment": UpdateEmploymentData(xml,institutionId,sdApi); break;
			case "GetEmploymentChanged": UpdateEmploymentData(xml,institutionId,sdApi); break; case "GetEmploymentChangedAtDate": UpdateEmploymentData(xml,institutionId,sdApi); break;
			case "GetInstitution": UpdateInstitutionData(xml,sdApi); break; case "GetOrganization": UpdateOrganizationData(xml,institutionId,sdApi); break;
			case "GetPerson": UpdatePersonData(xml,institutionId,sdApi); break; case "GetPersonChangedAtDate": UpdatePersonData(xml,institutionId,sdApi); break;
			case "GetProfession": UpdateProfessionData(xml,institutionId,sdApi); break; default: throw new ArgumentInvalidException(nameof(sdApi),sdApi,nameof(sdApi)+Error.UnkAPI); } }

	#endregion

	#region Private

	#region Update Data

	/// <summary>Updates <paramref name="xml"/> data into database</summary><param name="xml" /><param name="institutionId" /><param name="sdApi" />
	private void UpdateDepartmentData(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: GetDepartment XML string for "+institutionId+" is empty - "+
			CurrentMethod()+" line "+CurrentLineNumber()); return; } if (institutionId.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: institutionId is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
		if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; } WriteStringLineToLogFile("- Updating departments for "+institutionId+
			" - "+CurrentMethod()+" line "+CurrentLineNumber()); try { InitiateDeserializeSoapUpdate(xml,institutionId,sdApi); Garbage.Collect(); WriteStringLineToLogFile("- "+GetListCount<Department>()+
				" departments in the database after update - "+CurrentMethod()+" line "+CurrentLineNumber()); UpdateSuccessfulRunInDatabase(institutionId,sdApi); }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating departments for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			eex.ToErrorString()+Environment.NewLine+Environment.NewLine); Garbage.Collect(); }
		catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating departments for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			ExpressionException.ToErrorString(ex)+Environment.NewLine+Environment.NewLine); Garbage.Collect(); } }

	/// <summary>Updates <paramref name="xml"/> data into database</summary><param name="xml" /><param name="institutionId" /><param name="sdApi" />
	private void UpdateEmploymentData(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: GetEmployment XML string for "+institutionId+" is empty - "+
			CurrentMethod()+" line "+CurrentLineNumber()); return; } if (institutionId.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: institutionId is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
		if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; } WriteStringLineToLogFile("- Updating employments etc. for "+institutionId+
			" - "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine); try { InitiateDeserializeSoapUpdate(xml,institutionId,sdApi); Garbage.Collect(); WriteStringLineToLogFile("- "+GetListCount<Employment>()+
				" employments in the database after update - "+CurrentMethod()+" line "+CurrentLineNumber()); UpdateSuccessfulRunInDatabase(institutionId,sdApi); }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating employments etc. for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+
			Environment.NewLine+eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); }
		catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating employments etc. for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); } }

	/// <summary>Updates <paramref name="xml"/> data into database</summary><param name="xml" /><param name="sdApi" />
	private void UpdateInstitutionData(string xml,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: GetInstitution XML string is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
		if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; } WriteStringLineToLogFile("- Updating institutions - "+CurrentMethod()+
			" line "+CurrentLineNumber()+Environment.NewLine); try { InitiateDeserializeSoapUpdate(xml,"HB",sdApi); Garbage.Collect(); WriteStringLineToLogFile("- "+GetListCount<Institution>()+" institutions in the database after update - "+
				CurrentMethod()+" line "+CurrentLineNumber()); UpdateSuccessfulRunInDatabase("HB",sdApi); }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating institutions - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); } catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating institutions - "+CurrentMethod()+" line "+
				CurrentLineNumber()+":"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine+"- "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine); Garbage.Collect(); } }

	/// <summary>Updates <paramref name="xml"/> data into database</summary><param name="xml" /><param name="institutionId" /><param name="sdApi" />
	private void UpdateOrganizationData(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: GetOrganization XML string for "+institutionId+" is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
		if (institutionId.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: institutionId is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
		if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
		WriteStringLineToLogFile("- Updating organizations etc. for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()); try { InitiateDeserializeSoapUpdate(xml,institutionId,sdApi); Garbage.Collect();
			WriteStringLineToLogFile("- "+GetListCount<Organization>()+" organizations in the database after update"+Environment.NewLine+"- "+GetListCount<OrganizationStructure>()+" organization structures in the database "+
				"after update"+Environment.NewLine+"- "+GetListCount<DepartmentLevelReference>()+" department level references in the database after update"+Environment.NewLine+"- "+GetListCount<DepartmentReference>()+
				" department references in the database after update - "+CurrentMethod()+" line "+CurrentLineNumber()); UpdateSuccessfulRunInDatabase(institutionId,sdApi); }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating organizations etc. for "+institutionId+"- "+CurrentMethod()+" line "+CurrentLineNumber()+":"+
			Environment.NewLine+eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); } catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating organizations etc. for "+
				institutionId+"- "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); } }

	/// <summary>Updates <paramref name="xml"/> data into database</summary><param name="xml" /><param name="institutionId" /><param name="sdApi" />
	private void UpdatePersonData(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: GetPerson XML string for "+institutionId+" is empty - "+CurrentMethod()+
			" line "+CurrentLineNumber()); return; } if (institutionId.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: institutionId is empty - "+
			CurrentMethod()+" line "+CurrentLineNumber()); return; } if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
		WriteStringLineToLogFile("- Updating persons etc. for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()); try { InitiateDeserializeSoapUpdate(xml,institutionId,sdApi); Garbage.Collect();
		WriteStringLineToLogFile("- "+GetListCount<Person>()+" persons in the database after update - "+CurrentMethod()+" line "+CurrentLineNumber()); UpdateSuccessfulRunInDatabase(institutionId,sdApi); }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating persons etc. for "+institutionId+"- "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); } catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating persons etc. for "+institutionId+"- "+CurrentMethod()+
				" line "+CurrentLineNumber()+":"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); } }

	/// <summary>Updates <paramref name="xml"/> data into database</summary><param name="xml" /><param name="institutionId" /><param name="sdApi" />
	private void UpdateProfessionData(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: GetProfession XML string for "+institutionId+" is empty - "+
			CurrentMethod()+" line "+CurrentLineNumber()); return; } if (institutionId.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: institutionId is empty - "+
			CurrentMethod()+" line "+CurrentLineNumber()); return; } if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return; }
				WriteStringLineToLogFile("- Updating professions for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()); try { InitiateDeserializeSoapUpdate(xml,institutionId,sdApi); Garbage.Collect();
				WriteStringLineToLogFile("- "+GetListCount<Profession>()+" professions in the database after update - "+CurrentMethod()+" line "+CurrentLineNumber()); }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating professions etc. for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); } catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while updating professions etc. for "+institutionId+" - "+
				CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); } }

	#endregion

	#region Update Entities

	/// <summary>Updates entities in <paramref name="entity"/> into database</summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdateDepartments(GetDepartment20111201 entity) { string institutionId=entity.GetDepartmentRequestStructure.InstitutionIdentifier; try { if (entity.Departments.Count<1) return false;
		foreach (WsDepartment item in entity.Departments) { item.InstitutionIdentifier=institutionId; if (item.ContactInformation!=null) { ContactInformation info=item.ToContactInformation();
			UpdateContactInformation(ref info,item.DepartmentUuidIdentifier,true); } if (item.PostalAddress!=null) { PostalAddress addr=item.ToPostalAddress(); UpdatePostalAddress(ref addr,"",true); }
				Department dept=item.ToDepartment(); UpdateDepartment(ref dept,institutionId,true); } WriteStringLineToLogFile("- "+this.Config.DepartmentsUpdated+" departments for "+institutionId+" updated into database");
			if (this.Config.DepartmentsNotUpdated>=1) WriteStringLineToLogFile("- "+this.Config.DepartmentsNotUpdated+" departments for "+institutionId+" not updated into database");
			if (this.Config.DepartmentsIgnored>=1) WriteStringLineToLogFile("- "+this.Config.EmploymentsIgnored+" departments for "+institutionId+" were up-to-date"); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- Some departments etc. for "+institutionId+" not updated into database"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- Some departments etc. for "+institutionId+" not updated into database"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <summary>Updates entities in <paramref name="entity"/> into database</summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdateEmploymentsChanged(GetEmploymentChanged20111201 entity) { string institutionId=entity.GetEmploymentChangedRequestStructure.InstitutionIdentifier; try { if (entity.Persons.Count<1) return false;
			foreach (WsPerson item in entity.Persons) { foreach (WsEmployment empl in item.WsEmployments) { empl.InstitutionIdentifier=institutionId; empl.Employee=item.PersonCivilRegistrationIdentifier;
				EmploymentProfession prof=empl.ToEmploymentProfession(); UpdateEmploymentProfession(ref prof,true); EmploymentStatus status=empl.ToEmploymentStatus(); UpdateEmploymentStatus(ref status,empl.EmploymentIdentifier,true);
				SalaryAgreement agree=empl.ToSalaryAgreement(); UpdateSalaryAgreement(ref agree,empl.EmploymentIdentifier,true); SalaryCodeGroup group=empl.ToSalaryCodeGroup(); UpdateSalaryCodeGroup(ref group,empl.EmploymentIdentifier,true);
				WorkingTime time=empl.ToWorkingTime(); UpdateWorkingTime(ref time,empl.EmploymentIdentifier,true); Employment tempEmpl=empl.ToEmployment(); UpdateEmployment(ref tempEmpl,true); } }
			WriteStringLineToLogFile("- "+this.Config.EmploymentsUpdated+" employments etc. for "+institutionId+" updated into database"); if (this.Config.EmploymentsNotUpdated>=1) WriteStringLineToLogFile(
				"- "+this.Config.EmploymentsNotUpdated+" employments etc. for "+institutionId+" not updated into database"); if (this.Config.EmploymentsIgnored>=1) WriteStringLineToLogFile(
				"- "+this.Config.EmploymentsIgnored+" employments etc. for "+institutionId+" were up-to-date"); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- Some employments etc. for "+institutionId+" not updated into database"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- Some employments etc. for "+institutionId+" not updated into database"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <summary>Updates entities in <paramref name="entity"/> into database</summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdateEmploymentsChangedAtDate(GetEmploymentChangedAtDate20111201 entity) { string institutionId=entity.GetEmploymentChangedAtDateRequestStructure.InstitutionIdentifier; try { if (entity.Persons.Count<1)
			return false; foreach (WsPerson item in entity.Persons) { foreach (WsEmployment empl in item.WsEmployments) { empl.InstitutionIdentifier=institutionId; empl.Employee=item.PersonCivilRegistrationIdentifier; 
				EmploymentProfession prof=empl.ToEmploymentProfession(); UpdateEmploymentProfession(ref prof,true); EmploymentStatus status=empl.ToEmploymentStatus(); UpdateEmploymentStatus(ref status,empl.EmploymentIdentifier,true);
				SalaryAgreement agree=empl.ToSalaryAgreement(); UpdateSalaryAgreement(ref agree,empl.EmploymentIdentifier,true); SalaryCodeGroup group=empl.ToSalaryCodeGroup(); UpdateSalaryCodeGroup(ref group,empl.EmploymentIdentifier,true);
				WorkingTime time=empl.ToWorkingTime(); UpdateWorkingTime(ref time,empl.EmploymentIdentifier,true); Employment tempEmpl=empl.ToEmployment(); UpdateEmployment(ref tempEmpl,true); } }
			WriteStringLineToLogFile("- "+this.Config.EmploymentsUpdated+" employments etc. for "+institutionId+" updated into database"); if (this.Config.EmploymentsNotUpdated>=1) WriteStringLineToLogFile(
				"- "+this.Config.EmploymentsNotUpdated+" employments etc. for "+institutionId+" not updated into database"); if (this.Config.EmploymentsIgnored>=1) WriteStringLineToLogFile(
				"- "+this.Config.EmploymentsIgnored+" employments etc. for "+institutionId+" were up-to-date"); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- Some employments etc. for "+institutionId+" not updated into database"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- Some employments etc. for "+institutionId+" not updated into database"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <summary>Updates entities in <paramref name="entity"/> into database</summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdateInstitutions(GetInstitution20111201 entity) { if (entity.Region.Institutions.Count<1) return false; try { foreach (WsInstitution item in entity.Region.Institutions) {
			Institution inst=item.ToInstitution(); UpdateInstitution(ref inst,true); } WriteStringLineToLogFile("- "+this.Config.InstitutionsUpdated+" institutions updated into database");
			if (this.Config.EmploymentsNotUpdated>=1) WriteStringLineToLogFile("- "+this.Config.InstitutionsNotUpdated+" institutions not updated into database");
			if (this.Config.InstitutionsIgnored>=1) WriteStringLineToLogFile("- "+this.Config.InstitutionsIgnored+" institutions were up-to-date"); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- Some institutions not updated into database"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- Some institutions not added updated into database"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <summary>Updates entities in <paramref name="entity"/> into database</summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdatePersonsChangedAtDate(GetPersonChangedAtDate20111201 entity) { string institutionId=entity.GetPersonChangedAtDateRequestStructure.InstitutionIdentifier; try { if (entity.Persons.Count<1) return false;
			foreach (WsPerson item in entity.Persons) { item.InstitutionIdentifier=institutionId; if (item.ContactInformation!=null) { ContactInformation info=item.ToContactInformation();
				UpdateContactInformation(ref info,institutionId,true); } if (item.PostalAddress!=null) { PostalAddress addr=item.ToPostalAddress(); UpdatePostalAddress(ref addr,institutionId,true); }
				Person pers=item.ToPerson(); UpdatePerson(ref pers,true); } WriteStringLineToLogFile("- "+this.Config.PersonsUpdated+" persons for "+institutionId+" updated into database");
			if (this.Config.PersonsNotUpdated<=1) WriteStringLineToLogFile("- "+this.Config.PersonsNotUpdated+" persons for "+institutionId+" not updated into database");
			if (this.Config.InstitutionsIgnored>=1) WriteStringLineToLogFile("- "+this.Config.PersonsIgnored+" persons for "+institutionId+" were up-to-date"); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- Some persons for "+institutionId+" not updated into database"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- Some persons not updated into database"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <summary>Updates entities in <paramref name="entity"/> into database</summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdateProfessions(GetProfession20080201 entity) { string institutionId=entity.RequestKey.InstitutionIdentifier; try { if (entity.Professions.Count<1) return false;
			foreach (WsProfession item in entity.Professions) { item.InstitutionIdentifier=institutionId; Profession prof=item.ToProfession(); UpdateProfession(ref prof,true); }
			WriteStringLineToLogFile("- "+this.Config.ProfessionsUpdated+" professions for "+institutionId+" updated into database");
			if (this.Config.ProfessionsNotUpdated<=1) WriteStringLineToLogFile("- "+this.Config.ProfessionsNotUpdated+" professions for "+institutionId+" not updated into database");
			if (this.Config.ProfessionsIgnored>=1) WriteStringLineToLogFile("- "+this.Config.ProfessionsIgnored+" professions for "+institutionId+" were up-to-date"); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- Some professions for "+institutionId+" not updated into database"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- Some professions for "+institutionId+" not updated into database"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	#endregion

	#region Update Entity

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateContactInformation(ref ContactInformation entity,string parent="",bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=UpdateContactInformationNoCheck(ref entity,parent);
		Dictionary<string,ContactInformation> dict=GetContactInformationDict(); if (dict.ContainsKey(entity.TKey)) { if (dict[entity.TKey].Equals(entity)) { this.Config.ContactInformationsIgnored++; return true; }
			else { ContactInformation oldEntity=dict[entity.TKey]; if (UpdateContactInformation(ref oldEntity,ref entity,parent,updateInDatabase)) { entity=oldEntity; return true; } else return false; } } else if (updateInDatabase) {
				if (UpdateOrCreateInDatabase(entity)) {  entity=RetrieveContactInformation(entity); this.Config.ContactInformationsUpdated++; return true; } else { this.Config.ContactInformationsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateContactInformation(ref ContactInformation oldEntity,ref ContactInformation newEntity,string parent="",bool updateInDatabase=false) {
		if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) return false; if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; }
		if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) return false; if (oldEntity.Equals(newEntity)) return false; bool updateFlag=UpdateContactInformationNoCheck(ref oldEntity,parent); 
		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if (!newEntity.TelephoneNumberIdentifier1.IsNullOrWhiteSpace()&&!newEntity.TelephoneNumberIdentifier1.Equals("00000000")&&!oldEntity.TelephoneNumberIdentifier1.Equals(newEntity.TelephoneNumberIdentifier1)) { oldEntity.TelephoneNumberIdentifier1=newEntity.TelephoneNumberIdentifier1; if (!updateFlag) updateFlag=true; }
			if (!newEntity.TelephoneNumberIdentifier2.IsNullOrWhiteSpace()&&!newEntity.TelephoneNumberIdentifier2.Equals("00000000")&&!oldEntity.TelephoneNumberIdentifier2.Equals(newEntity.TelephoneNumberIdentifier2)) { oldEntity.TelephoneNumberIdentifier2=newEntity.TelephoneNumberIdentifier2; if (!updateFlag) updateFlag=true; }
			if (!newEntity.EmailAddressIdentifier1.IsNullOrWhiteSpace()&&!newEntity.EmailAddressIdentifier1.Equals("Empty@Empty.Com")&&!oldEntity.EmailAddressIdentifier1.Equals(newEntity.EmailAddressIdentifier1)) { oldEntity.EmailAddressIdentifier1=newEntity.EmailAddressIdentifier1; if (!updateFlag) updateFlag=true; }
			if (!newEntity.EmailAddressIdentifier2.IsNullOrWhiteSpace()&&!newEntity.EmailAddressIdentifier2.Equals("Empty@Empty.Com")&&!oldEntity.EmailAddressIdentifier2.Equals(newEntity.EmailAddressIdentifier2)) { oldEntity.EmailAddressIdentifier2=newEntity.EmailAddressIdentifier2; if (!updateFlag) updateFlag=true; }
			if (oldEntity.IsUpdated()) oldEntity.Validate(); }
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrieveContactInformation(oldEntity); this.Config.ContactInformationsUpdated++; return true; }
			else { this.Config.ContactInformationsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><returns>Result as bool</returns>
	private bool UpdateContactInformationNoCheck(ref ContactInformation entity,string parent="") { if (!parent.IsNullOrWhiteSpace()&&entity.ParentIdentifier.IsNullOrWhiteSpace())
			entity.ParentIdentifier=parent; if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) { RetrieveContactInformationId(entity); if (!updateFlag&entity.Id>=1) updateFlag=true; } 
		if (CheckCioPhoneNumbers(ref entity)&&!updateFlag) updateFlag=true;  if (CheckCioEmailAdresses(ref entity)&&!updateFlag) updateFlag=true; if (entity.IsUpdated()) { entity.Validate();
			if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="institutionId" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateDepartment(ref Department entity,string institutionId,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=UpdateDepartmentNoCheck(ref entity,institutionId);
		Dictionary<string,Department> dict=GetDepartmentDict(); if (dict.ContainsKey(entity.TKey)) { if (dict[entity.TKey].Equals(entity)) { this.Config.ContactInformationsIgnored++; return true; } else { Department oldEntity=
			dict[entity.TKey]; if (UpdateDepartment(ref oldEntity,ref entity,institutionId,updateInDatabase)) { entity=oldEntity; return true; } else return false; } } else if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) {
				entity=RetrieveDepartment(entity); this.Config.DepartmentsUpdated++; return true; } else { this.Config.DepartmentsNotUpdated++; return false; } } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="institutionId" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateDepartment(ref Department oldEntity,ref Department newEntity,string institutionId,bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) return false; 
		if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; } if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) return false;
		if (oldEntity.Equals(newEntity)) return false; bool updateFlag=UpdateDepartmentNoCheck(ref oldEntity,institutionId);
		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if (!newEntity.ActivationDate.Equals(DateOnly.Parse("2010-01-01"))&&(Convert.ToDateTime(oldEntity.ActivationDate)<Convert.ToDateTime(newEntity.ActivationDate)||
				oldEntity.ActivationDate.Equals(DateOnly.Parse("2010-01-01")))) { oldEntity.ActivationDate=newEntity.ActivationDate; if (!updateFlag) updateFlag=true; }
			if (!newEntity.DeactivationDate.Equals(DateOnly.Parse("9999-12-31"))&&(Convert.ToDateTime(oldEntity.DeactivationDate)<Convert.ToDateTime(newEntity.DeactivationDate)||
				oldEntity.DeactivationDate.Equals(DateOnly.Parse("9999-12-31")))) { oldEntity.DeactivationDate=newEntity.DeactivationDate; if (!updateFlag) updateFlag=true; }
			if (!newEntity.DepartmentUuidIdentifier.IsNullOrWhiteSpace()&&!newEntity.DepartmentUuidIdentifier.Equals("00000000-0000-0000-0000-000000000000")&&
				!oldEntity.DepartmentUuidIdentifier.Equals(newEntity.DepartmentUuidIdentifier)) { oldEntity.DepartmentUuidIdentifier=newEntity.DepartmentUuidIdentifier; if (!updateFlag) updateFlag=true; }
			if (!newEntity.DepartmentIdentifier.IsNullOrWhiteSpace()&&!newEntity.DepartmentIdentifier.Equals("0NONE")&&!oldEntity.DepartmentIdentifier.Equals(newEntity.DepartmentIdentifier)) { 
				oldEntity.DepartmentIdentifier=newEntity.DepartmentIdentifier; if (!updateFlag) updateFlag=true; }
			if (!newEntity.DepartmentLevelIdentifier.IsNullOrWhiteSpace()&&!newEntity.DepartmentLevelIdentifier.Equals("NY0-niveau")&&!oldEntity.DepartmentLevelIdentifier.Equals(
				newEntity.DepartmentLevelIdentifier)) { oldEntity.DepartmentLevelIdentifier=newEntity.DepartmentLevelIdentifier; if (!updateFlag) updateFlag=true; }
			if (!newEntity.DepartmentName.IsNullOrWhiteSpace()&&!newEntity.DepartmentName.Equals("None")&&!oldEntity.DepartmentName.Equals(newEntity.DepartmentName)) { 
				oldEntity.DepartmentName=newEntity.DepartmentName; if (!updateFlag) updateFlag=true; }
			if (!newEntity.ProductionUnitIdentifier.IsNullOrWhiteSpace()&&!newEntity.ProductionUnitIdentifier.Equals("1000000000")&&!oldEntity.ProductionUnitIdentifier.Equals(
				newEntity.ProductionUnitIdentifier)) { oldEntity.ProductionUnitIdentifier=newEntity.ProductionUnitIdentifier; if (!updateFlag) updateFlag=true; }
			if (!newEntity.InstitutionIdentifier.Equals("NO")&&!oldEntity.InstitutionIdentifier.Equals(newEntity.InstitutionIdentifier)) { oldEntity.InstitutionIdentifier=newEntity.InstitutionIdentifier;
				if (!updateFlag) updateFlag=true; } }
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrieveDepartment(oldEntity); this.Config.DepartmentsUpdated++; return true; }
			else { this.Config.DepartmentsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="institutionId" /><returns>Result as bool</returns>
	private bool UpdateDepartmentNoCheck(ref Department entity,string institutionId) { if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) { RetrieveDepartmentId(entity); if (!updateFlag&entity.Id>=1) updateFlag=true; }
		if (entity.InstitutionIdentifier.IsNullOrWhiteSpace()||entity.InstitutionIdentifier.Equals("NO")) { entity.InstitutionIdentifier=institutionId; if (!entity.InstitutionIdentifier.Equals("NO")&&!updateFlag) updateFlag=true; }
		if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateDepartmentLevelReference(ref DepartmentLevelReference entity,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=UpdateDepartmentLevelReferenceNoCheck(ref entity);
		Dictionary<string,DepartmentLevelReference> dict=GetDepartmentLevelReferenceDict(); if (dict.ContainsKey(entity.TKey)) { if (dict[entity.TKey].Equals(entity)) { this.Config.DepartmentLevelReferencesIgnored++;
			return true; } else { DepartmentLevelReference oldEntity=dict[entity.TKey]; if (UpdateDepartmentLevelReference(ref oldEntity,ref entity,updateInDatabase)) { entity=oldEntity; return true; }  else return false; } }
		else if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { entity=RetrieveDepartmentLevelReference(entity); this.Config.DepartmentLevelReferencesUpdated++; return true; } 
		else { this.Config.DepartmentLevelReferencesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateDepartmentLevelReference(ref DepartmentLevelReference oldEntity,ref DepartmentLevelReference newEntity,bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&!newEntity.IsEmpty()&&oldEntity.Equals(newEntity)) { oldEntity=new(oldEntity); return true; }
			else if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) { oldEntity=new(oldEntity); return true; } else if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; }
			else if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) { oldEntity=new(); return true; } bool updateFlag=UpdateDepartmentLevelReferenceNoCheck(ref oldEntity);
		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
		if (!newEntity.DepartmentLevelIdentifier.IsNullOrWhiteSpace()&&!newEntity.DepartmentLevelIdentifier.Equals("NY0-niveau")&&!oldEntity.DepartmentLevelIdentifier.Equals(newEntity.DepartmentLevelIdentifier))
			{ oldEntity.DepartmentLevelIdentifier=newEntity.DepartmentLevelIdentifier; if (!updateFlag) updateFlag=true; }
		if (!newEntity.OrganizationStructure.IsNullOrWhiteSpace()&&Config.CheckInstitutionIdentifier(newEntity.OrganizationStructure)&&!oldEntity.OrganizationStructure.Equals(newEntity.OrganizationStructure)) { oldEntity.OrganizationStructure=oldEntity.OrganizationStructure; if (!updateFlag) updateFlag=true; }
		if (!newEntity.SeniorDepartmentLevelReference.IsNullOrWhiteSpace()&&!newEntity.SeniorDepartmentLevelReference.Equals("00000000-0000-0000-0000-000000000000")&&!oldEntity.SeniorDepartmentLevelReference.Equals(
			newEntity.SeniorDepartmentLevelReference)) { oldEntity.SeniorDepartmentLevelReference=newEntity.SeniorDepartmentLevelReference; if (!updateFlag) updateFlag=true; } } 
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrieveDepartmentLevelReference(oldEntity); this.Config.DepartmentLevelReferencesUpdated++; return true; }
			else { this.Config.DepartmentLevelReferencesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdateDepartmentLevelReferenceNoCheck(ref DepartmentLevelReference entity) { if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) entity.Id=RetrieveDepartmentLevelReferenceId(entity); 
		if (entity.SeniorDepartmentLevelReference!=null&&(entity.SeniorDepartmentLevelReference).IsNullOrWhiteSpace()&&entity.SeniorDepartmentLevelReference.Equals(
			"00000000-0000-0000-0000-000000000000")) { entity.SeniorDepartmentLevelReference=string.Empty; if (!updateFlag) updateFlag=true; } if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateDepartmentReference(ref DepartmentReference entity,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=UpdateDepartmentReferenceNoCheck(ref entity);
		Dictionary<string,DepartmentReference> dict=GetDepartmentReferenceDict(); if (dict.ContainsKey(entity.TKey)) {  if (dict[entity.TKey].Equals(entity)) { this.Config.DepartmentReferencesIgnored++; return true; }
			else { DepartmentReference oldEntity=dict[entity.TKey]; if (UpdateDepartmentReference(ref oldEntity,ref entity,updateInDatabase)) { entity=oldEntity; return true; } else return false; } }
		else if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { entity=RetrieveDepartmentReference(entity); this.Config.DepartmentReferencesUpdated++; return true; }
		else { this.Config.DepartmentReferencesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateDepartmentReference(ref DepartmentReference oldEntity,ref DepartmentReference newEntity,bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&!newEntity.IsEmpty()&&oldEntity.Equals(newEntity)) { return true; }
		else if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } else if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; }
		else if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } else oldEntity=new(oldEntity); bool updateFlag=UpdateDepartmentReferenceNoCheck(ref oldEntity);
		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if ((newEntity.DepartmentLevelIdentifier).IsNullOrWhiteSpace()&&newEntity.DepartmentLevelIdentifier.Equals("NY0-niveau")&&!oldEntity.DepartmentLevelIdentifier.Equals(newEntity.DepartmentLevelIdentifier)) {
				oldEntity.DepartmentLevelIdentifier=newEntity.DepartmentLevelIdentifier; if (!updateFlag) updateFlag=true; }
			if (Config.CheckInstitutionIdentifier(newEntity.Organization)&&!newEntity.SeniorDepartmentReference.Equals("00000000-0000-0000-0000-000000000000")&&!oldEntity.Organization.Equals(newEntity.Organization)) {
				oldEntity.Organization=newEntity.Organization; if (!updateFlag) updateFlag=true; }
			if ((newEntity.SeniorDepartmentReference).IsNullOrWhiteSpace()&&!oldEntity.SeniorDepartmentReference.Equals(newEntity.SeniorDepartmentReference)) { oldEntity.SeniorDepartmentReference=
					newEntity.SeniorDepartmentReference; if (!updateFlag) updateFlag=true; } }
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrieveDepartmentReference(oldEntity); this.Config.DepartmentReferencesUpdated++; return true; }
			else { this.Config.DepartmentReferencesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdateDepartmentReferenceNoCheck(ref DepartmentReference entity) { if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) { entity.Id=RetrieveDepartmentReferenceId(entity);
			if (!updateFlag&&entity.Id>=1) updateFlag=true; } if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateEmployment(ref Employment entity,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=UpdateEmploymentNoCheck(ref entity); Dictionary<string,Employment> dict=
		GetEmploymentDict(); if (dict.ContainsKey(entity.TKey)) { if (dict[entity.TKey].Equals(entity)) { this.Config.EmploymentsIgnored++; return true; } else { Employment oldEntity=dict[entity.TKey];
			if (UpdateEmployment(ref oldEntity,ref entity,updateInDatabase)) { entity=oldEntity; return true; } else return false; } } else if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) {
				entity=RetrieveEmployment(entity); this.Config.EmploymentsUpdated++; return true; } else { this.Config.EmploymentsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateEmployment(ref Employment oldEntity,ref Employment newEntity,bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) return false; 
		if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; } if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) return false; 
		if (oldEntity.Equals(newEntity)) return false; bool updateFlag=UpdateEmploymentNoCheck(ref oldEntity);
		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if ((newEntity.EmploymentIdentifier).IsNullOrWhiteSpace()&&newEntity.EmploymentIdentifier.Equals("00000")&&!oldEntity.EmploymentIdentifier.Equals(
				newEntity.EmploymentIdentifier)) { oldEntity.EmploymentIdentifier=newEntity.EmploymentIdentifier; if (!updateFlag) updateFlag=true; }
			if (!newEntity.EmploymentDate.Equals(DateOnly.Parse("2010-01-01"))&&(Convert.ToDateTime(oldEntity.EmploymentDate)<Convert.ToDateTime(newEntity.EmploymentDate)||
				oldEntity.EmploymentDate.Equals(DateOnly.Parse("2010-01-01")))) { oldEntity.EmploymentDate=newEntity.EmploymentDate; if (!updateFlag) updateFlag=true; }
			if (newEntity.AnniversaryDate.Equals(DateOnly.Parse("2010-01-01"))&&(Convert.ToDateTime(oldEntity.AnniversaryDate)<Convert.ToDateTime(newEntity.AnniversaryDate)||
				oldEntity.AnniversaryDate.Equals(DateOnly.Parse("2010-01-01")))) { oldEntity.AnniversaryDate=newEntity.AnniversaryDate; if (!updateFlag) updateFlag=true; }
			if ((newEntity.InstitutionIdentifier).IsNullOrWhiteSpace()&&!oldEntity.InstitutionIdentifier.Equals(newEntity.InstitutionIdentifier)) { oldEntity.InstitutionIdentifier=newEntity.InstitutionIdentifier; if (!updateFlag) updateFlag=true; }
			if ((newEntity.Employee).IsNullOrWhiteSpace()&&!oldEntity.Employee.Equals(newEntity.Employee)) { oldEntity.Employee=newEntity.Employee; if (!updateFlag) updateFlag=true; }
			if ((newEntity.EmploymentDepartment).IsNullOrWhiteSpace()&&!oldEntity.EmploymentDepartment.Equals(newEntity.EmploymentDepartment)) { oldEntity.EmploymentDepartment=
				newEntity.EmploymentDepartment; if (!updateFlag) updateFlag=true; } if ((newEntity.EmploymentProfession).IsNullOrWhiteSpace()&&!oldEntity.EmploymentProfession.Equals(newEntity.EmploymentProfession)) { 
					oldEntity.EmploymentProfession=newEntity.EmploymentProfession; if (!updateFlag) updateFlag=true; } }
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrieveEmployment(oldEntity); this.Config.EmploymentsUpdated++; return true; }
			else { this.Config.EmploymentsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdateEmploymentNoCheck(ref Employment entity) { if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) { entity.Id=RetrieveEmploymentId(entity);
		if (!updateFlag&&entity.Id>=1) updateFlag=true; } if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateEmploymentProfession(ref EmploymentProfession entity,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=UpdateEmploymentProfessionNoCheck(ref entity);
		Dictionary<string,EmploymentProfession> dict=GetEmploymentProfessionDict(); if (dict.ContainsKey(entity.TKey)) { if (dict[entity.TKey].Equals(entity)) { this.Config.EmploymentProfessionsIgnored++; return true; }
			else { EmploymentProfession oldEntity=dict[entity.TKey]; if (UpdateEmploymentProfession(ref oldEntity,ref entity,updateInDatabase)) { entity=oldEntity; return true; } else return false; } }
		else if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { entity=RetrieveEmploymentProfession(entity); this.Config.EmploymentProfessionsUpdated++; return true; }
			else { this.Config.EmploymentProfessionsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateEmploymentProfession(ref EmploymentProfession oldEntity,ref EmploymentProfession newEntity,bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&!newEntity.IsEmpty()&&oldEntity.Equals(newEntity)) return true;
		else if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) return true; else if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; }
		else if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) return true; bool updateFlag=UpdateEmploymentProfessionNoCheck(ref oldEntity);
		if (!oldEntity.Equals(newEntity)) { 
			if ((newEntity.EmploymentName).IsNullOrWhiteSpace()&&newEntity.EmploymentName.Equals("None")&&!oldEntity.EmploymentName.Equals(newEntity.EmploymentName)) { oldEntity.EmploymentName=newEntity.EmploymentName;
				if (!updateFlag) updateFlag=true; } if ((newEntity.AppointmentCode).IsNullOrWhiteSpace()&&newEntity.AppointmentCode.Equals("0")&&!oldEntity.AppointmentCode.Equals(newEntity.AppointmentCode)) { 
				oldEntity.AppointmentCode=newEntity.AppointmentCode; if (!updateFlag) updateFlag=true; } if (oldEntity.IsUpdated()) oldEntity.Validate(); }
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrieveEmploymentProfession(oldEntity); this.Config.EmploymentProfessionsUpdated++; return true; }
			else { this.Config.EmploymentProfessionsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdateEmploymentProfessionNoCheck(ref EmploymentProfession entity) { if (entity.IsEmpty()) return false; bool updateFlag=false;
		if (entity.Id<1) { entity.Id=RetrieveEmploymentProfessionId(entity); if (!updateFlag&&entity.Id>=1) updateFlag=true; } if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateEmploymentStatus(ref EmploymentStatus entity,string parent="",bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=UpdateEmploymentStatusNoCheck(ref entity,parent);
		Dictionary<string,EmploymentStatus> dict=GetEmploymentStatusDict(); if (dict.ContainsKey(entity.TKey)) { if (dict[entity.TKey].Equals(entity)) { this.Config.EmploymentsIgnored++; return true; }
			else { EmploymentStatus oldEntity=dict[entity.TKey]; if (UpdateEmploymentStatus(ref oldEntity,ref entity,parent,updateInDatabase)) { entity=oldEntity; return true; } else return false; } }
		else if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { entity=RetrieveEmploymentStatus(entity); this.Config.EmploymentStatusesUpdated++; return true; }
		else { this.Config.EmploymentStatusesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateEmploymentStatus(ref EmploymentStatus oldEntity,ref EmploymentStatus newEntity,string parent="",bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) return false;
		if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; } if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) return false;
		if (oldEntity.Equals(newEntity)) return false; bool updateFlag=UpdateEmploymentStatusNoCheck(ref oldEntity,parent);
		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if (!newEntity.ActivationDate.Equals(DateTime.Parse("2010-01-01"))&&(oldEntity.ActivationDate<newEntity.ActivationDate||oldEntity.ActivationDate.Equals(DateTime.Parse("2010-01-01")))) { 
				oldEntity.ActivationDate=newEntity.ActivationDate; if (!updateFlag) updateFlag=true; }
			if (!newEntity.DeactivationDate.Equals(DateTime.Parse("9999-12-31"))&&(oldEntity.DeactivationDate<newEntity.DeactivationDate||oldEntity.DeactivationDate.Equals(DateTime.Parse("9999-12-31")))) { 
				oldEntity.DeactivationDate=newEntity.DeactivationDate; if (!updateFlag) updateFlag=true; }
			if ((newEntity.EmploymentStatusCode).IsNullOrWhiteSpace()&&newEntity.EmploymentStatusCode.Equals("0")&&!oldEntity.EmploymentStatusCode.Equals(newEntity.EmploymentStatusCode)) { 
				oldEntity.EmploymentStatusCode=newEntity.EmploymentStatusCode; if (!updateFlag) updateFlag=true; }
			if (!oldEntity.MarkedForDeletion.Equals(newEntity.MarkedForDeletion)) { oldEntity.MarkedForDeletion=newEntity.MarkedForDeletion; if (!updateFlag) updateFlag=true; } }
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrieveEmploymentStatus(oldEntity); this.Config.EmploymentStatusesUpdated++; return true; }
			else { this.Config.EmploymentStatusesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><returns>Result as bool</returns>
	private bool UpdateEmploymentStatusNoCheck(ref EmploymentStatus entity,string parent="") { if (parent.IsNullOrWhiteSpace()&&entity.EmploymentIdentifier.IsNullOrWhiteSpace()) entity.EmploymentIdentifier=parent;
		if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) { RetrieveEmploymentStatusId(entity); if (!updateFlag&entity.Id>=1) updateFlag=true; }
		if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateInstitution(ref Institution entity,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=UpdateInstitutionNoCheck(ref entity); Dictionary<string,Institution> dict=
		GetInstitutionDict(); if (dict.ContainsKey(entity.TKey)) { if (dict[entity.TKey].Equals(entity)) { this.Config.EmploymentsIgnored++; return true; } else { Institution oldEntity=dict[entity.TKey];
			if (UpdateInstitution(ref oldEntity,ref entity,updateInDatabase)) { entity=oldEntity; return true; } else return false; } } else if (updateInDatabase) { if (Config.CheckInstitutionIdentifier(entity.InstitutionIdentifier)&&
				UpdateOrCreateInDatabase(entity)) { entity=RetrieveInstitution(entity); this.Config.InstitutionsUpdated++; return true; } else { this.Config.InstitutionsNotUpdated++; return false; } } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateInstitution(ref Institution oldEntity,ref Institution newEntity,bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&!newEntity.IsEmpty()&&oldEntity.Equals(newEntity)) { return true; }
			else if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } else if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; }
			else if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } bool updateFlag=UpdateInstitutionNoCheck(ref oldEntity);
		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if ((newEntity.InstitutionUuidIdentifier).IsNullOrWhiteSpace()&&newEntity.InstitutionUuidIdentifier.Equals("00000000-0000-0000-0000-000000000000")&&
				!newEntity.InstitutionUuidIdentifier.Equals(newEntity.InstitutionUuidIdentifier)) { oldEntity.InstitutionUuidIdentifier=newEntity.InstitutionUuidIdentifier; if (!updateFlag) updateFlag=true; }
			if (!newEntity.InstitutionIdentifier.IsNullOrWhiteSpace()&&!newEntity.InstitutionIdentifier.Equals("NO")&&!oldEntity.InstitutionIdentifier.Equals(newEntity.InstitutionIdentifier)) {
				oldEntity.InstitutionIdentifier=newEntity.InstitutionIdentifier; if (!updateFlag) updateFlag=true; }
			if ((newEntity.InstitutionName).IsNullOrWhiteSpace()&&newEntity.InstitutionName.Equals("None")&&newEntity.InstitutionName!=newEntity.InstitutionName) { oldEntity.InstitutionName=newEntity.InstitutionName; if (!updateFlag) updateFlag=true; } }
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrieveInstitution(oldEntity); this.Config.InstitutionsUpdated++; return true; }
			else { this.Config.InstitutionsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdateInstitutionNoCheck(ref Institution entity) { if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) { RetrieveInstitutionId(entity); if (!updateFlag&entity.Id>=1) updateFlag=true; }
		if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="institutionId" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateOrganization(ref Organization entity,string institutionId,bool updateInDatabase=false) { if (!Config.CheckInstitutionIdentifier(institutionId)) return false; if (entity.InstitutionIdentifier.Equals("NO"))
			entity.InstitutionIdentifier=institutionId; if (entity.IsEmpty()) return false; bool updateFlag=UpdateOrganizationNoCheck(ref entity); Dictionary<string,Organization> dict=GetOrganizationDict();
		if (dict.ContainsKey(entity.TKey)) {  if (dict[entity.TKey].Equals(entity)) { this.Config.OrganizationsIgnored++; return true; } else { Organization org=dict[entity.TKey];
			if (UpdateOrganization(ref org,ref entity,updateInDatabase)) { entity=org; return true; } else return false; } } else if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) {
				entity=RetrieveOrganization(entity); this.Config.OrganizationsUpdated++; return true; } else {this.Config.OrganizationsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateOrganization(ref Organization oldEntity,ref Organization newEntity,bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&!newEntity.IsEmpty()&&oldEntity.Equals(newEntity)) { return true; }
		else if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } else if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; }
		else if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } bool updateFlag=UpdateOrganizationNoCheck(ref oldEntity);
		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if (!newEntity.ActivationDate.Equals(DateTime.Parse("2010-01-01"))&&(oldEntity.ActivationDate<newEntity.ActivationDate|| oldEntity.ActivationDate.Equals(DateTime.Parse("2010-01-01")))) { 
				oldEntity.ActivationDate=newEntity.ActivationDate; if (!updateFlag) updateFlag=true; }
			if (!newEntity.DeactivationDate.Equals(DateTime.Parse("9999-12-31"))&&(oldEntity.DeactivationDate<newEntity.DeactivationDate||oldEntity.DeactivationDate.Equals(DateTime.Parse("9999-12-31")))) { 
				oldEntity.DeactivationDate=newEntity.DeactivationDate; if (!updateFlag) updateFlag=true; }
			if (Config.CheckInstitutionIdentifier(newEntity.InstitutionIdentifier)&&!oldEntity.InstitutionIdentifier.Equals(newEntity.InstitutionIdentifier)) { oldEntity.InstitutionIdentifier=newEntity.InstitutionIdentifier;
				if (!updateFlag) updateFlag=true; } if (oldEntity.IsUpdated()) oldEntity.Validate(); }
	if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrieveOrganization(oldEntity); this.Config.OrganizationsUpdated++; return true; }
			else { this.Config.OrganizationsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates Organization and DepartmentReferences</summary><param name="entity" /><param name="institutionId" /><returns>Result as bool</returns>
	private bool UpdateOrganization(WsOrganization entity,string institutionId) { try { if (entity.WsDepartmentReferences.Count<1) foreach (WsDepartmentReference item in entity.WsDepartmentReferences)
			AddOrganizationToDepartmentReferencesUpdate(item,entity.InstitutionIdentifier); Organization org=entity.ToOrganization(); UpdateOrganization(ref org,institutionId,true);
			WriteStringLineToLogFile("- "+this.Config.OrganizationsUpdated+" organizations etc. updated into database");
			if (this.Config.OrganizationsNotUpdated>=1) WriteStringLineToLogFile("- "+this.Config.OrganizationsNotUpdated+" organizations etc. not updated into database");
			if (this.Config.OrganizationsIgnored>=1) WriteStringLineToLogFile("- "+this.Config.OrganizationsIgnored+" organizations etc. were up-to-date"); return true; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- Some organizations etc. not updated into database"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- Some organizations etc. not added updated into database"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdateOrganizationNoCheck(ref Organization entity) { bool active=entity.Active; bool updateFlag=false; if (entity.IsEmpty()) return false;
		if (entity.Id<1) { entity.Id=RetrieveOrganizationId(entity); if (entity.Id>=1&&!updateFlag) updateFlag=true; } if (!entity.Active.Equals(active)&&!updateFlag) updateFlag=true;
		if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="institutionId" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateOrganizationStructure(ref OrganizationStructure entity,string institutionId,bool updateInDatabase=false) { if (!Config.CheckInstitutionIdentifier(institutionId)) return false;
		if (entity.InstitutionIdentifier.Equals("NO")) entity.InstitutionIdentifier=institutionId; if (entity.IsEmpty()) return false; bool updateFlag=UpdateOrganizationStructureNoCheck(ref entity);
		Dictionary<string,OrganizationStructure> dict=GetOrganizationStructureDict(); if (dict.ContainsKey(entity.TKey)) { if (dict[entity.TKey].Equals(entity)) { this.Config.OrganizationStructuresIgnored++; return true; }
			else { OrganizationStructure tempEntity=dict[entity.TKey]; if (UpdateOrganizationStructure(ref tempEntity,ref entity,updateInDatabase)) { entity=tempEntity; return true; } else return false; } }
		else if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { entity=RetrieveOrganizationStructure(entity); this.Config.OrganizationStructuresUpdated++; return true; }
			else { this.Config.OrganizationStructuresNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateOrganizationStructure(ref OrganizationStructure oldEntity,ref OrganizationStructure newEntity,bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&!newEntity.IsEmpty()&&oldEntity.Equals(newEntity)) return true;
			else if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) return true; else if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; }
			else if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) return true; bool updateFlag=UpdateOrganizationStructureNoCheck(ref oldEntity);
		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if ((newEntity.InstitutionIdentifier).IsNullOrWhiteSpace()&&newEntity.InstitutionIdentifier.Equals("NO")&&
				!oldEntity.InstitutionIdentifier.Equals(newEntity.InstitutionIdentifier)) { oldEntity.InstitutionIdentifier=newEntity.InstitutionIdentifier; if (!updateFlag) updateFlag=true; } }
	if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrieveOrganizationStructure(oldEntity); this.Config.OrganizationStructuresUpdated++; return true; }
			else { this.Config.OrganizationStructuresNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates Organization and DepartmentReferences</summary><param name="entity" /><param name="institutionId" /><returns>Result as bool</returns>
	private bool UpdateOrganizationStructure(WsOrganizationStructure entity,string institutionId) { try { if (entity.WsDepartmentLevelReferences.Count<1) foreach (WsDepartmentLevelReference item in entity.WsDepartmentLevelReferences)
			AddOrganizationStructureToDepartmentLevelReferencesUpdate(item,entity.InstitutionIdentifier); OrganizationStructure structure=entity.ToOrganizationStructure(); UpdateOrganizationStructure(ref structure,institutionId,true);
			WriteStringLineToLogFile("- "+this.Config.OrganizationStructuresUpdated+" organization structures etc. updated into database");
			if (this.Config.OrganizationStructuresNotUpdated>=1) WriteStringLineToLogFile("- "+this.Config.OrganizationsNotUpdated+" organization structures etc. not updated into database");
			if (this.Config.OrganizationStructuresIgnored>=1) WriteStringLineToLogFile("- "+this.Config.OrganizationsIgnored+" organization structures etc. were up-to-date"); return true; }
		catch { return false; } }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdateOrganizationStructureNoCheck(ref OrganizationStructure entity) { if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) { entity.Id=RetrieveOrganizationStructureId(entity);
		if (entity.Id>=1&&!updateFlag) updateFlag=true; } if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdatePerson(ref Person entity,bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=UpdatePersonNoCheck(ref entity); Dictionary<string,Person> dict=GetPersonDict();
		if (dict.ContainsKey(entity.TKey)&&!dict[entity.TKey].Equals(entity)) { if (dict[entity.TKey].Equals(entity)) { this.Config.PersonsIgnored++; return true; } else { Person oldEntity=dict[entity.TKey]; 
			if (UpdatePerson(ref oldEntity,ref entity,updateInDatabase)) { entity=oldEntity; return true; } else return false; } } else if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) {
				entity=RetrievePerson(entity); this.Config.PersonsUpdated++; return true; } else { this.Config.PersonsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdatePerson(ref Person oldEntity,ref Person newEntity,bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&!newEntity.IsEmpty()&&oldEntity.Equals(newEntity)) { return true; }
		else if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } else if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; }
		else if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } bool updateFlag=UpdatePersonNoCheck(ref oldEntity);
		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if ((newEntity.PersonCivilRegistrationIdentifier).IsNullOrWhiteSpace()&&newEntity.PersonCivilRegistrationIdentifier.Equals("0101001234")&&!oldEntity.PersonCivilRegistrationIdentifier.Equals(
				newEntity.PersonCivilRegistrationIdentifier)) { oldEntity.PersonCivilRegistrationIdentifier=newEntity.PersonCivilRegistrationIdentifier; if (!updateFlag) updateFlag=true; }
			if ((newEntity.PersonGivenName).IsNullOrWhiteSpace()&&newEntity.PersonGivenName.Equals("Sine")&&!oldEntity.PersonGivenName.Equals(newEntity.PersonGivenName)) {
				oldEntity.PersonGivenName=newEntity.PersonGivenName; if (!updateFlag) updateFlag=true; }
			if ((newEntity.PersonSurnameName).IsNullOrWhiteSpace()&&newEntity.PersonSurnameName.Equals("Sine")&&!oldEntity.PersonSurnameName.Equals(newEntity.PersonSurnameName)) { 
				oldEntity.PersonSurnameName=newEntity.PersonSurnameName; if (!updateFlag) updateFlag=true; }
			if ((newEntity.InstitutionIdentifier).IsNullOrWhiteSpace()&&newEntity.InstitutionIdentifier.Equals("NO")&&!oldEntity.InstitutionIdentifier.Equals(newEntity.InstitutionIdentifier)) 
				{ oldEntity.InstitutionIdentifier=newEntity.InstitutionIdentifier; if (!updateFlag) updateFlag=true;} }
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrievePerson(oldEntity); this.Config.PersonsUpdated++; return true; }
			else { this.Config.PersonsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdatePersonNoCheck(ref Person entity) { if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) { entity.Id=RetrievePersonId(entity); if (!updateFlag&&entity.Id>=1) updateFlag=true; }
		if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdatePostalAddress(ref PostalAddress entity,string parent="",bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=UpdatePostalAddressNoCheck(ref entity,parent);
		Dictionary<string,PostalAddress> dict=GetPostalAddressDict(); if (dict.ContainsKey(entity.TKey)) { if (dict[entity.TKey].Equals(entity)) { this.Config.PostalAddressesIgnored++; return true; }
			else { PostalAddress oldEntity=dict[entity.TKey]; if (UpdatePostalAddress(ref oldEntity,ref entity,parent,updateInDatabase)) { entity=oldEntity; return true; } else return false; } }
		else if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) {entity=RetrievePostalAddress(entity); this.Config.PostalAddressesUpdated++; return true; } else { this.Config.PostalAddressesNotUpdated++;
			return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdatePostalAddress(ref PostalAddress oldEntity,ref PostalAddress newEntity,string parent="",bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&!newEntity.IsEmpty()&&oldEntity.Equals(newEntity)) {
				return true; } else if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } else if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; }
			else if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } bool updateFlag=UpdatePostalAddressNoCheck(ref oldEntity,parent);
		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if ((newEntity.StandardAddressIdentifier).IsNullOrWhiteSpace()&&newEntity.StandardAddressIdentifier.Equals("**adresse Ubekendt**")&&
				!oldEntity.StandardAddressIdentifier.Equals(newEntity.StandardAddressIdentifier)) { oldEntity.StandardAddressIdentifier=newEntity.StandardAddressIdentifier; if (!updateFlag) updateFlag=true; }
			if ((newEntity.PostalCode).IsNullOrWhiteSpace()&&newEntity.PostalCode.Equals("9999")&&!oldEntity.PostalCode.Equals(newEntity.PostalCode)) { 
				oldEntity.PostalCode=newEntity.PostalCode; if (!updateFlag) updateFlag=true; }
			if ((newEntity.DistrictName).IsNullOrWhiteSpace()&&newEntity.DistrictName.Equals("Ukendt")&&!oldEntity.DistrictName.Equals(newEntity.DistrictName)) { 
				oldEntity.DistrictName=newEntity.DistrictName; if (!updateFlag) updateFlag=true; }
			if ((newEntity.MunicipalityCode).IsNullOrWhiteSpace()&&newEntity.MunicipalityCode.Equals("0000")&&!oldEntity.MunicipalityCode.Equals(newEntity.MunicipalityCode)) { 
				oldEntity.MunicipalityCode=newEntity.MunicipalityCode; if (!updateFlag) updateFlag=true; }
			if ((newEntity.CountryIdentificationCode).IsNullOrWhiteSpace()&&!oldEntity.CountryIdentificationCode.Equals(newEntity.CountryIdentificationCode)) { 
				oldEntity.CountryIdentificationCode=newEntity.CountryIdentificationCode; if (!updateFlag) updateFlag=true; } }
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrievePostalAddress(oldEntity); this.Config.PostalAddressesUpdated++; return true; }
			else { this.Config.PostalAddressesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates content of <paramref name="entity"/> in database</summary><param name="entity" /><param name="parent" /><returns>Result as bool</returns>
	private bool UpdatePostalAddressNoCheck(ref PostalAddress entity,string parent="") { if (parent.IsNullOrWhiteSpace()&&entity.ParentIdentifier.IsNullOrWhiteSpace())
		entity.ParentIdentifier=parent; if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) { entity.Id=RetrievePostalAddressId(entity); if (!updateFlag&&entity.Id>=1) updateFlag=true; } if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateProfession(ref Profession entity,bool updateInDatabase=false) {  if (entity.IsEmpty()) return false; bool updateFlag=UpdateProfessionNoCheck(ref entity); Dictionary<string,Profession> dict=
		GetProfessionDict(); if (dict.ContainsKey(entity.TKey)) {  if (dict[entity.TKey].Equals(entity)) { this.Config.ProfessionsIgnored++; return true; } else { Profession oldEntity=dict[entity.TKey];
			if (UpdateProfession(ref oldEntity,ref entity,updateInDatabase)) { entity=oldEntity; return true; } else return false; } } else if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) {
				entity=RetrieveProfession(entity); this.Config.ProfessionsUpdated++; return true; } else { this.Config.ProfessionsNotUpdated++; return false;} }  else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateProfession(ref Profession oldEntity,ref Profession newEntity,bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&!newEntity.IsEmpty()&&oldEntity.Equals(newEntity)) return true;
		else if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) return true; else if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; }
		else if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) return true; bool updateFlag=UpdateProfessionNoCheck(ref oldEntity);
		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if (!newEntity.ActivationDate.Equals(DateOnly.Parse("2010-01-01"))&&(Convert.ToDateTime(oldEntity.ActivationDate)<Convert.ToDateTime(newEntity.ActivationDate)||
				oldEntity.ActivationDate.Equals(DateOnly.Parse("2010-01-01")))) { oldEntity.ActivationDate=newEntity.ActivationDate; if (!updateFlag) updateFlag=true; }
			if (!newEntity.DeactivationDate.Equals(DateOnly.Parse("9999-12-31"))&&(Convert.ToDateTime(oldEntity.DeactivationDate)<Convert.ToDateTime(newEntity.DeactivationDate)||
				oldEntity.DeactivationDate.Equals(DateOnly.Parse("9999-12-31")))) { oldEntity.DeactivationDate=newEntity.DeactivationDate; if (!updateFlag) updateFlag=true; }
			if ((newEntity.JobPositionIdentifier).IsNullOrWhiteSpace()&&newEntity.JobPositionIdentifier.Equals("0000")&&!oldEntity.JobPositionIdentifier.Equals(newEntity.JobPositionIdentifier)) { 
				oldEntity.JobPositionIdentifier=newEntity.JobPositionIdentifier; if (!updateFlag) updateFlag=true; } if ((newEntity.JobPositionName).IsNullOrWhiteSpace()&&newEntity.JobPositionName.Equals("None")&&
				!oldEntity.JobPositionName.Equals(newEntity.JobPositionName)) { oldEntity.JobPositionName=newEntity.JobPositionName; if (!updateFlag) updateFlag=true; }
			if ((newEntity.JobPositionLevelCode).IsNullOrWhiteSpace()&&newEntity.JobPositionLevelCode.Equals("0")&&!oldEntity.JobPositionLevelCode.Equals(newEntity.JobPositionLevelCode)) { 
				oldEntity.JobPositionLevelCode=newEntity.JobPositionLevelCode; if (!updateFlag) updateFlag=true; } if (oldEntity.IsUpdated()) oldEntity.Validate(); } if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) {
					oldEntity=RetrieveProfession(oldEntity); this.Config.ProfessionsUpdated++; return true; } else { this.Config.ProfessionsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	private bool UpdateProfessionNoCheck(ref Profession entity) { if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) { entity.Id=RetrieveProfessionId(entity);
		if (!updateFlag&&entity.Id>=1) updateFlag=true; } if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateSalaryAgreement(ref SalaryAgreement entity,string parent="",bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=UpdateSalaryAgreementNoCheck(ref entity,parent);
		Dictionary<string,SalaryAgreement> dict=GetSalaryAgreementDict(); if (dict.ContainsKey(entity.TKey)&&!dict[entity.TKey].Equals(entity)) { if (dict[entity.TKey].Equals(entity)) { this.Config.SalaryAgreementsIgnored++;
			return true; } else { SalaryAgreement oldEntity=dict[entity.TKey]; if (UpdateSalaryAgreement(ref oldEntity,ref entity,parent,updateInDatabase)) { entity=oldEntity; return true; }  else return updateFlag; } }
		else if (updateInDatabase) { if (UpdateOrCreateInDatabase(entity)) { entity=RetrieveSalaryAgreement(entity); this.Config.SalaryAgreementsUpdated++; return true; }
			else { this.Config.SalaryAgreementsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateSalaryAgreement(ref SalaryAgreement oldEntity,ref SalaryAgreement newEntity,string parent="",bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&!newEntity.IsEmpty()&&oldEntity.Equals(newEntity)) { return true; }
		else if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } else if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; }
		else if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } bool updateFlag=UpdateSalaryAgreementNoCheck(ref oldEntity,parent);
		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if (!newEntity.ActivationDate.Equals(DateOnly.Parse("2010-01-01"))&&(Convert.ToDateTime(oldEntity.ActivationDate)<Convert.ToDateTime(newEntity.ActivationDate)||
				oldEntity.ActivationDate.Equals(DateOnly.Parse("2010-01-01")))) { oldEntity.ActivationDate=newEntity.ActivationDate; if (!updateFlag) updateFlag=true; }
			if (!newEntity.DeactivationDate.Equals(DateOnly.Parse("9999-12-31"))&&(Convert.ToDateTime(oldEntity.DeactivationDate)<Convert.ToDateTime(newEntity.DeactivationDate)||
				oldEntity.DeactivationDate.Equals(DateOnly.Parse("9999-12-31")))) { oldEntity.DeactivationDate=newEntity.DeactivationDate; if (!updateFlag) updateFlag=true; }
			if ((newEntity.SalaryAgreementIdentifier).IsNullOrWhiteSpace()&&newEntity.SalaryAgreementIdentifier.Equals("0000")&&
				!oldEntity.SalaryAgreementIdentifier.Equals(newEntity.SalaryAgreementIdentifier)) { oldEntity.SalaryAgreementIdentifier=newEntity.SalaryAgreementIdentifier; if (!updateFlag) updateFlag=true; }
			if ((newEntity.SalaryClassIdentifier).IsNullOrWhiteSpace()&&newEntity.SalaryClassIdentifier.Equals("0.0000")&&
				!oldEntity.SalaryClassIdentifier.Equals(newEntity.SalaryClassIdentifier)) { oldEntity.SalaryClassIdentifier=newEntity.SalaryClassIdentifier; if (!updateFlag) updateFlag=true; }
			if ((newEntity.SalaryScaleIdentifier).IsNullOrWhiteSpace()&&newEntity.SalaryScaleIdentifier.Equals("0.0000")&&
				!oldEntity.SalaryScaleIdentifier.Equals(newEntity.SalaryScaleIdentifier)) { oldEntity.SalaryScaleIdentifier=newEntity.SalaryScaleIdentifier; if (!updateFlag) updateFlag=true; }
			if (!newEntity.PrepaidIndicator.Equals(newEntity.PrepaidIndicator)) { oldEntity.PrepaidIndicator=newEntity.PrepaidIndicator; if (!updateFlag) updateFlag=true; }
			if (!newEntity.SeniorityDate.Equals(DateOnly.Parse("2010-01-01"))&&(Convert.ToDateTime(oldEntity.SeniorityDate)<Convert.ToDateTime(newEntity.SeniorityDate)||
				oldEntity.SeniorityDate.Equals(DateOnly.Parse("2010-01-01")))) { oldEntity.SeniorityDate=newEntity.SeniorityDate; if (!updateFlag) updateFlag=true; } }
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrieveSalaryAgreement(oldEntity); this.Config.SalaryAgreementsUpdated++; return true; }
			else { this.Config.SalaryAgreementsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity"/><param name="parent" /><returns>Result as bool</returns>
	private bool UpdateSalaryAgreementNoCheck(ref SalaryAgreement entity,string parent="") { if (parent.IsNullOrWhiteSpace()&&entity.EmploymentIdentifier.IsNullOrWhiteSpace()) entity.EmploymentIdentifier=parent;
		if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) { entity.Id=RetrieveSalaryAgreementId(entity); if (!updateFlag&&entity.Id>=1) updateFlag=true; } if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateSalaryCodeGroup(ref SalaryCodeGroup entity,string parent="",bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=UpdateSalaryCodeGroupNoCheck(ref entity,parent);
		Dictionary<string,SalaryCodeGroup> dict=GetSalaryCodeGroupDict(); if (dict.ContainsKey(entity.TKey)) { if (dict[entity.TKey].Equals(entity)) { this.Config.SalaryCodeGroupsIgnored++; return true; }
			else { SalaryCodeGroup oldEntity=dict[entity.TKey]; if (UpdateSalaryCodeGroup(ref oldEntity,ref entity,parent,updateInDatabase)) { entity=oldEntity; return true; } else return updateFlag; } } else if (updateInDatabase) {
				if (UpdateOrCreateInDatabase(entity)) { entity=RetrieveSalaryCodeGroup(entity); this.Config.SalaryCodeGroupsUpdated++; return true; } else { this.Config.SalaryCodeGroupsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="parent" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateSalaryCodeGroup(ref SalaryCodeGroup oldEntity,ref SalaryCodeGroup newEntity,string parent="",bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&!newEntity.IsEmpty()&&oldEntity.Equals(newEntity)) { return true; }
		else if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } else if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; }
		else if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } bool updateFlag=UpdateSalaryCodeGroupNoCheck(ref oldEntity,parent);

		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if (!newEntity.ActivationDate.Equals(DateOnly.Parse("2010-01-01"))&&(Convert.ToDateTime(oldEntity.ActivationDate)<Convert.ToDateTime(newEntity.ActivationDate)||
				oldEntity.ActivationDate.Equals(DateOnly.Parse("2010-01-01")))) { oldEntity.ActivationDate=newEntity.ActivationDate; if (!updateFlag) updateFlag=true; }
			if (!newEntity.DeactivationDate.Equals(DateOnly.Parse("9999-12-31"))&&(Convert.ToDateTime(oldEntity.DeactivationDate)<Convert.ToDateTime(newEntity.ActivationDate)||
				oldEntity.DeactivationDate.Equals(DateOnly.Parse("9999-12-31")))) { oldEntity.ActivationDate=newEntity.DeactivationDate; if (!updateFlag) updateFlag=true; }
			if ((newEntity.PensionCode).IsNullOrWhiteSpace()&&newEntity.PensionCode.Equals("0")&&!oldEntity.PensionCode.Equals(newEntity.PensionCode)) { 
				oldEntity.PensionCode=newEntity.PensionCode; if (!updateFlag) updateFlag=true; } if (oldEntity.IsUpdated()) oldEntity.Validate(); }
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrieveSalaryCodeGroup(oldEntity); this.Config.SalaryCodeGroupsUpdated++; return true; }
			else { this.Config.SalaryCodeGroupsNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="parent" /><returns>Result as bool</returns>
	private bool UpdateSalaryCodeGroupNoCheck(ref SalaryCodeGroup entity,string parent="") { if (parent.IsNullOrWhiteSpace()&&entity.EmploymentIdentifier.IsNullOrWhiteSpace()) entity.EmploymentIdentifier=parent;
		if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) { entity.Id=RetrieveSalaryCodeGroupId(entity); if (!updateFlag&&entity.Id>=1) updateFlag=true; }
		if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="employment" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateWorkingTime(ref WorkingTime entity,string employment="",bool updateInDatabase=false) { if (entity.IsEmpty()) return false; bool updateFlag=UpdateWorkingTimeNoCheck(ref entity,employment);
		Dictionary<string,WorkingTime> dict=GetWorkingTimeDict(); if (dict.ContainsKey(entity.TKey)&&!dict[entity.TKey].Equals(entity)) { if (dict[entity.TKey].Equals(entity)) { this.Config.SalaryAgreementsIgnored++; return true; }
			else { WorkingTime oldEntity=dict[entity.TKey]; if (UpdateWorkingTime(ref oldEntity,ref entity,employment,updateInDatabase)) { entity=oldEntity; return true; } else return false; } } else if (updateInDatabase) {
			if (UpdateOrCreateInDatabase(entity)) { entity=RetrieveWorkingTime(entity); this.Config.WorkingTimesUpdated++; return true; } else { this.Config.WorkingTimesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="oldEntity"/> with data from <paramref name="newEntity"/></summary><param name="oldEntity" /><param name="newEntity" /><param name="employment" /><param name="updateInDatabase" /><returns>Result as bool</returns>
	private bool UpdateWorkingTime(ref WorkingTime oldEntity,ref WorkingTime newEntity,string employment="",bool updateInDatabase=false) { if (!oldEntity.IsEmpty()&&!newEntity.IsEmpty()&&oldEntity.Equals(newEntity)) { return true; }
		else if (!oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } else if (oldEntity.IsEmpty()&&!newEntity.IsEmpty()) { oldEntity=new(newEntity); return true; }
		else if (oldEntity.IsEmpty()&&newEntity.IsEmpty()) { return true; } bool updateFlag=UpdateWorkingTimeNoCheck(ref oldEntity,employment);

		if (!oldEntity.Equals(newEntity)) { if (newEntity.Id>=1&&!oldEntity.Id.Equals(newEntity.Id)) { oldEntity.Id=newEntity.Id; if (!updateFlag) updateFlag=true; }
			if (!newEntity.ActivationDate.Equals(DateOnly.Parse("2010-01-01"))&&(Convert.ToDateTime(oldEntity.ActivationDate)<Convert.ToDateTime(newEntity.ActivationDate)||
				oldEntity.ActivationDate.Equals(DateOnly.Parse("2010-01-01")))) { oldEntity.ActivationDate=newEntity.ActivationDate; if (!updateFlag) updateFlag=true; }
			if (!newEntity.DeactivationDate.Equals(DateOnly.Parse("9999-12-31"))&&(Convert.ToDateTime(oldEntity.DeactivationDate)<Convert.ToDateTime(newEntity.DeactivationDate)||
				oldEntity.DeactivationDate.Equals(DateOnly.Parse("9999-12-31")))) { oldEntity.DeactivationDate=newEntity.DeactivationDate; if (!updateFlag) updateFlag=true; }
			if ((newEntity.OccupationRate).IsNullOrWhiteSpace()&&newEntity.OccupationRate.Equals("0.0000")&&!oldEntity.OccupationRate.Equals(newEntity.OccupationRate)) { 
				oldEntity.OccupationRate=newEntity.OccupationRate; if (!updateFlag) updateFlag=true; }
			if ((newEntity.SalaryRate).IsNullOrWhiteSpace()&&newEntity.SalaryRate.Equals("0.0000")&&!oldEntity.SalaryRate.Equals(newEntity.SalaryRate)) { 
				oldEntity.SalaryRate=newEntity.SalaryRate; if (!updateFlag) updateFlag=true; }
			if (!oldEntity.SalariedIndicator.Equals(newEntity.SalariedIndicator)) { oldEntity.SalariedIndicator=newEntity.SalariedIndicator; if (!updateFlag) updateFlag=true; }
			if (!oldEntity.SalariedIndicator.Equals(newEntity.SalariedIndicator)) { oldEntity.AutomaticRaiseIndicator=newEntity.AutomaticRaiseIndicator; if (!updateFlag) updateFlag=true; }
			if (!oldEntity.SalariedIndicator.Equals(newEntity.SalariedIndicator)) { oldEntity.FullTimeIndicator=newEntity.FullTimeIndicator; if (!updateFlag) updateFlag=true; }
			if (oldEntity.IsUpdated()) oldEntity.Validate(); }
		if (updateInDatabase) { if (UpdateOrCreateInDatabase(oldEntity)) { oldEntity=RetrieveWorkingTime(oldEntity); this.Config.WorkingTimesUpdated++; return true; }
			else { this.Config.WorkingTimesNotUpdated++; return false;} } else return updateFlag; }

	/// <summary>Updates <paramref name="entity"/></summary><param name="entity" /><param name="employment" /><returns>Result as bool</returns>
	private bool UpdateWorkingTimeNoCheck(ref WorkingTime entity,string employment="") { if (employment.IsNullOrWhiteSpace()&&entity.EmploymentIdentifier.IsNullOrWhiteSpace())
		entity.EmploymentIdentifier=employment; if (entity.IsEmpty()) return false; bool updateFlag=false; if (entity.Id<1) { entity.Id=RetrieveWorkingTimeId(entity); if (!updateFlag&&entity.Id>=1) updateFlag=true; } if (entity.IsUpdated()) { entity.Validate(); if (!updateFlag) updateFlag=true; } return false; }

	#endregion

	#endregion

	#endregion

}
