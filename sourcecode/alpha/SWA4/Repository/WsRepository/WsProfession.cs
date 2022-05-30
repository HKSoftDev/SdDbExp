// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsProfession.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks/>
[JsonObject("Profession")][XmlType("Profession")][Serializable]
public class WsProfession
{

	#region Constructors

	/// <summary>Initializes an empty instance of Profession</summary>
	public WsProfession() { }

	/// <summary>Initializes a new instance of Profession</summary><param name="activationDate" /><param name="deactivationDate" /><param name="jobPositionId" />
	/// <param name="jobPositionName" /><param name="jobPositionLevelCode" />
	public WsProfession(string activationDate,string deactivationDate,string jobPositionId,string jobPositionName,string jobPositionLevelCode) { this.ActivationDate=activationDate;
		this.DeactivationDate=deactivationDate;this.JobPositionIdentifier=jobPositionId; this.JobPositionName=jobPositionName.Replace("'", "′"); this.JobPositionLevelCode=jobPositionLevelCode; }

	/// <summary>Initializes a new instance of Profession, that accepts data from existing Profession</summary><param name="prof">Profession</param>
	public WsProfession(WsProfession prof) { this.ActivationDate=prof.ActivationDate; this.DeactivationDate=prof.DeactivationDate; this.JobPositionIdentifier=prof.JobPositionIdentifier;
		this.JobPositionName=prof.JobPositionName; this.JobPositionLevelCode=prof.JobPositionLevelCode; }

	#endregion

	#region Properties

	/// <remarks/>
	[JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
	public string ActivationDate { get; set; } = "2010-01-01";

	/// <remarks/>
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public string DeactivationDate { get; set; } = "9999-12-31";

	/// <remarks/>
	[JsonProperty("JobPositionIdentifier")][XmlElement("JobPositionIdentifier")]
	public string JobPositionIdentifier { get; set; } = "0000";

	/// <remarks/>
	[JsonProperty("JobPositionName")][XmlElement("JobPositionName")]
	public string JobPositionName { get; set; } = "None";

	/// <remarks/>
	[JsonProperty("JobPositionLevelCode")][XmlElement("JobPositionLevelCode")]
	public string JobPositionLevelCode { get; set; } = "0";

	/// <remarks/>
	[JsonIgnore][XmlIgnore]
	public string InstitutionIdentifier { get; set; } = "NO";

	#endregion

	#region Methods

	/// <returns>Content of this Profession as string</returns><exception cref="NullReferenceException" />
	public Profession ToProfession() { if(this==null) throw new NullReferenceException(); else return new(DateTime.Parse(this.ActivationDate),DateTime.Parse(this.DeactivationDate),this.JobPositionIdentifier,
		this.JobPositionName,this.JobPositionLevelCode,this.InstitutionIdentifier); }

	/// <returns>Content of this Profession as string</returns><param name="institutionId" /><exception cref="NullReferenceException" />
	public Profession ToProfession(string institutionId) { if(this==null) throw new NullReferenceException(); else return new(this.ActivationDate,this.DeactivationDate,this.JobPositionIdentifier,
		this.JobPositionName,this.JobPositionLevelCode,institutionId); }

	/// <returns>Content of this Profession as string</returns>
	public override string ToString() { if(this==null) return "null"; else return this.JobPositionName+" ("+this.JobPositionIdentifier+")"; }

	#endregion

}
