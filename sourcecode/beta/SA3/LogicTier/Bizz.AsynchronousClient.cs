// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Process.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks />  
public class AsynchronousClient
{
	#pragma warning disable CS8600
	#pragma warning disable CS8602
	#pragma warning disable IDE0044
	#region Fields
	private Bizz cbz=new();
	private const int port=11000;

	// ManualResetEvent instances signal completion.  
	private static ManualResetEvent connectDone=new(false), sendDone=new(false), receiveDone=new(false);

	// The response from the remote device.  
	private static string response=string.Empty;

	#endregion

	#region Constructors
	/// <summary>Initiates an empty instance of AsynchronousClient</summary>
	public AsynchronousClient() { }

	/// <summary>Initiates a new instance of AsynchronousClient</summary><param name="bizz" />
	public AsynchronousClient(Bizz bizz) { this.cbz=bizz; }

	#endregion

	#region Methods
	/// <summary>Connect to a remote device</summary>
	public void Connect() { try { IPHostEntry ipHostInfo=Dns.GetHostEntry("udcsd"); IPAddress ipAddress=ipHostInfo.AddressList[0]; IPEndPoint remoteEP=new(ipAddress, port);
			using Socket client=new(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp); client.BeginConnect(remoteEP, new AsyncCallback(ConnectCallback), client); connectDone.WaitOne();
			Send(client, cbz.Config.Uri); sendDone.WaitOne(); Receive(client); receiveDone.WaitOne(); Console.WriteLine("Response received : {0}", response); client.Shutdown(SocketShutdown.Both); client.Close(); }
		catch (Exception e) { Console.WriteLine(e.ToString()); } finally { GC.Collect(); GC.WaitForPendingFinalizers(); } }

	/// <remarks /><param name="ar" />
	private void ConnectCallback(IAsyncResult ar) { try { using Socket client=(Socket)ar.AsyncState; client.EndConnect(ar); Console.WriteLine("Socket connected to {0}", client.RemoteEndPoint.ToString()); connectDone.Set(); }
		catch (Exception e) { Console.WriteLine(e.ToString()); } }

	/// <remarks /><param name="client" />
	private void Receive(Socket client) { try { StateObject state=new() { WorkSocket = client }; client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state); }
		catch (Exception e) { Console.WriteLine(e.ToString()); } }

	/// <remarks /><param name="ar" />
	private void ReceiveCallback(IAsyncResult ar) { try { StateObject state=(StateObject)ar.AsyncState; using Socket client=state.WorkSocket; int bytesRead=client.EndReceive(ar); if (bytesRead > 0) {
			state.Sb.Append(Encoding.ASCII.GetString(state.Buffer, 0, bytesRead)); client.BeginReceive(state.Buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReceiveCallback), state); }
		else { if (state.Sb.Length > 1) cbz.Config.ResponseString=state.Sb.ToString(); receiveDone.Set(); } } catch (Exception e) { Console.WriteLine(e.ToString()); } }

	/// <summary>Sends data to socket</summary><param name="client" /><param name="data" />
	private void Send(Socket client, string data) { byte[] byteData=Encoding.ASCII.GetBytes(data); client.BeginSend(byteData, 0, byteData.Length, 0, new AsyncCallback(SendCallback), client); }

	/// <remarks /><param name="ar" />
	private void SendCallback(IAsyncResult ar) { try { using Socket client=(Socket)ar.AsyncState; int bytesSent=client.EndSend(ar); Console.WriteLine("Sent {0} bytes to server.", bytesSent); sendDone.Set(); }
		catch (Exception e) { Console.WriteLine(e.ToString()); } }

	#endregion
	#pragma warning restore CS8600
	#pragma warning restore CS8602
	#pragma warning restore IDE0044

}
