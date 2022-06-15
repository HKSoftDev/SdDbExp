// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ADUser.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

///<remarks />
public class ADUser
{
	#region Constructors

	/// <summary>Initializes an empty instance of ADUser</summary>
	public ADUser() { }

	/// <summary>Initializes a new instance of ADUser</summary><param name="uId">UserId</param><param name="title" /><param name="fName">FullName</param><param name="dispName">DisplayName</param><param name="empId">employmentId</param><param name="empNo">EmployeeNumber</param>
	/// <param name="pgId">PrimaryGroupId</param><param name="memOf">MemberOf</param><param name="init">Initials</param><param name="gName">GivenName</param><param name="sName">SurName</param><param name="mail" /><param name="phone">Telephone</param><param name="IpPhone">IpPhone</param>
	/// <param name="mPhone">MobilePhone</param><param name="oPhone">OtherTelephone</param><param name="office" /><param name="comp">Company</param><param name="dept">Department</param><param name="distName">DistinguishedName</param><param name="aPath">AdsPath</param>
	public ADUser(string uId, string title, string fName, string dispName, string empId, string empNo, string pgId, string memOf, string init, string gName, string sName, string mail, string phone, string IpPhone, string mPhone, string oPhone, 
		string office, string comp, string dept, string distName, string aPath)
	{
		this.UserId=uId;
		this.Title=title;
		this.FullName=fName;
		this.DisplayName=dispName;
		this.EmployeeId=empId;
		this.EmployeeNumber=empNo;
		this.PrimaryGroupId=pgId;
		this.MemberOf=memOf;
		this.Initials=init;
		this.GivenName=gName;
		this.SurName=sName;

		if (!string.IsNullOrWhiteSpace(mail)) this.Mail=mail;
		else if (!string.IsNullOrWhiteSpace(UserId)) this.Mail=ConvertUserIdToMail(UserId);

		this.Telephone=phone;
		this.IpPhone=IpPhone;
		this.MobilePhone=mPhone;
		this.OtherTelephone=oPhone;
		this.Office=office;
		this.Company=comp;
		this.Department=dept;
		this.DistinguishedName=distName;
		this.AdsPath=aPath;

	}

	/// <summary>Initializes an instance of ADUser, that accepts data from an existing ADUser</summary><param name="user" />
	public ADUser(ADUser user)
	{
			this.UserId=user.UserId;
			this.Title=user.Title;
			this.FullName=user.FullName;
			this.DisplayName=user.DisplayName;
			this.EmployeeId=user.EmployeeId;
			this.EmployeeNumber=user.EmployeeNumber;
			this.PrimaryGroupId=user.PrimaryGroupId;
			this.MemberOf=user.MemberOf;
			this.Initials=user.Initials;
			this.GivenName=user.GivenName;
			this.SurName=user.SurName;

			if (!string.IsNullOrWhiteSpace(user.Mail)) this.Mail=user.Mail;
			else if (!string.IsNullOrWhiteSpace(user.UserId)) this.Mail=ConvertUserIdToMail(UserId);

			this.Telephone=user.Telephone;
			this.IpPhone=user.IpPhone;
			this.MobilePhone=user.MobilePhone;
			this.OtherTelephone=user.OtherTelephone;
			this.Office=user.Office;
			this.Company=user.Company;
			this.Department=user.Department;
			this.DistinguishedName=user.DistinguishedName;
			this.AdsPath=user.AdsPath;

	}

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
	public string Telephone { get; set; } = string.Empty;

	///<remarks />
	public string IpPhone { get; set; } = string.Empty;

	///<remarks />
	public string MobilePhone { get; set; } = string.Empty;

	///<remarks />
	public string OtherTelephone { get; set; } = string.Empty;

	///<remarks />
	public string Office { get; set; } = string.Empty;

	///<remarks />
	public string Company { get; set; } = string.Empty;

	///<remarks />
	public string Department { get; set; } = string.Empty;

	///<remarks />
	public string DistinguishedName { get; set; } = string.Empty;

	///<remarks />
	public string AdsPath { get; set; } = string.Empty;

	#endregion

	#region Other
	///<remarks />
	public string XmlHeader => "UserId;Title;Full Name;Display Name;Employee ID;Employee Number;Primary Group Id;Member Of;Initials;Given Name;SurName;Mail;Telephone;IP Phone;Mobile Phone;Other Telephone;Office;Company;Department;Distinguished Name;ADs Path";

	///<remarks />
	public string XmlString => UserId+";"+Title+";"+FullName+";"+DisplayName+";"+EmployeeId+";"+EmployeeNumber+";"+PrimaryGroupId+";"+MemberOf+";"+Initials+";"+GivenName+";"+SurName+";"+
		Mail+";"+Telephone+";"+IpPhone+";"+MobilePhone+";"+OtherTelephone+";"+Office+";"+Company+";"+Department+";"+DistinguishedName+";"+AdsPath;

	#endregion

	#endregion

	#region Methods
	///<returns>Requested mail address</returns>
	private string ConvertUserIdToMail(string userId) { if (userId.Contains(Convert.ToChar("@"))) { string result=userId; if (result.Remove(2).ToLower().Equals("di")) result=result.Remove(0,2);
		return result.ToLower(); } else return string.Empty; }

	///<returns>This entity as string</returns>
	public override string ToString() { if (this==null) return "null"; string result=string.Empty;
		if (!string.IsNullOrWhiteSpace(this.UserId)) result += "User Id: "+UserId+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.Title)) result += "Title: "+Title+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.FullName)) result += "Full Name: "+FullName+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.DisplayName)) result += "Display Name: "+DisplayName+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.EmployeeId)) result += "Employee ID: "+EmployeeId+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.EmployeeNumber)) result += "Employee Number: "+EmployeeNumber+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.PrimaryGroupId)) result += "Primary Group Id: "+PrimaryGroupId+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.MemberOf)) result += "Member Of: "+MemberOf+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.Initials)) result += "Initials: "+Initials+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.GivenName)) result += "Given Name: "+GivenName+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.SurName)) result += "SurName: "+SurName+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.Mail)) result += "Mail: "+Mail+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.Telephone)) result += "Telephone: "+Telephone+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.IpPhone)) result += "IP Phone: "+IpPhone+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.MobilePhone)) result += "Mobile Phone: "+MobilePhone+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.OtherTelephone)) result += "Other Telephone: "+OtherTelephone+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.Office)) result += "Office: "+Office+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.Company)) result += "Company: "+Company+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.Department)) result += "Department: "+Department+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.DistinguishedName)) result += "Distinguished Name: "+DistinguishedName+Environment.NewLine;
		if (!string.IsNullOrWhiteSpace(this.AdsPath)) result += "ADs Path: "+AdsPath+Environment.NewLine; return result; }

	#endregion

}
