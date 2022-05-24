// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ADUser.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

///<remarks />
public class ADUser
{
	#region Fields

	///<remarks />
	[NotMapped]
	public const string CsvHeader="UserId;Title;Full Name;Display Name;Employee ID;Employee Number;Primary Group Id;Member Of;Initials;Given Name;SurName;Mail;Mobile Phone;Office;Company;Department;DepartmentNumber;Distinguished Name;ADs Path\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ADUser</summary>
	public ADUser() { }

	/// <summary>Initializes a new instance of ADUser</summary><param name="userId" /><param name="title" /><param name="fullName" /><param name="displayName" /><param name="employmentId" /><param name="employeeNumber" />
	/// <param name="primaryGroupId" /><param name="memberOf" /><param name="initials" /><param name="givenName" /><param name="surName" /><param name="mail" /><param name="mobilePhone" /><param name="office" />
	/// <param name="company" /><param name="department" /><param name="departmentNumber" /><param name="distinguishedName" /><param name="adsPath" />
	public ADUser(string userId,string title,string fullName,string displayName,string employmentId,string employeeNumber,string primaryGroupId,string memberOf,string initials,string givenName,string surName,string mail,
		string mobilePhone,string office,string company,string department,string departmentNumber,string distinguishedName,string adsPath) { this.UserId=userId; this.Title=title; this.FullName=fullName;
		this.DisplayName=displayName; this.EmployeeId=employmentId; this.EmployeeNumber=employeeNumber; this.PrimaryGroupId=primaryGroupId; this.MemberOf=memberOf; this.Initials=initials; this.GivenName=givenName;
		this.SurName=surName; if (!string.IsNullOrWhiteSpace(mail)) this.Mail=mail; else if (!string.IsNullOrWhiteSpace(UserId)) this.Mail=ConvertUserIdToMail(UserId); this.MobilePhone=mobilePhone; this.Office=office;
		this.Company=company; this.Department=department; this.DepartmentNumber=departmentNumber; this.DistinguishedName=distinguishedName; this.AdsPath=adsPath; }

	/// <summary>Initializes an instance of ADUser, that accepts data from an existing ADUser</summary><param name="user" />
	public ADUser(ADUser user) { this.UserId=user.UserId; this.Title=user.Title; this.FullName=user.FullName; this.DisplayName=user.DisplayName; this.EmployeeId=user.EmployeeId; this.EmployeeNumber=user.EmployeeNumber;
		this.PrimaryGroupId=user.PrimaryGroupId; this.MemberOf=user.MemberOf; this.Initials=user.Initials; this.GivenName=user.GivenName; this.SurName=user.SurName; if (!string.IsNullOrWhiteSpace(user.Mail)) this.Mail=user.Mail;
		else if (!string.IsNullOrWhiteSpace(user.UserId)) this.Mail=ConvertUserIdToMail(UserId); this.MobilePhone=user.MobilePhone; this.Office=user.Office; this.Company=user.Company; this.Department=user.Department;
		this.DepartmentNumber=user.DepartmentNumber; this.DistinguishedName=user.DistinguishedName; this.AdsPath=user.AdsPath; }

	#endregion

	#region Properties

	#region AD Data

	///<remarks />
	public string UserId { get; set; } = string.Empty;

	///<remarks />
	public string Title { get; set; } = string.Empty;

	///<remarks />
	public string FullName { get; set; } = string.Empty;

	///<remarks />
	public string DisplayName { get; set; } = string.Empty;

	///<remarks />
	public string EmployeeId { get; set; } = string.Empty;

	///<remarks />
	public string EmployeeNumber { get; set; } = string.Empty;

	///<remarks />
	public string PrimaryGroupId { get; set; } = string.Empty;

	///<remarks />
	public string MemberOf { get; set; } = string.Empty;

	///<remarks />
	public string Initials { get; set; } = string.Empty;

	///<remarks />
	public string GivenName { get; set; } = string.Empty;

	///<remarks />
	public string SurName { get; set; } = string.Empty;

	///<remarks />
	public string Mail { get; set; } = string.Empty;

	///<remarks />
	public string MobilePhone { get; set; } = string.Empty;

	///<remarks />
	public string Office { get; set; } = string.Empty;

	///<remarks />
	public string Company { get; set; } = string.Empty;

	///<remarks />
	public string Department { get; set; } = string.Empty;

	///<remarks />
	public string DepartmentNumber { get; set; } = string.Empty;

	///<remarks />
	public string DistinguishedName { get; set; } = string.Empty;

	///<remarks />
	public string AdsPath { get; set; } = string.Empty;

	#endregion

	#region Other

	///<remarks />
	[NotMapped]
	public string CsvValue => UserId+";"+Title+";"+FullName+";"+DisplayName+";"+EmployeeId+";"+EmployeeNumber+";"+PrimaryGroupId+";"+MemberOf+";"+Initials+";"+
		GivenName+";"+SurName+";"+Mail+";"+MobilePhone+";"+Office+";"+Company+";"+Department+";"+DepartmentNumber+";"+DistinguishedName+";"+AdsPath+"\r\n";

	#endregion

	#endregion

	#region Methods
	///<returns>Requested mail address</returns>
	private string ConvertUserIdToMail(string userId) { if (userId.Contains(Convert.ToChar("@"))) { string result=userId; if (result.Remove(2).ToLower().Equals("di")) result=result.Remove(0,2);
		return result.ToLower(); } else return string.Empty; }

	///<returns>This entity as string</returns>
	public string ToMultiLineString() { if (this==null) return "null"; string result=string.Empty; if (!string.IsNullOrWhiteSpace(this.UserId)) result += "User Id: "+UserId+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.Title)) result += "Title: "+Title+Environment.NewLine; if (!string.IsNullOrWhiteSpace(this.FullName)) result += "Full Name: "+FullName+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.DisplayName)) result += "Display Name: "+DisplayName+Environment.NewLine; if (!string.IsNullOrWhiteSpace(this.EmployeeId)) result += "Employee ID: "+EmployeeId+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.EmployeeNumber)) result += "Employee Number: "+EmployeeNumber+Environment.NewLine; if (!string.IsNullOrWhiteSpace(this.PrimaryGroupId)) result += "Primary Group Id: "+PrimaryGroupId+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.MemberOf)) result += "Member Of: "+MemberOf+Environment.NewLine; if (!string.IsNullOrWhiteSpace(this.Initials)) result += "Initials: "+Initials+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.GivenName)) result += "Given Name: "+GivenName+Environment.NewLine; if (!string.IsNullOrWhiteSpace(this.SurName)) result += "SurName: "+SurName+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.Mail)) result += "Mail: "+Mail+Environment.NewLine; if (!string.IsNullOrWhiteSpace(this.MobilePhone)) result += "Mobile Phone: "+MobilePhone+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.Office)) result += "Office: "+Office+Environment.NewLine; if (!string.IsNullOrWhiteSpace(this.Company)) result += "Company: "+Company+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.Department)) result += "Department: "+Department+Environment.NewLine; if (!string.IsNullOrWhiteSpace(this.DistinguishedName)) result += "Distinguished Name: "+DistinguishedName+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.AdsPath)) result += "ADs Path: "+AdsPath+Environment.NewLine;return result; }

	///<returns>This entity as string</returns>
	public override string ToString() { if (this==null) return "null"; return FullName+" ("+UserId+" - "+Department+")"; }

	#endregion

}
