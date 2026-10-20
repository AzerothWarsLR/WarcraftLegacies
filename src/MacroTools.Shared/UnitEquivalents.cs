namespace MacroTools.Shared;

/// <summary>Pairs one faction's objects with the objects that fill the same role for another faction.</summary>
public static class UnitEquivalents
{
  /// <summary>Use as an override's value to leave an object as it is instead of swapping it.</summary>
  public const int Keep = 0;

  /// <summary>
  /// Pairs each object in <paramref name="from"/> with the object in the same position among <paramref name="to"/>'s
  /// objects of the same first category, or the last of them if there are fewer, then applies <paramref name="overrides"/>.
  /// </summary>
  public static Dictionary<int, int> Pair(IEnumerable<ObjectInfo> from, IEnumerable<ObjectInfo> to,
    IReadOnlyDictionary<int, int>? overrides = null)
  {
    var targetsByCategory = new Dictionary<UnitCategory, List<int>>();
    foreach (var objectInfo in to)
    {
      if (objectInfo.Categories.Count == 0)
      {
        continue;
      }

      var category = objectInfo.Categories[0];
      if (!targetsByCategory.TryGetValue(category, out var targets))
      {
        targets = new List<int>();
        targetsByCategory[category] = targets;
      }

      targets.Add(objectInfo.ObjectTypeId);
    }

    var pairs = new Dictionary<int, int>();
    var positions = new Dictionary<UnitCategory, int>();
    foreach (var objectInfo in from)
    {
      if (objectInfo.Categories.Count == 0)
      {
        continue;
      }

      var category = objectInfo.Categories[0];
      positions.TryGetValue(category, out var position);
      positions[category] = position + 1;
      if (pairs.ContainsKey(objectInfo.ObjectTypeId))
      {
        continue;
      }

      if (!targetsByCategory.TryGetValue(category, out var targets))
      {
        continue;
      }

      var target = targets[Math.Min(position, targets.Count - 1)];
      if (target != objectInfo.ObjectTypeId)
      {
        pairs[objectInfo.ObjectTypeId] = target;
      }
    }

    if (overrides == null)
    {
      return pairs;
    }

    foreach (var (objectTypeId, target) in overrides)
    {
      if (target == Keep)
      {
        pairs.Remove(objectTypeId);
      }
      else
      {
        pairs[objectTypeId] = target;
      }
    }

    return pairs;
  }
}
