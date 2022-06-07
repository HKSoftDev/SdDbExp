// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewDepartmentLevelReferenceList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewDepartmentLevelReference
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;DepartmentLevelIdentifier;OrganizationStructure;SeniorDepartmentLevelReference\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewDepartmentList</summary>
	public ViewDepartmentLevelReference ()	{ }

	/// <summary>Initializes a new instance of ViewDepartmentList</summary><param name="id" /><param name="departmentLevelId" /><param name="organizationStructure" /><param name="seniorDepartmentLevelRef" />
	public ViewDepartmentLevelReference(int id,string departmentLevelId,string organizationStructure,string seniorDepartmentLevelRef) { this.Id=id; 
		this.DepartmentLevelIdentifier=departmentLevelId; this.OrganizationStructure=organizationStructure; this.SeniorDepartmentLevelReference=seniorDepartmentLevelRef; }

	/// <summary>Initializes an instance of ViewDepartmentList, that accepts data from an existing ViewDepartmentList</summary><param name="entity" />
	public ViewDepartmentLevelReference(ViewDepartmentLevelReference entity) { this.Id=entity.Id; this.DepartmentLevelIdentifier=entity.DepartmentLevelIdentifier;
		this.OrganizationStructure=entity.OrganizationStructure; this.SeniorDepartmentLevelReference=entity.SeniorDepartmentLevelReference; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Id")][XmlElement("Id")]
	public int Id { get; set; }

	/// <remarks />
	[JsonProperty("DepartmentLevelIdentifier")][XmlElement("DepartmentLevelIdentifier")]
	public string DepartmentLevelIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("OrganizationStructure")][XmlElement("OrganizationStructure")]
	public string OrganizationStructure { get; set; } = null!;

	/// <remarks />
	[JsonProperty("SeniorDepartmentLevelReference")][XmlElement("SeniorDepartmentLevelReference")]
	public string SeniorDepartmentLevelReference { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.DepartmentLevelIdentifier+";"+this.OrganizationStructure+";"+this.SeniorDepartmentLevelReference+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewDepartmentLevelReference creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result += "    <DepartmentLevelIdentifier>"+DepartmentLevelIdentifier+"<\\DepartmentLevelIdentifier>"+Environment.NewLine;
		result += "    <OrganizationStructure>"+OrganizationStructure+"<\\OrganizationStructure>"+Environment.NewLine;
		result += "    <SeniorDepartmentLevelReference>"+SeniorDepartmentLevelReference+"<\\SeniorDepartmentLevelReference>"+Environment.NewLine;
		result += "<\\ViewDepartmentLevelReference>"+Environment.NewLine; return result; }

	#endregion

}
