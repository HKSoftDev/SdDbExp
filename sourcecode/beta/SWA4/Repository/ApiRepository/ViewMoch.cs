// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewMoch.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace ApiRepository;

/// <remarks />
public partial class ViewMoch
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="\"handle\",\"name\",\"email\",\"ou_roles\",\"user_roles\",\"password\",\"tmp_password\"\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of <see cref="ViewMoch"/></summary>
	public ViewMoch ()	{ }

	/// <summary>Initializes a new instance of ViewMoch</summary><param name="cpr" /><param name="tjenestenr" /><param name="silo" /><param name="afdeling" />
	/// <param name="fornavn" /><param name="efternavn" /><param name="email1" /><param name="email2" />
	public ViewMoch(string cpr,string tjenestenr,string silo,string afdeling,string fornavn,string efternavn,string email1,string email2) { this.Cpr=cpr;
		this.Tjenestenummer=tjenestenr; this.Silo=silo; this.Afdeling=afdeling; this.Fornavn=fornavn; this.Efternavn=efternavn; this.Email1=email1; this.Email2=email2; }

	/// <summary>Initializes an instance of ViewMoch, that accepts data from an existing ViewMoch</summary><param name="entity" />
	public ViewMoch(ViewMoch entity) { this.Cpr=entity.Cpr; this.Tjenestenummer=entity.Tjenestenummer; this.Silo=entity.Silo; this.Afdeling=entity.Afdeling;
		this.Fornavn=entity.Fornavn; this.Efternavn=entity.Efternavn; this.Email1=entity.Email1; this.Email2=entity.Email2; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Cpr")][XmlElement("Cpr")]
	public string Cpr { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Tjenestenummer")][XmlElement("Tjenestenummer")]
	public string Tjenestenummer { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Silo")][XmlElement("Silo")]
	public string Silo { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Afdeling")][XmlElement("Afdeling")]
	public string Afdeling { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Fornavn")][XmlElement("Fornavn")]
	public string Fornavn { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Efternavn")][XmlElement("Efternavn")]
	public string Efternavn { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Email1")][XmlElement("Email1")]
	public string? Email1 { get; set; }

	/// <remarks />
	[JsonProperty("Email2")][XmlElement("Email2")]
	public string? Email2 { get; set; }

	#endregion

	#endregion

	#region Methods

	/// <remarks/>
	private string CheckEmail() { if (!string.IsNullOrEmpty(Email1)&&Email1.ToLower().Contains("haderslev.dk")) return Email1; else if (!string.IsNullOrEmpty(Email2)&&Email2.ToLower().Contains("haderslev.dk")) return Email2;
		else if (!string.IsNullOrEmpty(Email1)&&Email1.ToLower().Contains("udcit.dk")) return Email1; else if (!string.IsNullOrEmpty(Email2)&&Email2.ToLower().Contains("udcit.dk")) return Email2;
		else if (!string.IsNullOrEmpty(Email1)&&Email1.ToLower().Contains("skolekom.dk")) return Email1; else if (!string.IsNullOrEmpty(Email2)&&Email2.ToLower().Contains("skolekom.dk")) return Email2;
		else if (!string.IsNullOrEmpty(Email1)&&!Email1.Equals("Empty@Empty.Com")) return Email1; else if (!string.IsNullOrEmpty(Email2)&&!Email2.Equals("Empty@Empty.Com")) return Email2; else return "Empty@Empty.Com"; }

	/// <returns>this as CSV value string</returns><param name="user_roles" /><param name="tmp_password" />
	public string ToCsvValue(string user_roles, string tmp_password) { string email = CheckEmail(); string handle=string.Empty; if (email.Contains("haderslev")||email.Contains("udcit")) handle="di"+email.Remove(email.IndexOf("@"));
		return "\""+handle+"\",\""+Fornavn+" "+Efternavn+"\",\""+email+"\",\"/Root/MOCH/Haderslev Kommune/Haderslev Kommune/"+Afdeling+ ":User\",\""+user_roles+"\",\""+tmp_password+"\",\"true\"\r\n"; }

	/// <returns>this as XML string</returns><param name="user_roles" /><param name="tmp_password" />
	public string ToXmlString(string user_roles, string tmp_password)
	{
		string email = CheckEmail();
		string handle=string.Empty; if (email.Contains("haderslev")||email.Contains("udcit")) handle="di"+email.Remove(email.IndexOf("@"));

		string result = "<ViewMoch creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <handle>"+handle+"</handle>"+Environment.NewLine;
		result += "    <name>"+Fornavn+" "+Efternavn+"</name>"+Environment.NewLine;
		result += "    <email>"+email+"</email>"+Environment.NewLine;
		result += "    <ou_roles>/Root/MOCH/Haderslev Kommune/Haderslev Kommune/"+Afdeling+":User</ou_roles>"+Environment.NewLine;
		result += "    <user_roles>"+user_roles+"</user_roles>"+Environment.NewLine;
		result += "    <password>"+tmp_password+"</password>"+Environment.NewLine;
		result += "    <tmp_password>true</tmp_password>"+Environment.NewLine;
		result += "</ViewMoch>"+Environment.NewLine;

		return result;
	}

	#endregion

}
