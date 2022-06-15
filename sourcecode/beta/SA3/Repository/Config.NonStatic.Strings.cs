// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.NonStatic.Strings.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks />
public partial class Config //Non-static Strings
{

	#region Properties

	#region A

	/// <remarks />
	public string Active { get; set; } = string.Empty;

	/// <remarks />
	public string Api { get; set; } = string.Empty;

	/// <remarks />
	public string AppName { get; } = RetrieveAppName();

	#endregion

	/// <remarks />
	public string DataSetPath { get; set; } = string.Empty;

	/// <remarks />
	public string ErrorPath { get; set; } = string.Empty;

	#region F

	/// <remarks />
	public string FilePath { get; set; } = string.Empty;

	/// <remarks />
	public string FileTimeStamp { get; set; } = string.Empty;

	/// <remarks />
	public string FileName { get; set; } = string.Empty;

	/// <remarks />
	public string Format { get; set; } = string.Empty;

	#endregion

	#region L

	/// <remarks />
	public string LogFilePath { get; } = Resources.LogsPath+"Log_"+RetrieveAppName()+"_"+DateTime.Now.ToString("s").Replace(":", ".")+@".txt";

	/// <remarks />
	public string LogTimeStamp { get; set; } = string.Empty;

	#endregion

	/// <remarks />
	public string MacAddress { get; private set;}

	/// <remarks />
	public string PageData { get; set; } = string.Empty;

	#region R

	/// <remarks />
	public string RequestString { get; set; } = string.Empty;

	/// <remarks />
	public string ResponseString { get; set; } = string.Empty;

	/// <remarks />
	public string RunMode { get; set; } = string.Empty;

	#endregion

	/// <remarks />
	public string Silo { get; set; } = string.Empty;

	/// <remarks />
	public string Uri { get; set; } = string.Empty; 

	/// <remarks />
	public string User { get; set; } = string.Empty; 

	/// <remarks />
	public string XmlFilePath { get; set; } = string.Empty;

	#endregion

}
