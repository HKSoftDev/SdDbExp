// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetDepartment20111201.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("GetDepartment20111201")][XmlType("GetDepartment20111201")][Serializable]
public class GetDepartment20111201
{
  #region Properties

  /// <remarks/>
  [JsonProperty("RequestStructure")][XmlElement("RequestStructure")]
  public GetDepartmentRequestStructure GetDepartmentRequestStructure { get; set; } = new();

  /// <remarks/>
  [JsonProperty("RegionIdentifier")][XmlElement("RegionIdentifier")]
  public string RegionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("RegionUUIDIdentifier")][XmlElement("RegionUUIDIdentifier")]
  public string RegionUuidIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
  public string InstitutionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("InstitutionUUIDIdentifier")][XmlElement("InstitutionUUIDIdentifier")]
  public string InstitutionUuidIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("Department")][XmlElement("Department")]
  public List<WsDepartment> Departments { get; set; } = new();

  #endregion

}
