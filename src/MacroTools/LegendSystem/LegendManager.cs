using System.Collections.Generic;
using System.Collections.ObjectModel;
using static War3Api.Common;

namespace MacroTools.LegendSystem
{
  /// <summary>
  /// Responsible for managing all <see cref="LegendaryHero"/>s.
  /// </summary>
  public static class LegendaryHeroManager
  {
    private static readonly Dictionary<unit, LegendaryHero> ByUnit = new();
    private static readonly List<LegendaryHero> AllLegendaryHeroes = new();

    /// <summary>
    /// Registers a <see cref="LegendaryHero"/> to the <see cref="LegendaryHeroManager"/>.
    /// </summary>
    public static void Register(LegendaryHero legendaryHero)
    {
      if (legendaryHero.Unit != null)
        ByUnit.Add(legendaryHero.Unit, legendaryHero);
      AllLegendaryHeroes.Add(legendaryHero);
      legendaryHero.UnitChanged += OnLegendUnitChanged;
    }

    /// <summary>
    /// Returns the <see cref="Legend"/> represented by the <see cref="Legend"/>.
    /// Returns null if there is no match.
    /// </summary>
    public static Legend? GetFromUnit(unit whichUnit)
    {
      return ByUnit.ContainsKey(whichUnit) ? ByUnit[whichUnit] : null;
    }
    
    /// <summary>
    /// Returns all registered <see cref="Legend"/>s.
    /// </summary>
    public static ReadOnlyCollection<LegendaryHero> GetAllLegends()
    {
      return AllLegendaryHeroes.AsReadOnly();
    }
    
    private static void OnLegendUnitChanged(object? sender, LegendChangeUnitEventArgs args)
    {
      if (args.PreviousUnit != null) 
        ByUnit.Remove(args.PreviousUnit);
      AllLegendaryHeroes.Add(args.Legend as LegendaryHero);
    }
  }
}