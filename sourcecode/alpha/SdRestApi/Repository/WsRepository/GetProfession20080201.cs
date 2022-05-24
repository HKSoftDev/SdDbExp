// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetProfession20080201.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("GetProfession20080201")][XmlType("GetProfession20080201")][Serializable]
public class GetProfession20080201
{
  #region Properties

  /// <remarks/>
  [JsonProperty("RequestKey")][XmlElement("RequestKey")]
  public RequestKey RequestKey { get; set; } = new RequestKey();

  /// <remarks/>
  [JsonIgnore][XmlIgnore]
  public string InstitutionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("Profession")][XmlElement("Profession")]
  public List<WsProfession> Professions { get; set; } = new();

  #endregion

}
