// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Retrieve.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace LogicTier;

/// <remarks/>
public partial class Bizz // Retrieve
{

	#region Methods

	/// <summary>Retrieve data from Silkeborg Data</summary><param name="institutionId" />
	protected void RetrieveData(string institutionId) { WriteStringLineToLogFile("- Log for "+Config.AppName+" initiated "+DateTime.Now.ToString("r")+" - "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine+
			Environment.NewLine+"- Preparing retrieval of data for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine); Console.WriteLine("- Forbereder hentning af data for "+institutionId);
		if (SetConfigParams()) { RetrieveApiFromSD(institutionId); Garbage.Collect(); WriteStringLineToLogFile("- Log "+Config.AppName+" concluded "+DateTime.Now.ToString("r")+" - "+CurrentMethod()+" line "+CurrentLineNumber()); } }

	#region Retrieve API

	/// <returns>View3in1Organizations as csv string</returns><param name="view" />
	public static async Task<string> Retrieve3in1Organizations(DbSet<View3in1Organization> view) { if (view == null) throw new NullReferenceException("- View3in1Organizations was not found"+Environment.NewLine+"  "+
		StatusCodes.Status404NotFound); List<View3in1Organization> result= await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[View3in1Organizations] ORDER BY AfdelingsId,Overordnet").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>View3in1OrganizationStructures as csv string</returns><param name="view" />
	public static async Task<string> Retrieve3in1OrganizationStructures(DbSet<View3in1OrganizationStructure> view) { if (view == null) throw new NullReferenceException("- View3in1OrganizationStructures was not found"+
		Environment.NewLine+"  "+StatusCodes.Status404NotFound); List<View3in1OrganizationStructure> result=await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[View3in1OrganizationStructures] ORDER BY Afdelingsniveau,Overordnet").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>View3in1Persons as csv string</returns><param name="view" />
	public static async Task<string> Retrieve3in1Persons(DbSet<View3in1Person> view) { if (view == null) throw new NullReferenceException("- View3in1Persons was not found"+Environment.NewLine+"  "+StatusCodes.Status404NotFound);
		List<View3in1Person> result=await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[View3in1Persons] ORDER BY Cpr,Tjenestenummer").ToListAsync(); 
		return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewContactInformationList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveContactInformationList(DbSet<ViewContactInformation> view) { if (view == null) throw new NullReferenceException("- View3in1ContactInformationList was not found"+Environment.NewLine+
		"  "+StatusCodes.Status404NotFound); List<ViewContactInformation> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewContactInformationListHB]").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewDepartmentLevelReferenceList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveDepartmentLevelReferenceList(DbSet<ViewDepartmentLevelReference> view) { if (view == null) throw new NullReferenceException("- ViewDepartmentLevelReferenceList was not found"+
		Environment.NewLine+"  "+StatusCodes.Status404NotFound); List<ViewDepartmentLevelReference> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewDepartmentLevelReferenceListHB]").ToListAsync(); return ConvertApiEntityListToCsvString(result);	}

	/// <returns>ViewDepartmentList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveDepartmentList(DbSet<ViewDepartment> view) { if (view == null) throw new NullReferenceException("- ViewDepartmentList was not found"+Environment.NewLine+"  "+
		StatusCodes.Status404NotFound); List<ViewDepartment> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewDepartmentListHB]").ToListAsync(); return ConvertApiEntityListToCsvString(result);}

	/// <returns>ViewDepartmentReferenceList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveDepartmentReferenceList(DbSet<ViewDepartmentReference> view) { if (view == null) throw new NullReferenceException("- ViewDepartmentReferenceList was not found"+Environment.NewLine+
		"  "+StatusCodes.Status404NotFound); List<ViewDepartmentReference> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewDepartmentReferenceListHB]").ToListAsync(); return ConvertApiEntityListToCsvString(result);	}

	/// <returns>ViewEmploymentList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveEmploymentList(DbSet<ViewEmployment> view) { if (view == null) throw new NullReferenceException("- ViewEmploymentList was not found"+Environment.NewLine+"  "+
		StatusCodes.Status404NotFound); List<ViewEmployment> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewEmploymentListHB]").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewEmploymentProfessionList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveEmploymentProfessionList(DbSet<ViewEmploymentProfession> view) { if (view == null) throw new NullReferenceException("- ViewEmploymentProfessionList was not found"+
		Environment.NewLine+"  "+StatusCodes.Status404NotFound); List<ViewEmploymentProfession> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewEmploymentProfessionListHB]").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewEmploymentStatusList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveEmploymentStatusList(DbSet<ViewEmploymentStatus> view) { if (view == null) throw new NullReferenceException("- ViewEmploymentStatusList was not found"+Environment.NewLine+"  "+
		StatusCodes.Status404NotFound); List<ViewEmploymentStatus> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewEmploymentstatusListHB]").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewInstitutionList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveInstitutionList(DbSet<ViewInstitution> view) { if (view == null) throw new NullReferenceException("- ViewInstitutionList was not found"+Environment.NewLine+"  "+
		StatusCodes.Status404NotFound); List<ViewInstitution> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewInstitutionList]").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewKantineList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveKantineList(DbSet<ViewKantine> view) { if (view == null) throw new NullReferenceException("- ViewKantineList was not found"+Environment.NewLine+"  "+StatusCodes.Status404NotFound);
		List<ViewKantine> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewKantineList] ORDER BY Cpr,Tjenestenummer,Afdelingskode,Beskæftigelsesdecimal DESC").ToListAsync(); return ConvertApiEntityListToCsvString(result);	}

	/// <returns>ViewMochs as csv string</returns><param name="view" />
	public static async Task<string> RetrieveMochs(DbSet<ViewMoch> view) { if (view == null) throw new NullReferenceException("- ViewMochs was not found"+Environment.NewLine+"  "+StatusCodes.Status404NotFound);
		List<ViewMoch> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewMochs] ORDER BY [Afdeling],[Tjenestenummer],[Efternavn],[Fornavn]").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewOrganizationList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveOrganizationList(DbSet<ViewOrganization> view) { if (view == null) throw new NullReferenceException("- ViewOrganizationList was not found"+Environment.NewLine+"  "+
		StatusCodes.Status404NotFound); List<ViewOrganization> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewOrganizationList]").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewOrganizationStructureList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveOrganizationStructureList(DbSet<ViewOrganizationStructure> view) { if (view == null) throw new NullReferenceException("- ViewOrganizationStructureList was not found"+
		Environment.NewLine+"  "+StatusCodes.Status404NotFound); List<ViewOrganizationStructure> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewOrganizationStructureList]").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewPersonList as csv string</returns><param name="view" />
	public static async Task<string> RetrievePersonList(DbSet<ViewPerson> view) { if (view == null) throw new NullReferenceException("- ViewPersonList was not found"+Environment.NewLine+"  "+StatusCodes.Status404NotFound);
	List<ViewPerson> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewPersonListHB]").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewPostalAddressList as csv string</returns><param name="view" />
	public static async Task<string> RetrievePostalAddressList(DbSet<ViewPostalAddress> view) { if (view == null) throw new NullReferenceException("- ViewPostalAddressList was not found"+Environment.NewLine+"  "+
		StatusCodes.Status404NotFound); List<ViewPostalAddress> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewPostalAddressListHB]").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewProfessionList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveProfessionList(DbSet<ViewProfession> view) { if (view == null) throw new NullReferenceException("- ViewProfessionList was not found"+Environment.NewLine+"  "+
		StatusCodes.Status404NotFound); List<ViewProfession> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewProfessionListHB]").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewSalaryAgreementList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveSalaryAgreementList(DbSet<ViewSalaryAgreement> view) { if (view == null) throw new NullReferenceException("- ViewSalaryAgreementList was not found"+Environment.NewLine+"  "+
		StatusCodes.Status404NotFound); List<ViewSalaryAgreement> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewSalaryAgreementListHB]").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewSalaryCodeGroupList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveSalaryCodeGroupList(DbSet<ViewSalaryCodeGroup> view) { if (view == null) throw new NullReferenceException("- ViewSalaryCodeGroupList was not found" + Environment.NewLine+"  "+
		StatusCodes.Status404NotFound); List<ViewSalaryCodeGroup> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewSalaryCodeGroupListHB]").ToListAsync(); return ConvertApiEntityListToCsvString(result); }

	/// <returns>ViewWorkingTimeList as csv string</returns><param name="view" />
	public static async Task<string> RetrieveWorkingTimeList(DbSet<ViewWorkingTime> view) { if (view == null) throw new NullReferenceException("- ViewWorkingTimeList was not found"+Environment.NewLine+"  "+StatusCodes.Status404NotFound);
		List<ViewWorkingTime> result = await view.FromSqlRaw("SELECT DISTINCT * FROM [SD].[dbo].[ViewWorkingTimeListHB]").ToListAsync();
		return ConvertApiEntityListToCsvString(result); }

	#endregion

	#region Retrieve SD API

	/// <summary>Retrieves,cleans and updates daily changes of Person and Employment data from SD-data</summary><param name="institutionId" />
	protected void RetrieveApiFromSD(string institutionId) { switch (Config.AppName.ToLower()) { case "sddbdepdataclone": RetrieveApiFromSdDepData(institutionId); break;
		case "sddbdataclone": RetrieveApiFromSdDataClone(institutionId); break;
		case "sddbdataupdate": RetrieveApiFromSdDataUpdate(institutionId); break; default: throw new InvalidRefException(nameof(Config.RunMode),Config.RunMode,nameof(Config.RunMode)+Error.UnkParam); } }

	/// <remarks /><param name="institutionId" /><exception cref="ArgumentInvalidException" />
	protected void RetrieveApiFromSdDataClone(string institutionId) { switch (institutionId.ToUpper()) { case "NO": RetrievePersonFromSD("HB"); RetrievePersonFromSD("HI"); RetrievePersonFromSD("HW"); 
			RetrieveEmploymentFromSD("HB"); RetrieveEmploymentFromSD("HI"); RetrieveEmploymentFromSD("HW"); break; case "hb": RetrievePersonFromSD("HB"); RetrieveEmploymentFromSD("HB"); break;
		case "hi": RetrievePersonFromSD("HI"); RetrieveEmploymentFromSD("HI"); break; case "hw": RetrievePersonFromSD("HW"); RetrieveEmploymentFromSD("HW"); break;
		default: throw new ArgumentInvalidException(nameof(institutionId),institutionId,nameof(institutionId)+Error.UnkArg); } }

	/// <remarks /><param name="institutionId" /><exception cref="ArgumentInvalidException" />
	protected void RetrieveApiFromSdDataUpdate(string institutionId) { switch (institutionId.ToUpper()) {
		case "NO": RetrievePersonChangedAtDateFromSD("HB"); RetrievePersonChangedAtDateFromSD("HI"); RetrievePersonChangedAtDateFromSD("HW"); RetrieveEmploymentChangedAtDateFromSD("HB"); RetrieveEmploymentChangedAtDateFromSD("HI");
			RetrieveEmploymentChangedAtDateFromSD("HW"); break;
		case "hb": RetrievePersonChangedAtDateFromSD("HB"); RetrieveEmploymentChangedAtDateFromSD("HB"); break; case "hi": RetrievePersonChangedAtDateFromSD("HI"); RetrieveEmploymentChangedAtDateFromSD("HI"); break;
		case "hw": RetrievePersonChangedAtDateFromSD("HW"); RetrieveEmploymentChangedAtDateFromSD("HW"); break;
		default: throw new ArgumentInvalidException(nameof(institutionId),institutionId,nameof(institutionId)+Error.UnkParam); } }

	/// <remarks /><param name="institutionId" /><exception cref="ArgumentInvalidException" />
	protected void RetrieveApiFromSdDepData(string institutionId) { switch (institutionId.ToUpper()) { 
		case "NO": RetrieveInstitutionFromSD(); RetrieveOrganizationFromSD("HB"); RetrieveOrganizationFromSD("HI"); RetrieveOrganizationFromSD("HW"); RetrieveProfessionFromSD("HB"); RetrieveProfessionFromSD("HI");
			RetrieveProfessionFromSD("HW"); RetrieveDepartmentFromSD("HB"); RetrieveDepartmentFromSD("HI"); RetrieveDepartmentFromSD("HW"); break;
		case "hb": RetrieveInstitutionFromSD(); RetrieveOrganizationFromSD("HB"); RetrieveProfessionFromSD("HB"); RetrieveDepartmentFromSD("HB"); break;
		case "hi": RetrieveInstitutionFromSD(); RetrieveOrganizationFromSD("HI"); RetrieveProfessionFromSD("HI"); RetrieveDepartmentFromSD("HI"); break;
		case "hw": RetrieveInstitutionFromSD(); RetrieveOrganizationFromSD("HW"); RetrieveProfessionFromSD("HW"); RetrieveDepartmentFromSD("HW"); break;
		default: throw new InvalidRefException(nameof(institutionId),institutionId,nameof(institutionId)+Error.UnkParam); } }

	#endregion

	/// <summary>Retrieves the current domain path</summary><returns>Result as string</returns>
	#pragma warning disable CS8602
	#pragma warning disable CA1416
	protected static string RetrieveCurrentDomainPath() { using DirectoryEntry de = new("LDAP://RootDSE"); return "LDAP://" + de.Properties["defaultNamingContext"][0].ToString(); }
	#pragma warning restore CS8602 // Converting null literal or possible null value to non-nullable type.
	#pragma warning restore CA1416

	/// <returns>Element Name from <paramref name="xml"/> as string</returns><param name="xml" />
	protected static string RetrieveElementNameFromXml(string xml) { using TextReader reader=new StringReader(xml); XDocument doc=XDocument.Load(reader); foreach (XElement xElement in doc.Descendants()) { switch (xElement.Name.ToString()) {
		case "GetDepartment20111201": return "GetDepartment20111201"; case "GetEmployment20111201": return "GetEmployment20111201"; case "GetEmploymentChanged20111201": return "GetEmploymentChanged20111201";
		case "GetEmploymentChangedAtDate20111201": return "GetEmploymentChangedAtDate20111201"; case "GetInstitution20111201": return "GetInstitution20111201"; case "GetOrganization20111201": return "GetOrganization20111201";
		case "GetPerson20111201": return "GetPerson20111201"; case "GetPersonChangedAtDate20111201": return "GetPersonChangedAtDate20111201"; case "GetProfession20080201": return "GetProfession20080201"; default: break; } } return string.Empty; }

	/// <remarks/>
	#pragma warning disable CS8604
	protected int RetrieveOldest<T>(T entity1,T entity2) where T : class { if (!entity1.GetType().Equals(entity2.GetType())) throw new InvalidRefException("entity1 and entity2 must have the same type.");
		string type=typeof(T).Name.ToLower(); return type switch { "contactinformation" => RetrieveOldestContactInformation(entity1 as ContactInformation,entity2 as ContactInformation),
			"department" => RetrieveOldestDepartment(entity1 as Department,entity2 as Department), "departmentlevelreference" => RetrieveOldestDepartmentLevelReference(entity1 as DepartmentLevelReference,entity2 as DepartmentLevelReference),
			"departmentreference" => RetrieveOldestDepartmentReference(entity1 as DepartmentReference,entity2 as DepartmentReference), "employment" => RetrieveOldestEmployment(entity1 as Employment,entity2 as Employment),
			"employmentprofession" => RetrieveOldestEmploymentProfession(entity1 as EmploymentProfession,entity2 as EmploymentProfession), "employmentstatus" => RetrieveOldestEmploymentStatus(entity1 as EmploymentStatus,entity2 as EmploymentStatus), 
			"institution" => RetrieveOldestInstitution(entity1 as Institution,entity2 as Institution), "organization" => RetrieveOldestOrganization(entity1 as Organization,entity2 as Organization),
			"organizationstructure" => RetrieveOldestOrganizationStructure(entity1 as OrganizationStructure,entity2 as OrganizationStructure), "person" => RetrieveOldestPerson(entity1 as Person,entity2 as Person),
			"postaladdress" => RetrieveOldestPostalAddress(entity1 as PostalAddress,entity2 as PostalAddress), "profession" => RetrieveOldestProfession(entity1 as Profession,entity2 as Profession),
			"salaryagreement" => RetrieveOldestSalaryAgreement(entity1 as SalaryAgreement,entity2 as SalaryAgreement), "salarycodegroup" => RetrieveOldestSalaryCodeGroup(entity1 as SalaryCodeGroup,entity2 as SalaryCodeGroup),
			"workingtime" => RetrieveOldestWorkingTime(entity1 as WorkingTime,entity2 as WorkingTime), _ => throw new InvalidRefException(), }; }
	#pragma warning restore CS8604

	#region Private

	/// <summary>Sets Fromdate for RunMode</summary><param name="institutionId" /><param name="sdApi" />
	private string RetrieveFromDate(string institutionId,string sdApi) { Dictionary<string,SuccessfulRun> dict=GetSuccessfulRunDict();
		if (sdApi.ToLower().Equals("getdepartment")) { if (dict.ContainsKey(institutionId+"-GetDepartment")&&!dict[institutionId+"-GetDepartment"].RunDate.IsNullOrWhiteSpace())
			return dict[institutionId+"-GetDepartment"].RunDate; else return DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"); }
		else if (sdApi.ToLower().Equals("getemploymentchanged")) { if (dict.ContainsKey(institutionId+"-GetEmployment")&&!dict[institutionId+"-GetEmployment"].RunDate.IsNullOrWhiteSpace())
			return dict[institutionId+"-GetEmploymentChanged"].RunDate; else return DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"); }
		else if (sdApi.ToLower().Equals("getemploymentchangedatdate")) { if (dict.ContainsKey(institutionId+"-GetEmploymentChangedAtDate")&&!dict[institutionId+"-GetEmploymentChangedAtDate"].RunDate.IsNullOrWhiteSpace())
			return dict[institutionId+"-GetEmploymentChangedAtDate"].RunDate; else if (dict.ContainsKey(institutionId+"-GetEmployment")&&!dict[institutionId+"-GetEmployment"].RunDate.IsNullOrWhiteSpace())
				return dict[institutionId+"-GetEmployment"].RunDate; else return DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"); }
		else if (sdApi.ToLower().Equals("getinstitution")) { if (dict.ContainsKey(institutionId+"-GetInstitution")&&!dict[institutionId+"-GetInstitution"].RunDate.IsNullOrWhiteSpace())
			return dict[institutionId+"-GetInstitution"].RunDate; else return DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"); }
		else if (sdApi.ToLower().Equals("getorganization")) { if (dict.ContainsKey(institutionId+"-GetOrganization")&&!dict[institutionId+"-GetOrganization"].RunDate.IsNullOrWhiteSpace())
			return dict[institutionId+"-GetOrganization"].RunDate; else return DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"); }
		else if (sdApi.ToLower().Equals("getpersonchangedatdate")) { if (dict.ContainsKey(institutionId+"-GetPersonChangedAtDate")&&!dict[institutionId+"-GetPersonChangedAtDate"].RunDate.IsNullOrWhiteSpace())
			return dict[institutionId+"-GetPersonChangedAtDate"].RunDate; else if (dict.ContainsKey(institutionId+"-GetPerson")&&!dict[institutionId+"-GetPerson"].RunDate.IsNullOrWhiteSpace())
				return dict[institutionId+"-GetPerson"].RunDate; else return DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"); }
		else if (sdApi.ToLower().Equals("getprofession")) { if (dict.ContainsKey(institutionId+"-GetProfession")&&!dict[institutionId+"-GetProfession"].RunDate.IsNullOrWhiteSpace())
			return dict[institutionId+"-GetProfession"].RunDate; else return DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"); }
		else return DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"); }

	#region Retrieve From Sd

	/// <summary>Retrieves,cleans and update data from GetDepartment API for <paramref name="institutionId"/> from SD-data</summary><param name="institutionId" />
	private string RetrieveDepartmentFromSD(string institutionId) { WriteStringLineToLogFile("- Initiate retrieval of departments for "+institutionId+" - "+"- "+CurrentMethod()+" line "+CurrentLineNumber()); 
		Console.WriteLine("- Henter afdelinger for "+institutionId); try { string result=InitiateRetrieveXml(institutionId,"GetDepartment"); Garbage.Collect(); return result; } 
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred while retrieving department data for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); return string.Empty; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred while retrieving department data for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); return string.Empty; }  }

	/// <summary>Retrieves,cleans and update data from GetDepartment API for <paramref name="institutionId"/> from SD-data</summary><param name="institutionId" />
	private string RetrieveEmploymentFromSD(string institutionId) { WriteStringLineToLogFile("- Initiate retrieval of employments for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber());
			Console.WriteLine("- Henter ansættelser for "+institutionId); try { string result=InitiateRetrieveXml(institutionId,"GetEmployment"); Garbage.Collect(); return result; } 
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred while retrieving employment data for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); return string.Empty; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred while retrieving employment data for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); return string.Empty; }  }

	/// <summary>Retrieves,cleans and update data from GetEmploymentChanged API for <paramref name="institutionId"/> from SD-data</summary><param name="institutionId" />
	private string RetrieveEmploymentChangedFromSD(string institutionId) { WriteStringLineToLogFile("- Initiate retrieval of changed employments for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber());
			Console.WriteLine("- Henter ændrede ansættelser for "+institutionId); try { string result=InitiateRetrieveXml(institutionId,"GetEmploymentChanged"); Garbage.Collect(); return result; } 
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred while retrieving changed employment data for "+institutionId+":"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine+" - "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine); Garbage.Collect(); return string.Empty; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred while retrieving changed employment data for "+institutionId+":"+Environment.NewLine+
			ExpressionException.ToErrorString(ex)+Environment.NewLine+"- "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine); Garbage.Collect(); return string.Empty; }  }

	/// <summary>Retrieves,cleans and update data from GetEmploymentChangedAtDate API for <paramref name="institutionId"/> from SD-data</summary><param name="institutionId" />
	private string RetrieveEmploymentChangedAtDateFromSD(string institutionId) { WriteStringLineToLogFile("- Initiate retrieval of employments changed at date for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber());
			Console.WriteLine("- Henter ansættelser ændret på dato for "+institutionId); try { string result=InitiateRetrieveXml(institutionId,"GetEmploymentChangedAtDate"); Garbage.Collect(); return result; } 
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred while retrieving employment data changed at date data for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+
			Environment.NewLine+eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); return string.Empty; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred while retrieving employment data changed at date for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+
			Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); return string.Empty; }  }

	/// <summary>Retrieves,cleans and update data from GetInstitution API at SD-data</summary>
	private string RetrieveInstitutionFromSD() { WriteStringLineToLogFile("- Initiate retrieval of institutions - "+CurrentMethod()+" line "+CurrentLineNumber()); Console.WriteLine("- Henter institutioner");
		try { string result=InitiateRetrieveXml("HB","GetInstitution"); Garbage.Collect(); return result; }  catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred while retrieving GetInstitution data:"+
			Environment.NewLine+eex.ToErrorString()+Environment.NewLine+"- "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine); Garbage.Collect(); return string.Empty; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred while retrieving GetInstitution data:"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine+
			"- "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine); Garbage.Collect(); return string.Empty; }  }

	/// <summary>Retrieves,cleans and update data from GetOrganization API for <paramref name="institutionId"/> from SD-data</summary><param name="institutionId" />
	private string RetrieveOrganizationFromSD(string institutionId) { WriteStringLineToLogFile("- Initiate retrieval of organizations for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber());
			Console.WriteLine("- Henter organisationer m.v for "+institutionId); try { string result=InitiateRetrieveXml(institutionId,"GetOrganization"); Garbage.Collect(); return result; } 
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred while retrieving "+institutionId+" data for GetOrganization:"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine+
			"- "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine); Garbage.Collect(); return string.Empty; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred while retrieving GetOrganization data for "+institutionId+":"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine+
			"- "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine); Garbage.Collect(); return string.Empty; } }

	/// <summary>Retrieves,cleans and update data from GetPerson API for <paramref name="institutionId"/> from SD-data</summary><param name="institutionId" />
	private string RetrievePersonFromSD(string institutionId) { WriteStringLineToLogFile("- Initiate retrieval of persons for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber());
			Console.WriteLine("- Henter personer for "+institutionId); try { string result=InitiateRetrieveXml(institutionId,"GetPerson"); Garbage.Collect(); return result; } 
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred while retrieving person data for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); return string.Empty; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred while retrieving person data for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); return string.Empty; }  }

	/// <summary>Retrieves,cleans and update data from GetPersonChangedAtDate API for <paramref name="institutionId"/> from SD-data</summary><param name="institutionId" />
	private string RetrievePersonChangedAtDateFromSD(string institutionId) { WriteStringLineToLogFile("- Initiate retrieval of persons changed at date for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber());
			Console.WriteLine("- Henter personer ændret på dato for "+institutionId); try { string result=InitiateRetrieveXml(institutionId,"GetPersonChangedAtDate"); Garbage.Collect(); return result; }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while retrieving person data changed at date for "+institutionId+":"+Environment.NewLine+eex.ToErrorString()+
			Environment.NewLine+"- "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine); Garbage.Collect(); return string.Empty; }
		catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred while retrieving person data changed at date for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+":"+
			Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); return string.Empty; } }

	/// <summary>Retrieves,cleans and update data from GetProfession API for <paramref name="institutionId"/> from SD-data</summary><param name="institutionId" />
	private string RetrieveProfessionFromSD(string institutionId) { WriteStringLineToLogFile("- Initiate retrieval of professions for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber());
			Console.WriteLine("- Henter professioner for "+institutionId); try { string result=InitiateRetrieveXml(institutionId,"GetProfession"); Garbage.Collect(); return result; }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred while retrieving profession data for "+institutionId+"- "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			eex.ToErrorString()+Environment.NewLine); Garbage.Collect(); return string.Empty; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred while retrieving profession data for "+institutionId+"- "+CurrentMethod()+" line "+CurrentLineNumber()+":"+Environment.NewLine+
			ExpressionException.ToErrorString(ex)+Environment.NewLine); Garbage.Collect(); return string.Empty; }  }

	#endregion

	///<remarks /><param name="user" />
	private static string RetrieveInstitutionIdentifier(ADUser user) => user.PrimaryGroupId;

	/// <returns>Node count from an <paramref name="xml"/> as string</returns><param name="sdApi" /><param name="xml" /><exception cref="ArgumentInvalidException" />
	private int RetrieveNodeCountFromxml(string sdApi,string xml) => sdApi switch { "GetDepartment" => XmlSerializationUtil.Deserialize<GetDepartment20111201>(xml).Departments.Count,
		"GetEmployment" => XmlSerializationUtil.Deserialize<GetEmployment20111201>(xml).Persons.Count, "GetEmploymentChanged" => XmlSerializationUtil.Deserialize<GetEmploymentChanged20111201>(xml).Persons.Count,
		"GetEmploymentChangedAtDate" => XmlSerializationUtil.Deserialize<GetEmploymentChangedAtDate20111201>(xml).Persons.Count, "GetInstitution" => XmlSerializationUtil.Deserialize<GetInstitution20111201>(xml).Region.Institutions.Count,
		"GetOrganization" => XmlSerializationUtil.Deserialize<GetOrganization20111201>(xml).Organizations.Count, "GetPerson" => XmlSerializationUtil.Deserialize<GetPerson20111201>(xml).Persons.Count,
		"GetPersonChangedAtDate" => XmlSerializationUtil.Deserialize<GetPersonChangedAtDate20111201>(xml).Persons.Count, "GetProfession" => XmlSerializationUtil.Deserialize<GetProfession20080201>(xml).Professions.Count,
		_ => throw new ArgumentInvalidException(nameof(sdApi),sdApi,sdApi+Error.UnkAPI), };

	#region Retrieve Oldest

	/// <remarks/>
	private int RetrieveOldestContactInformation(ContactInformation entity1,ContactInformation entity2) {if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 and entity2 does "+
		"not have the same ParentIdentifier and InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.Id.Equals(entity2.Id)) return 0; if (entity1.Id<entity2.Id) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestDepartment(Department entity1,Department entity2) { if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 and entity2 does not have the "+
		"same DepartmentIdentifier and InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id.Equals(entity2.Id)) return 0;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id<entity2.Id) return 1;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id>entity2.Id) return 2;
		else if (entity1.ActivationDate<entity2.ActivationDate) return 1; else if (entity1.ActivationDate>entity2.ActivationDate) return 2 ;
		else if (entity1.DeactivationDate<entity2.DeactivationDate) return 1; else return 2 ; }

	/// <remarks/>
	private int RetrieveOldestDepartmentLevelReference(DepartmentLevelReference entity1,DepartmentLevelReference entity2) { if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- entity1 and entity2 "+
		"does not have the same OrganizationStructureIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.Id.Equals(entity2.Id)) return 0; else if (entity1.Id<entity2.Id) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestDepartmentReference(DepartmentReference entity1,DepartmentReference entity2) { WriteStringLineToLogFile("- Error: entity1 and entity2 does not have the same OrganizationIdentifier"+
		Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); if (entity1.Id.Equals(entity2.Id)) return 0; else if (entity1.Id<entity2.Id) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestEmployment(Employment entity1,Employment entity2) { if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 and entity2 does not have the "+
		"same EmploymentIdentifier and InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.EmploymentDate.Equals(entity2.EmploymentDate)&&entity1.AnniversaryDate.Equals(entity2.AnniversaryDate)&&entity1.Id.Equals(entity2.Id)) return 0;
		else if (entity1.EmploymentDate.Equals(entity2.EmploymentDate)&&entity1.AnniversaryDate.Equals(entity2.AnniversaryDate)&&entity1.Id<entity2.Id) return 1;
		else if (entity1.EmploymentDate.Equals(entity2.EmploymentDate)&&entity1.AnniversaryDate.Equals(entity2.AnniversaryDate)&&entity1.Id>entity2.Id) return 2;
		else if (entity1.EmploymentDate<entity2.EmploymentDate) return 1; else if (entity1.EmploymentDate>entity2.EmploymentDate) return 2;
		else if (entity1.AnniversaryDate<entity2.AnniversaryDate) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestEmploymentProfession(EmploymentProfession entity1,EmploymentProfession entity2) { if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 and entity2 does "+
		"not have the same EmploymentIdentifier and InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id.Equals(entity2.Id)) return 0;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id<entity2.Id) return 1;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id>entity2.Id) return 2;
		else if (entity1.ActivationDate<entity2.ActivationDate) return 1; else if (entity1.ActivationDate>entity2.ActivationDate) return 2;
		else if (entity1.DeactivationDate<entity2.DeactivationDate) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestEmploymentStatus(EmploymentStatus entity1,EmploymentStatus entity2) { if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 and entity2 does not have "+
		"the same EmploymentIdentifier and InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id.Equals(entity2.Id)) return 0;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id<entity2.Id) return 1;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id>entity2.Id) return 2;
		else if (entity1.ActivationDate<entity2.ActivationDate) return 1; else if (entity1.ActivationDate>entity2.ActivationDate) return 2;
		else if (entity1.DeactivationDate<entity2.DeactivationDate) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestInstitution (Institution entity1,Institution entity2) { if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 and entity2 does not "+
		"have the same InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.Id.Equals(entity2.Id)) return 0; else if (entity1.Id<entity2.Id) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestOrganization (Organization entity1,Organization entity2) {  if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 and entity2 does not "+
		"have the same InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id.Equals(entity2.Id)) return 0;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id<entity2.Id) return 1;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id>entity2.Id) return 2;
		else if (entity1.ActivationDate<entity2.ActivationDate) return 1; else if (entity1.ActivationDate>entity2.ActivationDate) return 2;
		else if (entity1.DeactivationDate<entity2.DeactivationDate) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestOrganizationStructure (OrganizationStructure entity1,OrganizationStructure entity2) { if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 "+
		"and entity2 does not have the same InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.Id.Equals(entity2.Id)) return 0; else if (entity1.Id<entity2.Id) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestPerson (Person entity1,Person entity2) { if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 and entity2 does not have the same "+
		"PersonCivilRegistrationIdentifier and InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.Id.Equals(entity2.Id)) return 0; else if (entity1.Id<entity2.Id) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestPostalAddress(PostalAddress entity1,PostalAddress entity2) { if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 and entity2 does not have "+
		"the same ParentIdentifier and InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.Id.Equals(entity2.Id)) return 0; else if (entity1.Id<entity2.Id) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestProfession(Profession entity1,Profession entity2) { if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 and entity2 does not have the same "+
		"EmploymentIdentifier and InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id.Equals(entity2.Id)) return 0;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id<entity2.Id) return 1;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id>entity2.Id) return 2;
		else if (entity1.ActivationDate<entity2.ActivationDate) return 1; else if (entity1.ActivationDate>entity2.ActivationDate) return 2;
		else if (entity1.DeactivationDate<entity2.DeactivationDate) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestSalaryAgreement(SalaryAgreement entity1,SalaryAgreement entity2) { if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 and entity2 does not have "+
		"the same EmploymentIdentifier and InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id.Equals(entity2.Id)) return 0;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id<entity2.Id) return 1;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id>entity2.Id) return 2;
		else if (entity1.ActivationDate<entity2.ActivationDate) return 1; else if (entity1.ActivationDate>entity2.ActivationDate) return 2;
		else if (entity1.DeactivationDate<entity2.DeactivationDate) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestSalaryCodeGroup(SalaryCodeGroup entity1,SalaryCodeGroup entity2) { if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 and entity2 does not have "+
		"the same EmploymentIdentifier and InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id.Equals(entity2.Id)) return 0;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id<entity2.Id) return 1;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id>entity2.Id) return 2;
		else if (entity1.ActivationDate<entity2.ActivationDate) return 1; else if (entity1.ActivationDate>entity2.ActivationDate) return 2;
		else if (entity1.DeactivationDate<entity2.DeactivationDate) return 1; else return 2; }

	/// <remarks/>
	private int RetrieveOldestWorkingTime(WorkingTime entity1,WorkingTime entity2) { if (!entity1.TKey.Equals(entity2.TKey)) { WriteStringLineToLogFile("- Error: entity1 and entity2 does not have the "+
		"same EmploymentIdentifier and InstitutionIdentifier"+Environment.NewLine+"- entity1: "+entity1.TKey+" - entity2: "+entity2.TKey+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return -1; }
		if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id.Equals(entity2.Id)) return 0;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id<entity2.Id) return 1;
		else if (entity1.ActivationDate.Equals(entity2.ActivationDate)&&entity1.DeactivationDate.Equals(entity2.DeactivationDate)&&entity1.Id>entity2.Id) return 2;
		else if (entity1.ActivationDate<entity2.ActivationDate) return 1; else if (entity1.ActivationDate>entity2.ActivationDate) return 2;
		else if (entity1.DeactivationDate<entity2.DeactivationDate) return 1; else return 2; }

	#endregion

	/// <returns>SdApi from <paramref name="xml"/> as string</returns><param name="xml" />
	private string RetrieveSdApiFromxml(string xml) { string entityType=RetrieveElementNameFromXml(xml); return entityType switch { "GetDepartment20111201" => "GetDepartment", "GetEmployment20111201" => "GetEmployment",
		"GetEmploymentChanged20111201" => "GetEmploymentChanged", "GetEmploymentChangedAtDate20111201" => "GetEmploymentChangedAtDate", "GetInstitution20111201" => "GetInstitution", "GetOrganization20111201" => "GetOrganization",
		"GetPerson20111201" => "GetPerson", "GetPersonChangedAtDate20111201" => "GetPersonChangedAtDate", "GetProfession20080201" => "GetProfession", _ => throw new InvalidRefException(nameof(entityType),entityType,nameof(entityType)+Error.UnkParam), }; }

	#endregion

	#endregion

}
