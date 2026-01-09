namespace MacroTools.Shared;

/// <summary>
/// Provides information about a particular object, i.e. a unit type, ability type, etc.
/// </summary>
public sealed class ObjectInfo
{
  public int ObjectTypeId { get; }

  public int Limit { get; }

  /// <summary>
  /// If set, this will be used to determine the unit's limit tooltip rather than <see cref="Limit"/>.
  /// <remarks>You might use this when a unit icon should only be available after completing a research. The unit's limit
  /// will thus be 0 at game start, but any time the player could possibly see it, it will be something else.</remarks>
  /// </summary>
  public int? LimitTooltipOverride { get; init; }

  /// <summary>
  /// The arbitrary categories the object is assigned to, if any.
  /// </summary>
  public List<UnitCategory> Categories { get; }

  /// <summary>
  /// If set, indicates to the player how the object's limit can be changed in-game.
  /// </summary>
  public string? LimitIncreaseHint { get; }

  public ObjectInfo(int objectTypeId, int limit, List<UnitCategory> categories, string? limitIncreaseHint = null)
  {
    Categories = categories;
    ObjectTypeId = objectTypeId;
    Limit = limit;
    LimitIncreaseHint = limitIncreaseHint;
  }

  public ObjectInfo(int objectTypeId, int limit, UnitCategory category, string? limitIncreaseHint = null)
  {
    Categories = new List<UnitCategory> { category };
    ObjectTypeId = objectTypeId;
    Limit = limit;
    LimitIncreaseHint = limitIncreaseHint;
  }

  public ObjectInfo(int objectTypeId, int limit, string? limitIncreaseHint = null)
  {
    Categories = new List<UnitCategory>();
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
