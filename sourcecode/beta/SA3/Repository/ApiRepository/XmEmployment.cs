// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="XmEmployment.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks/>
public class XmEmployment
{
	#region Fields

	/// <remarks/>
	[NotMapped]
	public const string CsvHeader="EmploymentId;Cpr;GivenName;SurName;Silo;DeactivationDate;Email1;Email2\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of XmEmployment</summary>
	public XmEmployment() { }

	/// <summary>Initializes a new instance of XmEmployment</summary><param name="employmentId" /><param name="cpr" /><param name="givenName" /><param name="surName" /><param name="silo" />
	/// <param name="deactivationDate" /><param name="email1" /><param name="email2" />
	public XmEmployment(string employmentId, string cpr, string givenName, string surName, string silo, DateTime deactivationDate, string email1, string email2) { this.EmploymentId=employmentId;
		this.Cpr=cpr; this.GivenName=givenName; this.SurName=surName; this.Silo=silo; this.DeactivationDate=deactivationDate; this.Email1=email1; this.Email2=email2; }

	/// <summary>Initializes a new instance of XmEmployment</summary><param name="entity" /><exception cref="ArgumentOutOfRangeException" />
	public XmEmployment(XmEmployment entity) { this.EmploymentId=entity.EmploymentId; this.Cpr=entity.Cpr; this.GivenName=entity.GivenName; this.SurName=entity.SurName;
		this.Silo=entity.Silo; this.DeactivationDate=entity.DeactivationDate; this.Email1=entity.Email1; this.Email2=entity.Email2; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	[JsonProperty("EmploymentId")][XmlElement("EmploymentId")]
	public string EmploymentId { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Cpr")][XmlElement("Cpr")]
	public string Cpr { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("GivenName")][XmlElement("GivenName")]
	public string GivenName { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("SurName")][XmlElement("SurName")]
	public string SurName { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Silo")][XmlElement("Silo")]
	public string Silo { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public DateTime DeactivationDate { get; set; } = DateTime.Parse("9999-12-31");

	/// <remarks/>
	[JsonProperty("Email1")][XmlElement("Email1")]
	public string Email1 { get; set; } = string.Empty;

	/// <remarks/>
	[JsonProperty("Email2")][XmlElement("Email2")]
	public string Email2 { get; set; } = string.Empty;

	#endregion

	#region Other
	/// <remarks/>
	[NotMapped]
	public string CsvValue => EmploymentId+@";"+Cpr+@";"+GivenName+@";"+SurName+@";"+Silo+@";"+DeactivationDate.ToString("yyyy-MM-dd")+@";"+Email1+@";"+Email2+"\r\n";

	/// <remarks/>
	[NotMapped]
	public string TKey => GivenName+" "+SurName+" ("+Cpr+"-"+EmploymentId+")";

	#endregion

	#endregion

	#region Methods

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if (this==null) throw new NullReferenceException(); if (!string.IsNullOrEmpty(EmploymentId)) return false; else if (!string.IsNullOrEmpty(Cpr)) return false;
	else if (!string.IsNullOrEmpty(GivenName)) return false; else if (!string.IsNullOrEmpty(SurName)) return false; else if (!this.DeactivationDate.Equals(DateTime.Parse("9999-12-31"))) return false;
	else if (!string.IsNullOrEmpty(Email1)) return false; else if (!string.IsNullOrEmpty(Email2)) return false; else return true; }

	/// <returns>Content of XmEmployment as string</returns>
	public override string ToString() { if (this==null) return "null"; else return TKey; }

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<XmEmployment creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <EmploymentId>"+EmploymentId+"<\\EmploymentId>"+Environment.NewLine;
		result += "    <Cpr>"+Cpr+"<\\Cpr>"+Environment.NewLine;
		result += "    <GivenName>"+GivenName+"<\\GivenName>"+Environment.NewLine;
		result += "    <SurName>"+SurName+"<\\SurName>"+Environment.NewLine;
		result += "    <Silo>"+Silo+"<\\Silo>"+Environment.NewLine;
		result += "    <DeactivationDate>"+DeactivationDate.ToString("yyyy-MM-dd")+"<\\DeactivationDate>"+Environment.NewLine;
		result += "    <Email1>"+Email1+"<\\Email1>"+Environment.NewLine;
		result += "    <Email2>"+Email2+"<\\Email2>"+Environment.NewLine;
		result += "<\\XmEmployment>"+Environment.NewLine; return result; }

	#endregion

}
