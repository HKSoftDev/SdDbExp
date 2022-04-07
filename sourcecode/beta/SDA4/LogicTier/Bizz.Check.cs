// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Check.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Check
{
	#region Methods

	/// <returns>Result as bool</returns><typeparam name="T" /><param name="entity" />
	public bool CheckEntityExists<T>(T entity) where T : class => typeof(T).Name.ToLower() switch { "contactinformation" => CheckContactInformationExist(entity as ContactInformation),
		"department" => CheckDepartmentExist(entity as Department), "departmentlevelreference" => CheckDepartmentLevelReferenceExist(entity as DepartmentLevelReference),
		"departmentreference" => CheckDepartmentReferenceExist(entity as DepartmentReference), "employment" => CheckEmploymentExist(entity as Employment),
		"employmentprofession" => CheckEmploymentProfessionExist(entity as EmploymentProfession), "employmentstatus" => CheckEmploymentStatusExist(entity as EmploymentStatus), "institution" => CheckInstitutionExist(entity as Institution),
		"organization" => CheckOrganizationExist(entity as Organization), "organizationstructure" => CheckOrganizationStructureExist(entity as OrganizationStructure),
		"person" => CheckPersonExist(entity as Person), "postaladdress" => CheckPostalAddressExist(entity as PostalAddress), "profession" => CheckProfessionExist(entity as Profession),
		"salaryagreement" => CheckSalaryAgreementExist(entity as SalaryAgreement), "salarycodegroup" => CheckSalaryCodeGroupExist(entity as SalaryCodeGroup),
		"successfulrun" => CheckSuccessfulRunExist(entity as SuccessfulRun), "workingtime" => CheckWorkingTimeExist(entity as WorkingTime), _ => false, };

	#region Private

	/// <summary>Checks content of<paramref name="info"/></summary><param name="user" /><param name="info" /><exception cref="ArgumentEmptyException" />
	protected int CheckContactInformation(ADUser user,ContactInformation info) { if (info.IsEmpty()) throw new ArgumentEmptyException(nameof(info),nameof(info)+Error.CantBeEmpty);
		bool mailUpdated=CheckMail(user.Mail,info); bool phoneUpdated=CheckPhone(user.Telephone,info); bool ipPhoneUpdated=CheckPhone(user.IpPhone,info); bool cellPhoneUpdated=
			CheckPhone(user.MobilePhone,info); if (mailUpdated||phoneUpdated||ipPhoneUpdated||cellPhoneUpdated) return 1; else return 0; }

	#region Check entity exist

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckContactInformationExist(ContactInformation entity) => GetContactInformationDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckDepartmentExist(Department entity) => GetDepartmentDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckDepartmentLevelReferenceExist(DepartmentLevelReference entity) => GetDepartmentLevelReferenceDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckDepartmentReferenceExist(DepartmentReference entity) => GetDepartmentReferenceDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckEmploymentExist(Employment entity) => GetEmploymentDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckEmploymentProfessionExist(EmploymentProfession entity) => GetEmploymentProfessionDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckEmploymentStatusExist(EmploymentStatus entity) => GetEmploymentStatusDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckInstitutionExist(Institution entity) => GetEmploymentStatusDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckOrganizationExist(Organization entity) => GetOrganizationDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckOrganizationStructureExist(OrganizationStructure entity) => GetOrganizationStructureDict().ContainsKey(entity.InstitutionIdentifier);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckPersonExist(Person entity) => GetPersonDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckPostalAddressExist(PostalAddress entity) =>GetPostalAddressDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckProfessionExist(Profession entity) => GetProfessionDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckSalaryAgreementExist(SalaryAgreement entity) => GetSalaryAgreementDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckSalaryCodeGroupExist(SalaryCodeGroup entity) => GetSalaryCodeGroupDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckSuccessfulRunExist(SuccessfulRun entity) => GetSuccessfulRunDict().ContainsKey(entity.TKey);

	/// <returns>Result as bool</returns><param name="entity" />
	protected bool CheckWorkingTimeExist(WorkingTime entity) => GetWorkingTimeDict().ContainsKey(entity.TKey);

	#endregion

	/// <summary>Check Errors if any error stores error message in PageData</summary>
	protected void CheckErrors() { if (!this.Config.Authorized) { this.Config.ResponseString = Config.Error401Data; } else if (!this.Config.ContentProcessed) { this.Config.ResponseString = Config.Error501Data; }
		else if (this.Config.UnsupportedMedia) { this.Config.ResponseString = Config.Error415Data; } }

	#endregion

	#region Private

	/// <summary>Checks wether <paramref name="phone"/> exists in <paramref name="info"/></summary><param name="phone" /><param name="info" /><returns>Result as bool</returns>
	private bool CheckPhone(string phone,ContactInformation info) { if (info.IsEmpty()) throw new ArgumentEmptyException(nameof(info),nameof(info)+Error.CantBeEmpty);
		if (phone.IsNullOrWhiteSpace()) throw new ArgumentEmptyException(nameof(phone),nameof(phone)+Error.CantBeEmpty);
		if (!ContactInformation.IsPhoneNumber(phone)) throw new ArgumentInvalidException(nameof(phone),phone,nameof(phone)+Error.CantBeEmpty); bool updateFlag=false; 
		if (!info.TelephoneNumberIdentifier1.Equals("00000000")&&info.TelephoneNumberIdentifier2.Equals("00000000")) { if (!info.TelephoneNumberIdentifier1.Equals(phone))
			{ info.TelephoneNumberIdentifier2=phone; updateFlag=true; } }
		else if (info.TelephoneNumberIdentifier1.Equals("00000000")&&!info.TelephoneNumberIdentifier2.Equals("00000000")) { if (!info.TelephoneNumberIdentifier2.Equals(phone))
			{ info.TelephoneNumberIdentifier1=phone; updateFlag=true; } else { info.TelephoneNumberIdentifier1=phone; info.TelephoneNumberIdentifier2="00000000"; updateFlag=true; } }
		else { info.TelephoneNumberIdentifier1=phone; updateFlag=true; } if (updateFlag) return UpdateOrCreateInDatabase(info); else return false; }

	/// <summary>Checks wether <paramref name="mail"/> exists in <paramref name="info"/></summary><param name="mail" /><param name="info" /><returns>Result as bool</returns>
	private bool CheckMail(string mail,ContactInformation info) { if (info.IsEmpty()) throw new ArgumentEmptyException(nameof(info),nameof(info)+Error.CantBeEmpty);
		if (mail.IsNullOrWhiteSpace()) throw new ArgumentEmptyException(nameof(mail),nameof(mail)+Error.CantBeEmpty);
		if (!ContactInformation.IsEmail(mail)) throw new ArgumentInvalidException(nameof(mail),mail,nameof(mail)+Error.CantBeEmpty); bool updateFlag=false;
		if (!info.EmailAddressIdentifier1.Equals("Empty@Empty.Com")&&info.EmailAddressIdentifier1.Equals("Empty@Empty.Com")) { if (!info.EmailAddressIdentifier1.Equals(mail)) {
			info.EmailAddressIdentifier2=mail; updateFlag=true; } else { info.EmailAddressIdentifier2=mail; updateFlag=true; } }
		else if (info.EmailAddressIdentifier1.Equals("Empty@Empty.Com")&&!info.EmailAddressIdentifier1.Equals("Empty@Empty.Com")) { if (!info.EmailAddressIdentifier2.Equals(mail)) {
			info.EmailAddressIdentifier1=mail; updateFlag=true; } else {info.EmailAddressIdentifier1=mail; info.EmailAddressIdentifier2="Empty@Empty.Com"; updateFlag=true; } }
		else { info.EmailAddressIdentifier1=mail; updateFlag=true; }
		if (updateFlag) return UpdateOrCreateInDatabase(info); else return false; }

	#endregion

	#endregion

}
