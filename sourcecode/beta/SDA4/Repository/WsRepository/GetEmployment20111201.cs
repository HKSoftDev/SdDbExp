// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetEmployment20111201.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("GetEmployment20111201")][XmlType("GetEmployment20111201")][Serializable]
public class GetEmployment20111201
{
  #region Properties

  /// <remarks/>
  [JsonProperty("RequestStructure")][XmlElement("RequestStructure")]
  public GetEmploymentRequestStructure GetEmploymentRequestStructure { get; set; } = new();

  /// <remarks/>
  [JsonIgnore][XmlIgnore]
  public string InstitutionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("Person")][XmlElement("Person")]
  public List<WsPerson> Persons { get; set; } = new();

  #endregion

}
