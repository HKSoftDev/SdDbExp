// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewSelectEmployeeWorkplace.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewSelectEmployeeWorkplace
{
  /// <remarks />
  public string EmploymentId { get; set; } = null!;

  /// <remarks />
  public string DepartmentIdentifier { get; set; } = null!;

  /// <remarks />
  public string DepartmentName { get; set; } = null!;

  /// <remarks />
  public string ProductionUnitIdentifier { get; set; } = null!;

  /// <remarks />
  public string? Adresse { get; set; }

  /// <remarks />
  public string? Postnr { get; set; }

  /// <remarks />
  public string? By { get; set; }

}
