// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetOrganization20111201.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("GetOrganization20111201")][XmlType("GetOrganization20111201")][Serializable]
public class GetOrganization20111201
{
  #region Properties

  /// <remarks/>
  [JsonProperty("RequestStructure")][XmlElement("RequestStructure")]
  public GetOrganizationRequestStructure GetOrganizationRequestStructure { get; set; } = new();

  /// <remarks/>
  [JsonProperty("RegionIdentifier")][XmlElement("RegionIdentifier")]
  public string RegionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("RegionUUIDIdentifier")][XmlElement("RegionUUIDIdentifier")]
  public string RegionUuidIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
  public string InstitutionUuidIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("InstitutionUUIDIdentifier")][XmlElement("InstitutionUUIDIdentifier")]
  public string InstitutionIdentifier { get; set; } = string.Empty;

    /// <remarks/>
  [JsonProperty("DepartmentStructureName")][XmlElement("DepartmentStructureName")]
  public string DepartmentStructureName { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("OrganizationStructure")][XmlElement("OrganizationStructure")]
  public List<WsOrganizationStructure> OrganizationStructures { get; set; } = new();

  /// <remarks/>
  [JsonProperty("Organization")][XmlElement("Organization")]
  public List<WsOrganization> Organizations { get; set; } = new();

  #endregion

}
