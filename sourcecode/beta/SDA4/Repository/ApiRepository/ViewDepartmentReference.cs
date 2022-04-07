// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewDepartmentReferenceList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewDepartmentReference
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;DepartmentIdentifier;DepartmentUuidIdentifier;DepartmentLevelIdentifier;Organization;SeniorDepartmentReference\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewDepartmentReferenceList</summary>
	public ViewDepartmentReference ()	{ }

	/// <summary>Initializes a new instance of ViewDepartmentReferenceList</summary><param name="id" /><param name="departmentId" />
	/// <param name="departmentUuid" /><param name="departmentLevelId" /><param name="organization" /><param name="seniorDepartmentRef" />
	public ViewDepartmentReference(int id,string departmentId,string departmentUuid,string departmentLevelId,string organization,string seniorDepartmentRef) { this.Id=id; this.DepartmentIdentifier=departmentId;
		this.DepartmentUuidIdentifier=departmentUuid; this.DepartmentLevelIdentifier=departmentLevelId; this.Organization=organization; this.SeniorDepartmentReference=seniorDepartmentRef; }

	/// <summary>Initializes an instance of ViewDepartmentReferenceList, that accepts data from an existing ViewDepartmentReferenceList</summary><param name="entity" />
	public ViewDepartmentReference(ViewDepartmentReference entity) { this.Id=entity.Id; this.DepartmentIdentifier=entity.DepartmentIdentifier; this.DepartmentUuidIdentifier=entity.DepartmentUuidIdentifier;
		this.DepartmentLevelIdentifier=entity.DepartmentLevelIdentifier; this.Organization=entity.Organization; this.SeniorDepartmentReference=entity.SeniorDepartmentReference; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Id")][XmlElement("Id")]
	public int Id { get; set; }

	/// <remarks />
	[JsonProperty("DepartmentIdentifier")][XmlElement("DepartmentIdentifier")]
	public string DepartmentIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("DepartmentUuidIdentifier")][XmlElement("DepartmentUuidIdentifier")]
	public string DepartmentUuidIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("DepartmentLevelIdentifier")][XmlElement("DepartmentLevelIdentifier")]
	public string DepartmentLevelIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("Organization")][XmlElement("Organization")]
	public string Organization { get; set; } = null!;

	/// <remarks />
	[JsonProperty("SeniorDepartmentReference")][XmlElement("SeniorDepartmentReference")]
	public string SeniorDepartmentReference { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.DepartmentIdentifier+";"+this.DepartmentUuidIdentifier+";"+this.DepartmentLevelIdentifier+";"+this.Organization+";"+this.SeniorDepartmentReference+";"+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewDepartmentReference creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result += "    <DepartmentIdentifier>"+DepartmentIdentifier+"<\\DepartmentIdentifier>"+Environment.NewLine;
		result += "    <DepartmentUuidIdentifier>"+DepartmentUuidIdentifier+"<\\DepartmentUuidIdentifier>"+Environment.NewLine;
		result += "    <DepartmentLevelIdentifier>"+DepartmentLevelIdentifier+"<\\DepartmentLevelIdentifier>"+Environment.NewLine;
		result += "    <Organization>"+Organization+"<\\Organization>"+Environment.NewLine;
		result += "    <SeniorDepartmentReference>"+SeniorDepartmentReference+"<\\SeniorDepartmentReference>"+Environment.NewLine;
		result += "<\\ViewDepartmentReference>"+Environment.NewLine; return result; }

	#endregion

}
