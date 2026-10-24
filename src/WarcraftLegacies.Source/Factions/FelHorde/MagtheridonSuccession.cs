using MacroTools.Factions;
using MacroTools.Legends;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FelHorde;

/// <summary>Replaces Magtheridon with a weaker hero.</summary>
public static class MagtheridonSuccession
{
  /// <summary>Removes Magtheridon for good and gives <paramref name="felHorde"/> <paramref name="successor"/> instead.</summary>
  /// <paramref name="successor"/> hero where he was.
  public static void Replace(Faction felHorde, LegendaryHero successor)
  {
    var owner = felHorde.Player;
    var magtheridon = AllLegends.FelHorde.Magtheridon;
    var magtheridonUnit = magtheridon.Unit;
    var experience = magtheridonUnit == null ? 0 : magtheridonUnit.Experience;
    var position = owner == null ? null : GetSpawnPosition(magtheridon, owner);

    felHorde.ModObjectLimit(UNIT_NMAG_LORD_OF_OUTLAND_FEL, -felHorde.GetObjectLimit(UNIT_NMAG_LORD_OF_OUTLAND_FEL));
    if (magtheridon.Unit != null)
    {
      magtheridon.Unit = null;
    }

    if (owner == null || position == null)
    {
      return;
    }

    felHorde.ModObjectLimit(successor.UnitType, 1 - felHorde.GetObjectLimit(successor.UnitType));
    LegendaryHeroManager.Register(successor);
    PathBase.SummonLegend(successor, owner, position);
    if (successor.Unit != null && experience > successor.Unit.Experience)
    {
      successor.Unit.SetExperience(experience, false);
    }
  }

  private static Point GetSpawnPosition(LegendaryHero magtheridon, player owner)
  {
    var hellfireCitadel = AllLegends.FelHorde.HellfireCitadel.Unit;
    if (hellfireCitadel != null && hellfireCitadel.Alive)
    {
      return new Point(hellfireCitadel.X, hellfireCitadel.Y - 400);
    }

    if (magtheridon.Unit != null)
    {
      return new Point(magtheridon.Unit.X, magtheridon.Unit.Y);
    }

    var startLocation = GetPlayerStartLocation(owner);
    return new Point(GetStartLocationX(startLocation), GetStartLocationY(startLocation));
  }
}
