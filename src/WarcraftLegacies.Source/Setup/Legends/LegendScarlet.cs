using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendScarlet
  {
    public static LegendaryHero LegendBrigitte { get; private set; }
    public static LegendaryHero LEGEND_TIRION { get; private set; }

    public static void Setup()
    {
      LegendBrigitte = new LegendaryHero("?")
      {
        UnitType = FourCC("H00Y"),
        StartingXp = 7000
      };
      LegendaryHeroManager.Register(LegendBrigitte);

      LEGEND_TIRION = new LegendaryHero("?")
      {
        UnitType = FourCC("H09Z"),
        StartingXp = 7000
      };
      LegendaryHeroManager.Register(LEGEND_TIRION);
    }
  }
}