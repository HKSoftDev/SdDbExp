// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Miscellaneous.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Miscellaneous
{
	#region Methods

	/// <summary>Displays field count in <see cref="Console"/></summary>
	protected List<ADUser> DisplayFieldCount() { int userIds=0, titles=0, fullNames=0, displayNames=0, employeeIds=0, employeeNumbers=0, primaryGroupIds=0, memberOfs=0, initials=0;int givenNames=0;
		int surNames=0, emails=0, mPhones=0, offices=0, companies=0, departments=0, distinguishedNames=0, adsPathes=0;
		List<ADUser> list=SearchAllUsers(); ParseUserList(ref list); SaveUserList(list); foreach (ADUser user in list) { if (!user.UserId.IsNullOrWhiteSpace()) userIds++;
			if (!user.Title.IsNullOrWhiteSpace()) titles++; if (!user.FullName.IsNullOrWhiteSpace()) fullNames++; if (!user.DisplayName.IsNullOrWhiteSpace()) displayNames++; if (!user.EmployeeId.IsNullOrWhiteSpace()) employeeIds++;
			if (!user.EmployeeNumber.IsNullOrWhiteSpace()) employeeNumbers++; if (!user.PrimaryGroupId.IsNullOrWhiteSpace()) primaryGroupIds++; if (!user.MemberOf.IsNullOrWhiteSpace()) memberOfs++;
			if (!user.Initials.IsNullOrWhiteSpace()) initials++; if (!user.GivenName.IsNullOrWhiteSpace()) givenNames++; if (!user.SurName.IsNullOrWhiteSpace()) surNames++; if (!user.Mail.IsNullOrWhiteSpace()) emails++;
			if (!user.MobilePhone.IsNullOrWhiteSpace()) mPhones++; if (!user.Office.IsNullOrWhiteSpace()) offices++; if (!user.Company.IsNullOrWhiteSpace()) companies++; if (!user.Department.IsNullOrWhiteSpace()) departments++;
			if (!user.DistinguishedName.IsNullOrWhiteSpace()) distinguishedNames++; if (!user.AdsPath.IsNullOrWhiteSpace()) adsPathes++; }
		Console.WriteLine("- User Ids: "+userIds+Environment.NewLine+"- Titles: "+titles+Environment.NewLine+"- Full Names: "+fullNames+Environment.NewLine+"- Display Names: "+displayNames+
			Environment.NewLine+"- Employee Ids: "+employeeIds+Environment.NewLine+"- Employee Numbers: "+employeeNumbers+Environment.NewLine+"- Primary Group Ids: "+primaryGroupIds+
			Environment.NewLine+"- Member Ofs: "+memberOfs+Environment.NewLine+"- Initials: "+initials+Environment.NewLine+"- Given Names: "+givenNames+Environment.NewLine+"- Surnames: "+
			surNames+Environment.NewLine+"- Emails: "+emails+Environment.NewLine+"- Mobile Phones: "+mPhones+Environment.NewLine+"- Offices: "+offices+Environment.NewLine+"- Companies: "+
			companies+Environment.NewLine+"- Departments: "+departments+Environment.NewLine+"- Distinguished Names: "+distinguishedNames+Environment.NewLine+"- ADS Pathes: "+adsPathes+Environment.NewLine); return list; }

	///<remarks />
	protected void OptimizeContactInformations() { Config.CioInfoUpdated=true; List <ContactInformation> list=GetList<ContactInformation>(); for (int i=0; i<list.Count; i++) {
		if (!list[i].IsEmpty()) { ContactInformation info=list[i]; if (CheckCioPhoneNumbers(ref info)) { if (!UpdateOrCreateInDatabase(info)&&Config.CioInfoUpdated) Config.CioInfoUpdated=false; list[i]=info; } 
			if (CheckCioEmailAdresses(ref info)) { if (!UpdateOrCreateInDatabase(info)&&Config.CioInfoUpdated) Config.CioInfoUpdated=false; list[i]=info; } } } }

	///<remarks />
	protected void OptimizeEmploymentProfessions() { this.Config.ProfessionsOptimized=true; List<EmploymentProfession> list = GetList<EmploymentProfession>();
		Dictionary<string,Profession> dict = GetProfessionDict(); foreach (EmploymentProfession item in list) { if ((item.EmploymentName.IsNullOrWhiteSpace()||
			item.EmploymentName.ToLower().Equals("none"))&&dict.ContainsKey(item.InstitutionIdentifier+"-"+item.JobPositionIdentifier)) { item.EmploymentName=dict[item.JobPositionIdentifier+
				" - "+item.InstitutionIdentifier].JobPositionName; if(!UpdateOrCreateInDatabase(item)&&this.Config.ProfessionsOptimized) this.Config.ProfessionsOptimized=false; } } }

	/// <summary>Checks the Config.UserList for dublettes and removes users without useful data</summary>
	protected void ParseUserList(ref List<ADUser> list) { Console.WriteLine("- Brugere før validering: "+list.Count); int i=list.Count - 1; while (i>=0) { 
		if (!list[i].PrimaryGroupId.Equals("513")&&list.Count>=1) list.RemoveAt(i);  else if (!list[i].Mail.IsNullOrWhiteSpace()&&list[i].Mail.Remove(4).Equals("adm")&&list.Count>=1) list.RemoveAt(i); 
		else if ((list[i].EmployeeNumber.IsNullOrWhiteSpace()||list[i].EmployeeNumber.Remove(4).Equals("9999"))&&list.Count>=1) list.RemoveAt(i); else if (list[i].Department.IsNullOrWhiteSpace()) list.RemoveAt(i);
		else if (list[i].Mail.IsNullOrWhiteSpace()&&list[i].MobilePhone.IsNullOrWhiteSpace()) list.RemoveAt(i); i--; } Console.WriteLine("- Brugere efter validering: "+list.Count+Environment.NewLine); }

	/// <summary>Searches for all users in AD</summary>
	protected List<ADUser> SearchAllUsers() { List<ADUser> list=new(); using DirectoryEntry de=new(RetrieveCurrentDomainPath(),Resources.UDCSDUserame,Resources.UDCSDPassword); using DirectorySearcher ds=new(de);
		ds.PropertiesToLoad.Add("userprincipalname"); ds.PropertiesToLoad.Add("title"); ds.PropertiesToLoad.Add("name"); ds.PropertiesToLoad.Add("displayname"); ds.PropertiesToLoad.Add("employeeid");
		ds.PropertiesToLoad.Add("employeenumber"); ds.PropertiesToLoad.Add("primarygroupid"); ds.PropertiesToLoad.Add("memberOf"); ds.PropertiesToLoad.Add("initials"); ds.PropertiesToLoad.Add("givenname");
		ds.PropertiesToLoad.Add("sn"); ds.PropertiesToLoad.Add("mail"); ds.PropertiesToLoad.Add("mobile");  ds.PropertiesToLoad.Add("physicaldeliveryofficename"); ds.PropertiesToLoad.Add("company");
		ds.PropertiesToLoad.Add("department"); ds.PropertiesToLoad.Add("departmentNumber"); ds.PropertiesToLoad.Add("office"); ds.PropertiesToLoad.Add("distinguishedName"); ds.SearchScope=SearchScope.Subtree;
		ds.Filter="(objectClass=person)"; using SearchResultCollection results=ds.FindAll(); foreach (SearchResult sr in results) { list.Add(new ADUser(sr.RetrievePropertyValue("userprincipalname"),
			sr.RetrievePropertyValue("title"),sr.RetrievePropertyValue("name"),sr.RetrievePropertyValue("displayname"),sr.RetrievePropertyValue("employeeid"),sr.RetrievePropertyValue("employeenumber"),
			sr.RetrievePropertyValue("primarygroupid"),sr.RetrievePropertyValue("memberOf"),sr.RetrievePropertyValue("initials"),sr.RetrievePropertyValue("givenname"),sr.RetrievePropertyValue("sn"),
			sr.RetrievePropertyValue("mail"),sr.RetrievePropertyValue("mobile"),sr.RetrievePropertyValue("physicaldeliveryofficename"),sr.RetrievePropertyValue("company"),sr.RetrievePropertyValue("department"),
			sr.RetrievePropertyValue("departmentNumber"), sr.RetrievePropertyValue("distinguishedName"),sr.RetrievePropertyValue("adspath"))); } return list; }

	/// <returns>Trimmed <paramref name="number"/> to 8-digit string</returns><param name="number" />
	protected string TrimCioPhoneNumber(string number) { string result=string.Empty; if (number != null) { result=number; while (result.Length > 8) { 
		if (result.Remove(2).Equals("00")) { if (result.Remove(4).Equals(0045)) return result.Remove(0,4); else return result; }
		else if (result.Remove(1).Equals("+")) { if (result.Remove(3).Equals(+45)) return result.Remove(0,3); else return result; }
		else { if (result.Remove(4).Equals("7334")|result.Remove(4).Equals("7434")) return result.Remove(8); else result=result.Remove(0,1); } } } return result; }

	#region Private

	/// <returns>Current line number as int</returns><param name="lineNumber" />
	private static int CurrentLineNumber([CallerLineNumber] int lineNumber=0) => lineNumber;

	/// <returns>Current method name as string</returns><param name="memberName" />
	private static string CurrentMethod([CallerMemberName] string memberName="") => currentMethod+"."+memberName+"()";

	/// <summary>Checks, wether a user is part of of the SD security group</summary>
	private void Authentication() { if (this.Config.User.IsNullOrWhiteSpace()) this.Config.User=Config.UserName; if (this.Config.User.ToLower().Equals("3in1")||this.Config.User.ToLower().Equals("moch"))
			this.Config.Authorized=true; else { try { using WindowsIdentity winid=new(this.Config.User); WindowsPrincipal principal=new(winid); this.Config.Authorized=principal.IsInRole("SdDatabase_Gruppe"); }
			catch (ExpressionException eex) { this.Config.Authorized=false; WriteStringLineToLogFile(Environment.NewLine+"- Authentification Error:"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine+Environment.NewLine); }
			catch (Exception ex) { this.Config.Authorized=false; WriteStringLineToLogFile(Environment.NewLine+"- Authentification Error:"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine+Environment.NewLine); } } }

	/// <summary>Interpretes content of request</summary><param name="content" /><exception cref="ArgumentInvalidException" /><exception cref="NullRefException" />
	private void InterpreteContent(string content) { if (content.IsNullOrWhiteSpace()) throw new ArgumentInvalidException(nameof(content), content,nameof(content)+Error.CantBeEmpty);
		if (!content.ToLower().Contains("get")&&content.Contains(Convert.ToChar(" "))) throw new ArgumentInvalidException(nameof(content), nameof(content)+Error.UnkAPI);
		this.Config.ContentInterpreted=true; this.Config.ParameterDictionary.Clear();
		try { this.Config.Api=content.Remove(content.IndexOf("?")); string parameters=content.Remove(0, content.IndexOf("?")+1); string[] parameterArray=parameters.Split(Convert.ToChar("&"));
			foreach (string parameter in parameterArray) { string[] parameterDetails=parameter.Split(Convert.ToChar(@"=")); this.Config.ParameterDictionary.Add(parameterDetails[0],parameterDetails[1]); }
			foreach (KeyValuePair<string, string> parameterPair in this.Config.ParameterDictionary) { switch (parameterPair.Key.ToLower()) {
				case "active": this.Config.Active=parameterPair.Value.ToLower(); break; case "all": this.Config.All=Convert.ToBoolean(parameterPair.Value); break;
				case "contactinformationindicator": this.Config.ApiContactInformationIndicator=Convert.ToBoolean(parameterPair.Value); break;
				case "departmentidentifier": this.Config.ApiDepartmentIdentifier=parameterPair.Value.ToLower(); break;
				case "departmentindicator": this.Config.ApiDepartmentIndicator=bool.Parse(parameterPair.Value); break;
				case "departmentlevelreferenceindicator": this.Config.ApiDepartmentLevelReferenceIndicator=bool.Parse(parameterPair.Value); break;
				case "departmentreferenceindicator": this.Config.ApiDepartmentReferenceIndicator=bool.Parse(parameterPair.Value); break;
				case "employmentidentifier": this.Config.ApiEmploymentIdentifier=parameterPair.Value.ToLower(); break;
				case "employmentstatusindicator": this.Config.ApiEmploymentStatusIndicator=bool.Parse(parameterPair.Value); break;
				case "format": this.Config.Format=parameterPair.Value.ToLower(); if (!this.Config.MediaTypes.ContainsKey(this.Config.Format)) this.Config.UnsupportedMedia=true; else this.Config.UnsupportedMedia=false; break;
				case "institutionidentifier": this.Config.ApiInstitutionIdentifier=parameterPair.Value.ToLower(); break;
				case "jobpositionidentifier": this.Config.ApiJobPositionIdentifier=parameterPair.Value.ToLower(); break;
				case "organizationidentifier": this.Config.ApiOrganizationIdentifier=parameterPair.Value.ToLower(); break;
				case "organizationstructureidentifier": this.Config.ApiOrganizationStructureIdentifier=parameterPair.Value.ToLower(); break;
				case "password": this.Config.PassWord=parameterPair.Value.ToLower(); break; case "postaladdressindicator": this.Config.ApiPostalAddressIndicator=bool.Parse(parameterPair.Value); break;
				case "professionindicator": this.Config.ApiProfessionIndicator=Convert.ToBoolean(parameterPair.Value); break;
				case "roles": this.Config.Roles=parameterPair.Value; break; case "salaryagreementindicator": this.Config.ApiSalaryAgreementIndicator=bool.Parse(parameterPair.Value); break;
				case "salarycodegroupindicator": this.Config.ApiSalaryCodegroupIndicator=Convert.ToBoolean(parameterPair.Value); break;
				case "silo": this.Config.Silo=parameterPair.Value; break; case "workingtimeindicator": this.Config.ApiWorkingTimeIndicator=bool.Parse(parameterPair.Value); break;
				case "uuid": this.Config.Uuid=bool.Parse(parameterPair.Value.ToLower()); break; case "user": this.Config.User=parameterPair.Value; Authentication(); break;
				default: this.Config.ContentInterpreted=false; throw new InvalidRefException(nameof(parameterPair.Key),parameterPair.Key+Error.UnkParam); } } }
		catch (ExpressionException eex) { Console.WriteLine(eex.ToErrorString()); DiscAccess.WriteStringLineToFile(this.Config.LogFilePath,Environment.NewLine+eex.ToErrorString()); this.Config.ContentInterpreted=false; }
		catch (Exception ex) { Console.WriteLine(ExpressionException.ToErrorString(ex)); DiscAccess.WriteStringLineToFile(this.Config.LogFilePath,Environment.NewLine+ExpressionException.ToErrorString(ex));
			this.Config.ContentInterpreted=false; } }

	#region P

	/// <summary>Processes content of request</summary>
	private void ProcessContent() { this.Config.ContentProcessed=true; try { Authentication(); switch (this.Config.Api.ToLower()) {
			case "get3in1organizations": ProcessEntityList<View3in1Organization>(); break;
			case "get3in1organizationstructures": ProcessEntityList<View3in1OrganizationStructure>(); break;
			case "get3in1persons": ProcessEntityList<View3in1Person>(); break;
			case "getdepartments": ProcessEntityList<ViewDepartment>(); break;
			case "getemployments": ProcessEntityList<ViewEmployment>(); break;
			case "getinstitutions": ProcessEntityList<ViewInstitution>(); break;
			case "getmochpersons": ProcessEntityList<ViewMoch>(); break;
			case "getorganizations": ProcessEntityList<ViewOrganization>(); break;
			case "getorganizationstructures": ProcessEntityList<ViewOrganizationStructure>(); break;
			case "getpersons": ProcessEntityList<ViewPerson>(); break;
			case "getprofessions": ProcessEntityList<ViewProfession>(); break;
			default: throw new InvalidRefException(nameof(this.Config.Api),this.Config.Api,nameof(this.Config.Api)+Error.UnkAPI); } }
		catch (ExpressionException eex) { WriteStringLineToLogFile("- An error occurred. Content could not be processed:" + Environment.NewLine + eex.ToErrorString()+Environment.NewLine+Environment.NewLine); this.Config.ContentProcessed=false; }
		catch (Exception ex) { WriteStringLineToLogFile("- An error occurred. Content could not be processed:" + Environment.NewLine + ExpressionException.ToErrorString(ex)+Environment.NewLine+Environment.NewLine); this.Config.ContentProcessed=false; } }

	/// <summary>Proces result from Api</summary><typeparam name="T" />
	private void ProcessEntityList<T>() where T : class { try { List<T> list=GetList<T>(); if (list.Count>=1) { this.Config.ResponseString=this.Config.Format switch { "csv" => ConvertApiEntityListToCsvString(list), "json" => ConvertApiEntityListToJsonString(list), "xml" => ConvertApiEntityListToXmlString(list),
				_ => throw new InvalidRefException(nameof(this.Config.Format), this.Config.Format, nameof(this.Config.Format)+Error.UnkParam), }; } }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+eex.ToErrorString()+Environment.NewLine+Environment.NewLine); }
		catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine+Environment.NewLine); } }

	/// <summary>Processes the responce to request</summary><param name="content" /><exception cref="ArgumentInvalidException" /><exception cref="NullRefException" />
	private void ProcessResponce(string content) { if (content.IsNullOrWhiteSpace()) throw new ArgumentInvalidException(nameof(content), content,nameof(content)+Error.CantBeEmpty);
		InterpreteContent(content); if (this.Config.ContentInterpreted) ProcessContent(); CheckErrors(); }

	#endregion

	#region S

	/// <summary>Saves sorted XmEmployments</summary>
	private void SaveCsvList() { Config.XmListSaved=false; string xmCsv=string.Empty; bool csvHeader=false; foreach (XmEmployment item in Config.XmEmploymentList) if (!item.IsEmpty()) { 
		if (!csvHeader) { xmCsv+=XmEmployment.CsvHeader; csvHeader=true; } xmCsv+=item.CsvValue; } if (!string.IsNullOrEmpty(xmCsv)) { Uri uri=new(Environment.CurrentDirectory+@"\EmploymentTerminationAlert_"+
			DateTime.Today.ToString("yyyy-MM-dd")+@".csv"); if (DiscAccess.WriteStringToFile(Environment.CurrentDirectory+@"\EmploymentTerminationAlert_"+DateTime.Today.ToString("yyyy-MM-dd")+@".csv",xmCsv)) {
				Config.XmListSaved=true; WriteStringLineToLogFile("- Expiring employments successfully saved - "+CurrentMethod()+" line "+CurrentLineNumber()); MailXmList(Environment.CurrentDirectory+
					@"\EmploymentTerminationAlert_"+DateTime.Today.ToString("yyyy-MM-dd")+@".csv"); } else WriteStringLineToLogFile("- Expiring employments could not be saved - "+CurrentMethod()+" line "+CurrentLineNumber()); } }

	/// <summary>Saves sorted XmEmployments</summary>
	private void SaveUserList(List<ADUser> list) { Config.UserListSaved=false; string userCsv=string.Empty; bool csvHeader=false; foreach (ADUser item in list) { if (item.GivenName.Length>=1&&item.SurName.Length>=1&&
		!item.AdsPath.Contains("Museum Soenderjylland")&&!item.AdsPath.Contains("SystemAccounts")&&!item.AdsPath.Contains("ServiceAccounts")&&!item.AdsPath.Contains("Slettede brugere")) { if (!csvHeader) {
			userCsv+=ADUser.CsvHeader; csvHeader=true; } userCsv+=item.CsvValue; } } if (!string.IsNullOrEmpty(userCsv)) { string path=Resources.CsvPath+@"ADUsers_"+DateTime.Today.ToString("yyyy-MM-dd")+@".csv";
				if (DiscAccess.WriteStringToFile(path,userCsv)) { Config.UserListSaved=true; WriteStringLineToLogFile("- AD users succaeesfully saved to "+path+
					" - "+CurrentMethod()+" line "+CurrentLineNumber()); } } }

	/// <summary>Sends <paramref name="data"/></summary><param name="handler" /><param name="data" />
	private void Send(Socket handler,string data) { byte[] byteData=Encoding.ASCII.GetBytes(data); this.Config.PageData=string.Empty;
		handler.BeginSend(byteData,0,byteData.Length,0,new AsyncCallback(SendCallback), handler); }

	/// <summary>Sends a CallBack to socket</summary><param name="ar" />
	private void SendCallback(IAsyncResult ar) { try { Socket handler=(Socket)ar.AsyncState; int bytesSent=handler.EndSend(ar); Console.WriteLine("Sent {0} bytes to client.", bytesSent);
		handler.Shutdown(SocketShutdown.Both); handler.Close(); } catch (Exception e) { Console.WriteLine(e.ToString()); } }

	/// <remarks />
	private bool SetConfigParams() { try { Config.AllDataRetrieved=true; Config.AllDataDeserialized=true; Config.AllDataCleaned=true; Config.AllDatabaseUpdated=true; return true; } catch (Exception) { return false; } }

	/// <remarks />
	private void SetToDate() => this.Config.ToDate=Config.Tomorrow;

	#endregion

	#endregion

	#endregion

}
