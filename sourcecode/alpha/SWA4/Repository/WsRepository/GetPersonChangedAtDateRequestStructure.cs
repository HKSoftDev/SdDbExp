// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetPersonChangedAtDate.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("RequestStructure")][XmlType("RequestStructure")][Serializable]
public class GetPersonChangedAtDateRequestStructure
{
  #region Properties
  /// <remarks/>
  [JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
  public string InstitutionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
  public string ActivationDate { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("ActivationTime")][XmlElement("ActivationTime")]
  public string ActivationTime { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
  public string DeactivationDate { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("DeactivationTime")][XmlElement("DeactivationTime")]
  public string DeactivationTime { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("ContactInformationIndicator")][XmlElement("ContactInformationIndicator")]
  public string ContactInformationIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("PostalAddressIndicator")][XmlElement("PostalAddressIndicator")]
  public string PostalAddressIndicator { get; set; } = string.Empty;

  #endregion

}
