using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendTroll
  {
    public static LegendaryHero LEGEND_PRIEST { get; private set; }
    public static LegendaryHero LEGEND_RASTAKHAN { get; private set; }
    public static LegendaryHero LEGEND_HAKKAR { get; private set; }

    public static void Setup()
    {
      LEGEND_PRIEST = new LegendaryHero
      {
        UnitType = FourCC("O01J"),
      };
      Legend.Register(LEGEND_PRIEST);

      LEGEND_HAKKAR = new LegendaryHero
      {
        UnitType = FourCC("U023")
      };
      Legend.Register(LEGEND_HAKKAR);

      LEGEND_RASTAKHAN = new LegendaryHero
      {
        UnitType = FourCC("O026"),
        StartingXp = 2800
      };
      Legend.Register(LEGEND_RASTAKHAN);
    }
  }
}