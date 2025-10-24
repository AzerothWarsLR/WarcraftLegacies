namespace MacroTools.Shared;

/// <summary>
/// Provides information about a particular object, i.e. a unit type, ability type, etc.
/// </summary>
public sealed class ObjectInfo
{
  public int ObjectTypeId { get; }

  public int Limit { get; }

  /// <summary>
  /// The arbitrary category the object is assigned to, if any.
  /// </summary>
  public UnitCategory Category { get; }

  /// <summary>
  /// If set, indicates to the player how the object's limit can be changed in-game.
  /// </summary>
  public string? LimitIncreaseHint { get; }

  public ObjectInfo(int objectTypeId, int limit, UnitCategory category = UnitCategory.None, string? limitIncreaseHint = null)
  {
    Category = category;
    ObjectTypeId = objectTypeId;
    Limit = limit;
    LimitIncreaseHint = limitIncreaseHint;
  }

  public void Deconstruct(out int objectTypeId, out ObjectInfo info)
  {
    objectTypeId = ObjectTypeId;
    info = this;
  }
}
