// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsProfession.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks/>
[JsonObject("Profession")][XmlType("Profession")][Serializable]
public class WsEmploymentProfession
{

	#region Constructors

	/// <summary>Initializes an empty instance of Profession</summary>
	public WsEmploymentProfession() { }

	/// <summary>Initializes a new instance of Profession</summary><param name="activationDate" /><param name="deactivationDate" />
	/// <param name="jobPositionId" /><param name="institutionId" /><param name="employmentName" /><param name="appointmentCode" />
	public WsEmploymentProfession(string activationDate,string deactivationDate,string jobPositionId,string institutionId,string employmentName,string appointmentCode) { this.ActivationDate=activationDate;
		this.DeactivationDate=deactivationDate; this.JobPositionIdentifier=jobPositionId; this.InstitutionIdentifier=institutionId; this.EmploymentName=employmentName.Replace("'", "′"); this.AppointmentCode=appointmentCode; }

	/// <summary>Initializes a new instance of WsEmploymentProfession, that accepts data from existing WsEmploymentProfession</summary><param name="profession">Profession</param>
	public WsEmploymentProfession(WsEmploymentProfession profession) { this.ActivationDate=profession.ActivationDate; this.DeactivationDate=profession.DeactivationDate; this.JobPositionIdentifier=profession.JobPositionIdentifier;
		this.InstitutionIdentifier=profession.InstitutionIdentifier; this.EmploymentName= profession.EmploymentName; this.AppointmentCode= profession.AppointmentCode; }

	#endregion

	#region Properties

	/// <remarks/>
	[JsonIgnore][XmlIgnore]
	public string EmploymentIdentifier { get; set; } = "00000";

	/// <remarks/>
	[JsonIgnore][XmlIgnore]
	public string InstitutionIdentifier { get; set; } = "NO";

	/// <remarks/>
	[JsonProperty("JobPositionIdentifier")][XmlElement("JobPositionIdentifier")]
	public string JobPositionIdentifier { get; set; } = "0000";

	/// <remarks/>
	[JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
	public string ActivationDate { get; set; } = "2010-01-01";

	/// <remarks/>
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public string DeactivationDate { get; set; } = "9999-12-31";

	/// <remarks/>
	[JsonProperty("EmploymentName")][XmlElement("EmploymentName")]
	public string EmploymentName { get; set; } = "None";

	/// <remarks/>
	[JsonProperty("AppointmentCode")][XmlElement("AppointmentCode")]
	public string AppointmentCode { get; set; } = "0";

	#endregion

	#region Methods

	/// <returns>Content of this Profession as string</returns><exception cref="NullReferenceException" />
	public EmploymentProfession ToEmploymentProfession() { if(this==null) throw new NullReferenceException(); else return new(this.EmploymentIdentifier,this.InstitutionIdentifier,
		this.JobPositionIdentifier,DateTime.Parse(this.ActivationDate),DateTime.Parse(this.DeactivationDate),this.EmploymentName,this.AppointmentCode); }

	/// <returns>Content of this Profession as string</returns><param name="employmentId" /><param name="institutionId" /><exception cref="NullReferenceException" />
	public EmploymentProfession ToEmploymentProfession(string employmentId,string institutionId) { if(this==null) throw new NullReferenceException(); else return new(
		employmentId,institutionId,this.JobPositionIdentifier,this.ActivationDate,this.DeactivationDate,this.EmploymentName,this.AppointmentCode); }

	/// <returns>Content of this Profession as string</returns>
	public override string ToString() { if(this==null) return "null"; return this.EmploymentName+" ("+this.InstitutionIdentifier+"-"+this.JobPositionIdentifier+")"; }

	#endregion

}
