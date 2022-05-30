// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Region.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("Region")][XmlType("sd:Region")][Serializable]
public class Region
{
  #region Constructors
  /// <summary>Initializes an empty instance of Region</summary>
  public Region() { }

  /// <summary>Initializes a new instance of Region</summary><param name="regId">RegionIdentifier</param><param name="regUuid">RegionUuidIdentifier</param><param name="regName">RegionName</param><param name="insts">Institutions</param>
  public Region(string regId, string regUuid, string regName, List<WsInstitution>? insts=null) { this.RegionIdentifier=regId; this.RegionUuidIdentifier=regUuid; this.RegionName=regName; this.Institutions=insts; }

  /// <summary>Initializes a new instance of Region accepting data from existing Region</summary><param name="reg" />
  public Region(Region reg) { this.RegionIdentifier=reg.RegionIdentifier; this.RegionUuidIdentifier=reg.RegionUuidIdentifier; this.RegionName=reg.RegionName; this.Institutions=reg.Institutions; }

  #endregion

  #region Properties

  /// <remarks/>
  [XmlElement("RegionIdentifier")][JsonProperty("sd:RegionIdentifier")]
  public string RegionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [XmlElement("RegionUUIDIdentifier")][JsonProperty("sd:RegionUUIDIdentifier")]
  public string RegionUuidIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [XmlElement("RegionName")][JsonProperty("sd20080201:RegionName")]
  public string RegionName { get; set; } = string.Empty;

  /// <remarks/>
  [XmlElement("Institution")][JsonProperty("sd:Institution")]
  public List<WsInstitution> Institutions { get; set; } = new();

  #endregion

}
