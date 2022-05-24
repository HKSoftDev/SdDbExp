// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetInstitution20111201.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("GetInstitution20111201")][XmlType("GetInstitution20111201")][Serializable]
public class GetInstitution20111201
{
  #region Properties

  /// <remarks/>
  [JsonProperty("RequestStructure")][XmlElement("RequestStructure")]
  public GetInstitutionRequestStructure GetInstitutionRequestStructure { get; set; } = new();

  /// <remarks/>
  [JsonProperty("Region")][XmlElement("Region")]
  public Region Region { get; set; } = new();

  #endregion

}
