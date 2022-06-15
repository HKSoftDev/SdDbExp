// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="DiscAccess.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace DataTier;

///<summary>Logic for simple disc access</summary>
public class DiscAccess
{
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

	/// <summary>Checks wether a file exists on disk</summary><param name="filePath" /><returns>Result as bool</returns>
	public static bool FileExist(string filePath) => File.Exists(filePath);

	/// <returns>Result as bool</returns><param name="filePath" /><param name="fileContent" /><param name="encoding" /><exception cref="ArgumentEmptyException" />
	public static bool WriteStringToFile(string filePath, string fileContent, Encoding? encoding = null) { if(string.IsNullOrWhiteSpace(filePath)) throw new ArgumentEmptyException(nameof(filePath),
			nameof(filePath)+Error.CantBeEmpty); if(string.IsNullOrWhiteSpace(fileContent)) throw new ArgumentEmptyException(nameof(fileContent),nameof(fileContent)+Error.CantBeEmpty);
		if (encoding==null) encoding=Encoding.UTF8; try { File.WriteAllText(filePath,fileContent,encoding); return true; } catch (Exception) { return false; } }

	/// <returns>Result as bool</returns><param name="filePath" /><param name="lineContent" /><param name="encoding" /><exception cref="ArgumentEmptyException" />
	public static bool WriteStringLineToFile(string filePath, string lineContent, Encoding? encoding = null) { if(string.IsNullOrWhiteSpace(filePath)) throw new ArgumentEmptyException(nameof(filePath),
			nameof(filePath)+Error.CantBeEmpty); if(string.IsNullOrWhiteSpace(lineContent)) throw new ArgumentEmptyException(nameof(lineContent),nameof(lineContent)+Error.CantBeEmpty);
		if (encoding==null) encoding=Encoding.UTF8; try { File.AppendAllText(filePath, lineContent+Environment.NewLine, encoding); return true; } catch (Exception) { return false; } }

	#endregion
}
