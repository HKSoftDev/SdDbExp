// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Update.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Repository;

/// <remarks/>
public class TaskItem
{
  /// <remarks/>
  [BsonId][BsonRepresentation(BsonType.ObjectId)]
  public string Id { get; set; } = string.Empty;

  /// <remarks/>
  public string Email { get; set; } = string.Empty;

  /// <remarks/>
  public string Name { get; set; } = string.Empty;


  /// <remarks/>
  public DateTimeOffset DueDate { get; set; }

  /// <remarks/>
  public int Priority { get; set; }

  /// <remarks/>
  public bool IsCompleated { get; set; }

}