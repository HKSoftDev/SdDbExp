// -----------------------------------------------------------------------------------------------------------------------------------------
// <copyright file="View3in1PermanentEmployment.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -----------------------------------------------------------------------------------------------------------------------------------------
namespace ApiRepository;

/// <remarks />
public partial class View3in1PermanentEmployment
{
  /// <remarks />
  public int Id { get; set; }

  /// <remarks />
  public string Cpr { get; set; } = null!;

  /// <remarks />
  public string Fornavn { get; set; } = null!;

  /// <remarks />
  public string Efternavn { get; set; } = null!;

  /// <remarks />
  public string Silo { get; set; } = null!;

  /// <remarks />
  public string AfdelingsUuid { get; set; } = null!;

  /// <remarks />
  public string Afdelingsniveau { get; set; } = null!;

  /// <remarks />
  public string? Phone1 { get; set; }

  /// <remarks />
  public string? Phone2 { get; set; }

  /// <remarks />
  public string? Email1 { get; set; }

  /// <remarks />
  public string? Email2 { get; set; }

}
