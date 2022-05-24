// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DiscAccess.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace DataTier;

///<summary>Logic for simple disc access</summary>
public class DiscAccess
{
	#region Constructors
	///<remarks />
	public DiscAccess() { }

	#endregion
		
	#region Properties
	///<remarks />
	public static string CsvPath { get; } = Resources.CsvPath;

	///<remarks />
	public static string DataSetsPath { get; } = Resources.DataSetsPath;

	///<remarks />
	public static string LogsPath { get; } = Resources.LogsPath;

	///<remarks />
	public static string ResourcesPath { get; } = Resources.ResourcesPath;

	#endregion

	#region Methods

	#region C

	/// <summary>Checks wether folders exists on disk</summary>
	public static void CheckFoldersExist() { if(!FolderExist(CsvPath)) CreateFolder(CsvPath); if(!FolderExist(DataSetsPath)) CreateFolder(DataSetsPath);
		if(!FolderExist(LogsPath)) CreateFolder(LogsPath); if(!FolderExist(ResourcesPath)) CreateFolder(ResourcesPath); }

	/// <summary>Creates a file on disk</summary><param name="filePath" /><returns>Result as bool</returns>
	public static void CreateFile(string filePath) => File.WriteAllText(filePath, "", Encoding.UTF8);

	/// <summary>Creates a folder on disk</summary><param name="folderPath"></param><returns>Result as bool</returns>
	public static void CreateFolder(string folderPath) => Directory.CreateDirectory(folderPath);

	/// <returns>string containing the requested amount of dashes</returns><param name="dashes" />
	private static string CreateDashString(int dashes) { string result = string.Empty; for (int i = 0; i<dashes; i++) result+="-"; return result; }

	#endregion

	#region F

	/// <summary>Checks wether a file exists on disk</summary><param name="filePath" /><returns>Result as bool</returns>
	public static bool FileExist(string filePath) => File.Exists(filePath);

	/// <summary>Checks wether a folder exists on disk</summary><param name="folderPath">Folder path</param><returns>Result as bool</returns>
	public static bool FolderExist(string folderPath) => Directory.Exists(folderPath);

	#endregion

	#region R

	#region Read

	/// <returns>Content of <paramref name="filePath"/> as string[]</returns><param name="filePath" />
	public static string[] ReadStringArrayFromFile(string filePath) => File.ReadAllLines(filePath);

	/// <returns>Content of <paramref name="filePath"/> as <see cref="string"/></returns><param name="filePath" />
	public static string ReadStringFromFile(string filePath) => File.ReadAllText(filePath);

	#endregion

	#region Retrieve

	/// <returns><paramref name="s"/> extended with dashes intended for console as string</returns><param name="s" /><exception cref="ArgumentEmptyException" />
	public static string RetrieveDashedStringConsole(string s) { if (string.IsNullOrWhiteSpace(s)) throw new ArgumentEmptyException(nameof(s),nameof(s)+Error.CantBeEmpty);
		if (s.Length.Equals(0)) return CreateDashString(70); if (s.Length>70) return s.Remove(70);
		else return CreateDashString((70-s.Length)/2)+s+CreateDashString((70-s.Length)-((70-s.Length)/2)); }

	/// <returns>Requested XML file path as string</returns><param name="sdApi" /><param name="institutionIdentifier" /><exception cref="ArgumentEmptyException" /><exception cref="ArgumentInvalidException" />
	public static string RetrieveXmlFilePath(string sdApi, string institutionIdentifier) { if (string.IsNullOrWhiteSpace(sdApi)) throw new ArgumentEmptyException(nameof(sdApi),nameof(sdApi)+Error.CantBeEmpty);
		if (string.IsNullOrWhiteSpace(institutionIdentifier)) throw new ArgumentEmptyException(nameof(institutionIdentifier),nameof(institutionIdentifier)+Error.CantBeEmpty);
		return sdApi.ToLower() switch { "getdepartment" => DataSetsPath+"NewDataset_GetDepartment20111201_"+institutionIdentifier+"_"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+".xml",
			"getemployment" => DataSetsPath+"NewDataset_GetEmployment20111201_"+institutionIdentifier+"_"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+".xml",
			"getemploymentchanged" => DataSetsPath+"NewDataset_GetEmploymentChanged20111201_"+institutionIdentifier+"_"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+".xml",
			"getemploymentchangedatdate" => DataSetsPath+"NewDataset_GetEmploymentChangedAtDate20111201_"+institutionIdentifier+"_"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+".xml",
			"getinstitution" => DataSetsPath+"NewDataset_GetInstitution20111201_"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+".xml",
			"getorganization" => DataSetsPath+"NewDataset_GetOrganization20111201_"+institutionIdentifier+"_"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+".xml",
			"getperson" => DataSetsPath+"NewDataset_GetPerson20111201_"+institutionIdentifier+"_"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+".xml",
			"getpersonchangedatdate" => DataSetsPath+"NewDataset_GetPersonChangedAtDate20111201_"+institutionIdentifier+"_"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+".xml",
			"getprofession" => DataSetsPath+"NewDataset_GetProfession20080201_"+institutionIdentifier+"_"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+".xml",
			_ => throw new ArgumentInvalidException(nameof(sdApi), sdApi, nameof(sdApi)+Error.UnkAPI), }; }

	#endregion

	#endregion

	#region W

	/// <returns>Result as bool</returns><param name="filePath" /><param name="fileContent" /><param name="encoding" /><exception cref="ArgumentEmptyException" />
	public static bool WriteStringToFile(string filePath, string fileContent, Encoding? encoding = null) {
		if(string.IsNullOrWhiteSpace(filePath)) throw new ArgumentEmptyException(nameof(filePath),nameof(filePath)+Error.CantBeEmpty);
		if(string.IsNullOrWhiteSpace(fileContent)) throw new ArgumentEmptyException(nameof(fileContent),nameof(fileContent)+Error.CantBeEmpty);
		if (encoding==null) encoding=Encoding.UTF8;
		try { File.WriteAllText(filePath,fileContent,encoding); return true; }
		catch (Exception) { return false; } }

	/// <returns>Result as bool</returns><param name="filePath" /><param name="lineContent" /><param name="encoding" /><exception cref="ArgumentEmptyException" />
	public static bool WriteStringLineToFile(string filePath, string lineContent, Encoding? encoding = null) {
		if(string.IsNullOrWhiteSpace(filePath)) throw new ArgumentEmptyException(nameof(filePath),nameof(filePath)+Error.CantBeEmpty);
		if(string.IsNullOrWhiteSpace(lineContent)) throw new ArgumentEmptyException(nameof(lineContent),nameof(lineContent)+Error.CantBeEmpty);
		if (encoding==null) encoding=Encoding.UTF8;
		try { File.AppendAllText(filePath, lineContent+Environment.NewLine, encoding); return true; }
		catch (Exception) { return false; } }

	#endregion

	#endregion
}
