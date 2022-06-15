// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiPair.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public class ApiPair
{
  #region Constructors
  /// <summary>Initializes an empty instance of ApiPair</summary>
  public ApiPair() { }

  /// <summary>Initializes a new instance of ApiPair</summary><param name="sdApi" /><param name="instId">InstitutionIdentifier</param>
  public ApiPair(string sdApi, string instId) { this.SdApi=sdApi; this.InstitutionIdentifier=instId; }

  /// <summary>Initializes a new instance of ApiPair accepting data from existing ApiPair</summary><param name="apiPair" />
  public ApiPair(ApiPair apiPair) { this.SdApi=apiPair.SdApi; this.InstitutionIdentifier=apiPair.InstitutionIdentifier; }

  #endregion

  #region Properties
  /// <remarks />
  public string SdApi { get; set; } = string.Empty;

  /// <remarks />
  public string InstitutionIdentifier { get; set; } = string.Empty;

  #endregion

}
