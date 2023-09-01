using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using static War3Api.Common;

namespace MacroTools.LegendSystem
{
  /// <summary>
  /// Responsible for managing all <see cref="Capital"/>s.
  /// </summary>
  public static class CapitalManager
  {
    private static readonly Dictionary<unit, Capital> ByUnit = new();
    private static readonly List<Capital> AllCapitals = new();

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
      AllCapitals.Add(capital);
    }

    /// <summary>
    /// Returns the <see cref="Legend"/> represented by the <see cref="Legend"/>.
    /// Returns null if there is no match.
    /// </summary>
    public static Capital? GetFromUnit(unit whichUnit)
    {
      return ByUnit.TryGetValue(whichUnit, out var value) ? value : null;
    }
    
    /// <summary>
    ///   Whether or not the given unit is a <see cref="Capital" />.
    /// </summary>
    public static bool UnitIsCapital(unit unit) => ByUnit.ContainsKey(unit);

    /// <summary>
    ///   Whether or not the given unit is a <see cref="Protector" />.
    /// </summary>
    public static bool UnitIsProtector(unit unit)
    {
      foreach (var capital in AllCapitals)
      {
        if (capital.ProtectorsByUnit.ContainsKey(unit))
          return true;
      }
      return false;
    }
    
    /// <summary>
    ///   Whether or not the given unit is a <see cref="Protector" /> of a given <see cref="Capital" />.
    /// </summary>
    public static bool UnitIsCapitalProtector(unit protector, unit capital)
    {
      return ByUnit[capital].ProtectorsByUnit.ContainsKey(protector);
    }
    
    /// <summary>
    /// Returns all registered <see cref="Capital"/>s.
    /// </summary>
    public static ReadOnlyCollection<Capital> GetAll() => AllCapitals.AsReadOnly();
  }
}