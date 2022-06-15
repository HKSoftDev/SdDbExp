// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public partial class Person
{

	#region Fields

	/// <summary>Header for CSV-file</summary>
	[NotMapped]
	public const string CsvHeader="Id;PersonCivilRegistrationIdentifier;PersonGivenName;PersonSurnameName;InstitutionIdentifier\r\n";

	private string personGivenName="Non", personSurnameName="Nomine";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of Person</summary>
	public Person() { }

	/// <summary>Initializes a new instance of Person</summary><param name="personCivilRegistrationId" /><param name="personGivenName" /><param name="personSurnameName" /><param name="institutionId" />
	public Person(string personCivilRegistrationId, string personGivenName, string personSurnameName, string institutionId) {
		this.PersonCivilRegistrationIdentifier=personCivilRegistrationId; this.personGivenName=personGivenName.Replace("'", "′"); this.personSurnameName=personSurnameName.Replace("'", "′"); 
		this.InstitutionIdentifier=institutionId; Validate(); }

	/// <summary>Initializes an instance of Person from database</summary><param name="id" /><param name="personCivilRegistrationId" /><param name="personGivenName" />
	/// <param name="personSurnameName" /><param name="institutionId" />
	public Person(int id, string personCivilRegistrationId, string personGivenName, string personSurnameName, string institutionId) {
		this.Id=id; this.PersonCivilRegistrationIdentifier=personCivilRegistrationId; this.personGivenName=personGivenName;
		this.personSurnameName=personSurnameName; this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes a new instance of Person from database</summary><param name="array" />
	public Person(string[] array) { this.Id=int.Parse(array[0]); this.PersonCivilRegistrationIdentifier=array[1]; this.personGivenName=array[2]; this.personSurnameName=array[3]; this.InstitutionIdentifier=array[4]; }

	/// <summary>Initializes a new instance of Person, that accepts data from an existing Person</summary><param name="entity"></param>
	public Person(Person entity) { this.Id=entity.Id; this.PersonCivilRegistrationIdentifier=entity.PersonCivilRegistrationIdentifier; this.personGivenName=entity.PersonGivenName; 
		this.personSurnameName=entity.PersonSurnameName; this.InstitutionIdentifier=entity.InstitutionIdentifier; }

	#endregion

	#region Properties

	#region Database

	/// <remarks/>
	public int Id { get; set; } = 0;

	/// <remarks/>
	public string PersonCivilRegistrationIdentifier { get; set; } = "0101001234";

	/// <remarks/>
	public string PersonGivenName { get => personGivenName; set => personGivenName=value.Replace("'", "′"); }

	/// <remarks/>
	public string PersonSurnameName { get => personSurnameName; set => personSurnameName=value.Replace("'", "′"); }

	/// <remarks/>
	public string InstitutionIdentifier { get; set; }="NO";

	#endregion

	#region Other

	/// <summary>Value for CSV-file</summary>
	[NotMapped]
	public string CsvValue => this.Id+";"+this.PersonCivilRegistrationIdentifier+";"+this.personGivenName+";"+this.personSurnameName+";"+this.InstitutionIdentifier+Environment.NewLine;

	/// <summary>Delete Person SQL-query</summary>
	[NotMapped]
	public string SqlDeleteQuery => @"DELETE FROM [dbo].[PersonList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <summary>Insert Person SQL-query</summary>
	[NotMapped]
	public string SqlInsertQuery => "INSERT INTO [dbo].[PersonList]([PersonCivilRegistrationIdentifier],[PersonGivenName],[PersonSurnameName],[InstitutionIdentifier]) VALUES('"+
		this.PersonCivilRegistrationIdentifier+@"','"+this.PersonGivenName+@"','"+this.PersonSurnameName+@"','"+this.InstitutionIdentifier+@"')"+Environment.NewLine;

	/// <summary>Select Person SQL-query</summary>
	[NotMapped]
	public string SqlSelectQuery => @"SELECT * FROM [dbo].[PersonList] WHERE [Id]="+this.Id+";"+Environment.NewLine;

	/// <summary>Update Person SQL-query</summary>
	[NotMapped]
	public string SqlUpdateQuery => @"UPDATE [dbo].[PersonList] SET [PersonCivilRegistrationIdentifier]='"+this.PersonCivilRegistrationIdentifier+@"',[PersonGivenName]='"+this.PersonGivenName.Replace("'", "′")+
		@"',[PersonSurnameName]='"+this.PersonSurnameName.Replace("'", "′")+@"',[InstitutionIdentifier]='"+this.InstitutionIdentifier+@"' WHERE [Id]="+this.Id+Environment.NewLine;

	/// <summary>Tkey for Dictionary</summary>
	[NotMapped]
	public string TKey => this.InstitutionIdentifier+"-"+this.PersonCivilRegistrationIdentifier;

	#endregion

	#endregion

	#region Methods

	/// <summary>Compares this Person to <paramref name="entity"/></summary><param name="entity" /><returns>Result as bool</returns>
	public bool Equals(Person entity) { if (this==null||entity==null) return false; if (!this.PersonCivilRegistrationIdentifier.Equals(entity.PersonCivilRegistrationIdentifier))
			return false; else if (!this.personGivenName.Equals(entity.PersonGivenName)) return false; else if (!this.personSurnameName.Equals(entity.PersonSurnameName)) return false;
		else if (!this.InstitutionIdentifier.Equals(entity.InstitutionIdentifier)) return false; else return true; }

	#region Is something

	/// <returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsEmpty() { if (this==null) return true; Validate(); if (!this.PersonCivilRegistrationIdentifier.Equals("0101001234")&&!this.InstitutionIdentifier.Equals("NO")) return false; else return true; }

	/// <summary>Checks wether validation of this Person cause changes, that must be updated in database</summary><returns>Result as bool</returns><exception cref="NullReferenceException" />
	public bool IsUpdated() { if (this==null) throw new NullReferenceException(); Person valPers=new(this.PersonCivilRegistrationIdentifier,this.personGivenName,this.personSurnameName,
		this.InstitutionIdentifier) { Id=this.Id }; if (!Equals(valPers)) return true; else return false; }

	#endregion

	#region To something

	/// <returns>Content of this Person as a long string</returns>
	public string ToLongString() { if (this==null) return "null"; else return "Cpr.:"+this.PersonCivilRegistrationIdentifier+Environment.NewLine+this.personGivenName+" "+this.personSurnameName; }

	/// <returns>Content of Person as string</returns>
	public override string ToString() { if(this==null) return "null"; else return this.personGivenName+" "+this.personSurnameName+" ("+this.InstitutionIdentifier+"-"+this.PersonCivilRegistrationIdentifier+")"; }

	#endregion

	/// <summary>Validates data in this Person</summary><exception cref="NullReferenceException" />
	public void Validate() { if (this==null) throw new NullReferenceException(); if (string.IsNullOrWhiteSpace(this.PersonCivilRegistrationIdentifier))
		this.PersonCivilRegistrationIdentifier="0101001234"; if (string.IsNullOrWhiteSpace(this.InstitutionIdentifier)) this.InstitutionIdentifier="00000000-0000-0000-0000-000000000000"; }

	#endregion

}
