// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Update.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
namespace Repository;

/// <remarks/>
public class MongoDatabaseSettings : IMongoDatabaseSettings
{
  /// <remarks/>
  public string CollectionName { get; set; } = string.Empty;

  /// <remarks/>
  public string ConnectionString { get; set; } = string.Empty;

  /// <remarks/>
  public string DatabaseName { get; set; } = string.Empty;

}

public interface IMongoDatabaseSettings
{
  /// <remarks/>
  string CollectionName { get; set; }

  /// <remarks/>
  string ConnectionString { get; set; }

  /// <remarks/>
  string DatabaseName { get; set; }

}
