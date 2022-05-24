// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewDepartmentList.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewDepartment
{

	#region Fields

	/// <remarks/>
	public const string CsvHeader="Id;ActivationDate;DeactivationDate;DepartmentUuidIdentifier;DepartmentIdentifier;DepartmentLevelIdentifier;DepartmentName;ProductionUnitIdentifier;InstitutionIdentifier\r\n";

	#endregion

	#region Constructors

	/// <summary>Initializes an empty instance of ViewDepartmentList</summary>
	public ViewDepartment ()	{ }

	/// <summary>Initializes a new instance of ViewDepartmentList</summary><param name="id" /><param name="activationDate" /><param name="deactivationDate" /><param name="departmentUuidId" /><param name="departmentId" />
	/// <param name="departmentLevelId" /><param name="departmentName" /><param name="productionUnitId" /><param name="institutionId" />
	public ViewDepartment(int id,DateTime activationDate,DateTime deactivationDate,string departmentUuidId,string departmentId,string departmentLevelId,string departmentName,string productionUnitId,
		string institutionId) { this.Id=id; this.ActivationDate=activationDate; this.DeactivationDate=deactivationDate; this.DepartmentUuidIdentifier=departmentUuidId; this.DepartmentIdentifier=departmentId; 
		this.DepartmentLevelIdentifier=departmentLevelId; this.DepartmentName=departmentName; this.ProductionUnitIdentifier=productionUnitId; this.InstitutionIdentifier=institutionId; }

	/// <summary>Initializes an instance of ViewDepartmentList, that accepts data from an existing ViewDepartmentList</summary><param name="entity" />
	public ViewDepartment(ViewDepartment entity) { this.Id=entity.Id; this.ActivationDate=entity.ActivationDate; this.DeactivationDate=entity.DeactivationDate;
		this.DepartmentUuidIdentifier=entity.DepartmentUuidIdentifier; this.DepartmentIdentifier=entity.DepartmentIdentifier; this.DepartmentLevelIdentifier=entity.DepartmentLevelIdentifier;
		this.DepartmentName=entity.DepartmentName; this.ProductionUnitIdentifier=entity.ProductionUnitIdentifier; this.InstitutionIdentifier=entity.InstitutionIdentifier; }

	#endregion

	#region Properties

	#region Database

	/// <remarks />
	[JsonProperty("Id")][XmlElement("Id")]
	public int Id { get; set; }

	/// <remarks />
	[JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
	public DateTime ActivationDate { get; set; } = DateTime.Parse("2010-01-01");

	/// <remarks />
	[JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
	public DateTime DeactivationDate { get; set; } = DateTime.Parse("9999-12-31");

	/// <remarks />
	[JsonProperty("DepartmentUuidIdentifier")][XmlElement("DepartmentUuidIdentifier")]
	public string DepartmentUuidIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("DepartmentIdentifier")][XmlElement("DepartmentIdentifier")]
	public string DepartmentIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("DepartmentLevelIdentifier")][XmlElement("DepartmentLevelIdentifier")]
	public string DepartmentLevelIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("DepartmentName")][XmlElement("DepartmentName")]
	public string DepartmentName { get; set; } = null!;

	/// <remarks />
	[JsonProperty("ProductionUnitIdentifier")][XmlElement("ProductionUnitIdentifier")]
	public string ProductionUnitIdentifier { get; set; } = null!;

	/// <remarks />
	[JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
	public string InstitutionIdentifier { get; set; } = null!;

	#endregion

	#region Other

	/// <remarks/>
	public string CsvValue => this.Id+";"+this.ActivationDate+";"+this.DeactivationDate+";"+this.DepartmentUuidIdentifier+";"+this.DepartmentIdentifier+";"+this.DepartmentLevelIdentifier+";"+
		this.DepartmentLevelIdentifier+";"+this.DepartmentName+";"+this.ProductionUnitIdentifier+";"+this.InstitutionIdentifier+"\r\n";

	#endregion

	#endregion

	#region Methods

	/// <returns>Field content as xml string</returns>
	public string ToXmlString() { string result="<ViewDepartment creationDateTime=\""+DateTime.Now.ToString("yyyy-MM-ddThh:mm:ss")+"\">"+Environment.NewLine;
		result += "    <Id>"+Id+"<\\Id>"+Environment.NewLine;
		result += "    <ActivationDate>"+ActivationDate+"<\\ActivationDate>"+Environment.NewLine;
		result += "    <DeactivationDate>"+DeactivationDate+"<\\DeactivationDate>"+Environment.NewLine;
		result += "    <DepartmentUuidIdentifier>"+DepartmentUuidIdentifier+"<\\DepartmentUuidIdentifier>"+Environment.NewLine;
		result += "    <DepartmentIdentifier>"+DepartmentIdentifier+"<\\DepartmentIdentifier>"+Environment.NewLine;
		result += "    <DepartmentLevelIdentifier>"+DepartmentLevelIdentifier+"<\\DepartmentLevelIdentifier>"+Environment.NewLine;
		result += "    <DepartmentLevelIdentifier>"+DepartmentLevelIdentifier+"<\\DepartmentLevelIdentifier>"+Environment.NewLine;
		result += "    <DepartmentName>"+DepartmentName+"<\\DepartmentName>"+Environment.NewLine;
		result += "    <ProductionUnitIdentifier>"+ProductionUnitIdentifier+"<\\ProductionUnitIdentifier>"+Environment.NewLine;
		result += "    <InstitutionIdentifier>"+InstitutionIdentifier+"<\\InstitutionIdentifier>"+Environment.NewLine;
		result += "<\\ViewDepartment>"+Environment.NewLine; return result; }

	#endregion

}
