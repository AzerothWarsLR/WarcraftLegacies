using System.Collections.Generic;

namespace WarcraftLegacies.Source.UniqueUnitNames;

public class NamePool
{
  private readonly List<string> _allNames;
  private readonly HashSet<string> _used = new();

  public NamePool(IEnumerable<string> names)
  {
    _allNames = new List<string>(names);
  }

  public bool TryAssign(unit unit)
  {
    if (unit == null || _allNames.Count == 0)
    {
      return false;
    }

    var available = new List<string>();
    foreach (var name in _allNames)
    {
      if (!_used.Contains(name))
      {
        available.Add(name);
      }
    }

    if (available.Count == 0)
    {
      unit.Name = "";
      return false;
    }

    int index = GetRandomInt(0, available.Count - 1);
    string chosen = available[index];
    unit.Name = chosen;
    _used.Add(chosen);
    return true;
  }

  public bool TryRelease(unit unit)
  {
    if (unit == null)
    {
      return false;
    }

    return _used.Remove(unit.Name);
  }
}
