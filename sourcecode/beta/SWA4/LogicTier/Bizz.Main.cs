// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Main.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Main
{
	#region Methods


	/// <summary>Accept a CallBack on socket</summary><param name="ar" />
	#pragma warning disable CS8600
	#pragma warning disable CS8602
	public void AcceptCallback(IAsyncResult ar)
	{
		// Signal the main thread to continue.  
		allDone.Set();

		// Get the socket that handles the client request.
		Socket listener=(Socket)ar.AsyncState;
		Socket handler=listener.EndAccept(ar);

		// Create the state object.  
		StateObject state=new() { WorkSocket=handler };
		handler.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
	}

	/// <summary>Displays execution help</summary>
	public void DisplayHelp() { switch (Config.AppName) { case "SetRetrDataClone": Console.WriteLine("Downloads all person data from Silkeborg Data."); break;
			case "SetRetrDataUpdate": Console.WriteLine("Downloads updated person data from Silkeborg Data."); break;
			case "SetRetrDepData": Console.WriteLine("Downloads dependency data from Silkeborg Data."); break;
			case "SetUpdtDataClone": Console.WriteLine("Clones person data from disk to database."); break;
			case "SetUpdtDataUpdate": Console.WriteLine("Updates person data from disk to database."); break;
			case "SetUpdtDepClone": Console.WriteLine("Clones dependency data from disk to database."); break;
			case "SetUpdtDepUpdate": Console.WriteLine("Updates dependency data from disk to database."); break; }
		Console.WriteLine(Environment.NewLine+Config.AppName+Environment.NewLine+Config.AppName+" [instId]"+Environment.NewLine+Config.AppName+" [help]"+Environment.NewLine+
			Environment.NewLine+"instId - Specify the institution identifier as 'HB','HI',or 'HW'."+Environment.NewLine+"help - displays this help section"+Environment.NewLine+
			"-help - displays this help section"+Environment.NewLine+"-h - displays this help section"+Environment.NewLine+"/H - displays this help section"+Environment.NewLine+
			"/? - displays this help section"+Environment.NewLine+"-help - displays this help section"+Environment.NewLine+Environment.NewLine+"The 'HB' instId identifies Haderslev kommune"+
			Environment.NewLine+"The 'HI' instId identifies Haderslev Museum"+Environment.NewLine+"The 'HW' instId identifies Haderslev kommunes Familiepleje"); }

	/// <summary>Displays or logs Config.xml error message</summary><param name="args" /><param name="exception" />
	public void HandleError(string[] args,string exception) { string log = "- Log for "+Config.AppName+" running in "+Config.RunMode+@" mode "+Environment.NewLine+"- Log initiated "+DateTime.Now.ToString("r")+" "+
		Environment.NewLine+"- Arguments: "; Parallel.ForEach(args,item => log+=item+@","); log=log.TrimEnd(Convert.ToChar(@",")); log+=Environment.NewLine+"- An unhandled run error occurred:"+Environment.NewLine+exception+
		Environment.NewLine+ "- "+CurrentMethod()+" line "+CurrentLineNumber()+Environment.NewLine+Environment.NewLine+"- Log concluded "+DateTime.Now.ToString("r")+" "; WriteStringLineToLogFile(log); MailError(); }

	/// <summary>Reads a CallBack from socket</summary><param name="ar" />
	public void ReadCallback(IAsyncResult ar)
	{
		string content = string.Empty;

		// Retrieve the state object and the handler socket from the asynchronous state object.  
		StateObject state=(StateObject)ar.AsyncState;

		Socket handler=state.WorkSocket;

		// Read data from the client socket.
		int bytesRead=handler.EndReceive(ar);

		if (bytesRead > 0)
		{
			// There  might be more data, so store the data received so far.  
			state.Sb.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead));

			// Check for end-of-file tag. If it is not there, read
			// more data.  
			content=state.Sb.ToString();

			if (content.IndexOf("<EOF>") > -1 || content.Contains("User"))
			{
				// All the data has been read from the
				// client. Display it on the console.  
				Console.WriteLine("Read {0} bytes from socket. \n Data : {1}", content.Length, content);

				//Process the responce
				ProcessResponce(content);

				// Send responce data back to the client.  
				Send(handler,this.Config.PageData);

			}
			else
			{
				// Not all data received. Get more.  
				handler.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
			}
		}

	}
	#pragma warning restore CS8600
	#pragma warning restore CS8602

	#region S

	#region Set Parameters

	/// <remarks/>
	public void SetCloneDepartmentsParameters() { this.Config.ContactInformationsUpdated=0; this.Config.ContactInformationsNotUpdated=0; this.Config.PostalAddressesUpdated=0; this.Config.PostalAddressesNotUpdated=0;
		this.Config.DepartmentsUpdated=0; this.Config.DepartmentsNotUpdated=0;}

	/// <remarks/>
	public void SetCloneInstitutionsParameters() { this.Config.InstitutionsUpdated=0; this.Config.InstitutionsNotUpdated=0; }

	/// <remarks/>
	public void SetCloneOrganizationsParameters() { this.Config.OrganizationsUpdated=0; this.Config.OrganizationsNotUpdated=0; this.Config.OrganizationStructuresUpdated=0; this.Config.OrganizationStructuresNotUpdated=0;
		this.Config.DepartmentLevelReferencesUpdated=0; this.Config.DepartmentLevelReferencesNotUpdated=0; this.Config.DepartmentReferencesUpdated=0; this.Config.DepartmentReferencesNotUpdated=0; }

	/// <remarks/>
	public void SetCloneProfessionsParameters() { this.Config.ProfessionsUpdated=0; this.Config.ProfessionsNotUpdated=0; }

	/// <remarks/>
	public void SetEmploymentsParameters() { this.Config.EmploymentProfessionsUpdated=0; this.Config.EmploymentProfessionsNotUpdated=0; this.Config.EmploymentStatusesUpdated=0; this.Config.EmploymentStatusesNotUpdated=0;
		this.Config.SalaryAgreementsUpdated=0; this.Config.SalaryAgreementsNotUpdated=0; this.Config.SalaryCodeGroupsUpdated=0; this.Config.SalaryCodeGroupsNotUpdated=0; this.Config.WorkingTimesUpdated=0;
		this.Config.WorkingTimesNotUpdated=0; this.Config.EmploymentsUpdated=0; this.Config.EmploymentsNotUpdated=0;}

	/// <remarks/>
	public void SetEmploymentsChangedParameters() { this.Config.EmploymentProfessionsIgnored=0; this.Config.EmploymentStatusesIgnored=0; this.Config.SalaryAgreementsIgnored=0;
		this.Config.SalaryCodeGroupsIgnored=0; this.Config.WorkingTimesIgnored=0; this.Config.EmploymentsIgnored=0; SetEmploymentsParameters(); }

	/// <remarks/>
	public void SetEmploymentsChangedAtDateParameters() => SetEmploymentsChangedParameters();

	/// <remarks/>
	public void SetPersonsChangedAtDateParameters() { this.Config.ContactInformationsIgnored=0; this.Config.PostalAddressesIgnored=0; this.Config.PersonsIgnored=0; SetPersonsParameters(); }

	/// <remarks/>
	public void SetPersonsParameters() { this.Config.ContactInformationsUpdated=0; this.Config.ContactInformationsNotUpdated=0; this.Config.PostalAddressesUpdated=0; this.Config.PostalAddressesNotUpdated=0;
		this.Config.PersonsUpdated=0; this.Config.PersonsNotUpdated=0; }

	/// <remarks/>
	public void SetUpdateDepartmentsParameters() { this.Config.ContactInformationsIgnored=0; this.Config.PostalAddressesIgnored=0; this.Config.DepartmentsIgnored=0; SetCloneDepartmentsParameters(); }

	/// <remarks/>
	public void SetUpdateInstitutionsParameters() { this.Config.InstitutionsIgnored=0; SetCloneInstitutionsParameters(); }

	/// <remarks/>
	public void SetUpdateOrganizationsParameters() { this.Config.OrganizationsIgnored=0; this.Config.OrganizationStructuresIgnored=0; this.Config.DepartmentLevelReferencesIgnored=0; this.Config.DepartmentReferencesIgnored=0; SetCloneOrganizationsParameters(); }

	/// <remarks/>
	public void SetUpdateProfessionsParameters() { this.Config.ProfessionsIgnored=0; SetCloneProfessionsParameters(); }

	#endregion

	/// <summary>Listens for call on socket</summary>
	public void StartListening()
	{
		IPHostEntry ipHostInfo=Dns.GetHostEntry(Dns.GetHostName());
		IPAddress ipAddress=ipHostInfo.AddressList[1];
		IPEndPoint localEndPoint=new(ipAddress, 11000);
		this.Config.RunServer=true;



		Console.WriteLine($"Local address and port : {localEndPoint}");

		// Create a TCP/IP socket.
		using Socket listener=new(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

		// Bind the socket to the local endpoint and listen for incoming connections.  
		try
		{
			listener.Bind(localEndPoint);
			listener.Listen(100);

			while (this.Config.RunServer)
			{
				// Set the event to nonsignaled state.  
				allDone.Reset();

				// Start an asynchronous socket to listen for connections.  
				listener.BeginAccept(new AsyncCallback(AcceptCallback),listener);

				// Wait until a connection is made before continuing.  
				Console.WriteLine("Waiting for a connection...");
				allDone.WaitOne();
			}

		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
		}

		listener.Dispose();
		allDone.Dispose();
		Console.WriteLine("Closing the listener...");


	}

	#endregion

	/// <returns>Result as bool</returns><param name="lineContent" />
	public bool WriteStringLineToLogFile(string lineContent) { if (!config.LogFilePath.IsNullOrWhiteSpace()) { try { if (DiscAccess.FileExist(config.LogFilePath))
		return DiscAccess.WriteStringLineToFile(config.LogFilePath,lineContent); else return DiscAccess.WriteStringToFile(config.LogFilePath,lineContent+Environment.NewLine); } 
			catch (ExpressionException eex) { Console.WriteLine(eex.ToErrorString()); return false; } catch (Exception ex) { Console.WriteLine(ExpressionException.ToErrorString(ex)); return false; } } 
				else { Console.Write(lineContent); return false; } }

	#endregion

}
