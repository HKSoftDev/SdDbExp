// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Main.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Main
{
	#region Methods

	/// <returns>Result as bool</returns>
	public void ResetFields() { this.Config.Active=string.Empty; this.Config.Format=string.Empty; this.Config.ResponseString=string.Empty; this.Config.Silo=string.Empty; this.Config.Uuid=false; }

	/// <returns>Result as bool</returns>
	public bool SaveResponseStringToFile() { string path=DiscAccess.CsvPath+this.Config.Api+"_"+DateTime.Today.ToString("yyyy-MM-dd")+".csv";
		if (DiscAccess.WriteStringToFile(path,this.Config.ResponseString)) { WriteStringLineToLogFile("- Response string was saved to "+path); return true; }
		else { WriteStringLineToLogFile("- Response string could not be saved to disc"+path); return false; } }

	/// <returns>Result as bool</returns><param name="lineContent" />
	public bool WriteStringLineToLogFile(string lineContent) { if (!string.IsNullOrWhiteSpace(config.LogFilePath)) { try { if(DiscAccess.FileExist(config.LogFilePath))
		return DiscAccess.WriteStringLineToFile(config.LogFilePath,lineContent); else return DiscAccess.WriteStringToFile(config.LogFilePath,lineContent+Environment.NewLine); } 
			catch (ExpressionException eex) { Console.WriteLine(eex.ToErrorString()); return false; } catch (Exception ex) { Console.WriteLine(ExpressionException.ToErrorString(ex)); return false; } } 
				else { Console.Write(lineContent); return false; } }

	#endregion

}
