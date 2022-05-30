// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetPersonRequestStructure.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("RequestStructure")][XmlType("RequestStructure")][Serializable]
public class GetPersonRequestStructure
{
  #region Properties
  /// <remarks/>
  [JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
  public string InstitutionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("EffectiveDate")][XmlElement("EffectiveDate")]
  public string EffectiveDate { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("StatusActiveIndicator")][XmlElement("StatusActiveIndicator")]
  public string StatusActiveIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("StatusPassiveIndicator")][XmlElement("StatusPassiveIndicator")]
  public string StatusPassiveIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("ContactInformationIndicator")][XmlElement("ContactInformationIndicator")]
  public string ContactInformationIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("PostalAddressIndicator")][XmlElement("PostalAddressIndicator")]
  public string PostalAddressIndicator { get; set; } = string.Empty;

  #endregion

}
