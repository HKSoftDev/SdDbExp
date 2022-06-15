// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Config.Const.Static.FieldProps.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks />
public partial class Config //Const Fields and static props
{
	#region Fields

	/// <remarks />
	public const string Error400Data="<!DOCTYPE html>\r\n<html>\r\n  <head>\r\n    <title>400 Bad Request</title>\r\n  </head>\r\n  <body>\r\n    <H1>400 Bad Request</H1>\r\n    <p>The server cannot or will not process the request due to an apparent client error (e.g., malformed request syntax, size too large, invalid request message framing, or deceptive request routing).</p>\r\n  </body>\r\n</html>";

	/// <remarks />
	public const string Error401Data="<!DOCTYPE html>\r\n<html>\r\n  <head>\r\n    <title>401 Unauthorized</title>\r\n  </head>\r\n  <body>\r\n    <H1>401 Unauthorized</H1>\r\n    <p>Indicates that authentication is required and has failed or has not yet been provided. The user supplied in request does not have valid authentication credentials for the target resource.<p>\r\n  </body>\r\n</html>";

	/// <remarks />
	public const string Error415Data="<!DOCTYPE html>\r\n<html>\r\n  <head>\r\n    <title>415 Unsupported Media Type</title>\r\n  </head>\r\n  <body>\r\n    <H1>415 Unsupported Media Type</H1>\r\n    <p>Indicates that the requested Format is an unsupported type. Supported types are CSV, JSON & XML<p>\r\n  </body>\r\n</html>";

	/// <remarks />
	public const string Error501Data="<!DOCTYPE html>\r\n<html>\r\n  <head>\r\n    <title>501 NotImplemented</title>\r\n  </head>\r\n  <body>\r\n    <H1>501 NotImplemented</H1>\r\n    <p>Indicates that the server does not support the requested function.</p>\r\n  </body>\r\n</html>";

	/// <remarks />
	public const string PassWord = "Haderslev123", Roles="Haderslev";

	#endregion

	#region Properties

	/// <remarks/>
	public static List<string> InstitutionIdentifierList { get; } = new List<string> { "HB", "HI", "HW" };

	/// <remarks />
	public static string UserName { get; } = Environment.UserName;

	#endregion

}
