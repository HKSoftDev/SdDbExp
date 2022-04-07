// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Retrieve.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace LogicTier;

/// <remarks/>
public partial class Bizz // Retrieve
{

	#region Methods

	/// <summary>Retrieves the current domain path</summary><returns>Result as string</returns>
	protected static string RetrieveCurrentDomainPath() { using (DirectoryEntry de=new("LDAP://RootDSE")) { return "LDAP://"+de.Properties["defaultNamingContext"][0].ToString(); } }

	/// <summary>Sets Fromdate for RunMode</summary>
	private string RetrieveFromDate(string sdApi) { if (string.IsNullOrWhiteSpace(sdApi)) throw new ArgumentEmptyException(nameof(sdApi),nameof(sdApi)+Error.CantBeEmpty); List<SuccessfulRun> list=GetList<SuccessfulRun>();
		if (sdApi.ToLower().Equals("getemploymentchangedatdate")) { for (int i = list.Count - 1; i > -1; i--) { if ((list[i].SdApi.ToLower().Equals("getemployment")||
			list[i].SdApi.ToLower().Equals("getemploymentchangedatdate"))&&!string.IsNullOrWhiteSpace(list[i].RunDate)) return list[i].RunDate; } }
		else if (sdApi.ToLower().Equals("getpersonchangedatdate")) { for (int i = list.Count - 1; i > -1; i--) { if (list[i].SdApi.ToLower().Equals("getperson")||
			list[i].SdApi.ToLower().Equals("getpersonchangedatdate")&&!string.IsNullOrWhiteSpace(list[i].RunDate)) return list[i].RunDate; } }
		return DateTime.Today.AddDays(-1).ToString("yyyy-MM-dd"); }

	///<remarks /><param name="user" />
	private string RetrieveInstitutionUuidIdentifier(ADUser user) { if (user.PrimaryGroupId.Contains("HB")) return RetrieveInstitution("HB").InstitutionUuidIdentifier;
		else if (user.PrimaryGroupId.Contains("HI")) return RetrieveInstitution("HI").InstitutionUuidIdentifier; else if (user.PrimaryGroupId.Contains("HW"))
			return RetrieveInstitution("HW").InstitutionUuidIdentifier; else if (user.MemberOf.Contains("HB")) return RetrieveInstitution("HB").InstitutionUuidIdentifier;
		else if (user.MemberOf.Contains("HI")) return RetrieveInstitution("HI").InstitutionUuidIdentifier; else if (user.MemberOf.Contains("HW"))
			return RetrieveInstitution("HW").InstitutionUuidIdentifier; else return "00000000-0000-0000-0000-000000000000"; }

	#endregion

}
