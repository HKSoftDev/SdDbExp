// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetEmployment20111201.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("GetEmploymentChanged20111201")][XmlType("GetEmploymentChanged20111201")][Serializable]
public class GetEmploymentChanged20111201
{
  #region Properties

  /// <remarks/>
  [JsonProperty("RequestStructure")][XmlElement("RequestStructure")]
  public GetEmploymentChangedRequestStructure GetEmploymentChangedRequestStructure { get; set; } = new();

  /// <remarks/>
  [JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
  public string InstitutionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("Person")][XmlElement("Person")]
  public List<WsPerson> Persons { get; set; } = new();

  #endregion

}
