// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="GetEmploymentRequestStructure.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace WsRepository;

/// <remarks/>
[JsonObject("RequestStructure")][XmlType("RequestStructure")][Serializable]
public class GetEmploymentRequestStructure
{
  #region Properties
  /// <remarks/>
  [JsonProperty("InstitutionIdentifier")][XmlElement("InstitutionIdentifier")]
  public string InstitutionIdentifier { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("EffectiveDate")][XmlElement("EffectiveDate")]
  public string EffectiveDate { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("StatusActiveIndicator")][XmlElement("StatusActiveIndicator")]
  public string StatusActiveIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("StatusPassiveIndicator")][XmlElement("StatusPassiveIndicator")]
  public string StatusPassiveIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("DepartmentIndicator")][XmlElement("DepartmentIndicator")]
  public string DepartmentIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("EmploymentStatusIndicator")][XmlElement("EmploymentStatusIndicator")]
  public string EmploymentStatusIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("ProfessionIndicator")][XmlElement("ProfessionIndicator")]
  public string ProfessionIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("SalaryAgreementIndicator")][XmlElement("SalaryAgreementIndicator")]
  public string SalaryAgreementIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("SalaryCodeGroupIndicator")][XmlElement("SalaryCodeGroupIndicator")]
  public string SalaryCodeGroupIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("WorkingTimeIndicator")][XmlElement("WorkingTimeIndicator")]
  public string WorkingTimeIndicator { get; set; } = string.Empty;

  /// <remarks/>
  [JsonProperty("UUIDIndicator")][XmlElement("UUIDIndicator")]
  public string UuidIndicator { get; set; } = string.Empty;

  #endregion

}
