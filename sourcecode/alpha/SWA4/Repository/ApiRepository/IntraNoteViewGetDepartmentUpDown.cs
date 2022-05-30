// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="IntraNoteViewGetDepartmentUpDown.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class IntraNoteViewGetDepartmentUpDown
{
  /// <remarks />
  public string DepartmentIdentifier { get; set; } = null!;

  /// <remarks />
  public string DepartmentName { get; set; } = null!;

  /// <remarks />
  public int DepartmentReferencesId { get; set; }

  /// <remarks />
  public int UpReference { get; set; }

  /// <remarks />
  public string UpIdentifier { get; set; } = null!;

  /// <remarks />
  public string UpName { get; set; } = null!;

  /// <remarks />
  public int DownReference { get; set; }

  /// <remarks />
  public string DownIdentifier { get; set; } = null!;

  /// <remarks />
  public string DownName { get; set; } = null!;
}
