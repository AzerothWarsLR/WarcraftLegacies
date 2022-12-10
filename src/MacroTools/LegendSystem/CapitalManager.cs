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
      if (capital.Unit != null)
        ByUnit.Add(capital.Unit, capital);
      AllCapitals.Add(capital);
      capital.UnitChanged += OnLegendUnitChanged;
    }

    /// <summary>
    /// Returns the <see cref="Legend"/> represented by the <see cref="Legend"/>.
    /// Returns null if there is no match.
    /// </summary>
    public static Capital? GetFromUnit(unit whichUnit)
    {
      return ByUnit.ContainsKey(whichUnit) ? ByUnit[whichUnit] : null;
    }
    
    /// <summary>
    /// Returns all registered <see cref="Legend"/>s.
    /// </summary>
    public static ReadOnlyCollection<Capital> GetAllCapitals()
    {
      return AllCapitals.AsReadOnly();
    }
    
    private static void OnLegendUnitChanged(object? sender, LegendChangeUnitEventArgs args)
    {
      if (args.PreviousUnit != null) 
        ByUnit.Remove(args.PreviousUnit);
      AllCapitals.Add(args.Legend as Capital);
    }
  }
}