// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="PostalAddress.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public partial class PostalAddress
{
	#region Fields
	private string standardAddressIdentifier="**adresse Ubekendt**";
	private string districtName="Ukendt";

	#endregion

	#region Constructors
	/// <summary>Initializes an empty instance of PostalAddress</summary>
	public PostalAddress() { }

	/// <summary>Initializes a new instance of PostalAddress</summary><param name="parentId" /><param name="institutionId" /><param name="standardAddressId" />
	/// <param name="postalCode" /><param name="districtName" /><param name="municipalityCode" /><param name="countryIdCode" />
	public PostalAddress(string parentId,string institutionId,string standardAddressId, string postalCode, string districtName, string municipalityCode, string countryIdCode) {
		this.ParentIdentifier=parentId; this.InstitutionIdentifier=institutionId; this.standardAddressIdentifier=standardAddressId.Replace("'", "′"); this.PostalCode=postalCode;
		this.districtName=districtName.Replace("'", "′"); this.MunicipalityCode=municipalityCode; this.CountryIdentificationCode=countryIdCode; Validate(); }

	/// <summary>Initializes a new instance of PostalAddress from database</summary><param name="id" /><param name="parentId" /><param name="institutionId" /><param name="standardAddressId" />
	/// <param name="postalCode" /><param name="districtName" /><param name="mmunicipalityCode" /><param name="countryIdCode" />
	public PostalAddress(int id,string parentId,string institutionId,string standardAddressId,string postalCode,string districtName,string mmunicipalityCode,string countryIdCode) { this.Id=id;
		this.ParentIdentifier=parentId; this.InstitutionIdentifier=institutionId; this.standardAddressIdentifier=standardAddressId; this.PostalCode=postalCode; this.districtName=districtName;
		this.MunicipalityCode=mmunicipalityCode; this.CountryIdentificationCode=countryIdCode; }

	/// <summary>Initializes a new instance of PostalAddress from database</summary><param name="array" />
	public PostalAddress(string[] array) { this.Id=int.Parse(array[0]); this.ParentIdentifier=array[1]; this.InstitutionIdentifier=array[2]; this.standardAddressIdentifier=array[3];
		this.PostalCode=array[4]; this.districtName=array[5]; this.MunicipalityCode=array[6]; this.CountryIdentificationCode=array[7]; }

	/// <summary>Initializes a new instance of PostalAddress, that accepts data from existing PostalAddress</summary><param name="addr" />
	public PostalAddress(PostalAddress addr) { this.Id=addr.Id; this.ParentIdentifier=addr.ParentIdentifier; this.InstitutionIdentifier=addr.InstitutionIdentifier;
		this.standardAddressIdentifier= addr.StandardAddressIdentifier; this.PostalCode=addr.PostalCode; this.districtName=addr.DistrictName;
		this.MunicipalityCode=addr.MunicipalityCode; this.CountryIdentificationCode=addr.CountryIdentificationCode; }

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
	public string StandardAddressIdentifier { get => standardAddressIdentifier; set => standardAddressIdentifier=value.Replace("'", "′"); }

	/// <remarks/>
	public string PostalCode { get; set; } = "9999";

	/// <remarks/>
	public string DistrictName { get => districtName; set => districtName=value.Replace("'", "′"); }

	/// <remarks/>
	public string MunicipalityCode { get; set; } = "0510";

	/// <remarks/>
	public string CountryIdentificationCode { get; set; } = string.Empty;

	#endregion

	#region Other

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public static string CsvHeader => "Id;ParentIdentifier;InstitutionIdentifier;StandardAddressIdentifier;PostalCode;DistrictName;MunicipalityCode;CountryIdentificationCode"+Environment.NewLine;

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.ParentIdentifier+";"+this.InstitutionIdentifier+";"+this.standardAddressIdentifier+";"+this.PostalCode+";"+this.districtName+";"+this.MunicipalityCode+";"+this.CountryIdentificationCode+Environment.NewLine;

	/// <returns>Delete PostalAddress SQL-query as string</returns><exception cref="NullReferenceException" /><exception cref="EmptyRefException" /><exception cref="InvalidRefException" />
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [dbo].[PostalAddressList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <returns>Insert PostalAddress SQL-query as string</returns><exception cref="NullReferenceException" /><exception cref="EmptyRefException" /><exception cref="InvalidRefException" />
	[NotMapped]
	public string SqlInsertQuery => @"INSERT INTO [dbo].[PostalAddressList]([ParentIdentifier],[InstitutionIdentifier],[StandardAddressIdentifier],[PostalCode],[DistrictName],[MunicipalityCode],"+
		"[CountryIdentificationCode]) VALUES('"+this.ParentIdentifier+@"','"+this.InstitutionIdentifier+@"','"+this.StandardAddressIdentifier.Replace("'", "′")+@"','"+this.PostalCode+@"','"+
		this.DistrictName.Replace("'", "′")+@"','"+this.MunicipalityCode+@"','"+this.CountryIdentificationCode+"');"+Environment.NewLine;

	/// <returns>Select PostalAddress SQL-query as string</returns><exception cref="NullReferenceException" /><exception cref="EmptyRefException" /><exception cref="InvalidRefException" />
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [dbo].[PostalAddressList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <returns>Update PostalAddress SQL-query as string</returns><exception cref="NullReferenceException" /><exception cref="EmptyRefException" /><exception cref="InvalidRefException" />
	[NotMapped]
	public string SqlUpdateQuery => @"UPDATE [dbo].[PostalAddressList] SET [ParentIdentifier]='"+this.ParentIdentifier+"',[InstitutionIdentifier]='"+this.InstitutionIdentifier+"',[StandardAddressIdentifier]='"+
		this.StandardAddressIdentifier.Replace("'", "′")+"',[PostalCode]='"+this.PostalCode+"',[DistrictName]='"+this.DistrictName.Replace("'", "′")+"',[MunicipalityCode]='"+this.MunicipalityCode+
		"',[CountryIdentificationCode]='"+this.CountryIdentificationCode+"' WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier+"-"+this.ParentIdentifier;

	#endregion

	#endregion

	#region Methods
	/// <summary>Determines whether this PostalAddress and <paramref name="entity"/> have the same value</summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(PostalAddress entity) { if(this==null||entity==null) return false; if (!this.ParentIdentifier.Equals(entity.ParentIdentifier)) return false;
		else if (!this.InstitutionIdentifier.Equals(entity.InstitutionIdentifier)) return false; else if (!this.standardAddressIdentifier.Equals(entity.StandardAddressIdentifier)) return false;
		else if (!this.PostalCode.Equals(entity.PostalCode)) return false; else if (!this.districtName.Equals(entity.DistrictName)) return false;
		else if (!this.MunicipalityCode.Equals(entity.MunicipalityCode)) return false; else if (!this.CountryIdentificationCode.Equals(entity.CountryIdentificationCode)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if(this==null) return true; Validate(); if (!this.ParentIdentifier.Equals("00000")&&!this.InstitutionIdentifier.Equals("NO")&&
			!this.standardAddressIdentifier.Equals("**adresse Ubekendt**")) return false; else return true; }

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsPersonPostalAddress() { if(this==null) throw new NullReferenceException(); Validate(); if (this.ParentIdentifier.Length.Equals(10)) return int.TryParse(this.ParentIdentifier,out int result); else return false; }

	/// <summary>Check wether validation of this PostalAddress cause changes, that must be updated in database.</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsUpdated() { if(this==null) throw new NullReferenceException(); PostalAddress tempAddr=new(this.Id,this.ParentIdentifier,this.InstitutionIdentifier,this.standardAddressIdentifier,
		this.PostalCode,this.districtName,this.MunicipalityCode,this.CountryIdentificationCode); if (!Equals(tempAddr)) return true; else return false; }

	#endregion

	#region To Something

	/// <returns>Content of this PostalAddress as a long string</returns>
	public string ToLongString() { if(this==null) return "null"; Validate(); if (!string.IsNullOrWhiteSpace(this.CountryIdentificationCode)) return StandardAddressIdentifier+
			Environment.NewLine+PostalCode+" "+DistrictName+Environment.NewLine+"Kommune: "+this.MunicipalityCode+Environment.NewLine+"Land: "+this.CountryIdentificationCode;
		else return StandardAddressIdentifier+Environment.NewLine+PostalCode+" "+DistrictName+Environment.NewLine+"Kommune: "+this.MunicipalityCode; }

	/// <returns>Content of this PostalAddress as string</returns>
	public override string ToString() { if(this==null) return string.Empty; Validate(); return this.standardAddressIdentifier+"-"+this.PostalCode+" "+this.districtName+
		" - Kommune: "+this.MunicipalityCode+" - Land: "+this.CountryIdentificationCode; }

	#endregion

	/// <summary>Validates data in this PostalAddress</summary><exception cref="NullReferenceException" />
	public void Validate() { if(this==null) throw new NullReferenceException(); if(this.Id<0) this.Id=0; if(string.IsNullOrWhiteSpace(this.ParentIdentifier))
			this.ParentIdentifier="00000"; else if(string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) this.InstitutionIdentifier="NO"; else if(string.IsNullOrWhiteSpace(
				this.PostalCode)) this.PostalCode="9999"; if(string.IsNullOrWhiteSpace(this.MunicipalityCode)) this.MunicipalityCode="0000"; if(string.IsNullOrWhiteSpace(
					this.standardAddressIdentifier)) this.standardAddressIdentifier="**adresse Ubekendt**"; else this.standardAddressIdentifier=this.standardAddressIdentifier.Replace("'", "′");
		if(string.IsNullOrWhiteSpace(this.districtName)) this.districtName="Ukendt"; else this.districtName=this.districtName.Replace("'", "′"); if (this.CountryIdentificationCode==null)
			this.CountryIdentificationCode=string.Empty; }

	#endregion

}
