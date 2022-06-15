// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsWorkingTime.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks />
[JsonObject("WorkingTime")][XmlType("WorkingTime")][Serializable]
public class WsWorkingTime
{
	#region Constructors
	/// <summary>Initializes an empty instance of WorkingTime</summary>
	public WsWorkingTime() { }

	/// <summary>Initializes a new instance of WorkingTime</summary><param name="activationDate" /><param name="deactivationDate" /><param name="occupationRate" />
	/// <param name="salaryRate" /><param name="salariedIndicator" /><param name="automaticRaiseIndicator" /><param name="fullTimeIndicator" />
	public WsWorkingTime(string activationDate,string deactivationDate,string occupationRate,string salaryRate,string salariedIndicator="false",string automaticRaiseIndicator="false",string fullTimeIndicator="false") {
			this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.OccupationRate=occupationRate; this.SalaryRate=salaryRate; this.SalariedIndicator=salariedIndicator;
			this.AutomaticRaiseIndicator=automaticRaiseIndicator; this.FullTimeIndicator=fullTimeIndicator; }

	/// <summary>Initializes a new instance of WorkingTime,that accepts data from existing WorkingTime</summary><param name="time" />
	public WsWorkingTime(WsWorkingTime time) { this.ActivationDate=time.ActivationDate; this.DeactivationDate=time.DeactivationDate; this.OccupationRate=time.OccupationRate; this.SalaryRate=time.SalaryRate;
		this.SalariedIndicator=time.SalariedIndicator; this.AutomaticRaiseIndicator=time.AutomaticRaiseIndicator; this.FullTimeIndicator=time.FullTimeIndicator; }

	#endregion

	#region Properties

	/// <remarks />
	[JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
	public string ActivationDate { get; set; } = "2010-01-01";

	/// <remarks />
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public string DeactivationDate { get; set; } = "9999-12-31";

	/// <remarks />
	[JsonProperty("OccupationRate")][XmlElement("OccupationRate")]
	public string OccupationRate { get; set; } = "0.0000";

	/// <remarks />
	[JsonProperty("SalaryRate")][XmlElement("SalaryRate")]
	public string SalaryRate { get; set; } = "0.0000";

	/// <remarks />
	[JsonProperty("SalariedIndicator")][XmlElement("SalariedIndicator")]
	public string SalariedIndicator { get; set; } = "false";

	/// <remarks />
	[JsonProperty("AutomaticRaiseIndicator")][XmlElement("AutomaticRaiseIndicator")]
	public string AutomaticRaiseIndicator { get; set; } = "false";

	/// <remarks />
	[JsonProperty("FullTimeIndicator")][XmlElement("FullTimeIndicator")]
	public string FullTimeIndicator { get; set; } = "false";

	#endregion

	#region Methods

	/// <returns>Content of this WorkingTime as a long string</returns><param name="employmentId" /><param name="institutionId" /><exception cref="NullReferenceException" />
	public WorkingTime ToWorkingTime(string employmentId,string institutionId) { if (this==null) throw new NullReferenceException(); else return new(employmentId,institutionId,this.ActivationDate,
		this.DeactivationDate,this.OccupationRate,this.SalaryRate,this.SalariedIndicator,this.AutomaticRaiseIndicator,this.FullTimeIndicator); }

	/// <returns>Content of this WorkingTime as string</returns>
	public override string ToString() { if(this==null) return "null"; else return "OccupationRate: "+this.OccupationRate+" - SalaryRate: "+this.SalaryRate+" ("+this.ActivationDate+"-"+this.DeactivationDate+")"; }

	#endregion

}
