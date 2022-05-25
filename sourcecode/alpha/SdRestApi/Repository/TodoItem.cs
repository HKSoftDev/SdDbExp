// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="TodoItem.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public class TodoItem
{
  /// <remarks/>
  public long Id { get; set; }

  /// <remarks/>
  public string? Name { get; set; }

  /// <remarks/>
  public bool IsComplete { get; set; }

}
