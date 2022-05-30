// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsSalaryAgreement.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks />
[JsonObject("SalaryAgreement")][XmlType("SalaryAgreement")][Serializable]
public class WsSalaryAgreement
{
	#region Constructors

	/// <summary>Initializes an empty instance of SalaryAgreement</summary>
	public WsSalaryAgreement() { }

	/// <summary>Initializes a new instance of SalaryAgreement</summary><param name="activationDate" /><param name="deactivationDate" /><param name="salaryAgreementId" /><param name="salaryClassId" />
	/// <param name="salaryScaleId" /><param name="prepaidIndicator" /><param name="seniorityDate" />
	public WsSalaryAgreement(string activationDate,string deactivationDate,string salaryAgreementId,string salaryClassId,string salaryScaleId,string prepaidIndicator,string seniorityDate) {
		this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.SalaryAgreementIdentifier=salaryAgreementId; this.SalaryClassIdentifier=salaryClassId; 
		this.SalaryScaleIdentifier=salaryScaleId; this.PrepaidIndicator=prepaidIndicator; this.SeniorityDate=seniorityDate; }

	/// <summary>Initializes a new instance of SalaryAgreement, that accepts data from an existing SalaryAgreement</summary><param name="agree" />
	public WsSalaryAgreement(WsSalaryAgreement agree) { this.ActivationDate=agree.ActivationDate; this.DeactivationDate=agree.DeactivationDate; this.SalaryAgreementIdentifier=agree.SalaryAgreementIdentifier; 
		this.SalaryClassIdentifier=agree.SalaryClassIdentifier; this.SalaryScaleIdentifier=agree.SalaryScaleIdentifier; this.PrepaidIndicator=agree.PrepaidIndicator; this.SeniorityDate=agree.SeniorityDate; }

	#endregion

	#region Properties

	/// <remarks />
	[JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
	public string ActivationDate { get; set; } = "2010-01-01";

	/// <remarks />
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public string DeactivationDate { get; set; } = "9999-12-31";

	/// <remarks />
	[JsonProperty("SalaryAgreementIdentifier")][XmlElement("SalaryAgreementIdentifier")]
	public string SalaryAgreementIdentifier { get; set; } = "0000";

	/// <remarks />
	[JsonProperty("SalaryClassIdentifier")][XmlElement("SalaryClassIdentifier")]
	public string SalaryClassIdentifier { get; set; } = "0.0000";

	/// <remarks />
	[JsonProperty("SalaryScaleIdentifier")][XmlElement("SalaryScaleIdentifier")]
	public string SalaryScaleIdentifier { get; set; } = "0.0000";

	/// <remarks />
	[JsonProperty("PrepaidIndicator")][XmlElement("PrepaidIndicator")]
	public string PrepaidIndicator { get; set; } = "false";

	/// <remarks />
	[JsonProperty("SeniorityDate")][XmlElement("SeniorityDate")]
	public string SeniorityDate { get; set; } = "2010-01-01";

	#endregion

	#region Methods

	/// <returns>Content of SalaryAgreement as a long string</returns><param name="employmentId" /><param name="institutionId" /><exception cref="NullReferenceException" />
	public SalaryAgreement ToSalaryAgreement(string employmentId,string institutionId) { if(this==null) throw new NullReferenceException(); else return new(employmentId,institutionId,this.ActivationDate,this.DeactivationDate,
		this.SalaryAgreementIdentifier,this.SalaryClassIdentifier,this.SalaryScaleIdentifier,this.SeniorityDate,this.PrepaidIndicator); }

	/// <returns>Content of SalaryAgreement as string</returns>
	public override string ToString() { if(this==null) return "null"; else return this.SalaryAgreementIdentifier+" ("+this.ActivationDate+"-"+this.DeactivationDate+")"; }

	#endregion

}
