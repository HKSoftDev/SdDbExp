// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IntraNoteViewGetUniquePersonEmail.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class IntraNoteViewGetUniquePersonEmail
{
  /// <remarks />
  public string EmploymentId { get; set; } = null!;

  /// <remarks />
  public double? PersonCivilRegistrationIdentifier { get; set; }

  /// <remarks />
  public string Fornavn { get; set; } = null!;

  /// <remarks />
  public string Efternavn { get; set; } = null!;

  /// <remarks />
  public string? Adresse { get; set; }

  /// <remarks />
  public string? Postnr { get; set; }

  /// <remarks />
  public string? By { get; set; }

  /// <remarks />
  public string? Kommune { get; set; }

  /// <remarks />
  public string? Land { get; set; }

  /// <remarks />
  public string? Phone1 { get; set; }

  /// <remarks />
  public string? Phone2 { get; set; }

  /// <remarks />
  public string? Email1 { get; set; }

  /// <remarks />
  public string? Email2 { get; set; }

}
