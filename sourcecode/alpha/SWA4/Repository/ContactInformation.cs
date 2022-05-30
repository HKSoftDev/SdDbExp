// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactInformation.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
using System.Net.Mail;
using PhoneNumbers;

namespace Repository;

/// <remarks/>
public partial class ContactInformation
{
	#region Constructors

	/// <summary>Initializes an empty instance of ContactInformation</summary>
	public ContactInformation() { }

	/// <summary>Initializes a new instance of ContactInformation</summary><param name="parentId" /><param name="institutionId" /><param name="phone1" /><param name="phone2" />
	/// <param name="email1" /><param name="email2" />
	public ContactInformation(string parentId,string institutionId,string phone1,string phone2,string email1,string email2) { this.ParentIdentifier=parentId; this.InstitutionIdentifier=institutionId;
		this.TelephoneNumberIdentifier1=phone1; this.TelephoneNumberIdentifier2=phone2; this.EmailAddressIdentifier1=email1; this.EmailAddressIdentifier2=email2; Validate(); }

	/// <summary>Initializes a new instance of ContactInformation from database</summary><param name="id" /><param name="parentId" /><param name="institutionId" /><param name="phone1" />
	/// <param name="phone2" /><param name="email1" /><param name="email2" />
	public ContactInformation(int id,string parentId,string institutionId,string phone1,string phone2,string email1,string email2) { this.Id=id; this.ParentIdentifier=parentId; 
		this.InstitutionIdentifier=institutionId; this.TelephoneNumberIdentifier1=phone1; this.TelephoneNumberIdentifier2=phone2; this.EmailAddressIdentifier1=email1; this.EmailAddressIdentifier2=email2; }

	/// <summary>Initializes a new instance of ContactInformation from database</summary><param name="array" />
	public ContactInformation(string[] array) { this.Id=int.Parse(array[0]); this.ParentIdentifier=array[1]; this.InstitutionIdentifier=array[2];
		this.TelephoneNumberIdentifier1=array[3]; this.TelephoneNumberIdentifier2=array[4]; this.EmailAddressIdentifier1=array[5]; this.EmailAddressIdentifier2=array[6]; }

	/// <summary>Initializes a new instance of ContactInformation, that accepts data from existing ContactInformation</summary><param name="entity" />
	public ContactInformation(ContactInformation entity) { this.Id=entity.Id; this.ParentIdentifier=entity.ParentIdentifier; this.InstitutionIdentifier=entity.InstitutionIdentifier;
		this.TelephoneNumberIdentifier1=entity.TelephoneNumberIdentifier1; this.TelephoneNumberIdentifier2=entity.TelephoneNumberIdentifier2;
		this.EmailAddressIdentifier1=entity.EmailAddressIdentifier1; this.EmailAddressIdentifier2=entity.EmailAddressIdentifier2; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	public int Id { get; set; } = 0;

	/// <summary>Aka. PersonCivilRegistrationIdentifier or DepartmentIdentifier</summary>
	public string ParentIdentifier { get; set; } = "00000";

	/// <remarks/>
	public string InstitutionIdentifier { get; set; } = "NO";

	/// <remarks/>
	public string TelephoneNumberIdentifier1 { get; set; } = "00000000";

	/// <remarks/>
	public string TelephoneNumberIdentifier2 { get; set; } = "00000000";

	/// <remarks/>
	public string EmailAddressIdentifier1 { get; set; } = "Empty@Empty.Com";

	/// <remarks/>
	public string EmailAddressIdentifier2 { get; set; } = "Empty@Empty.Com";

	#endregion

	#region Other

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public static string CsvHeader => "Id;ParentIdentifier;InstitutionIdentifier;TelephoneNumberIdentifier1;TelephoneNumberIdentifier2;EmailAddressIdentifier1;EmailAddressIdentifier2"+Environment.NewLine;

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.ParentIdentifier+";"+this.InstitutionIdentifier+";"+this.TelephoneNumberIdentifier1+";"+this.TelephoneNumberIdentifier2+";"+this.EmailAddressIdentifier1+";"+this.EmailAddressIdentifier2+Environment.NewLine;

	/// <summary>Delete ContactInformation SQL-query</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [SD].[dbo].[ContactInformationList] "+"WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <summary>Select PostalAddress SQL-query</summary>
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [SD].[dbo].[ContactInformationList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <summary>[SD].[dbo].[UpdateOrCreateContactInformation] @parentId, @instId, @phone1, @phone2, @email1, @email2</summary>
	[NotMapped]
	public string SqlUpdateOrCreateQuery => @"EXECUTE [SD].[dbo].[UpdateOrCreateContactInformation] @parentId='"+ParentIdentifier+ "', @instId='"+InstitutionIdentifier+"', @phone1='"+TelephoneNumberIdentifier1+
		"', @phone2='"+TelephoneNumberIdentifier2+"', @email1='"+EmailAddressIdentifier1+"', @email2='"+EmailAddressIdentifier2+"'";

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier+"-"+this.ParentIdentifier;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this ContactInformation to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(ContactInformation entity) { if (this==null||entity==null) return false; if (!this.ParentIdentifier.Equals(entity.ParentIdentifier)) return false;
		else if (!this.InstitutionIdentifier.Equals(entity.InstitutionIdentifier)) return false; else if (!this.TelephoneNumberIdentifier1.Equals(entity.TelephoneNumberIdentifier1)) return false;
		else if (!this.TelephoneNumberIdentifier2.Equals(entity.TelephoneNumberIdentifier2)) return false; else if (!this.EmailAddressIdentifier1.Equals(entity.EmailAddressIdentifier1))
			return false; else if (!this.EmailAddressIdentifier2.Equals(entity.EmailAddressIdentifier2)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns>
	public static bool IsEmail(string mail) { try { MailAddress m = new(mail); return true; } catch (Exception) { return false; } }

	/// <returns>Result as bool</returns>
	public static bool IsPhoneNumber(string phone) { if(string.IsNullOrWhiteSpace(phone)) return false; if(PhoneNumberUtil.IsViablePhoneNumber(phone)) return true; else return false; }

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if(this==null) return true; Validate(); if (!this.ParentIdentifier.Equals("00000")&&!this.ParentIdentifier.Equals("0101001234")&&
		!this.InstitutionIdentifier.Equals("NO")&&(!this.EmailAddressIdentifier1.Equals("Empty@Empty.Com")||!this.EmailAddressIdentifier2.Equals("Empty@Empty.Com")||
		!this.TelephoneNumberIdentifier1.Equals("00000000")||!this.TelephoneNumberIdentifier2.Equals("00000000"))) return false; else return true; }

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsPersonContactInformation() { if(this==null) throw new NullReferenceException(); Validate(); if (this.ParentIdentifier.Length.Equals(10)) return int.TryParse(this.ParentIdentifier,out int result); else return false; }

	/// <summary>Checks wether validation cause changes, that must be updated in database</summary><returns>Result as bool</returns>
	public bool IsUpdated() { if(this==null) throw new NullReferenceException(); ContactInformation valInfo=new(this.ParentIdentifier,this.InstitutionIdentifier,this.TelephoneNumberIdentifier1,
		this.TelephoneNumberIdentifier2,this.EmailAddressIdentifier1,this.EmailAddressIdentifier2) { Id=this.Id }; if (!Equals(valInfo)) return true; else return false; }

	#endregion

	#region To something

	/// <returns>Content as a long string</returns>
	public string ToLongString() { if (this==null) return "null"; else return "Id: "+this.Id+"-"+ToString(); }

	/// <returns>Content as a multiline string</returns>
	public string ToMultiLineString() { if (this==null) return "null"; string result=string.Empty; if (!string.IsNullOrWhiteSpace(this.TelephoneNumberIdentifier1))
		result += "Tlf.: "+this.TelephoneNumberIdentifier1+Environment.NewLine; if (!string.IsNullOrWhiteSpace(this.TelephoneNumberIdentifier2))
		result += "Tlf.: "+this.TelephoneNumberIdentifier2+Environment.NewLine; if (!string.IsNullOrWhiteSpace(this.EmailAddressIdentifier1))
		result += "Email: "+this.EmailAddressIdentifier1+Environment.NewLine; if (!string.IsNullOrWhiteSpace(this.EmailAddressIdentifier2))
		result += "Email: "+this.EmailAddressIdentifier2; return result; }

	/// <returns>Content as string</returns>
	public override string ToString() { if (this==null) return "null"; else return "Tlf1: "+this.TelephoneNumberIdentifier1+" - Tlf2: "+this.TelephoneNumberIdentifier2+
		" - Email1: "+this.EmailAddressIdentifier1+" - Email2: "+this.EmailAddressIdentifier2;  }

	#endregion

	/// <summary>Validates data in this <see cref="ContactInformation"/></summary><exception cref="NullReferenceException" />
	public void Validate() {  if(this==null) throw new NullReferenceException(); if(string.IsNullOrWhiteSpace(this.ParentIdentifier)) this.ParentIdentifier="00000";
		else if(string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) this.InstitutionIdentifier="NO"; if(!IsPhoneNumber(this.TelephoneNumberIdentifier1))
			this.TelephoneNumberIdentifier1="00000000"; if(!IsPhoneNumber(this.TelephoneNumberIdentifier2)) this.TelephoneNumberIdentifier2="00000000"; if(!IsEmail(
				this.EmailAddressIdentifier1)) this.EmailAddressIdentifier1="Empty@Empty.Com"; if(!IsEmail(this.EmailAddressIdentifier2)) this.EmailAddressIdentifier2="Empty@Empty.Com"; }

	#endregion

}
