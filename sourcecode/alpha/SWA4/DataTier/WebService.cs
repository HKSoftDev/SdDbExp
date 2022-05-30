// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WebService.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace DataTier;

/// <remarks/>
public class WebService
{
	#region Fields
	private const string currentMethod="DataTier.WebService";
	private static readonly string[] trustedHosts=new[] { "silkeborgdata.dk", "sd.dk" };

	#endregion

	#region Methods

	/// <returns>Requested log message line as string</returns><param name="institutionId" /><param name="sdApi" />
	public static string GetFinishedRetrievingLogMessageLine(string institutionId,string sdApi) => "- Finished retrieving "+sdApi+" data "+institutionId;

	/// <returns>Requested log message line as string</returns><param name="institutionId" /><param name="sdApi" />
	public static string GetRetrievingLogMessageLine(string institutionId,string sdApi) => "- Retrieving "+sdApi+" data for "+institutionId;

	/// <returns><paramref name="xml"/> string corrected for common UTF-8 character encoding problems etc.</returns><param name="xml" /><param name="logFilePath" />
	public static string ParseSoapResult(string xml,string logFilePath) { string result=xml; result=ParseXmlString(result); result=result.Replace("doctype", "DOCTYPE");
		// result=AddXmlns(result); 
		if (result.ToLower().Contains(@"?xml")&&!result.ToLower().Contains(@"fault")) result=IndentXml(result,logFilePath); return result; }

	/// <summary>Retrieves and saves xml string from webservice</summary><param name="config" /><param name="institutionId" /><param name="sdApi" /><param name="fromDate" /><returns>Result as bool</returns>
	public string CallWebService(ref Config config,string institutionId,string sdApi,string fromDate) { try {  DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Calling "+sdApi+" at Silkeborg Data for "+institutionId+
				" - "+CurrentMethod()+" line "+CurrentLineNumber()); config.DataRetrieved=true;
			string result=DownloadAndSaveXmlString(ref config,institutionId,sdApi,fromDate); if (!string.IsNullOrWhiteSpace(result)) { DiscAccess.WriteStringLineToFile(config.LogFilePath,
				"- End of  "+sdApi+" call for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return result; }
			else { DiscAccess.WriteStringLineToFile(config.LogFilePath,"- No xml string was rerieved from "+sdApi+" at Silkeborg Data for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()); return result; } }
		catch (ExpressionException eex) { config.DataRetrieved=false; DiscAccess.WriteStringLineToFile(config.LogFilePath,"- No xml string was rerieved from "+sdApi+" at Silkeborg Data for "+institutionId+" - "+
			CurrentMethod()+" line "+CurrentLineNumber()+eex.ToErrorString()+Environment.NewLine); return string.Empty; } catch (Exception ex) { config.DataRetrieved=false; DiscAccess.WriteStringLineToFile(config.LogFilePath,
				"- No xml string was rerieved from "+sdApi+" at Silkeborg Data for "+institutionId+" - "+CurrentMethod()+" line "+CurrentLineNumber()+ExpressionException.ToErrorString(ex)+Environment.NewLine); return string.Empty; } }

	#region Private

	#region Static

	/// <returns>Current line number as int</returns><param name="lineNumber" />
	protected static int CurrentLineNumber([CallerLineNumber] int lineNumber=0) => lineNumber;

	/// <returns>Current method name as string</returns><param name="memberName" />
	protected static string CurrentMethod([CallerMemberName] string memberName="") => currentMethod+"."+memberName+"()";

	/// <summary>Enables trusted hosts for ssl/tsl encryption for tcp/ip</summary>
	protected static void EnabletrustedHosts() { ServicePointManager.ServerCertificateValidationCallback=(sender, certificate, chain, errors) => { if (errors==SslPolicyErrors.None) return true; if (sender is HttpWebRequest request) { foreach (string item in trustedHosts) if (item.Contains(request.RequestUri.Host)) return true; } return false; }; }

	/// <returns>Indented <paramref name="xml"/>as string</returns><param name="logFilePath" /><param name="xml" />
	protected static string IndentXml(string xml,string logFilePath) { try { using MemoryStream stream=new(); using XmlTextWriter writer=new(stream,Encoding.UTF8);
			XmlDocument doc=new(); doc.LoadXml(xml); writer.Formatting=System.Xml.Formatting.Indented; doc.WriteContentTo(writer); writer.Flush(); stream.Flush();
			stream.Position=0; using StreamReader reader=new(stream); return reader.ReadToEnd(); }
		catch (ExpressionException eex) { DiscAccess.WriteStringLineToFile(logFilePath,Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return xml; }
		catch (Exception ex) { DiscAccess.WriteStringLineToFile(logFilePath,Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return xml; } }

	/// <returns><paramref name="xmlString"/> corrected for common UTF-8 character encoding problems</returns><param name="xmlString" />
	protected static string ParseXmlString(string xmlString) { xmlString=xmlString.Replace("Å’", "\u0152"); xmlString=xmlString.Replace("Å½", "\u017D"); xmlString=xmlString.Replace("Å¡", "\u0161"); 
		xmlString=xmlString.Replace("Å“", "\u0153");  xmlString=xmlString.Replace("Å¾", "\u017E"); xmlString=xmlString.Replace("Å¸", "\u0178"); xmlString=xmlString.Replace("Â§", "\u00A7"); 
		xmlString=xmlString.Replace("Ã€", "\u00C0"); xmlString=xmlString.Replace("Ã‚", "\u00C2"); xmlString=xmlString.Replace("Ãƒ", "\u00C3"); xmlString=xmlString.Replace("Ã„", "\u00C4"); 
		xmlString=xmlString.Replace("Ã…", "\u00C5"); xmlString=xmlString.Replace("Ã†", "\u00C6"); xmlString=xmlString.Replace("Ã‡", "\u00C7"); xmlString=xmlString.Replace("Ãˆ", "\u00C8"); 
		xmlString=xmlString.Replace("Ã‰", "\u00C9"); xmlString=xmlString.Replace("ÃŠ", "\u00CA"); xmlString=xmlString.Replace("Ã‹", "\u00CB"); xmlString=xmlString.Replace("ÃŒ", "\u00CC"); 
		xmlString=xmlString.Replace("ÃŽ", "\u00CE"); xmlString=xmlString.Replace("Ã‘", "\u00D1"); xmlString=xmlString.Replace("Ã’", "\u00D2"); xmlString=xmlString.Replace("Ã“", "\u00D3"); 
		xmlString=xmlString.Replace("Ã”", "\u00D4"); xmlString=xmlString.Replace("Ã•", "\u00D5"); xmlString=xmlString.Replace("Ã–", "\u00D6"); xmlString=xmlString.Replace("Ã˜", "\u00D8"); 
		xmlString=xmlString.Replace("Ã™", "\u00D9"); xmlString=xmlString.Replace("Ãš", "\u00DA"); xmlString=xmlString.Replace("Ã›", "\u00DB"); xmlString=xmlString.Replace("Ãœ", "\u00DC"); 
		xmlString=xmlString.Replace("Ãž", "\u00DE"); xmlString=xmlString.Replace("ÃŸ", "\u00DF"); xmlString=xmlString.Replace("Ã¡", "\u00E1"); xmlString=xmlString.Replace("Ã¢", "\u00E2"); 
		xmlString=xmlString.Replace("Ã£", "\u00E3"); xmlString=xmlString.Replace("Ã¤", "\u00E4"); xmlString=xmlString.Replace("Ã¥", "\u00E5"); xmlString=xmlString.Replace("Ã¦", "\u00E6"); 
		xmlString=xmlString.Replace("Ã§", "\u00E7"); xmlString=xmlString.Replace("Ã¨", "\u00E8"); xmlString=xmlString.Replace("Ã©", "\u00E9"); xmlString=xmlString.Replace("Ãª", "\u00EA"); 
		xmlString=xmlString.Replace("Ã«", "\u00EB"); xmlString=xmlString.Replace("Ã¬", "\u00EC"); xmlString=xmlString.Replace("Ã®", "\u00EE"); xmlString=xmlString.Replace("Ã¯", "\u00EF"); 
		xmlString=xmlString.Replace("Ã°", "\u00F0"); xmlString=xmlString.Replace("Ã±", "\u00F1"); xmlString=xmlString.Replace("Ã²", "\u00F2"); xmlString=xmlString.Replace("Ã³", "\u00F3"); 
		xmlString=xmlString.Replace("Ã´", "\u00F4"); xmlString=xmlString.Replace("Ãµ", "\u00F5"); xmlString=xmlString.Replace("Ã¶", "\u00F6"); xmlString=xmlString.Replace("Ã¸", "\u00F8"); 
		xmlString=xmlString.Replace("Ã¹", "\u00F9"); xmlString=xmlString.Replace("Ãº", "\u00FA"); xmlString=xmlString.Replace("Ã»", "\u00FB"); xmlString=xmlString.Replace("Ã¼", "\u00FC"); 
		xmlString=xmlString.Replace("Ã½", "\u00FD"); xmlString=xmlString.Replace("Ã¾", "\u00FE"); xmlString=xmlString.Replace("Ã¿", "\u00FF"); return xmlString; }

	/// <returns>Result as string</returns><param name="institutionId" /><param name="sdApi" />
	protected static string RetrieveDataSetPath(string institutionId,string sdApi) { string path=Resources.DataSetsPath+@"NewDataset_"+sdApi; if (!sdApi.ToLower().Contains("getinstitution")) path +="_"+institutionId; return path +"_"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+".xml"; }

	/// <returns>Result as string</returns><param name="appName" /><param name="sdApi" /><param name="institutionId" /><param name="type">html or txt</param>
	protected static string RetrieveErrorPath(string appName,string institutionId,string sdApi,string type="txt") => Resources.ErrorPath+@"Error_"+appName+"_"+sdApi+"_"+institutionId+"_"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+"."+type;

	#endregion

	#region Non Static

	/// <summary>Accepts all certifications</summary><param name="sender" /><param name="certification" /><param name="chain" /><param name="sslPolicyErrors" /><returns>Result as bool</returns>
	protected bool AcceptAllCertifications(object sender, X509Certificate certification, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true;

	#pragma warning disable SYSLIB0014

	/// <summary>Contacts Silkeborg Data Web Service, sends request, and receives an xml string</summary><param name="config" /><param name="institutionId" /><param name="sdApi" />
	/// <param name="fromDate" /><returns>Result as bool</returns><exception cref="ArgumentEmptyException" />
	protected string ContactSDWS(ref Config config,string institutionId,string sdApi,string fromDate) { try { string result=string.Empty; DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Preparing web client");
			using WebClient webClient=new(); webClient.Headers.Add ("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/97.0.4692.71 Safari/537.36 Edg/97.0.1072.62");
			webClient.Credentials=new NetworkCredential(Resources.SDWSUsername,Resources.SDWSPassword); string actionUrl=XmlHandler.RetrieveActionUrl(fromDate,institutionId,sdApi);
			DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Web client is ready:"+Environment.NewLine+"  URI: "+Resources.WebServiceURL+Environment.NewLine+"  Action: "+actionUrl+Environment.NewLine+Environment.NewLine+
				"- Receiving SOAP result for "+institutionId+" from "+sdApi); result=webClient.DownloadString(actionUrl); if (result.ToLower().Contains(@"fault")) { SaveError(ref config,institutionId,sdApi,"xml"); return result; }
					else if (result.ToLower().Contains(@"<html>")) { SaveError(ref config,institutionId,sdApi,"html"); return result; } else if (result.Contains("?xml")) { result=ParseSoapResult(result,config.LogFilePath); config.XmlFilePath=
						RetrieveDataSetPath(institutionId,sdApi); DiscAccess.WriteStringToFile(config.XmlFilePath,result); DiscAccess.WriteStringLineToFile(config.LogFilePath,"- SOAP result for "+institutionId+" retrieved from "+sdApi+
							" and saved to disc"+Environment.NewLine); return result; } else if (!string.IsNullOrWhiteSpace(result)) { SaveError(ref config,institutionId,sdApi,result); return result; } else return result; }
		catch (ExpressionException eex) { DiscAccess.WriteStringLineToFile(config.LogFilePath,Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return string.Empty; }
		catch (Exception ex) { DiscAccess.WriteStringLineToFile(config.LogFilePath,Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return string.Empty; } }

	#pragma warning restore SYSLIB0014

	/// <summary>Downloads xml string from Silkeborg Data and save them to disk</summary><param name="config" /><param name="institutionId" /><param name="sdApi" /><param name="fromDate" /><returns>Result as bool</returns>
	protected string DownloadAndSaveXmlString(ref Config config,string institutionId,string sdApi,string fromDate) {
		DiscAccess.WriteStringLineToFile(config.LogFilePath,GetRetrievingLogMessageLine(institutionId,sdApi)+Environment.NewLine+Environment.NewLine+"- Download of xml string for "+institutionId+" from "+sdApi+" initiated");
		try { string result=RetrieveXmlData(ref config,institutionId,sdApi,fromDate); if (!string.IsNullOrWhiteSpace(result)) { DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Xml string for "+institutionId+
			" was received from "+sdApi+" - "+CurrentMethod()+" - line "+CurrentLineNumber()+":"+Environment.NewLine+GetFinishedRetrievingLogMessageLine(institutionId,sdApi)); return result; }
			else { DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Xml string for "+institutionId+" was not received from "+sdApi+" - "+CurrentMethod()+" - line "+CurrentLineNumber()+Environment.NewLine+
				GetRetrievingLogMessageLine(institutionId,sdApi)+Environment.NewLine); return result; } }
		catch (ExpressionException eex) { DiscAccess.WriteStringLineToFile(config.LogFilePath ,"- Xml string for "+institutionId+" was not received from "+sdApi+" - "+CurrentMethod()+" - line "+CurrentLineNumber()+
			Environment.NewLine+eex.ToErrorString()+Environment.NewLine+Environment.NewLine+GetFinishedRetrievingLogMessageLine(institutionId,sdApi)+Environment.NewLine); return string.Empty; }
		catch (Exception ex) { DiscAccess.WriteStringLineToFile(config.LogFilePath ,"- Xml string for "+institutionId+" was not received from "+sdApi+" - "+CurrentMethod()+" - line "+CurrentLineNumber()+Environment.NewLine+
			ExpressionException.ToErrorString(ex)+Environment.NewLine+GetFinishedRetrievingLogMessageLine(institutionId,sdApi)+Environment.NewLine); return string.Empty; } }

	/// <summary>Prepares an XML request</summary><param name="config" /><param name="institution" /><param name="sdApi" /><returns>Result as bool</returns>
	protected string PrepareXmlRequest(ref Config config,string institution,string sdApi) { string result=XmlHandler.RetrieveSoapRequestString(institution,sdApi);
		DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Xml request prepared:"+Environment.NewLine+result); return result; }

	#region R

	/// <summary>Stores the requested query in the Config.WebServiceQuery, and sets ValidQuery</summary><param name="config" /><param name="sdApi" /><returns>Result as bool</returns><exception cref="ArgumentInvalidException" />
	protected bool RetrieveQueryString(ref Config config,string sdApi) { DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Retrieving web service query URI"+Environment.NewLine);
		switch (sdApi) { case "GetDepartment": config.WebServiceQueryString=config.InstitutionIdentifier+Config.InstitutionUUIDIdentifier+Config.DepartmentIdentifier+
				Config.DepartmentLevelIdentifier+Config.DepartmentUUIDIdentifier+config.ActivationDate+config.DeactivationDate+Config.ContactInformationIndicator+Config.DepartmentNameIndicator+
				Config.EmploymentDepartmentIndicator+Config.PostalAddressIndicator+Config.ProductionUnitIndicator; DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Valid query URI:"+
				Environment.NewLine+config.WebServiceActionUri+config.WebServiceQueryString+Environment.NewLine); return true;
			case "GetEmployment": config.WebServiceQueryString=config.InstitutionIdentifier+Config.PersonCivilRegistrationIdentifier+Config.EmploymentIdentifier+Config.DepartmentIdentifier+
				Config.DepartmentLevelIdentifier+config.EffectiveDate+Config.StatusActiveIndicator+Config.StatusPassiveIndicator+Config.DepartmentIndicator+Config.EmploymentStatusIndicator+
				Config.ProfessionIndicator+Config.SalaryAgreementIndicator+Config.SalaryCodeGroupIndicator+Config.WorkingTimeIndicator; DiscAccess.WriteStringLineToFile(config.LogFilePath,
					"- Valid query URI:"+Environment.NewLine+config.WebServiceActionUri+config.WebServiceQueryString+Environment.NewLine); DiscAccess.WriteStringLineToFile(config.LogFilePath,
						"- Valid query URI:"+Environment.NewLine+config.WebServiceActionUri+config.WebServiceQueryString+Environment.NewLine); return true;
			case "GetEmploymentChanged": config.WebServiceQueryString=config.InstitutionIdentifier+Config.PersonCivilRegistrationIdentifier+Config.EmploymentIdentifier+Config.DepartmentIdentifier+
				Config.DepartmentLevelIdentifier+config.ActivationDate+config.DeactivationDate+Config.DepartmentIndicator+Config.EmploymentStatusIndicator+Config.ProfessionIndicator+
				Config.SalaryAgreementIndicator+Config.SalaryCodeGroupIndicator+Config.WorkingTimeIndicator; DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Valid query URI:"+
				Environment.NewLine+config.WebServiceActionUri+config.WebServiceQueryString+Environment.NewLine); return true;
			case "GetEmploymentChangedAtDate": config.WebServiceQueryString=config.InstitutionIdentifier+Config.PersonCivilRegistrationIdentifier+Config.EmploymentIdentifier+
					Config.DepartmentIdentifier+Config.DepartmentLevelIdentifier+config.ActivationDate+Config.ActivationTime+ config.DeactivationDate+Config.DeactivationTime+Config.DepartmentIndicator+
					Config.EmploymentStatusIndicator+Config.ProfessionIndicator+Config.SalaryAgreementIndicator+Config.SalaryCodeGroupIndicator+Config.WorkingTimeIndicator+Config.FutureInformationIndicator;
				DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Valid query URI:"+Environment.NewLine+config.WebServiceActionUri+config.WebServiceQueryString+Environment.NewLine); return true;
			case "GetInstitution": config.WebServiceQueryString=Config.RegionIdentifier+Config.RegionUUIDIdentifier+config.InstitutionIdentifier+Config.InstitutionUUIDIdentifier+
					Config.AdministrationIndicator+Config.ContactInformationIndicator+Config.PostalAddressIndicator+Config.ProductionUnitIndicator;
				DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Valid query URI:"+Environment.NewLine+config.WebServiceActionUri+config.WebServiceQueryString+Environment.NewLine); return true;
			case "GetOrganization": config.WebServiceQueryString=config.InstitutionIdentifier+Config.InstitutionUUIDIdentifier+config.ActivationDate+config.DeactivationDate;
				DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Valid query URI:"+ Environment.NewLine+config.WebServiceActionUri+config.WebServiceQueryString+Environment.NewLine); return true;
			case "GetPerson": config.WebServiceQueryString=config.InstitutionIdentifier+Config.PersonCivilRegistrationIdentifier+Config.EmploymentIdentifier+Config.DepartmentIdentifier+
					Config.DepartmentLevelIdentifier+config.EffectiveDate+Config.StatusActiveIndicator+Config.StatusPassiveIndicator+Config.ContactInformationIndicator+Config.PostalAddressIndicator; 
				DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Valid query URI:"+Environment.NewLine+config.WebServiceActionUri+config.WebServiceQueryString+Environment.NewLine); return true;
			case "GetPersonChangedAtDate": config.WebServiceQueryString=config.InstitutionIdentifier+Config.PersonCivilRegistrationIdentifier+Config.EmploymentIdentifier+Config.DepartmentIdentifier+Config.DepartmentLevelIdentifier+config.ActivationDate+
				Config.ActivationTime+config.DeactivationDate+Config.DeactivationTime+Config.ContactInformationIndicator+Config.PostalAddressIndicator; DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Valid query URI:"+Environment.NewLine+
				config.WebServiceActionUri+config.WebServiceQueryString+Environment.NewLine); return true;
			case "GetProfession": config.WebServiceQueryString=config.InstitutionIdentifier+Config.JobPositionIdentifier; DiscAccess.WriteStringLineToFile(config.LogFilePath,
				"- Valid query URI:"+Environment.NewLine+config.WebServiceActionUri+config.WebServiceQueryString+Environment.NewLine); return true;
			default: throw new ArgumentInvalidException(nameof(sdApi),sdApi,nameof(sdApi)+Error.UnkAPI); } }

	/// <summary>returns SoapResult data from Silkeborg as string</summary><param name="config" /><param name="institutionId" /><param name="sdApi" /><param name="fromDate" /><returns>Result as bool</returns>
	protected string RetrieveXmlData(ref Config config,string institutionId,string sdApi,string fromDate) { try { string result=ContactSDWS(ref config,institutionId,sdApi,fromDate); if (!string.IsNullOrWhiteSpace(result)) {
			int i=191; if (result.Length<i) i=result.Length-1; DiscAccess.WriteStringLineToFile(config.LogFilePath,"- XML result for "+institutionId+" retrieved from "+sdApi+":"+Environment.NewLine+
				result.Remove(191)+Environment.NewLine); return result; } else { DiscAccess.WriteStringLineToFile(config.LogFilePath,"- Xml result could not be retrieved"); return result; } }
		catch (ExpressionException eex) { DiscAccess.WriteStringLineToFile(config.LogFilePath,Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return string.Empty; }
		catch (Exception ex) { DiscAccess.WriteStringLineToFile(config.LogFilePath,Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); return string.Empty; } }

	#endregion

	#region S

	/// <returns>Result as bool</returns><param name="config" /><param name="institutionId" /><param name="sdApi" /><param name="soapResult" /><param name="type">html or txt</param>
	protected void SaveError(ref Config config,string institutionId,string sdApi,string soapResult,string type="txt") { try { string path=RetrieveErrorPath(config.AppName,institutionId,sdApi,type);
			File.WriteAllText(path,soapResult); if (type.Equals("html")) { DiscAccess.WriteStringLineToFile(config.LogFilePath ,"- Invalid SOAP result received and saved to: "+path+Environment.NewLine);
				Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe",path); } else { DiscAccess.WriteStringLineToFile(config.LogFilePath ,
					"- Unknown SOAP result received and saved to: "+path+Environment.NewLine); } }
		catch (ExpressionException eex) { DiscAccess.WriteStringLineToFile(config.LogFilePath,Environment.NewLine+eex.ToErrorString()+Environment.NewLine); }
		catch (Exception ex) { DiscAccess.WriteStringLineToFile(config.LogFilePath,Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); } }

	/// <returns>Result as bool</returns><param name="config" /><param name="institutionId" /><param name="sdApi" /><param name="soapResult" />
	protected bool SaveDataset(ref Config config,string institutionId,string sdApi,string soapResult) { try { soapResult=soapResult.Replace("doctype","DOCTYPE"); string path=RetrieveDataSetPath(institutionId,sdApi);
			File.WriteAllText(path,soapResult); DiscAccess.WriteStringLineToFile(config.LogFilePath,"- SOAP result received and saved to "+path+Environment.NewLine); return true; }
		catch (ExpressionException eex) { DiscAccess.WriteStringLineToFile(config.LogFilePath,Environment.NewLine+eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { DiscAccess.WriteStringLineToFile(config.LogFilePath,Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); config.DataRetrieved=false; return false; } }

	#endregion

	#endregion

	#endregion

	#endregion

}
