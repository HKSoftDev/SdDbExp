// Copyright (c) Daniel Giversen. All Rights reserved.
// Copyright (c) Haderslev Kommune. All Rights reserved.
// Licenced under Proprietary License. See License.txt
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LogicTier
{
	/// <remarks />  
	public class SynchronousSocketClient
	{
		#region Fields
		private Bizz cbz;
		private const int port = 11000;

		#endregion

		#region Constructors
		/// <summary>
		/// Initiates an empty instance of <see cref="SynchronousSocketClient"/>.
		/// </summary>
		public SynchronousSocketClient() 
		{
			cbz = new Bizz();
		}

		/// <summary>
		/// Initiates a new instance of <see cref="SynchronousSocketClient"/>.
		/// </summary>
		/// <param name="bizz"><see cref="Bizz"/></param>
		public SynchronousSocketClient(Bizz bizz)
		{
			this.cbz = bizz;
		}

		#endregion

		#region Properties
		///<remarks />
		public int Port { get => port; }

		#endregion

		#region Methods
		/// <summary>
		/// Connect to a remote device.
		/// </summary>
		public void Connect()
		{
			//Assume true until disproven
			cbz.ResponseContainsData = true;

			// Data buffer for incoming data.  
			byte[] bytes = new byte[268435456];

			// Establish the remote endpoint for the socket.  
			// IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
			IPHostEntry ipHostInfo = Dns.GetHostEntry("udcsd");
			IPAddress ipAddress = ipHostInfo.AddressList[0];
			IPEndPoint remoteEP = new IPEndPoint(ipAddress, port);

			// Create a TCP/IP socket.
			using (Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
			{
				// Connect to a remote device.  
				try
				{
					// Connect to the remote endpoint.  
					sender.Connect(remoteEP);

					// Encode the data string into a byte array.  
					byte[] msg = Encoding.ASCII.GetBytes(cbz.RequestString);

					// Send the data through the socket.  
					int bytesSent = sender.Send(msg);

					// Receive the response from the remote device.  
					int bytesRec = sender.Receive(bytes);
					cbz.ResponseString = Encoding.ASCII.GetString(bytes, 0, bytesRec);

					if (string.IsNullOrWhiteSpace(cbz.ResponseString))
					{
						cbz.ResponseContainsData = false;
					}

					// Release the socket.  
					sender.Shutdown(SocketShutdown.Both);
					sender.Close();

				}
				catch (Exception)
				{
					throw;
				}
				finally
				{
					GC.Collect();
					GC.WaitForPendingFinalizers();
				}
			}

		}

		#endregion

	}
}
