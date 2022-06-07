// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetPerson20111201.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("GetPerson20111201")][XmlType("GetPerson20111201")][Serializable]
public class GetPerson20111201
{
  #region Properties

  /// <remarks/>
  [JsonProperty("RequestStructure")][XmlElement("RequestStructure")]
  public GetPersonRequestStructure GetPersonRequestStructure { get; set; } = new();


  /// <remarks/>
  [JsonIgnore][XmlIgnore]
  public string InstitutionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("Person")][XmlElement("Person")]
  public List<WsPerson> Persons { get; set; } = new();

  #endregion

}
