// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsInstitution.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks/>
[JsonObject("Institution")][XmlType("Institution")][Serializable]
public class WsInstitution
{

	#region Constructors
	/// <summary>Initializes an empty instance of Institution</summary>
	public WsInstitution() { }

	/// <summary>Initializes a new instance of Institution</summary><param name="institutionUuid" /><param name="institutionId" /><param name="institutionName" />
	public WsInstitution(string institutionUuid, string institutionId, string institutionName) { this.InstitutionUuidIdentifier=institutionUuid;
		this.InstitutionIdentifier=institutionId.Replace("'", "′"); this.InstitutionName=institutionName.Replace("'", "′"); }

	/// <summary>Initializes a new instance of Institution, that accepts data from an existing Institution</summary><param name="inst" />
	public WsInstitution(Institution inst) { this.InstitutionUuidIdentifier=inst.InstitutionUuidIdentifier; this.InstitutionIdentifier=inst.InstitutionIdentifier; this.InstitutionName=inst.InstitutionName; }

	/// <summary>Initializes a new instance of Institution, that accepts data from an existing Institution</summary><param name="inst" />
	public WsInstitution(WsInstitution inst) { this.InstitutionUuidIdentifier=inst.InstitutionUuidIdentifier; this.InstitutionIdentifier=inst.InstitutionIdentifier; this.InstitutionName=inst.InstitutionName; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("InstitutionUUIDIdentifier")][XmlElement("InstitutionUUIDIdentifier")]
	public string InstitutionUuidIdentifier { get; set; } = "00000000-0000-0000-0000-000000000000";

	/// <remarks />
	[JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
	public string InstitutionIdentifier { get; set; } = "NO";

	/// <remarks />
	[JsonProperty("InstitutionName")][XmlElement("InstitutionName")]
	public string InstitutionName { get; set; } = "None";

	#endregion

	#endregion

	#region Methods

	/// <returns>This WsInstitution as Institution</returns>
	public Institution ToInstitution() { if(this==null) throw new NullReferenceException(); else return new(this.InstitutionUuidIdentifier,this.InstitutionIdentifier,this.InstitutionName); }

	/// <returns>Content of this Institution as string</returns>
	public override string ToString() { if(this==null) return "null"; return this.InstitutionName+" ("+this.InstitutionIdentifier+")"; }

	#endregion

}
