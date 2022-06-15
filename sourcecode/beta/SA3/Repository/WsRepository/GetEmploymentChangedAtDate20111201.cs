// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetEmploymentChangedAtDate20111201.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("GetEmploymentChangedAtDate20111201")][XmlType("GetEmploymentChangedAtDate20111201")][Serializable]
public class GetEmploymentChangedAtDate20111201
{
  #region Properties
  /// <remarks/>
  [JsonProperty("RequestStructure")][XmlElement("RequestStructure")]
  public GetEmploymentChangedAtDateRequestStructure GetEmploymentChangedAtDateRequestStructure { get; set; } = new();

  /// <remarks/>
  [JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
  public string InstitutionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("Person")][XmlElement("Person")]
  public List<WsPerson> Persons { get; set; } = new();

  #endregion

}
