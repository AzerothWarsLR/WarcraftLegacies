using MacroTools.Legends;

namespace WarcraftLegacies.Source.Factions.TaurenTribes;

/// <summary>
/// Responsible for setting up all Tauren Tribes <see cref="Legend"/>s.
/// </summary>
public sealed class TaurenTribesLegends
{
  public LegendaryHero CairneBloodhoof { get; }
  public LegendaryHero Rexxar { get; }

  public TaurenTribesLegends()
  {
    CairneBloodhoof = new LegendaryHero("Cairne Bloodhoof")
    {
      UnitType = UNIT_OCBH_CHIEFTAIN_OF_THE_BLOODHOOF_TAUREN_TRIBES
    };

    Rexxar = new LegendaryHero("Rexxar")
    {
      UnitType = UNIT_OREX_BEASTMASTER_TAUREN_TRIBES
    };
  }

  public void RegisterLegends()
  {
    LegendaryHeroManager.Register(CairneBloodhoof);
    LegendaryHeroManager.Register(Rexxar);
  }
}
