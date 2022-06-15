// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Miscellaneous.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Miscellaneous
{
	#region Methods

	/// <returns>Current line number as int</returns><param name="lineNumber" />
	private static int CurrentLineNumber([CallerLineNumber] int lineNumber=0) => lineNumber;

	/// <returns>Current method name as string</returns><param name="memberName" />
	private static string CurrentMethod([CallerMemberName] string memberName="") => currentMethod+"."+memberName+"()";

	/// <summary>Checks, wether a user is part of of the SD security group</summary>
	private void Authentication() { if (string.IsNullOrWhiteSpace(this.Config.User)) this.Config.User=Config.UserName; if (this.Config.User.ToLower().Equals("3in1")||this.Config.User.ToLower().Equals("moch")) this.Config.Authorized = true;
		else { try { using WindowsIdentity winid = new(this.Config.User); WindowsPrincipal principal = new(winid); this.Config.Authorized = principal.IsInRole("SdDatabase_Gruppe"); }
			catch (ExpressionException eex) { this.Config.Authorized = false; WriteStringLineToLogFile(Environment.NewLine+"- Authentification Error:"+Environment.NewLine+eex.ToErrorString()+Environment.NewLine+Environment.NewLine); }
			catch (Exception ex) { this.Config.Authorized = false; WriteStringLineToLogFile(Environment.NewLine+"- Authentification Error:"+Environment.NewLine+ExpressionException.ToErrorString(ex)+Environment.NewLine+Environment.NewLine); } } }

	#endregion

}
