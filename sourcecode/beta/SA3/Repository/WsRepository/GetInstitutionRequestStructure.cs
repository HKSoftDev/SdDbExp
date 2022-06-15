// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetInstitutionRequestStructure.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("RequestStructure")][XmlType("RequestStructure")][Serializable]
public class GetInstitutionRequestStructure
{
  #region Properties
  /// <remarks/>
  [JsonProperty("RegionIdentifier")][XmlElement("RegionIdentifier")]
  public string RegionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("AdministrationIndicator")][XmlElement("AdministrationIndicator")]
  public string AdministrationIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("ContactInformationIndicator")][XmlElement("ContactInformationIndicator")]
  public string ContactInformationIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("PostalAddressIndicator")][XmlElement("PostalAddressIndicator")]
  public string PostalAddressIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("ProductionUnitIndicator")][XmlElement("ProductionUnitIndicator")]
  public string ProductionUnitIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("UUIDIndicator")][XmlElement("UUIDIndicator")]
  public string UuidIndicator { get; set; } = string.Empty;

  #endregion

}
