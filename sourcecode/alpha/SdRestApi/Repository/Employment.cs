// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Employment.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public partial class Employment
{

	#region Fields

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public const string CsvHeader="Id;EmploymentIdentifier;EmploymentDate;AnniversaryDate;InstitutionIdentifier;Employee;EmploymentDepartment;EmploymentProfession\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of Employment</summary>
	public Employment() { }

	/// <summary>Initializes a new instance of Employment</summary><param name="employmentId" /><param name="employmentDate" /><param name="anniversaryDate" />
	/// <param name="institutionId" /><param name="employee" /><param name="department" /><param name="profession" />
	public Employment(string employmentId,DateTime employmentDate,DateTime anniversaryDate,string institutionId,string employee,string department,string profession) {
		this.EmploymentIdentifier=employmentId.Replace("'", "′"); this.EmploymentDate=employmentDate; this.AnniversaryDate=anniversaryDate; this.InstitutionIdentifier=institutionId;
		this.Employee=employee; this.EmploymentDepartment=department; this.EmploymentProfession=profession; Validate(); }

	/// <summary>Initializes an instance of Employment from database</summary><param name="id" /><param name="employmentId" /><param name="employmentDate" />
	/// <param name="anniversaryDate" /><param name="institutionId" /><param name="department" /><param name="profession" />
	public Employment(int id,string employmentId,DateTime employmentDate,DateTime anniversaryDate,string institutionId,string department,string profession) { this.Id=id; 
		this.EmploymentIdentifier=employmentId; this.EmploymentDate=employmentDate; this.AnniversaryDate=anniversaryDate; this.InstitutionIdentifier=institutionId; this.EmploymentDepartment=department; 
		this.EmploymentProfession=profession; }

	/// <summary>Initializes a new instance of Employment from database</summary><param name="array" />
	public Employment(string[] array) { this.Id=int.Parse(array[0]); this.EmploymentIdentifier=array[1]; this.EmploymentDate=DateTime.Parse(array[2]);this.AnniversaryDate=DateTime.Parse(array[3]);
		this.InstitutionIdentifier=array[4]; this.Employee=array[5]; this.EmploymentDepartment=array[6]; this.EmploymentProfession=array[7]; }

	/// <summary>Initializes a new instance of Employment, that accepts data from an existing Employment</summary><param name="entity" />
	public Employment(Employment entity) { this.Id=entity.Id; this.EmploymentIdentifier=entity.EmploymentIdentifier; this.EmploymentDate=entity.EmploymentDate; this.AnniversaryDate=entity.AnniversaryDate;
		this.InstitutionIdentifier=entity.InstitutionIdentifier; this.EmploymentDepartment=entity.EmploymentDepartment; this.EmploymentProfession=entity.EmploymentProfession; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	public int Id { get; set; } = 0;

	/// <remarks/>
	public string EmploymentIdentifier { get; set; } = "00000";

	/// <remarks/>
	public DateTime EmploymentDate { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks/>
	public DateTime AnniversaryDate { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks/>
	public string InstitutionIdentifier { get; set; } = "NO";

	/// <remarks/>
	public string Employee { get; set; } = "0101001234";

	/// <remarks/>
	public string EmploymentDepartment { get; set; } = "00000000-0000-0000-0000-000000000000";

	/// <remarks/>
	public string EmploymentProfession { get; set; } = "0000";

	#endregion

	#region Other

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.EmploymentIdentifier+";"+this.EmploymentDate.ToString("yyyy-MM-dd")+";"+this.AnniversaryDate.ToString("yyyy-MM-dd")+";"+
		this.InstitutionIdentifier+";"+this.Employee+";"+this.EmploymentDepartment+";"+this.EmploymentProfession+"\r\n";

	/// <summary>DELETE FROM [dbo].[EmploymentList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [SD].[dbo].[EmploymentList] WHERE [Id]="+this.Id;

	/// <summary>SELECT * FROM [dbo].[EmploymentList] WHERE [Id]=Id</summary>
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [SD].[dbo].[EmploymentList] WHERE [Id]="+this.Id;

	/// <summary>[SD].[dbo].[UpdateOrCreateEmployment] @parentId, @instId, @phone1, @phone2, @email1, @email2"</summary>
	[NotMapped]
	public string SqlUpdateOrCreateQuery => @"EXECUTE [SD].[dbo].[UpdateOrCreateEmployment] @emplId'" + EmploymentIdentifier + "', @emplDate'" + EmploymentDate.ToString("yyyy-MM-dd") + "', @annivDate'" + AnniversaryDate + "', @instId'" + InstitutionIdentifier + "', @employee'" + Employee + "', @emplDept'" + EmploymentDepartment + "', @emplProf'" + EmploymentProfession + "'";

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier+"-"+this.EmploymentIdentifier;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this Employment to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(Employment entity) { if (this==null) return false; if (!this.EmploymentIdentifier.Equals(entity.EmploymentIdentifier)) return false; else if (!this.EmploymentDate.Equals(entity.EmploymentDate)) return false;
		else if (!this.AnniversaryDate.Equals(entity.AnniversaryDate)) return false; else if (!this.Employee.Equals(entity.Employee)) return false; else if (!this.InstitutionIdentifier.Equals(entity.InstitutionIdentifier)) return false; else return true; }

	#region Is something
	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if (this==null) throw new NullReferenceException(); Validate(); if (!this.EmploymentIdentifier.Equals("00000")&&!this.InstitutionIdentifier.Equals("NO")) return false; else return true; }

	/// <summary>Check wether validation of this Employment cause changes, that must be updated in database</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsUpdated() { if (this==null) throw new NullReferenceException(); Employment valEmpl=new(this.EmploymentIdentifier,this.EmploymentDate,this.AnniversaryDate,
		this.InstitutionIdentifier,this.Employee,this.EmploymentDepartment,this.EmploymentProfession) { Id=this.Id }; if (!Equals(valEmpl)) return true; else return false; }

	#endregion

	/// <returns>Content of this Employment as string</returns>
	public override string ToString() { if (this==null) return "null"; else return this.EmploymentIdentifier; }

	/// <summary>Validates data in Employment</summary><exception cref="NullReferenceException" />
	public void Validate() { if(this==null) throw new NullReferenceException(); if (string.IsNullOrWhiteSpace(this.EmploymentIdentifier)) this.EmploymentIdentifier="00000"; 
		else this.EmploymentIdentifier=this.EmploymentIdentifier.Replace("'", "′"); if (string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) this.InstitutionIdentifier="NO";
		if (string.IsNullOrWhiteSpace(this.Employee)) this.Employee="0101001234"; if (string.IsNullOrWhiteSpace(this.EmploymentDepartment)) this.EmploymentDepartment="00000000-0000-0000-0000-000000000000";
		if (string.IsNullOrWhiteSpace(this.EmploymentProfession)) this.EmploymentProfession="0000"; }

	#region Private

	/// <returns>13th control digit for <paramref name="num12"/> as string</returns><param name="num12">12 digit numeric string</param><exception cref="ArgumentInvalidException" />
	private string RetrieveControlDigit(string num12) { if (string.IsNullOrWhiteSpace(num12)) throw new ArgumentInvalidException(nameof(num12),num12,nameof(num12)+Error.CantBeEmpty);
		if (num12.Length!=12) throw new ArgumentInvalidException(nameof(num12),num12,nameof(num12)+"must be exactly 12 digits"); if (int.TryParse(num12,out int i)) {
			int[] iArray = RetrieveIntArray(num12); int s = iArray[0]+(iArray[1]*3)+iArray[2]+(iArray[3]*3)+iArray[4]+(iArray[5]*3)+iArray[6]+(iArray[7]*3)+iArray[8]+(iArray[9]*3)+
				iArray[10]+(iArray[11]*3); int mod10 = Math.DivRem(s,10,out int rem); if (rem>=1) return (10-rem).ToString(); else return rem.ToString(); } else return "Z"; }

	/// <returns>Unique identifier for this Employment as string</returns><exception cref="NullReferenceException" />
	private string RetrieveEmploymentUniqueIdentifier() { if (this==null) throw new NullReferenceException(); return ToTwoDigitInstitutionIdentifier(InstitutionIdentifier)+RetrieveTenDigitEmploymentIdentifier()+
		RetrieveControlDigit(ToTwoDigitInstitutionIdentifier(InstitutionIdentifier)+RetrieveTenDigitEmploymentIdentifier()); }

	/// <returns><paramref name="number"/> as int[]</returns><param name="number">numeric string</param>
	private int[] RetrieveIntArray(string number) { int[] result = new int[number.Length]; int i = 0; foreach (char c in number) { result[i]=Convert.ToInt32(c); i++; } return result; }

	/// <returns>EmploymentIdentifier as ten digit numeric string</returns><exception cref="NullReferenceException" />
	private string RetrieveTenDigitEmploymentIdentifier() { if (this==null) throw new NullReferenceException(); if (string.IsNullOrWhiteSpace(this.EmploymentIdentifier)) return "0000000000"; if (!int.TryParse(
		this.EmploymentIdentifier,out int i)) return "0000000000"; string result = i.ToString(); while (result.Length<10) { result="0"+result; } while (result.Length>10) { result=result.Remove(0,1); } return result; }

	/// <returns>Two digit <paramref name="institutionId"/> as string</returns><param name="institutionId" />
	private string ToTwoDigitInstitutionIdentifier(string institutionId) => institutionId switch{ "HB" => "01", "HI" => "02", "HW" => "03", _ => throw new ArgumentInvalidException(nameof(institutionId),institutionId,nameof(institutionId)+Error.UnkArg) };

	#endregion

	#endregion

}
