// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewSelectDepartment.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class ViewSelectDepartment
{
  /// <remarks />
  public string DepartmentIdentifier { get; set; } = null!;

  /// <remarks />
  public int DepartmentReferencesId { get; set; }

  /// <remarks />
  public int? Parent { get; set; }

  /// <remarks />
  public string ProductionUnitIdentifier { get; set; } = null!;

  /// <remarks />
  public string DepartmentName { get; set; } = null!;

  /// <remarks />
  public string? Telefon { get; set; }

  /// <remarks />
  public string? Fax { get; set; }

  /// <remarks />
  public string? Email1 { get; set; }

  /// <remarks />
  public string? Email2 { get; set; }

  /// <remarks />
  public string? Postnr { get; set; }

  /// <remarks />
  public string? By { get; set; }

  /// <remarks />
  public string? Adresse { get; set; }

}
