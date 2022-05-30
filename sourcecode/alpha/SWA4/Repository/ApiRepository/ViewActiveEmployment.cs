// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewActiveEmployment.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewActiveEmployment
{
  /// <remarks />
  public string EmploymentId { get; set; } = null!;

  /// <remarks />
  public string PersonCivilRegistrationIdentifierNvarchar { get; set; } = null!;

  /// <remarks />
  public double? PersonCivilRegistrationIdentifier { get; set; }

  /// <remarks />
  public string PersonGivenName { get; set; } = null!;

  /// <remarks />
  public string PersonSurnameName { get; set; } = null!;

  /// <remarks />
  public string EmploymentStatusCode { get; set; } = null!;

  /// <remarks />
  public string OccupationRate { get; set; } = null!;

  /// <remarks />
  public string SalaryRate { get; set; } = null!;

  /// <remarks />
  public int WorkingTime { get; set; }

  /// <remarks />
  public decimal? Hoursw { get; set; }

  /// <remarks />
  public string JobPositionIdentifier { get; set; } = null!;

  /// <remarks />
  public string DepartmentName { get; set; } = null!;

  /// <remarks />
  public DateTime ActivationDate { get; set; }

  /// <remarks />
  public DateTime DeactivationDate { get; set; }

  /// <remarks />
  public string JobPositionName { get; set; } = null!;

  /// <remarks />
  public string EmploymentName { get; set; } = null!;

  /// <remarks />
  public DateTime AnniversaryDate { get; set; }

  /// <remarks />
  public string DepartmentIdentifier { get; set; } = null!;

}
