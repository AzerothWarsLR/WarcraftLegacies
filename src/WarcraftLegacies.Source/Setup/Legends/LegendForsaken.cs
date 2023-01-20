using MacroTools.LegendSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public sealed class LegendForsaken
  {
    public LegendaryHero SylvanasUndead { get; private set; }
    public LegendaryHero Varimathras { get; private set; }
    public LegendaryHero Nathanos { get; private set; }

    public static void Setup()
    {
      SylvanasUndead = new LegendaryHero("Sylvanas")
      {
        UnitType = Constants.UNIT_USYL_DARK_RANGER_FORSAKEN,
        StartingXp = 15400
      };
      LegendaryHeroManager.Register(SylvanasUndead);

      Nathanos = new LegendaryHero("Nathanos Blightcaller")
      {
        UnitType = Constants.UNIT_H049_RANGER_LORD_FORSAKEN,
        StartingXp = 4000
      };
      LegendaryHeroManager.Register(Nathanos);

      Varimathras = new LegendaryHero("Varimathras")
      {
        UnitType = Constants.UNIT_UVAR_ARCH_DREADLORD_FORSAKEN,
        PlayerColor = PLAYER_COLOR_RED
      };
      LegendaryHeroManager.Register(Varimathras);
    }
  }
}