using System;
using System.Collections.Generic;

namespace MacroTools.UnitNameTools;

public class NamePool
{
  private readonly List<string> _allNames;
  private readonly HashSet<string> _used = new();
  private static readonly Random _random = new();

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

    var index = _random.Next(0, available.Count);
    var chosen = available[index];
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
