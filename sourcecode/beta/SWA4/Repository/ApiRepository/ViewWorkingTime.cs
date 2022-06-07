// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewWorkingTime.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewWorkingTime
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;EmploymentIdentifier;InstitutionIdentifier;ActivationDate;DeactivationDate;OccupationRate;SalaryRate;SalariedIndicator;AutomaticRaiseIndicator;FullTimeIndicator\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewWorkingTime</summary>
	public ViewWorkingTime ()	{ }

	/// <summary>Initializes a new instance of ViewWorkingTime</summary><param name="id" /><param name="employmentId" /><param name="activationDate" /><param name="deactivationDate" />
	/// <param name="occupationRate" /><param name="salaryRate" /><param name="salaried" /><param name="automaticRaise" /><param name="fullTime" />
	public ViewWorkingTime(int id,string employmentId,DateTime activationDate, DateTime deactivationDate,string occupationRate,string salaryRate,bool salaried, bool automaticRaise, bool fullTime) { this.Id=id;
		this.EmploymentIdentifier=employmentId; this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.OccupationRate=occupationRate; this.SalaryRate=salaryRate; this.SalariedIndicator= salaried;
		this.AutomaticRaiseIndicator= automaticRaise; this.FullTimeIndicator= fullTime; }

	/// <summary>Initializes an instance of ViewWorkingTime, that accepts data from an existing ViewWorkingTime</summary><param name="entity" />
	public ViewWorkingTime(ViewWorkingTime entity) { this.Id=entity.Id; this.EmploymentIdentifier=entity.EmploymentIdentifier; this.InstitutionIdentifier=entity.InstitutionIdentifier; 
		this.ActivationDate=entity.ActivationDate; this.DeactivationDate=entity.DeactivationDate; this.OccupationRate=entity.OccupationRate; this.SalaryRate=entity.SalaryRate;
		this.SalariedIndicator=entity.SalariedIndicator; this.AutomaticRaiseIndicator=entity.AutomaticRaiseIndicator; this.FullTimeIndicator=entity.FullTimeIndicator; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Id")][XmlElement("Id")]
	public int Id { get; set; }

	/// <remarks />
	[JsonProperty("EmploymentIdentifier")][XmlElement("EmploymentIdentifier")]
	public string EmploymentIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
	public string InstitutionIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
	public DateTime ActivationDate { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks />
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public DateTime DeactivationDate { get; set; } = DateTime.Parse("9999-12-31");

	/// <remarks />
	[JsonProperty("OccupationRate")][XmlElement("OccupationRate")]
	public string OccupationRate { get; set; } = null!;

	/// <remarks />
	[JsonProperty("SalaryRate")][XmlElement("SalaryRate")]
	public string SalaryRate { get; set; } = null!;

	/// <remarks />
	[JsonProperty("SalariedIndicator")][XmlElement("SalariedIndicator")]
	public bool SalariedIndicator { get; set; }

	/// <remarks />
	[JsonProperty("AutomaticRaiseIndicator")][XmlElement("AutomaticRaiseIndicator")]
	public bool AutomaticRaiseIndicator { get; set; }

	/// <remarks />
	[JsonProperty("FullTimeIndicator")][XmlElement("FullTimeIndicator")]
	public bool FullTimeIndicator { get; set; }

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.EmploymentIdentifier+";"+this.InstitutionIdentifier+";"+this.ActivationDate.ToString("yyyy-MM-dd")+";"+this.DeactivationDate.ToString("yyyy-MM-dd")+";"+
		this.OccupationRate+";"+this.SalaryRate+";"+this.SalariedIndicator.ToString()+";"+this.AutomaticRaiseIndicator.ToString()+";"+this.FullTimeIndicator.ToString()+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewWorkingTime creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine+"    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result+="    <EmploymentIdentifier>"+EmploymentIdentifier+"<\\EmploymentIdentifier>"+Environment.NewLine+"    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine;
		result+="    <ActivationDate>"+ActivationDate.ToString("yyyy-MM-dd")+"<\\ActivationDate>"+Environment.NewLine+"    <DeactivationDate>"+DeactivationDate.ToString("yyyy-MM-dd")+"<\\DeactivationDate>"+Environment.NewLine;
		result+="    <OccupationRate>"+OccupationRate+"<\\OccupationRate>"+Environment.NewLine+"    <SalaryRate>"+SalaryRate+"<\\SalaryRate>"+Environment.NewLine+"    <SalariedIndicator>"+SalariedIndicator.ToString();
		result+= "<\\SalariedIndicator>"+Environment.NewLine+"    <AutomaticRaiseIndicator>"+AutomaticRaiseIndicator.ToString()+"<\\AutomaticRaiseIndicator>"+Environment.NewLine+"    <FullTimeIndicator>";
		result+= FullTimeIndicator.ToString()+"<\\FullTimeIndicator>"+Environment.NewLine+"<\\ViewWorkingTime>"+Environment.NewLine; return result; }

	#endregion

}
