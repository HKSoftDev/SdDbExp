// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetOrganizationRequestStructure.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("RequestStructure")][XmlType("RequestStructure")][Serializable]

public class GetOrganizationRequestStructure
{
  #region Properties
  /// <remarks/>
  [JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
  public string InstitutionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
  public string ActivationDate { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
  public string DeactivationDate { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("UUIDIndicator")][XmlElement("UUIDIndicator")]
  public string UuidIndicator { get; set; } = string.Empty;

  #endregion

}

