// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="WsEmploymentStatus.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using Repository;

namespace WsRepository;

/// <remarks/>
[JsonObject("EmploymentStatus")][XmlType("EmploymentStatus")][Serializable]
public class WsEmploymentStatus
{
	#region Constructors

	/// <summary>Initializes an empty instance of EmploymentStatus</summary>
	public WsEmploymentStatus() { }

	/// <summary>Initializes a new instance of EmploymentStatus</summary><param name="activationDate" /><param name="deactivationDate" /><param name="employmentStatusCode" /><param name="markedForDeletion" />
	public WsEmploymentStatus(string activationDate, string deactivationDate, string employmentStatusCode, string markedForDeletion="false") {
		this.ActivationDate=activationDate;this.DeactivationDate=deactivationDate; this.EmploymentStatusCode=employmentStatusCode; this.MarkedForDeletion=markedForDeletion; }

	/// <summary>Initializes a new instance of WsEmploymentStatus, that accepts data from existing WsEmploymentStatus</summary><param name="employmentStatus" />
	public WsEmploymentStatus(WsEmploymentStatus employmentStatus) { this.ActivationDate=employmentStatus.ActivationDate; this.DeactivationDate=employmentStatus.DeactivationDate;
		this.EmploymentStatusCode=employmentStatus.EmploymentStatusCode; this.MarkedForDeletion=employmentStatus.MarkedForDeletion; }

	#endregion

	#region Properties

	/// <remarks/>
	[JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
	public string ActivationDate { get; set; } = "2010-01-01";

	/// <remarks/>
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public string DeactivationDate { get; set; } = "9999-12-31";

	/// <remarks/>
	[JsonProperty("EmploymentStatusCode")][XmlElement("EmploymentStatusCode")]
	public string EmploymentStatusCode { get; set; } = "0";

	/// <remarks/>
	[JsonProperty("MarkedForDeletion")][XmlElement("MarkedForDeletion")]
	public string MarkedForDeletion { get; set; } = "false";

	#endregion

	#region Methods

	/// <returns>Content of this EmploymentStatus as a long string</returns><param name="employmentId" /><param name="institutionId" /><exception cref="NullReferenceException" />
	public EmploymentStatus ToEmploymentStatus(string employmentId,string institutionId) { if(this==null) throw new NullReferenceException(); else return new(employmentId,institutionId,this.ActivationDate,
		this.DeactivationDate,this.EmploymentStatusCode,this.MarkedForDeletion); }

	/// <returns>Content of this EmploymentStatus as string</returns>
	public override string ToString() { if(this==null) return "null"; else return "EmploymentStatusCode: "+this.EmploymentStatusCode+" ("+this.ActivationDate+"-"+this.DeactivationDate+")"; }

	#endregion

}
