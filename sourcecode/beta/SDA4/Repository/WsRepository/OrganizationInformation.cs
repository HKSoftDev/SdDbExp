// Copyright (c) Gywerd. All Rights reserved.
// Copyright (c) Haderslev Kommune. All Rights reserved.
// Licenced under Proprietary License. See License.txt

namespace WsRepository;

/// <remarks/>
[JsonObject("OrganizationInformation")][XmlType("OrganizationInformation")][Serializable]
public class OrganizationInformation
{
  /// <remarks/>
  [JsonProperty("Region")][XmlAttribute("Region")]
  public Region Region { get; set; } = new();

}
