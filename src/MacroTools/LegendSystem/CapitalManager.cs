using System;
using System.Collections.Generic;
using static War3Api.Common;

namespace MacroTools.LegendSystem
{
  /// <summary>
  /// Responsible for managing all <see cref="Capital"/>s.
  /// </summary>
  public static class CapitalManager
  {
    private static readonly Dictionary<unit, Capital> ByUnit = new();

    /// <summary>
    /// Registers a <see cref="Capital"/> to the <see cref="CapitalManager"/>.
    /// </summary>
    public static void Register(Capital capital)
    {
      if (capital.Unit == null)
        return;
      if (ByUnit.ContainsKey(capital.Unit))
        throw new Exception($"Tried to register {nameof(Capital)} {capital.Name} but it is already registered.");
      ByUnit.Add(capital.Unit, capital);
    }

    /// <summary>
    /// Returns the <see cref="Legend"/> represented by the <see cref="Legend"/>.
    /// Returns null if there is no match.
    /// </summary>
    public static Capital? GetFromUnit(unit whichUnit)
    {
      return ByUnit.ContainsKey(whichUnit) ? ByUnit[whichUnit] : null;
    }
  }
}