// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="EFExtension.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace DataTier;

/// <remarks/>
public class EFExtension
{

	#pragma warning disable CS8602
	#pragma warning disable CS8603
	#region Methods

	/// <remarks /><typeparam name="T" /><param name="entity" /><exception cref="InvalidRefException" />
	public static int CreateInDatabase<T>(T entity) where T : class { string type=typeof(T).Name; using EFContext dbo=new(); return type switch {
		"ContactInformation" => dbo.Database.ExecuteSqlRawAsync((entity as ContactInformation).SqlInsertQuery).Result,
		"Department" => dbo.Database.ExecuteSqlRawAsync((entity as Department).SqlInsertQuery).Result,
		"DepartmentLevelReference" => dbo.Database.ExecuteSqlRawAsync((entity as DepartmentLevelReference).SqlInsertQuery).Result,
		"DepartmentReference" => dbo.Database.ExecuteSqlRawAsync((entity as DepartmentReference).SqlInsertQuery).Result,
		"Employment" => dbo.Database.ExecuteSqlRawAsync((entity as Employment).SqlInsertQuery).Result,
		"EmploymentProfession" => dbo.Database.ExecuteSqlRawAsync((entity as EmploymentProfession).SqlInsertQuery).Result,
		"EmploymentStatus" => dbo.Database.ExecuteSqlRawAsync((entity as EmploymentStatus).SqlInsertQuery).Result,
		"Institution" => dbo.Database.ExecuteSqlRawAsync((entity as Institution).SqlInsertQuery).Result,
		"Organization" => dbo.Database.ExecuteSqlRawAsync((entity as Organization).SqlInsertQuery).Result,
		"OrganizationStructure" => dbo.Database.ExecuteSqlRawAsync((entity as OrganizationStructure).SqlInsertQuery).Result,
		"Person" => dbo.Database.ExecuteSqlRawAsync((entity as Person).SqlInsertQuery).Result,
		"PostalAddress" => dbo.Database.ExecuteSqlRawAsync((entity as PostalAddress).SqlInsertQuery).Result,
		"Profession" => dbo.Database.ExecuteSqlRawAsync((entity as Profession).SqlInsertQuery).Result,
		"SalaryAgreement" => dbo.Database.ExecuteSqlRawAsync((entity as SalaryAgreement).SqlInsertQuery).Result,
		"SalaryCodeGroup" => dbo.Database.ExecuteSqlRawAsync((entity as SalaryCodeGroup).SqlInsertQuery).Result,
		"SuccessfulRun" => dbo.Database.ExecuteSqlRawAsync((entity as SuccessfulRun).SqlInsertQuery).Result,
		"WorkingTime" => dbo.Database.ExecuteSqlRawAsync((entity as WorkingTime).SqlInsertQuery).Result,
		_ => throw new InvalidRefException(nameof(type),type,type+Error.InvTypeParam), }; }

	/// <summary>Selects a List from Database</summary><typeparam name="T" />
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

	/// <summary>Selects a view from Database</summary><typeparam name="T" />
	public static List<T> SelectViewFromDatabase<T>() where T : class { string command=GetSelectViewCommand(typeof(T).Name); using SqlConnection dbConnection=new(Resources.ConnectionString);
		using IDbCommand dbCommand=new SqlCommand() { Connection=dbConnection, CommandType=CommandType.Text, CommandText=command, CommandTimeout=60 }; dbConnection.Open();
		using IDataReader reader=dbCommand.ExecuteReader(); return GetViewFromReader<T>(reader); }


	/// <remarks /><typeparam name="T" /><param name="entity" /><exception cref="InvalidRefException" />
	public static int UpdateInDatabase<T>(T entity) where T : class { string type=typeof(T).Name; using EFContext dbo=new(); return type switch {
		"ContactInformation" => dbo.Database.ExecuteSqlRawAsync((entity as ContactInformation).SqlUpdateQuery).Result,
		"Department" => dbo.Database.ExecuteSqlRawAsync((entity as Department).SqlUpdateQuery).Result,
		"DepartmentLevelReference" => dbo.Database.ExecuteSqlRawAsync((entity as DepartmentLevelReference).SqlUpdateQuery).Result,
		"DepartmentReference" => dbo.Database.ExecuteSqlRawAsync((entity as DepartmentReference).SqlUpdateQuery).Result,
		"Employment" => dbo.Database.ExecuteSqlRawAsync((entity as Employment).SqlUpdateQuery).Result,
		"EmploymentProfession" => dbo.Database.ExecuteSqlRawAsync((entity as EmploymentProfession).SqlUpdateQuery).Result,
		"EmploymentStatus" => dbo.Database.ExecuteSqlRawAsync((entity as EmploymentStatus).SqlUpdateQuery).Result,
		"Institution" => dbo.Database.ExecuteSqlRawAsync((entity as Institution).SqlUpdateQuery).Result,
		"Organization" => dbo.Database.ExecuteSqlRawAsync((entity as Organization).SqlUpdateQuery).Result,
		"OrganizationStructure" => dbo.Database.ExecuteSqlRawAsync((entity as OrganizationStructure).SqlUpdateQuery).Result,
		"Person" => dbo.Database.ExecuteSqlRawAsync((entity as Person).SqlUpdateQuery).Result,
		"PostalAddress" => dbo.Database.ExecuteSqlRawAsync((entity as PostalAddress).SqlUpdateQuery).Result,
		"Profession" => dbo.Database.ExecuteSqlRawAsync((entity as Profession).SqlUpdateQuery).Result,
		"SalaryAgreement" => dbo.Database.ExecuteSqlRawAsync((entity as SalaryAgreement).SqlUpdateQuery).Result,
		"SalaryCodeGroup" => dbo.Database.ExecuteSqlRawAsync((entity as SalaryCodeGroup).SqlUpdateQuery).Result,
		"SuccessfulRun" => dbo.Database.ExecuteSqlRawAsync((entity as SuccessfulRun).SqlUpdateQuery).Result,
		"WorkingTime" => dbo.Database.ExecuteSqlRawAsync((entity as WorkingTime).SqlUpdateQuery).Result,
		_ => throw new InvalidRefException(nameof(type),type,type+Error.InvTypeParam), }; }

	#region Private

	/// <summary>Result as string</summary><param name="entityType" /><exception cref="InvalidRefException" />
	private static string GetSelectViewCommand(string entityType) => entityType.ToLower() switch { "view3in1organization" => "SELECT * FROM [SD].[dbo].[View3in1Organizations] ORDER BY Afdelingsid,Overordnet",
		"view3in1organizationstructure" => "SELECT * FROM [SD].[dbo].[View3in1OrganizationStructures] ORDER BY Afdelingsid,Overordnet", "view3in1person" => "SELECT * FROM [SD].[dbo].[View3in1Persons] ORDER BY Cpr,Tjenestenummer",
		"viewcontactinformation" => "SELECT * FROM [SD].[dbo].[ViewContactInformationListHB] ORDER BY ParentIdentifier, InstitutionIdentifier", "viewcontrol" => "SELECT * FROM [SD].[dbo].[ViewController] "+
			"ORDER BY Cpr, Tjenestenummer, Silo", "viewdepartment" => "SELECT * FROM [SD].[dbo].[ViewDepartmentListHB] ORDER BY DepartmentIdentifier,InstitutionIdentifier", "viewdepartmentlevelreference" =>
				"SELECT * FROM [SD].[dbo].[ViewDepartmentLevelReferenceListHB] ORDER BY DepartmentLevelIdentifier, OrganizationStructure", "viewdepartmentreference" => "SELECT * FROM [SD].[dbo].[ViewDepartmentReferenceListHB] "+
					"ORDER BY DepartmentIdentifier, Organization", "viewemployment" => "SELECT * FROM [SD].[dbo].[ViewEmploymentListHB] ORDER BY EmploymentIdentifier, InstitutionIdentifier",
		"viewemploymentprofession" => "SELECT * FROM [SD].[dbo].[ViewEmploymentProfessionListHB] ORDER BY EmploymentIdentifier, InstitutionIdentifier, JobPositionIdentifier", "viewemploymentstatus" => "SELECT * FROM "+
			"[SD].[dbo].[ViewEmploymentstatusListHB] ORDER BY EmploymentIdentifier, InstitutionIdentifier", "viewfullprofession" => "SELECT * FROM [SD].[dbo].[ViewFullProfessions] ORDER BY EmploymentIdentifier, "+
				"InstitutionIdentifier, JobPositionIdentifier", "viewinstitution" => "SELECT * FROM [SD].[dbo].[ViewInstitutionListHB] ORDER BY InstitutionIdentifier",
		"viewkantine" => "SELECT * FROM [SD].[dbo].[ViewKantineList] ORDER BY Cpr, Tjenestenummer, Afdelingskode, Beskæftigelsesdecimal DESC", "viewmoch" => "SELECT * FROM [SD].[dbo].[ViewMochs] ORDER BY Cpr, Tjenestenummer, Silo",
		"vieworganization" => "SELECT * FROM [SD].[dbo].[ViewOrganizationListHB] ORDER BY InstitutionIdentifier", "vieworganizationstructure" => "SELECT * FROM [SD].[dbo].[ViewOrganizationStructureListHB] ORDER BY InstitutionIdentifier",
		"viewperson" => "SELECT * FROM [SD].[dbo].[ViewPersonListHB] ORDER BY PersonCivilRegistrationIdentifier, InstitutionIdentifier", "viewpostaladdress" => "SELECT * FROM [SD].[dbo].[ViewPostalAddressListHB] "+
			"ORDER BY ParentIdentifier, InstitutionIdentifier", "viewprofession" => "SELECT * FROM [SD].[dbo].[ViewProfessionListHB] ORDER BY JobPositionIdentifier, InstitutionIdentifier", "viewsalaryagreement" =>
				"SELECT * FROM [SD].[dbo].[ViewSalaryAgreementListHB] ORDER BY EmploymentIdentifier, InstitutionIdentifier", "viewsalarycodegroup" => "SELECT * FROM [SD].[dbo].[ViewSalaryCodeGroupListHB] "+
					"ORDER BY EmploymentIdentifier, InstitutionIdentifier", "viewworkingtime" => "SELECT * FROM [SD].[dbo].[ViewWorkingTimeListHB] ORDER BY EmploymentIdentifier, InstitutionIdentifier",
		"xmemployment" => "SELECT * FROM [SD].[dbo].[ViewXmEmployments] ORDER BY Cpr,EmploymentId", _ => throw new InvalidRefException(entityType+Error.InvTypeParam), };

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<View3in1Organization> GetView3in1OrganizationsFromReader(IDataReader reader) { List<View3in1Organization> result=new(); while (reader.Read()) { View3in1Organization entity=new() {
		Silo=(string)reader["Silo"], Organisation=(string)reader["Organisation"], Aktiveringsdato=(DateTime)reader["Aktiveringsdato"], Deaktiveringsdato=(DateTime)reader["Deaktiveringsdato"], Afdelingsid=
			(string)reader["Afdelingsid"], Afdelingsuuid=(string)reader["AfdelingsUuid"], Afdelingsniveau=(string)reader["Afdelingsniveau"], Overordnet=(string)reader["Overordnet"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<View3in1OrganizationStructure> GetView3in1OrganizationStructuresFromReader(IDataReader reader) { List<View3in1OrganizationStructure> result=new(); while (reader.Read()) {
		View3in1OrganizationStructure entity=new() { Silo=(string)reader["Silo"], Organisationstruktur=(string)reader["Organisationstruktur"], Afdelingsid=(string)reader["Afdelingsid"],
			Afdelingsuuid=(string)reader["AfdelingsUuid"], Afdelingsniveau=(string)reader["Afdelingsniveau"], Overordnet=(string)reader["Overordnet"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<View3in1Person> GetView3in1PersonsFromReader(IDataReader reader) { List<View3in1Person> result=new(); while (reader.Read()) { View3in1Person entity=new() { Tjenestenummer=(string)reader["Tjenestenummer"],
		Silo=(string)reader["Silo"], Afdelingsid=(string)reader["Afdelingsid"], Afdelingsuuid=(string)reader["AfdelingsUuid"], Afdelingsnavn=(string)reader["Afdelingsnavn"], Cpr=(string)reader["Cpr"],
		Fornavn=(string)reader["Fornavn"], Efternavn=(string)reader["Efternavn"] }; try { entity.Email2=(string)reader["Email2"]; } catch (Exception) { } try { entity.Email1=(string)reader["Email1"]; } catch (Exception) { }
		try { entity.Tlf1=(string)reader["Tlf1"]; } catch (Exception) { } try { entity.Tlf2=(string)reader["Tlf2"]; } catch (Exception) { } result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewContactInformation> GetViewContactInformationListFromReader(IDataReader reader) { List<ViewContactInformation> result=new(); while (reader.Read()) { ViewContactInformation entity=new() {
		Id=(int)reader["Id"], ParentIdentifier=(string)reader["ParentIdentifier"], TelephoneNumberIdentifier1=(string)reader["TelephoneNumberIdentifier1"], TelephoneNumberIdentifier2=(string)reader["TelephoneNumberIdentifier2"],
		EmailAddressIdentifier1=(string)reader["EmailAddressIdentifier1"], EmailAddressIdentifier2=(string)reader["EmailAddressIdentifier2"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewControl> GetViewControllerFromReader(IDataReader reader) { List<ViewControl> result=new(); while (reader.Read()) { ViewControl entity=new() { Cpr=(string)reader["Cpr"],
			Tjenestenummer=(string)reader["Tjenestenummer"], Beskæftigelsesrate=(string)reader["BeskæftigelsesRate"], Silo=(string)reader["Silo"], Afdeling=(string)reader["Afdeling"],
			Fornavn=(string)reader["Fornavn"], Efternavn=(string)reader["Efternavn"] }; try { entity.Email1=(string)reader["Email1"]; } catch (Exception) { } try { entity.Email2=(string)reader["Email2"]; }
		catch (Exception) { } try { entity.DI_User=(string)reader["DI_User"]; } catch (Exception) { } entity.Beskæftigelse=(string)reader["Beskæftigelse"]; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewDepartmentLevelReference> GetViewDepartmentLevelReferenceListFromReader(IDataReader reader) { List<ViewDepartmentLevelReference> result=new(); while (reader.Read()) {
		ViewDepartmentLevelReference entity=new() { Id=(int)reader["Id"], DepartmentLevelIdentifier=(string)reader["DepartmentLevelIdentifier"], OrganizationStructure=(string)reader["OrganizationStructure"],
			SeniorDepartmentLevelReference=(string)reader["SeniorDepartmentLevelReference"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewDepartment> GetViewDepartmentListFromReader(IDataReader reader) { List<ViewDepartment> result=new(); while (reader.Read()) { ViewDepartment entity=new() { Id=(int)reader["Id"],
		ActivationDate=(DateTime)reader["ActivationDate"], DeactivationDate=(DateTime)reader["DeactivationDate"], DepartmentUuidIdentifier=(string)reader["DepartmentUuidIdentifier"],
		DepartmentIdentifier=(string)reader["DepartmentIdentifier"], DepartmentLevelIdentifier=(string)reader["DepartmentLevelIdentifier"], DepartmentName=(string)reader["DepartmentName"],
		ProductionUnitIdentifier=(string)reader["ProductionUnitIdentifier"], InstitutionIdentifier=(string)reader["InstitutionIdentifier"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewDepartmentReference> GetViewDepartmentReferenceListFromReader(IDataReader reader) { List<ViewDepartmentReference> result=new(); while (reader.Read()) { ViewDepartmentReference entity=new() {
		Id=(int)reader["Id"], DepartmentIdentifier=(string)reader["DepartmentIdentifier"], DepartmentUuidIdentifier=(string)reader["DepartmentUuidIdentifier"], DepartmentLevelIdentifier=(string)reader["DepartmentLevelIdentifier"],
		Organization=(string)reader["Organization"], SeniorDepartmentReference=(string)reader["SeniorDepartmentReference"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewEmployment> GetViewEmploymentListFromReader(IDataReader reader) { List<ViewEmployment> result=new(); while (reader.Read()) { ViewEmployment entity=new() { Id=(int)reader["Id"],
		EmploymentIdentifier=(string)reader["EmploymentIdentifier"], EmploymentDate=(DateTime)reader["EmploymentDate"], InstitutionIdentifier=(string)reader["InstitutionIdentifier"], Employee=(string)reader["Employee"],
		EmploymentDepartment=(string)reader["EmploymentDepartment"], EmploymentProfession=(string)reader["EmploymentProfession"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewEmploymentProfession> GetViewEmploymentProfessionListFromReader(IDataReader reader) { List<ViewEmploymentProfession> result=new(); while (reader.Read()) { ViewEmploymentProfession entity=new() {
			Id=(int)reader["Id"], EmploymentIdentifier=(string)reader["EmploymentIdentifier"], InstitutionIdentifier=(string)reader["InstitutionIdentifier"], JobPositionIdentifier=(string)reader["JobPositionIdentifier"],
			ActivationDate=(DateTime)reader["ActivationDate"], DeactivationDate=(DateTime)reader["DeactivationDate"], EmploymentName= (string)reader["EmploymentName"], AppointmentCode=(string)reader["AppointmentCode"] };
		result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewEmploymentStatus> GetViewEmploymentStatusListFromReader(IDataReader reader) { List<ViewEmploymentStatus> result=new(); while (reader.Read()) { ViewEmploymentStatus entity=new() {
		Id=(int)reader["Id"], EmploymentIdentifier=(string)reader["EmploymentIdentifier"], InstitutionIdentifier= (string)reader["InstitutionIdentifier"], ActivationDate=(DateTime)reader["ActivationDate"],
		DeactivationDate=(DateTime)reader["DeactivationDate"], EmploymentStatusCode=(string)reader["EmploymentStatusCode"], MarkedForDeletion=(bool)reader["MarkedForDeletion"]}; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" /><exception cref="InvalidRefException" />
	private static List<T> GetViewFromReader<T>(IDataReader reader) where T : class { return typeof(T).Name.ToLower() switch { "view3in1organization" => GetView3in1OrganizationsFromReader(reader) as List<T>,
		"view3in1organizationstructure" => GetView3in1OrganizationStructuresFromReader(reader) as List<T>, "view3in1person" => GetView3in1PersonsFromReader(reader) as List<T>,
		"viewcontactinformation" => GetViewContactInformationListFromReader(reader) as List<T>, "viewcontrol" => GetViewControllerFromReader(reader) as List<T>,
		"viewdepartment" => GetViewDepartmentListFromReader(reader) as List<T>, "viewdepartmentlevelreference" => GetViewDepartmentLevelReferenceListFromReader(reader) as List<T>,
		"viewdepartmentreference" => GetViewDepartmentReferenceListFromReader(reader) as List<T>, "viewemployment" => GetViewEmploymentListFromReader(reader) as List<T>,
		"viewemploymentprofession" => GetViewEmploymentProfessionListFromReader(reader) as List<T>, "viewemploymentstatus" => GetViewEmploymentStatusListFromReader(reader) as List<T>,
		"viewfullprofession" => GetViewFullProfessionsFromReader(reader) as List<T>, "viewinstitution" => GetViewInstitutionListFromReader(reader) as List<T>,
		"viewkantine" => GetViewKantineListFromReader( reader) as List<T>, "viewmoch" => GetViewMochsFromReader(reader) as List<T>, "vieworganization" => GetViewOrganizationListFromReader(reader) as List<T>,
		"vieworganizationstructure" => GetViewOrganizationStructureListFromReader(reader) as List<T>, "viewperson" => GetViewPersonListFromReader(reader) as List<T>,
		"viewpostaladdress" => GetViewPostalAddressListFromReader(reader) as List<T>, "viewprofession" => GetViewProfessionListFromReader(reader) as List<T>,
		"viewsalaryagreement" => GetViewSalaryAgreementListFromReader(reader) as List<T>, "viewsalarycodegroup" => GetViewSalaryCodeGroupListFromReader(reader) as List<T>,
		"viewworkingtime" => GetViewWorkingTimeListFromReader(reader) as List<T>, "xmemployment" => GetViewXmEmploymentsFromReader(reader) as List<T>, _ => throw new InvalidRefException(typeof(T).Name+Error.InvTypeParam), }; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewFullProfession> GetViewFullProfessionsFromReader(IDataReader reader) { List<ViewFullProfession> result=new(); while (reader.Read()) { ViewFullProfession entity=new() {
		ProfessionId=(int)reader["ProfessionId"], EmploymentProfessionId=(int)reader["EmploymentProfessionId"], ActivationDate=(DateTime)reader["ActivationDate"], DeactivationDate=(DateTime)reader["DeactivationDate"],
		JobPositionIdentifier=(string)reader["JobPositionIdentifier"], JobPositionName=(string)reader["JobPositionName"], JobPositionLevelCode=(string)reader["InstitutionIdentifier"],
		EmploymentName=(string)reader["EmploymentName"], AppointmentCode=(string)reader["AppointmentCode"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewInstitution> GetViewInstitutionListFromReader(IDataReader reader) { List<ViewInstitution> result=new(); while (reader.Read()) { ViewInstitution entity=new() { Id=(int)reader["Id"],InstitutionUuidIdentifier=
		(string)reader["InstitutionUuidIdentifier"], InstitutionIdentifier=(string)reader["InstitutionIdentifier"], InstitutionName=(string)reader["InstitutionName"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewKantine> GetViewKantineListFromReader(IDataReader reader) { List<ViewKantine> result=new(); while (reader.Read()) { ViewKantine entity=new() { Tjenestenummer=(string)reader["Tjenestenummer"],
		Cpr=(string)reader["Cpr"], Fornavn=(string)reader["Fornavn"], Efternavn=(string)reader["Efternavn"], Titel=(string)reader["Titel"], Afdeling=(string)reader["Afdeling"], StartDato=(DateTime)reader["StartDato"],
		SlutDato=(DateTime)reader["SlutDato"], Beskæftigelsesdecimal=(string)reader["Beskæftigelsesdecimal"], Jubi=(DateTime)reader["Jubi"], Afdelingskode=(string)reader["Afdelingskode"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewMoch> GetViewMochsFromReader(IDataReader reader) { List<ViewMoch> result=new(); while (reader.Read()) { ViewMoch entity=new() { Cpr=(string)reader["Cpr"], Tjenestenummer=
		(string)reader["Tjenestenummer"], Silo=(string)reader["Silo"], Afdeling=(string)reader["Afdeling"], Fornavn=(string)reader["Fornavn"], Efternavn=(string)reader["Efternavn"] }; try { entity.Email1=
			(string)reader["Email1"]; } catch { } try { entity.Email2=(string)reader["Email2"]; } catch { } result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewOrganization> GetViewOrganizationListFromReader(IDataReader reader) { List<ViewOrganization> result=new(); while (reader.Read()) { ViewOrganization entity=new() { Id=(int)reader["Id"],
		ActivationDate=(DateTime)reader["ActivationDate"], DeactivationDate=(DateTime)reader["DeactivationDate"], InstitutionIdentifier=(string)reader["InstitutionIdentifier"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewOrganizationStructure> GetViewOrganizationStructureListFromReader(IDataReader reader) { List<ViewOrganizationStructure> result=new(); while (reader.Read()) { ViewOrganizationStructure entity=new() {
		Id=(int)reader["Id"], InstitutionIdentifier=(string)reader["InstitutionIdentifier"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewPerson> GetViewPersonListFromReader(IDataReader reader) { List<ViewPerson> result=new(); while (reader.Read()) { ViewPerson entity=new() { Id=(int)reader["Id"],
		PersonCivilRegistrationIdentifier=(string)reader["PersonCivilRegistrationIdentifier"], PersonGivenName=(string)reader["PersonGivenName"], PersonSurnameName= (string)reader["PersonSurnameName"],
		InstitutionIdentifier=(string)reader["InstitutionIdentifier"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewPostalAddress> GetViewPostalAddressListFromReader(IDataReader reader) { List<ViewPostalAddress> result=new(); while (reader.Read()) { ViewPostalAddress entity=new() { 
			Id=(int)reader["Id"], ParentIdentifier=(string)reader["ParentIdentifier"], InstitutionIdentifier=(string)reader["InstitutionIdentifier"], StandardAddressIdentifier=(string)reader["StandardAddressIdentifier"],
			PostalCode= (string)reader["PostalCode"], DistrictName=(string)reader["DistrictName"], MunicipalityCode=(string)reader["MunicipalityCode"], CountryIdentificationCode=(string)reader["CountryIdentificationCode"] };
		result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewProfession> GetViewProfessionListFromReader(IDataReader reader) { List<ViewProfession> result=new(); while (reader.Read()) { ViewProfession entity=new() {
		Id=(int)reader["Id"], JobPositionIdentifier=(string)reader["JobPositionIdentifier"], JobPositionName=(string)reader["JobPositionName"], JobPositionLevelCode=
			(string)reader["JobPositionLevelCode"], InstitutionIdentifier=(string)reader["InstitutionIdentifier"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewSalaryAgreement> GetViewSalaryAgreementListFromReader(IDataReader reader) { List<ViewSalaryAgreement> result=new(); while (reader.Read()) { ViewSalaryAgreement entity=new() {
		Id=(int)reader["Id"], EmploymentIdentifier=(string)reader["EmploymentIdentifier"], InstitutionIdentifier=(string)reader["InstitutionIdentifier"], ActivationDate=(DateTime)reader["ActivationDate"],
		DeactivationDate=(DateTime)reader["DeactivationDate"], SalaryAgreementIdentifier=(string)reader["SalaryAgreementIdentifier"], SalaryClassIdentifier=(string)reader["SalaryClassIdentifier"],
		SalaryScaleIdentifier=(string)reader["SalaryScaleIdentifier"], PrepaidIndicator=(bool)reader["PrepaidIndicator"], SeniorityDate=(DateTime)reader["SeniorityDate"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewSalaryCodeGroup> GetViewSalaryCodeGroupListFromReader(IDataReader reader) { List<ViewSalaryCodeGroup> result=new(); while (reader.Read()) { ViewSalaryCodeGroup entity=new() { Id=(int)reader["Id"],
		EmploymentIdentifier=(string)reader["EmploymentIdentifier"], InstitutionIdentifier=(string)reader["InstitutionIdentifier"], ActivationDate=(DateTime)reader["ActivationDate"], DeactivationDate=
			(DateTime)reader["DeactivationDate"], PensionCode=(string)reader["PensionCode"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<ViewWorkingTime> GetViewWorkingTimeListFromReader(IDataReader reader) { List<ViewWorkingTime> result=new(); while (reader.Read()) { ViewWorkingTime entity=new() { Id=(int)reader["Id"],
		EmploymentIdentifier=(string)reader["EmploymentIdentifier"], InstitutionIdentifier=(string)reader["InstitutionIdentifier"], ActivationDate=(DateTime)reader["ActivationDate"], DeactivationDate=
			(DateTime)reader["DeactivationDate"], OccupationRate=(string)reader["OccupationRate"], SalaryRate=(string)reader["SalaryRate"], SalariedIndicator=(bool)reader["SalariedIndicator"], AutomaticRaiseIndicator=
				(bool)reader["AutomaticRaiseIndicator"], FullTimeIndicator=(bool)reader["FullTimeIndicator"] }; result.Add(entity); } return result; }

	/// <returns>Result as List{T}</returns><param name="reader" />
	private static List<XmEmployment> GetViewXmEmploymentsFromReader(IDataReader reader) { List<XmEmployment> result=new(); while (reader.Read()) { XmEmployment entity=new() {
		EmploymentId=(string)reader["EmploymentId"], Cpr=(string)reader["Cpr"], GivenName=(string)reader["GivenName"], SurName=(string)reader["SurName"], Silo=(string)reader["Silo"],
		DeactivationDate=(DateTime)reader["DeactivationDate"], Email1=(string)reader["Email1"], Email2=(string)reader["Email2"] }; result.Add(entity); } return result; }

	#endregion

	#endregion
	#pragma warning restore CS8602
	#pragma warning restore CS8603

}
