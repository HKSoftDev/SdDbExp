// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Mail.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Mail
{
	#region Methods

	/// <summary>Sends an email with logfile to recipient</summary>
	protected void MailError() => SendEmail("Error Mail created by "+config.AppName+" "+Config.Today,"bdbg@haderslev.dk","An error occured during runtime."+Environment.NewLine+"Runmode: "+config.RunMode,config.LogFilePath);

	/// <summary>Sends an email with logfile to recipient</summary><param name="content" />
	protected void MailError(string content) => SendEmail("Error Mail created by "+config.AppName+" "+Config.Today,"bdbg@haderslev.dk","An error occured during runtime."+Environment.NewLine+Environment.NewLine+content,config.LogFilePath);

	/// <summary>Displays field count in <see cref="Console"/></summary>
	/// <summary>Method,that sends an email with logfile to recipient</summary><param name="listPath">string</param>
	protected void MailXmList(string listPath) => SendEmail("Mail list created by XmAlert "+Config.Today,"nsc@haderslev.dk","Attached is a list of soon expiring employments.",Config.LogFilePath,listPath);

	/// <summary>Method, that creates a Mail Item</summary><param name="subject" /><param name="to" /><param name="body" /><param name="logFilePath" /><param name="listFilePath" />
	private bool SendEmail(string subject, string to, string body, string logFilePath, string? listFilePath=null) { if (to.IsNullOrWhiteSpace()) throw new ArgumentInvalidException(nameof(to),to,nameof(to));
		if (logFilePath.IsNullOrWhiteSpace()) throw new ArgumentInvalidException(nameof(logFilePath),logFilePath,nameof(logFilePath)); try { using SmtpClient client=new("smtphost.intern.udcit.dk",25);
			client.EnableSsl=false;  client.UseDefaultCredentials=true; using MailMessage message=new("dibdbg@haderslev.dk", to, subject, body); message.BodyEncoding=Encoding.UTF8; message.SubjectEncoding=Encoding.UTF8;
			message.Attachments.Add(new(logFilePath)); if (listFilePath!=null) message.Attachments.Add(new(listFilePath)); client.TargetName="STARTTLS/smtphost.intern.udcit.dk"; client.Send(message); return true; }
		catch (ExpressionException eex) { DiscAccess.WriteStringLineToFile(logFilePath,eex.ToErrorString()+Environment.NewLine); return false; }
		catch (Exception ex) { DiscAccess.WriteStringLineToFile(logFilePath,ExpressionException.ToErrorString(ex)+Environment.NewLine); return false; } }

	#endregion

}
