using MacroTools.LegendSystem;

#pragma warning disable CS1591

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendTwilight
  {
    public LegendaryHero Chogall { get; }
    public LegendaryHero Azil { get; }
    public LegendaryHero Ignacious { get; }
    public LegendaryHero Emberscar { get; }

    public LegendTwilight()
    {
      Chogall = new LegendaryHero("Cho'gal")
      {
        UnitType = UNIT_O01P_LEADER_OF_THE_TWILIGHT_S_HAMMER_TWILIGHT_HAMMER,
         StartingXp = 10000,
      };

      Azil = new LegendaryHero("Azil")
      {
        UnitType = UNIT_H08Q_HIGH_PRIESTESS_TWILIGHT_HAMMER,
        StartingXp = 7000,
      };

      Ignacious = new LegendaryHero("Ignacious")
      {
        UnitType = UNIT_O06M_ASCENDANT_COUNCILLOR_OF_FLAME_TWILIGHT,
        StartingXp = 7000,
      };

      Emberscar = new LegendaryHero("Emberscar")
      {
        UnitType = UNIT_O04H_CHAMPION_OF_THE_TWILIGHT_S_HAMMER_TWILIGHT,
        StartingXp = 7000,
      };
    }
    public void RegisterLegends()
    {
      LegendaryHeroManager.Register(Chogall);
      LegendaryHeroManager.Register(Ignacious);
      LegendaryHeroManager.Register(Azil);
      LegendaryHeroManager.Register(Emberscar);
    }
  }
}