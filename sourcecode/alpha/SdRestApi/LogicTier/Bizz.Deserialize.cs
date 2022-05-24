// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Deserialize.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks />
public partial class Bizz // Deserialize retrieved data
{
	#region Methods

	/// <summary>Deserializes <paramref name="xml"/></summary><param name="xml" /><param name="institutionId" /><param name="sdApi" /><returns>Result as bool</returns>
	protected bool DeserializeXmlClone(string xml,string institutionId,string sdApi) => sdApi switch { "GetDepartment" => DeserializeGetDepartmentXmlClone(xml,institutionId), "GetEmployment" => DeserializeGetEmploymentXml(xml,institutionId),
		"GetOrganization" => DeserializeGetOrganizationXmlClone(xml,institutionId,sdApi), "GetPerson" => DeserializeGetPersonXml(xml,institutionId),"GetProfession" => DeserializeGetProfessionXmlClone(xml,institutionId), _ => false,};

	/// <summary>Deserializes <paramref name="xml"/></summary><param name="xml" /><param name="institutionId" /><param name="sdApi" /><returns>Result as bool</returns>
	protected bool DeserializeXmlUpdate(string xml,string institutionId,string sdApi) => sdApi switch { "GetDepartment" => DeserializeGetDepartmentXmlUpdate(xml,institutionId),
		"GetEmploymentChanged" => DeserializeGetEmploymentChangedXml(xml,institutionId), "GetEmploymentChangedAtDate" => DeserializeGetEmploymentChangedAtDateXml(xml,institutionId),
		"GetInstitution" => DeserializeGetInstitutionXmlUpdate(xml), "GetOrganization" => DeserializeGetOrganizationXmlUpdate(xml,institutionId,sdApi),
		"GetPersonChangedAtDate" => DeserializeGetPersonChangedAtDateXml(xml,institutionId), "GetProfession" => DeserializeGetProfessionXmlUpdate(xml,institutionId), _ => false,};

	#region Private

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" />
	private bool DeSerializeGetDepartmentClone(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; } 
		GetDepartment20111201 getDepartment=XmlSerializationUtil.Deserialize<GetDepartment20111201>(xml); if (getDepartment.Departments.Count<1) {
			WriteStringLineToLogFile("- GetDepartment for "+institutionId+" contained no data"); return true; }
		else if (CloneDepartments(getDepartment)) { WriteStringLineToLogFile("- GetDepartment data for "+institutionId+" was updated"); return true; }
		else { WriteStringLineToLogFile("- GetDepartment data for "+institutionId+" was not updated"); return false; } }

	private bool DeSerializeGetDepartmentUpdate(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; } 
		GetDepartment20111201 getDepartment=XmlSerializationUtil.Deserialize<GetDepartment20111201>(xml); if (getDepartment.Departments.Count<1) {
			WriteStringLineToLogFile("- GetDepartment for "+institutionId+" contained no data"); return true; }
		else if (UpdateDepartments(getDepartment)) { WriteStringLineToLogFile("- GetDepartment data for "+institutionId+" was updated"); return true; }
		else { WriteStringLineToLogFile("- GetDepartment data for "+institutionId+" was not updated"); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" />
	private bool DeserializeGetDepartmentXmlClone(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; } 
		WriteStringLineToLogFile("- Updating from GetDepartment for "+institutionId); Config.DepartmentsUpdated=0; Config.DepartmentsNotUpdated=0;
		if (DeSerializeGetDepartmentClone(xml,institutionId)) { Config.ResetDepartmentErrorFlags(); return true;} else { Config.SetDepartmentErrorFlags(); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" />
	private bool DeserializeGetDepartmentXmlUpdate(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; } 
		WriteStringLineToLogFile("- Updating from GetDepartment for "+institutionId); Config.DepartmentsUpdated=0; Config.DepartmentsNotUpdated=0;
		if (DeSerializeGetDepartmentUpdate(xml,institutionId)) { Config.SetDepartmentErrorFlags(); return true; } else { Config.SetDepartmentErrorFlags(); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeSerializeGetEmployment(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		GetEmployment20111201 getEmployment=XmlSerializationUtil.Deserialize<GetEmployment20111201>(xml);
		if (getEmployment.Persons.Count<1) { WriteStringLineToLogFile("- GetEmployment for "+institutionId+" contained no data"); return true; }
		else if (CloneEmployments(getEmployment)) { WriteStringLineToLogFile("- GetEmployment data for "+institutionId+" was updated"); return true; }
		else { WriteStringLineToLogFile("- GetEmployment data for "+institutionId+" was updated"); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeserializeGetEmploymentXml(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		WriteStringLineToLogFile("- Updating from GetEmployment for "+institutionId); Config.DepartmentsUpdated=0; Config.DepartmentsNotUpdated=0;
		if (DeSerializeGetEmployment(xml,institutionId)) { Config.ResetEmploymentErrorFlags(); return true;} else { Config.SetEmploymentErrorFlags(); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeSerializeGetEmploymentChanged(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		GetEmploymentChanged20111201 getEmploymentChanged=XmlSerializationUtil.Deserialize<GetEmploymentChanged20111201>(xml);
		if (getEmploymentChanged.Persons.Count<1) { WriteStringLineToLogFile("- GetEmploymentChanged for "+institutionId+" contained no data"); return true; }
		else if (UpdateEmploymentsChanged(getEmploymentChanged)) { WriteStringLineToLogFile("- GetEmployment data for "+institutionId+" was updated"); return true; }
		else { WriteStringLineToLogFile("- GetEmploymentChanged for "+institutionId+" was updated"); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeserializeGetEmploymentChangedXml(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		WriteStringLineToLogFile("- Updating from GetEmploymentChanged for "+institutionId); if (DeSerializeGetEmploymentChanged(xml,institutionId)) { Config.ResetEmploymentChangedErrorFlags(); return true; }
		else { Config.SetEmploymentChangedErrorFlags(); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeSerializeGetEmploymentChangedAtDate(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		GetEmploymentChangedAtDate20111201 getEmploymentChangedAtDate=XmlSerializationUtil.Deserialize<GetEmploymentChangedAtDate20111201>(xml);
		if (getEmploymentChangedAtDate.Persons.Count<1) { WriteStringLineToLogFile( "- GetEmploymentChangedAtDate for "+institutionId+" contained no data"); return true; } 
		else if (UpdateEmploymentsChangedAtDate(getEmploymentChangedAtDate)) { WriteStringLineToLogFile("- GetEmploymentChangedAtDate for "+institutionId+" was updated"); return true; }
		else { WriteStringLineToLogFile("- GetEmploymentChangedAtDate for "+getEmploymentChangedAtDate.GetEmploymentChangedAtDateRequestStructure.InstitutionIdentifier+" was not updated"); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeserializeGetEmploymentChangedAtDateXml(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		WriteStringLineToLogFile("- Updating from GetEmploymentChangedAtDate for "+institutionId); if (DeSerializeGetEmploymentChangedAtDate(xml,institutionId)) { Config.ResetEmploymentChangedAtDateErrorFlags(); return true; }
		else { Config.SetEmploymentChangedAtDateErrorFlags(); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeSerializeGetInstitutionClone(string xml) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
			GetInstitution20111201 getInstitution=XmlSerializationUtil.Deserialize<GetInstitution20111201>(xml); if (getInstitution.Region.Institutions.Count<1) { WriteStringLineToLogFile(
				"- GetInstitution contained no data"); return true; } else if (CloneInstitutions(getInstitution)) { WriteStringLineToLogFile("- GetInstitution data was updated"); return true; }
		else { WriteStringLineToLogFile("- GetInstitution data was not updated"); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeSerializeGetInstitutionUpdate(string xml) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
			GetInstitution20111201 getInstitution=XmlSerializationUtil.Deserialize<GetInstitution20111201>(xml); if (getInstitution.Region.Institutions.Count<1) { WriteStringLineToLogFile(
				"- GetInstitution contained no data"); return true; } else if (UpdateInstitutions(getInstitution)) { WriteStringLineToLogFile("- GetInstitution data was updated"); return true; }
		else { WriteStringLineToLogFile("- GetInstitution data was not updated"); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeserializeGetInstitutionXmlClone(string xml) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		WriteStringLineToLogFile("- Updating from GetInstitution"); Config.InstitutionsUpdated=0; Config.InstitutionsNotUpdated=0; if (DeSerializeGetInstitutionClone(xml)) { 
			Config.ResetInstitutionErrorFlags(); return true; } else { Config.SetInstitutionErrorFlags(); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeserializeGetInstitutionXmlUpdate(string xml) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		WriteStringLineToLogFile("- Updating from GetInstitution"); Config.InstitutionsUpdated=0; Config.InstitutionsNotUpdated=0; if (DeSerializeGetInstitutionUpdate(xml)) { 
			Config.ResetInstitutionErrorFlags(); return true; } else { Config.SetInstitutionErrorFlags(); return false;} }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><param name="sdApi" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeSerializeGetOrganizationClone(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		if (institutionId.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: institutionId is empty"); return false; } if (sdApi.IsNullOrWhiteSpace()) {WriteStringLineToLogFile("- Error: sdApi is empty"); return false; }
		try { bool orgUpdated=true; bool structureUpdated=true; using StringReader stringReader=new(xml); using XmlReader xr=XmlReader.Create(stringReader); while (xr.Read()) { if (xr.NodeType == XmlNodeType.Element) {
			if (!xr.LocalName.IsNullOrWhiteSpace()&&xr.LocalName.Contains("Org")&&!xr.LocalName.Contains("Get")&&!xr.LocalName.Contains("Req")) {
				switch (xr.LocalName) { case "Organization": if (!CloneOrganization(XmlSerializationUtil.Deserialize<WsOrganization>(XDocument.Load(xr.ReadSubtree())),institutionId)&&orgUpdated) orgUpdated=false;; break;
							case "OrganizationStructure": if (!CloneOrganizationStructure(XmlSerializationUtil.Deserialize<WsOrganizationStructure>(XDocument.Load(xr.ReadSubtree())),institutionId)&&structureUpdated) structureUpdated=false; break; } } } }
			WriteStringLineToLogFile("- Finished deserializing organization xml string for "+institutionId); if (orgUpdated&&structureUpdated) return true; else return false; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred while deserializing Organizations and OrganizationStructures:"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine+Environment.NewLine+"- Content of input string:"+Environment.NewLine+xml+Environment.NewLine+Environment.NewLine+"- Finished deserializing xml string"+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred while deserializing Organizations and OrganizationStructures:"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine+
			Environment.NewLine+"- Content of input string:"+Environment.NewLine+xml+Environment.NewLine+Environment.NewLine+"- Finished deserializing xml string"+Environment.NewLine); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><param name="sdApi" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeSerializeGetOrganizationUpdate(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		if (institutionId.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: institutionId is empty"); return false; } if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty"); return false; }
		try { bool orgUpdated=true; bool structureUpdated=true; using StringReader stringReader=new(xml); using XmlReader xr=XmlReader.Create(stringReader); while (xr.Read()) { if (xr.NodeType == XmlNodeType.Element) {
			if (!xr.LocalName.IsNullOrWhiteSpace()&&xr.LocalName.Contains("Org")&&!xr.LocalName.Contains("Get")&&!xr.LocalName.Contains("Req")) {
				switch (xr.LocalName) { case "Organization": if (!UpdateOrganization(XmlSerializationUtil.Deserialize<WsOrganization>(XDocument.Load(xr.ReadSubtree())),institutionId)&&orgUpdated) orgUpdated=false;; break;
							case "OrganizationStructure": if (!UpdateOrganizationStructure(XmlSerializationUtil.Deserialize<WsOrganizationStructure>(XDocument.Load(xr.ReadSubtree())),institutionId)&&structureUpdated) structureUpdated=false; break; } } } }
			WriteStringLineToLogFile("- Finished deserializing organization xml string for "+institutionId); if (orgUpdated&&structureUpdated) return true; else return false; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred while deserializing Organizations and OrganizationStructures:"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine+Environment.NewLine+"- Content of input string:"+Environment.NewLine+xml+Environment.NewLine+Environment.NewLine+"- Finished deserializing xml string"+Environment.NewLine); return false; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred while deserializing Organizations and OrganizationStructures:"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine+
			Environment.NewLine+"- Content of input string:"+Environment.NewLine+xml+Environment.NewLine+Environment.NewLine+"- Finished deserializing xml string"+Environment.NewLine); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><param name="sdApi" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeserializeGetOrganizationXmlClone(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty - "+CurrentMethod()+" line "+
			CurrentLineNumber()); return false; } if (institutionId.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: institutionId is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return false; }
		if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return false; }
		if (DeSerializeGetOrganizationClone(xml,institutionId,sdApi)) { this.Config.ResetOrganizationErrorFlags(); return true; } else { this.Config.SetOrganizationErrorFlags(); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><param name="sdApi" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeserializeGetOrganizationXmlUpdate(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty - "+CurrentMethod()+" line "+
			CurrentLineNumber()); return false; } if (institutionId.IsNullOrWhiteSpace()){ WriteStringLineToLogFile("- Error: institutionId is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return false; }
		if (sdApi.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: sdApi is empty - "+CurrentMethod()+" line "+CurrentLineNumber()); return false; }
		if (DeSerializeGetOrganizationUpdate(xml,institutionId,sdApi)) { this.Config.ResetOrganizationErrorFlags(); return true; } else { this.Config.SetOrganizationErrorFlags(); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeSerializeGetPerson(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		GetPerson20111201 getPerson=XmlSerializationUtil.Deserialize<GetPerson20111201>(xml);
		if (getPerson.Persons.Count<1) { WriteStringLineToLogFile("- GetPerson for "+institutionId+" contained no data"); return true; }
		else if (ClonePersons(getPerson)) { WriteStringLineToLogFile("- GetPerson data for "+institutionId+" was updated"); return true; } 
		else { WriteStringLineToLogFile("- GetPerson data for "+institutionId+" was not updated"); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeserializeGetPersonXml(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		WriteStringLineToLogFile("- Updating from GetPerson for "+institutionId); if (DeSerializeGetPerson(xml,institutionId)) { Config.ResetPersonErrorFlags(); return true; }
		else { Config.SetPersonErrorFlags(); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeSerializeGetPersonChangedAtDate(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		GetPersonChangedAtDate20111201 getPersonChangedAtDate=XmlSerializationUtil.Deserialize<GetPersonChangedAtDate20111201>(xml);
		if (getPersonChangedAtDate.Persons.Count<1) { WriteStringLineToLogFile("- GetPersonChangedAtDate for "+institutionId+" contained no data"); return true; }
		else if (UpdatePersonsChangedAtDate(getPersonChangedAtDate)) { WriteStringLineToLogFile("- GetPersonChangedAtDate for "+institutionId+" was updated"); return true; }
		else { WriteStringLineToLogFile("- GetPersonChangedAtDate for "+institutionId+" was updated"); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeserializeGetPersonChangedAtDateXml(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		WriteStringLineToLogFile("- Updating from GetPersonChangedAtDate for "+institutionId); if (DeSerializeGetPersonChangedAtDate(xml,institutionId)) { Config.ResetPersonChangedAtDateErrorFlags(); return true; }
		else { Config.SetPersonChangedAtDateErrorFlags(); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeSerializeGetProfessionClone(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
			GetProfession20080201 getProfession=XmlSerializationUtil.Deserialize<GetProfession20080201>(xml); if (getProfession.Professions.Count<1) { WriteStringLineToLogFile("- GetProfession for "+institutionId+
				" contained no data"); return true; } else if (CloneProfessions(getProfession)) { WriteStringLineToLogFile("- GetProfession data for "+getProfession.RequestKey.InstitutionIdentifier+
					" was updated"); return true; } else { WriteStringLineToLogFile("- GetProfession data for "+institutionId+" was not updated"); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeSerializeGetProfessionUpdate(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
			GetProfession20080201 getProfession=XmlSerializationUtil.Deserialize<GetProfession20080201>(xml); if (getProfession.Professions.Count<1) { WriteStringLineToLogFile("- GetProfession for "+institutionId+
				" contained no data"); return true; } else if (UpdateProfessions(getProfession)) { WriteStringLineToLogFile("- GetProfession data for "+getProfession.RequestKey.InstitutionIdentifier+
					" was updated"); return true; } else { WriteStringLineToLogFile("- GetProfession data for "+institutionId+" was not updated"); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeserializeGetProfessionXmlClone(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		WriteStringLineToLogFile("- Updating from GetProfession for "+institutionId); if (DeSerializeGetProfessionClone(xml,institutionId)) { Config.ResetProfessionErrorFlags(); return true; }
		else { Config.SetProfessionErrorFlags(); return false; } }

	/// <returns>Result as bool</returns><param name="xml" /><param name="institutionId" /><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	private bool DeserializeGetProfessionXmlUpdate(string xml,string institutionId) { if (xml.IsNullOrWhiteSpace()) { WriteStringLineToLogFile("- Error: XML-string is empty"); return false; }
		WriteStringLineToLogFile("- Updating from GetProfession for "+institutionId); if (DeSerializeGetProfessionUpdate(xml,institutionId))  { Config.ResetProfessionErrorFlags(); return true; }
		else { Config.SetProfessionErrorFlags(); return false; } }

	#endregion

	#endregion

}
