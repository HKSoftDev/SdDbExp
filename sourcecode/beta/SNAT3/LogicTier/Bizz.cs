// Copyright (c) Daniel Giversen. All Rights reserved.
// Copyright (c) Haderslev Kommune. All Rights reserved.
// Licenced under Proprietary License. See License.txt
using LibDiscIO;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace LogicTier
{
	///<remarks />
	public class Bizz
	{
		#region Constructors
		///<remarks />
		public Bizz()
		{
			this.DiscAccess = new DiscAccess(AppDomain.CurrentDomain.FriendlyName);
			this.Client = new SynchronousSocketClient(this);
		}

		#endregion

		#region Properties
		///<remarks />
		public SynchronousSocketClient Client { get; set; }

		///<remarks />
		public DiscAccess DiscAccess { get; set; }

		#region Strings
		/// <remarks />
		public static string UserName { get; } = Environment.UserName;

		/// <remarks />
		public string Active { get; set; } = string.Empty;

		/// <remarks />
		public string Api { get; set; } = string.Empty;

		/// <remarks />
		public string FileName { get; set; } = string.Empty;

		/// <remarks />
		public string Format { get; set; } = string.Empty;

		/// <remarks />
		public string PassWord { get; set; } = string.Empty;

		/// <remarks />
		public string RequestString { get; set; } = string.Empty;

		/// <remarks />
		public string ResponseString { get; set; } = string.Empty;

		/// <remarks />
		public string Roles { get; set; } = string.Empty;

		/// <remarks />
		public string Silo { get; set; } = string.Empty;

		#endregion

		#region Booleans
		/// <remarkss />
		public bool RequestContainsData { get; set; }

		/// <remarkss />
		public bool ResponseContainsData { get; set; }

		/// <remarkss />
		public bool ResponseSaved { get; set; }

		/// <remarkss />
		public bool Uuid { get; set; }

		#endregion

		#endregion

		#region Methods

		private void CheckRequest()
		{
			if (RequestString.Length >= 1)
			{
				RequestContainsData = true;
			}
			else
			{
				RequestContainsData = false;
			}

		}

		#region Create Requests
		/// <summary>
		/// Creates request for 3IN1 APIs.
		/// </summary>
		/// <param name="apiType">E.g. 3in1 or moch</param>
		public void CreateSpecialApiRequest(string apiType)
		{
			switch (apiType)
			{
				case "3in1":
					RequestString = this.Api + @"?User=3IN1&Silo=" + Silo + @"&Format=" + Format;
					break;
				case "moch":
					RequestString = this.Api + @"?User=MOCH&Silo=" + Silo + @"&Format=" + Format + @"&Roles=" + Roles + @"&PassWord=" + PassWord;
					break;
				default:
					break;
			}

			CheckRequest();

		}

		/// <summary>
		/// Creates request for Default APIs.
		/// </summary>
		/// <param name="status"><see cref="bool"/></param>
		public void CreateDefaultApiRequest(bool status = false)
		{
			if (status)
			{
				RequestString = this.Api + @"?User=" + UserName + @"&Silo=" + Silo + @"&UUID=" + Uuid + @"&Active=" + Active + @"&Format=" + Format;
			}
			else
			{
				RequestString = this.Api + @"?User=" + UserName + @"&Silo=" + Silo + @"&UUID=" + Uuid + @"&Format=" + Format;
			}

			CheckRequest();

		}


		#endregion

		/// <summary>
		/// Resets fields in <see cref="Bizz"/>.
		/// </summary>
		public void ResetFields()
		{
			Active = string.Empty;
			Api = string.Empty;
			FileName = string.Empty;
			Format = string.Empty;
			PassWord = string.Empty;
			RequestString = string.Empty;
			ResponseString = string.Empty;
			Roles = string.Empty;
			Silo = string.Empty;

			RequestContainsData = false;
			ResponseContainsData = false;
			ResponseSaved = false;
			Uuid = false;

		}

		#region Save
		/// <summary>
		/// Saves <see cref="ResponseString"/> to disc.
		/// </summary>
		public void SaveResponse() => ResponseSaved = SaveToFile();

		/// <summary>
		/// Saves <see cref="ResponseString"/> to disc.
		/// </summary>
		/// <returns>bool</returns>
		private bool SaveToFile()
		{
			bool result = false;
			ResponseContainsData = true;

			try
			{
				if (ResponseString.Length < 1)
				{
					ResponseContainsData = false;
				}

				if (ResponseContainsData)
				{
					if (DiscAccess.RetrieveResourcesPath(out string path))
					{
						if (!ResponseString.Contains(@"<!DOCTYPE html>"))
						{
							DiscAccess.WriteStringToFile(ResponseString, new Uri(path.Replace("Resources", "CSV") + "SdNetApi_" + Api + "_" + Silo + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + "." + Format.ToLower()), Encoding.UTF8);
							result = true;
						}
						else
						{
							Uri uri = new Uri(path.Replace("Resources", "CSV") + "SdNetApi_" + Api + "_" + Silo + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".html");
							DiscAccess.WriteStringToFile(ResponseString, uri);
							System.Diagnostics.Process.Start(uri.AbsoluteUri);
						}
					}
				}
				else
				{
					throw new OperationCanceledException("The " + nameof(ResponseString) + " was empty.");
				}
			}
			catch (Exception)
			{
				throw;
			}

			return result;

		}

		#endregion

		/// <summary>
		/// Communicates with server and stores <see cref="ResponseString"/>.
		/// </summary>
		public void ShutdownServer()
		{
			WebRequest request = WebRequest.Create(@"http://localhost:8000/Shutdown");
			request.Timeout = 5000;
			request.Method = "POST";
			request.Proxy = null;

			try
			{
				using (WebResponse response = request.GetResponse())
				{
					using (Stream stream = response.GetResponseStream())
					{
						using (StreamReader reader = new StreamReader(stream))
						{
							ResponseString = reader.ReadToEnd();
							reader.Close();
						}
						stream.Flush();
						stream.Close();
					}
					response.Close();
				}
			}
			catch (WebException)
			{
				throw;
			}
			finally
			{
				request.Abort();
				request = null;
				GC.Collect();
			}

			if (ResponseString != null)
			{
				if (ResponseString.Length >= 1)
				{
					ResponseContainsData = true;
				}
			}
			else
			{
				ResponseContainsData = false;
			}

		}

		#endregion

	}
}
