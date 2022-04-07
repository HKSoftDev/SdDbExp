// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.Main.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks />
public partial class Config // Main
{
	#region Constructors
	/// <summary>Initializes an empty instance of Config</summary>
	public Config() { this.MacAddress=RetrieveMacAddress(); }

	/// <summary>Initializes an instance of Config, that accepts data from an existing Config</summary><param name="config" />
	public Config(Config config) { this.MacAddress=RetrieveMacAddress(); FillFieldProps(config); }

	#endregion

	#region Methods

	/// <returns>Result as bool</returns><param name="s">'HB', 'HI', or'HW'</param>
	public static bool CheckInstitutionIdentifier(string s) { if (string.IsNullOrWhiteSpace(s)) return false;  foreach (string item in InstitutionIdentifierList) if (item.Equals(s)) return true; return false; }

	#region Protected

	/// <returns>AppName as string</returns>
	protected static string RetrieveAppName() { string result = AppDomain.CurrentDomain.FriendlyName; while (result.Contains(Convert.ToChar("_"))) { result=result.Remove(result.IndexOf('_')); }
		while (result.Contains(Convert.ToChar("."))) { result=result.Remove(result.IndexOf('.')); } return result; }

	/// <summary>Adds data from <paramref name="config"/> to this Config</summary><param name="config" />
	protected void FillFieldProps(Config config) { this.UserList=new(config.UserList); this.DataSetPath=config.DataSetPath; this.ErrorPath=config.ErrorPath;
		this.FilePath=config.FilePath; this.FileTimeStamp=config.FileTimeStamp; this.LogTimeStamp=config.LogTimeStamp; this.All=config.All; this.AllDatabaseUpdated=config.AllDatabaseUpdated; 
		this.AllDataCleaned=config.AllDataCleaned; this.AllDataDeserialized=config.AllDataDeserialized; this.AllDataRetrieved=config.AllDataRetrieved; this.Authorized=config.Authorized;
		this.CioInfoUpdated=config.CioInfoUpdated; this.ContentInterpreted=config.ContentInterpreted; this.ContentProcessed=config.ContentProcessed; this.DataBaseUpdated=config.DataBaseUpdated;
		this.DataCleaned=config.DataCleaned; this.DataDeserialized=config.DataDeserialized; this.DataRetrieved=config.DataRetrieved; this.InfosUpdated=config.InfosUpdated; this.NewDataRetrieved=config.NewDataRetrieved;
		this.OldDataretrieved=config.OldDataretrieved; this.RequestContainsData=config.RequestContainsData; this.ResponseContainsData=config.ResponseContainsData; this.ResponseSaved=config.ResponseSaved;
		this.UnsupportedMedia=config.UnsupportedMedia; this.UpdateError=config.UpdateError; this.UseCachedDownloadList=config.UseCachedDownloadList; this.Uuid=config.Uuid; this.ValidDates=config.ValidDates;
		this.ValidFilePath=config.ValidFilePath; this.ValidQuery=config.ValidQuery; this.ValidRequest=config.ValidRequest; this.ValidResponse=config.ValidResponse; this.ValidSdApi=config.ValidSdApi;
		this.XmlDataDeserialized=config.XmlDataDeserialized; this.XmlDataRetrieved=config.XmlDataRetrieved; this.Active=config.Active; this.Api=config.Api; this.FileName=config.FileName;
		this.Format=config.Format; this.RequestString=config.RequestString; this.ResponseString=config.ResponseString; this.RunMode=config.RunMode; this.Silo=config.Silo; }

	/// <summary>Retrieves MacAddress of this environment</summary>
	protected string RetrieveMacAddress() { try { return NetworkInterface.GetAllNetworkInterfaces().Where(nic => nic.OperationalStatus==OperationalStatus.Up&&nic.NetworkInterfaceType!=
		NetworkInterfaceType.Loopback).Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault()??string.Empty; } catch (Exception ex) {
			Console.WriteLine(ExpressionException.ToErrorString(ex)); MacAddressSet=false; return string.Empty; } }

	#endregion

	#endregion

}
