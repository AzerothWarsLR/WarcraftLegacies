using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

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
      {
        if (ByUnit.ContainsKey(legendaryHero.Unit))
          throw new Exception($"Tried to register {nameof(LegendaryHero)} {legendaryHero.Name} but it is already registered.");;
        ByUnit.Add(legendaryHero.Unit, legendaryHero);
      }
        
      AllLegendaryHeroes.Add(legendaryHero);
      legendaryHero.UnitChanged += OnLegendUnitChanged;
    }

    /// <summary>
    /// Returns the <see cref="Legend"/> represented by the <see cref="Legend"/>.
    /// Returns null if there is no match.
    /// </summary>
    public static LegendaryHero? GetFromUnit(unit whichUnit) => ByUnit.ContainsKey(whichUnit) ? ByUnit[whichUnit] : null;

    /// <summary>
    /// Returns all registered <see cref="Legend"/>s.
    /// </summary>
    public static ReadOnlyCollection<LegendaryHero> GetAll() => AllLegendaryHeroes.AsReadOnly();

    private static void OnLegendUnitChanged(object? sender, LegendChangeUnitEventArgs args)
    {
      if (args.PreviousUnit != null) 
        ByUnit.Remove(args.PreviousUnit);
      if (args.Legend is LegendaryHero hero && hero.Unit != null) 
        ByUnit.Add(hero.Unit, hero);
    }
  }
}