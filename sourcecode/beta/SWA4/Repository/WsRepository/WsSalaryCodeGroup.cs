// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsSalaryCodeGroup.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks />
[JsonObject("SalaryCodeGroup")][XmlType("SalaryCodeGroup")][Serializable]
public class WsSalaryCodeGroup
{
	#region Constructors
	/// <summary>Initializes an empty instance of SalaryCodeGroup</summary>
	public WsSalaryCodeGroup() { }

	/// <summary>Initializes a new instance of SalaryCodeGroup</summary><param name="activationDate" /><param name="deactivationDate" /><param name="pensionCode" />
	public WsSalaryCodeGroup(string activationDate, string deactivationDate, string pensionCode) {  this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.PensionCode=pensionCode; }

	/// <summary>Initializes a new instance of SalaryCodeGroup from database, that accepts data from existing SalaryCodeGroup</summary><param name="group" />
	public WsSalaryCodeGroup(WsSalaryCodeGroup group) {this.ActivationDate=group.ActivationDate; this.DeactivationDate=group.DeactivationDate; this.PensionCode=group.PensionCode; }

	#endregion

	#region Properties

	/// <remarks />
	[JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
	public string ActivationDate { get; set; } = "2010-01-01";

	/// <remarks />
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public string DeactivationDate { get; set; } = "9999-12-31";

	/// <remarks />
	[JsonProperty("PensionCode")][XmlElement("PensionCode")]
	public string PensionCode { get; set; } ="0";

	#endregion

	#region Methods

	/// <returns>This WsSalaryCodeGroup as SalaryCodeGroup</returns><param name="employmentId" /><param name="institutionId" /><exception cref="NullReferenceException" />
	public SalaryCodeGroup ToSalaryCodeGroup(string employmentId,string institutionId) { if (this==null) throw new NullReferenceException(); else return new(employmentId,institutionId,this.ActivationDate,
		this.DeactivationDate,this.PensionCode); }

	/// <returns>Content of SalaryCodeGroup as string</returns>
	public override string ToString() { if(this==null) return "null"; else return "PensionCode: "+this.PensionCode+" ("+this.ActivationDate+"-"+this.DeactivationDate+")"; }

	#endregion

}

