// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Main.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Main
{
	#pragma warning disable SYSLIB0014
	#region Methods

	/// <summary>Communicates with server and retrieves Config.ResponseString"/>.
	/// </summary>
	public void CommunicateWithServer() { WebRequest request=WebRequest.Create(new Uri(this.Config.Uri)); this.Config.ResponseString=string.Empty; try { request.Timeout=120000; request.Proxy=null;
			using WebResponse response=request.GetResponse(); using Stream stream=response.GetResponseStream(); using StreamReader reader=new(stream); this.Config.ResponseString=reader.ReadToEnd(); reader.Close();
			stream.Flush(); stream.Close(); response.Close(); } catch (IOException) { throw; } catch (NotImplementedException) { throw; } catch (NotSupportedException) { throw; } catch (OutOfMemoryException) { throw; }
		catch (WebException) { throw; } finally { request.Abort(); GC.Collect(); GC.WaitForPendingFinalizers(); } }

	/// <returns>Result as bool</returns>
	public void ResetFields() { this.Config.Active=string.Empty; this.Config.FileName=string.Empty; this.Config.Format=string.Empty; this.Config.ResponseContainsData=false; this.Config.ResponseSaved=false; 
		this.Config.ResponseString=string.Empty; this.Config.Silo=string.Empty; this.Config.Uri=string.Empty; this.Config.UriContainsData=false;this.Config.Uuid=false; }

	#region Save
	/// <summary>Saves Config.ResponseString to disc</summary>
	public void SaveResponse() => this.Config.ResponseSaved=SaveToFile();

	/// <summary>Saves Config.ResponseString to disc</summary><returns>Result as bool</returns>
	private bool SaveToFile() { bool result; this.Config.ResponseContainsData=true; try { this.Config.ResponseContainsData=!string.IsNullOrWhiteSpace(this.Config.ResponseString);
		if (this.Config.ResponseContainsData) { DiscAccess.WriteStringToFile(Resources.ResourcesPath+"SdApi_"+this.Config.Api+"_"+this.Config.Silo+"_"+DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")+"."+Config.Format,
			this.Config.ResponseString); result=true; } else throw new OperationCanceledException("The "+nameof(this.Config.ResponseString)+" was empty."); } catch (Exception) { throw; } return result; }

	/// <returns>Result as bool</returns>
	public bool SaveResponseStringToFile() { string path=DiscAccess.CsvPath+this.Config.Api+"_"+DateTime.Today.ToString("yyyy-MM-dd")+".csv";
		if (DiscAccess.WriteStringToFile(path,this.Config.ResponseString)) { WriteStringLineToLogFile("- Response string was saved to "+path); return true; }
		else { WriteStringLineToLogFile("- Response string could not be saved to disc"+path); return false; } }

	#endregion

	/// <remarks />
	public void ShutdownServer() { WebRequest request=WebRequest.Create(@"http://localhost:8000/Shutdown"); request.Timeout=5000; request.Method="POST"; request.Proxy=null; try { using WebResponse response=
			request.GetResponse(); using Stream stream=response.GetResponseStream(); using StreamReader reader=new(stream); this.Config.ResponseString=reader.ReadToEnd(); reader.Close(); stream.Flush();
		stream.Close(); response.Close(); } catch (WebException) { throw; } finally { request.Abort(); GC.Collect(); GC.WaitForPendingFinalizers(); } if (!string.IsNullOrWhiteSpace(this.Config.ResponseString))
			this.Config.ResponseContainsData=true; else this.Config.ResponseContainsData=false; }

	/// <returns>Result as bool</returns><param name="lineContent" />
	public bool WriteStringLineToLogFile(string lineContent) { if (!string.IsNullOrWhiteSpace(config.LogFilePath)) { try { if(DiscAccess.FileExist(config.LogFilePath))
		return DiscAccess.WriteStringLineToFile(config.LogFilePath,lineContent); else return DiscAccess.WriteStringToFile(config.LogFilePath,lineContent+Environment.NewLine); } 
			catch (ExpressionException eex) { Console.WriteLine(eex.ToErrorString()); return false; } catch (Exception ex) { Console.WriteLine(ExpressionException.ToErrorString(ex)); return false; } } 
				else { Console.Write(lineContent); return false; } }

	#endregion
	#pragma warning restore SYSLIB0014

}
