// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.NonStatic.Flags.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks />
public partial class Config //Non-static Flags
{
	#region Properties

	#region A

	/// <remarks />
	public bool All { get; set; }

	/// <remarks />
	public bool AllDataDeserialized { get; set; }

	/// <remarks />
	public bool AllDataRetrieved { get; set; }

	/// <remarks />
	public bool AllDatabaseUpdated { get; set; }

	/// <remarks />
	public bool AllDataCleaned { get; set; }

	/// <remarks />
	public bool Authorized { get; set; }

	#endregion

	#region C
	///<remarks />
	public bool CioInfoUpdated { get; set;}

	/// <remarks />
	public bool ContentInterpreted { get; set; }

	/// <remarks />
	public bool ContentProcessed { get; set; }

	#endregion

	#region D
	/// <remarks/>
	public bool DataBaseUpdated { get; set; }

	/// <remarks/>
	public bool DataCleaned { get; set; }

	/// <remarks />
	public bool DataDeserialized { get; set; }

	/// <remarks />
	public bool DataRetrieved { get; set; }

	#endregion

	///<remarks />
	public bool InfosUpdated { get; private set;}

	/// <remarks/>
	public static bool MacAddressSet { get; set; }

	/// <remarks/>
	public bool NewDataRetrieved { get; set; }

	/// <remarks/>
	public bool OldDataretrieved { get; set; }

	#region R

	/// <remarks />
	public bool RequestContainsData { get; set; }

	/// <remarks />
	public bool ResponseContainsData { get; set; }

	/// <remarks />
	public bool ResponseSaved { get; set; }

	#endregion

	#region U
	/// <remarks />
	public bool UnsupportedMedia { get; set; }

	/// <remarks/>
	public bool UpdateError { get; set; }

	/// <remarks/>
	public bool UseCachedDownloadList { get; set; }

	/// <remarks />
	public bool Uuid { get; set; }

	#endregion

	#region V
	/// <remarks />
	public bool ValidDates { get; set; }

	/// <remarks/>
	public bool ValidFilePath { get; set; }

	/// <remarks />
	public bool ValidQuery { get; set; }

	/// <remarks />
	public bool ValidRequest { get; set; }

	/// <remarks />
	public bool ValidResponse { get; set; }

	/// <remarks />
	public bool ValidSdApi { get; set; }

	#endregion

	/// <remarks />
	public bool WorkingTimeDoubletsRemoved { get; set; }

	#region X
	/// <remarks/>
	public bool XmlDataDeserialized { get; set; }

	/// <remarks/>
	public bool XmlDataRetrieved { get; set; }

	#endregion

	#endregion

}
