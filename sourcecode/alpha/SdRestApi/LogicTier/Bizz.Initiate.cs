// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Initiate.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Initiate
{
	#region Methods


	/// <summary>Search the database for expiring employments</summary>
	public void InitiateAlertCheck() { CheckXmEmploymentAlerts(); CheckXmResult(); WriteStringLineToLogFile(Environment.NewLine+Environment.NewLine+
		" Log concluded "+DateTime.Now.ToString("D")+"_"+DateTime.Now.ToString("T")+"- "+CurrentMethod()+" line "+CurrentLineNumber()); }

	/// <summary>Optimizes data i Config.Database.ContactInformations</summary>
	public void InitiateDatabaseOptimization() { WriteStringLineToLogFile(Environment.NewLine+" Log initiated "+DateTime.Now.ToString("D")+"_"+DateTime.Now.ToString("T")+" - "+CurrentMethod()+" line "+CurrentLineNumber());
		try { Console.WriteLine(@"- Optimering af database påbegyndt"); Console.WriteLine("- Fjernelse af dubletter påbegyndt"); RemoveDoublets(); Console.WriteLine(@"- Fjernelse af dubletter afsluttet"); 
			Console.WriteLine("- Berigelse af brugere påbegyndt"); InitiateUserEnrichment(); Console.WriteLine(@"- Berigelse af brugere afsluttet"); Console.WriteLine("- Sortering af kontaktinformationer påbegyndt");
			OptimizeContactInformations(); CheckCioResult(); Console.WriteLine(@"- Sortering af kontaktinformationer afsluttet"); Console.WriteLine(@"- Optimering af professioner påbegyndt"); OptimizeEmploymentProfessions();
			Console.WriteLine(@"- Optimering af professioner afsluttet"); Console.WriteLine("- Optimering af database afsluttet"); }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+"- An error occurred during optimization of database:"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine); } 
		catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+ "- An error occurred during optimization of database:"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine); } 
		WriteStringLineToLogFile(Environment.NewLine+" Log concluded "+DateTime.Now.ToString("D")+"_"+DateTime.Now.ToString("T")+" - "+CurrentMethod()+" line "+CurrentLineNumber()); }

	/// <summary>Deserializes <paramref name="xml"/></summary><param name="xml" /><param name="institutionId" /><param name="sdApi" /><returns>result as bool</returns><exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	protected bool InitiateDeserializeSoapClone(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) throw new ArgumentEmptyException(nameof(xml),nameof(xml)+Error.CantBeEmpty);
		if (xml.Contains("Fault")) throw new XmlException(nameof(xml)+" can not be deserialized, as i conatains an error."); xml=WebService.ParseSoapResult(xml,config.LogFilePath);
		WriteStringLineToLogFile("- Deserializing retrieved "+sdApi+" xml Data for "+institutionId); try { config.DataDeserialized=true; return sdApi switch {"GetDepartment" => DeserializeGetDepartmentXmlClone(xml,institutionId),
			"GetEmployment" => DeserializeGetEmploymentXml(xml,institutionId),"GetInstitution" => DeserializeGetInstitutionXmlClone(xml),"GetOrganization" => DeserializeGetOrganizationXmlClone(xml,institutionId,sdApi),
			"GetPerson" => DeserializeGetPersonXml(xml,institutionId),"GetProfession" => DeserializeGetProfessionXmlClone(xml,institutionId), _ => throw new ArgumentInvalidException(nameof(sdApi),sdApi,nameof(sdApi)+Error.UnkAPI), }; }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+eex.ToErrorString()+Environment.NewLine+Environment.NewLine+xml+Environment.NewLine+"- End of deserializing "+sdApi+" xml Data for "+
			institutionId+Environment.NewLine); return false; } catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine+Environment.NewLine+
				xml+Environment.NewLine+"- End of deserializing "+sdApi+" xml Data for "+institutionId+Environment.NewLine); return false; } }

	/// <summary>Deserializes <paramref name="xml"/></summary><param name="xml" /><param name="institutionId" /><param name="sdApi" /><returns>result as bool</returns>
	/// <exception cref="ArgumentEmptyException" /><exception cref="InvalidRefException" />
	protected bool InitiateDeserializeSoapUpdate(string xml,string institutionId,string sdApi) { if (xml.IsNullOrWhiteSpace()) throw new ArgumentEmptyException(nameof(xml),nameof(xml)+Error.CantBeEmpty);
		if (xml.Contains("Fault")) throw new XmlException(nameof(xml)+" can not be deserialized, as i conatains an error."); xml=WebService.ParseSoapResult(xml,config.LogFilePath);
		WriteStringLineToLogFile("- Deserializing retrieved "+sdApi+" xml Data for "+institutionId); try { config.DataDeserialized=true; return sdApi switch { "GetDepartment" => DeserializeGetDepartmentXmlUpdate(xml,institutionId),
			"GetEmploymentChanged" => DeserializeGetEmploymentChangedXml(xml,institutionId), "GetEmploymentChangedAtDate" => DeserializeGetEmploymentChangedAtDateXml(xml,institutionId),
			"GetInstitution" => DeserializeGetInstitutionXmlUpdate(xml), "GetOrganization" => DeserializeGetOrganizationXmlUpdate(xml,institutionId,sdApi), "GetPersonChangedAtDate" => DeserializeGetPersonChangedAtDateXml(
						xml,institutionId), "GetProfession" => DeserializeGetProfessionXmlUpdate(xml,institutionId), _ => throw new ArgumentInvalidException(nameof(sdApi),sdApi,nameof(sdApi)+Error.UnkAPI), }; }
		catch (ExpressionException eex) { WriteStringLineToLogFile(Environment.NewLine+eex.ToErrorString()+Environment.NewLine+Environment.NewLine+xml+Environment.NewLine+"- End of deserializing "+sdApi+" xml Data for "+
			institutionId+Environment.NewLine); return false; } catch (Exception ex) { WriteStringLineToLogFile(Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine+Environment.NewLine+
				xml+Environment.NewLine+"- End of deserializing "+sdApi+" xml Data for "+institutionId+Environment.NewLine); return false; } }

	/// <summary>Retrieves xml from the Silkeborg Data Api</summary><param name="institutionId" /><param name="sdApi" /><returns>Result as bool</returns>
	public string InitiateRetrieveXml(string institutionId,string sdApi) { config.DataRetrieved=true; WebService service=new(); WriteStringLineToLogFile("- Data retrieval initiated for "+institutionId+
				" from "+sdApi+Environment.NewLine); try { string result=service.CallWebService(ref config,institutionId,sdApi,RetrieveFromDate(institutionId,sdApi));
			DiscAccess.WriteStringLineToFile(config.LogFilePath,Environment.NewLine+"- Data retrieval for "+institutionId+" from "+sdApi+" ended"+Environment.NewLine); return result; }
		catch (ExpressionException eex) { DiscAccess.WriteStringLineToFile(config.LogFilePath,Environment.NewLine+eex.ToErrorString()+
			Environment.NewLine+WebService.GetFinishedRetrievingLogMessageLine(institutionId,sdApi)+Environment.NewLine); return string.Empty; }
		catch (Exception ex) { DiscAccess.WriteStringLineToFile(config.LogFilePath,Environment.NewLine+ExpressionException.ToErrorString(ex)+
			Environment.NewLine+WebService.GetFinishedRetrievingLogMessageLine(institutionId,sdApi)+Environment.NewLine); return string.Empty; } }

	/// <summary>Initiates the enrichment of SD database stub with data from Active Directory</summary>
	public void InitiateUserEnrichment() => CheckUsers(DisplayFieldCount());

	#endregion

}
