// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Requestkey.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks />
[JsonObject("RequestKey")][XmlType("sd:RequestKey")][Serializable]
public class RequestKey
{
  #region Properties

  /// <remarks />
  [JsonProperty("InstitutionIdentifier")] [XmlElement("InstitutionIdentifier")]
  public string InstitutionIdentifier { get; set; } = string.Empty;

  #endregion

}
