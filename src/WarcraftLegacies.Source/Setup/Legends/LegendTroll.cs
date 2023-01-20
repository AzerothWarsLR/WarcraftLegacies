using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendTroll : IRegistersLegends
  {
    public LegendaryHero LEGEND_PRIEST { get; private set; }
    public LegendaryHero LEGEND_RASTAKHAN { get; private set; }
    public LegendaryHero LEGEND_HAKKAR { get; private set; }

    public static void Setup()
    {
      LEGEND_PRIEST = new LegendaryHero("Zul")
      {
        UnitType = FourCC("O01J")
      };
      LegendaryHeroManager.Register(LEGEND_PRIEST);

      LEGEND_HAKKAR = new LegendaryHero("Hakkar the Soulflayer")
      {
        UnitType = FourCC("U023")
      };
      LegendaryHeroManager.Register(LEGEND_HAKKAR);

      LEGEND_RASTAKHAN = new LegendaryHero("Rastakhan")
      {
        UnitType = FourCC("O026"),
        StartingXp = 2800
      };
      LegendaryHeroManager.Register(LEGEND_RASTAKHAN);
    }
  }
}