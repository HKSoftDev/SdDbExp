// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetDepartmentRequestStructure.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("RequestStructure")][XmlType("RequestStructure")][Serializable]
public class GetDepartmentRequestStructure
{
  #region Properties
  /// <remarks/>
  [JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
  public string InstitutionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("ActivationDate")][XmlElement("ActivationDate")]
  public string ActivationDate { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("DeactivationDate")][XmlElement("DeactivationDate")]
  public string DeactivationDate { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("ContactInformationIndicator")][XmlElement("ContactInformationIndicator")]
  public string ContactInformationIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("DepartmentNameIndicator")][XmlElement("DepartmentNameIndicator")]
  public string DepartmentNameIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("EmploymentDepartmentIndicator")][XmlElement("EmploymentDepartmentIndicator")]
  public string EmploymentDepartmentIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("PostalAddressIndicator")][XmlElement("PostalAddressIndicator")]
  public string PostalAddressIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("ProductionUnitIndicator")][XmlElement("ProductionUnitIndicator")]
  public string ProductionUnitIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("UUIDIndicator")][XmlElement("UUIDIndicator")]
  public string UuidIndicator { get; set; } = string.Empty;

  #endregion

}

