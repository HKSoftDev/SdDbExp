// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewPermanentEmploymentSalaried.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewPermanentEmploymentSalaried
{
  /// <remarks />
  public int Id { get; set; }

  /// <remarks />
  public string Institution { get; set; } = null!;

  /// <remarks />
  public string Cpr { get; set; } = null!;

  /// <remarks />
  public string EmploymentId { get; set; } = null!;

  /// <remarks />
  public string? JobPositionName { get; set; }

  /// <remarks />
  public string? EmploymentName { get; set; }

  /// <remarks />
  public string GivenName { get; set; } = null!;

  /// <remarks />
  public string SurName { get; set; } = null!;

  /// <remarks />
  public string? Department { get; set; }

  /// <remarks />
  public string? DepartmentUuid { get; set; }

  /// <remarks />
  public string? Phone1 { get; set; }

  /// <remarks />
  public string? Phone2 { get; set; }

  /// <remarks />
  public string? Email1 { get; set; }

  /// <remarks />
  public string? Email2 { get; set; }

}
