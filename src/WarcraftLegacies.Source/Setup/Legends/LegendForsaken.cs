using MacroTools;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendForsaken
  {
    public static Legend SylvanasUndead { get; private set; }
    public static Legend Scholomance { get; private set; }
    public static Legend Varimathras { get; private set; }
    public static Legend Nathanos { get; private set; }

    public static void Setup()
    {
      SylvanasUndead = new Legend
      {
        UnitType = Constants.UNIT_USYL_DARK_RANGER_FORSAKEN,
        StartingXp = 15400
      };
      Legend.Register(SylvanasUndead);

      Nathanos = new Legend
      {
        UnitType = Constants.UNIT_H049_RANGER_LORD_FORSAKEN,
        StartingXp = 4000
      };
      Legend.Register(Nathanos);

      Varimathras = new Legend
      {
        UnitType = Constants.UNIT_UVAR_ARCH_DREADLORD_FORSAKEN,
        PlayerColor = PLAYER_COLOR_RED
      };
      Legend.Register(Varimathras);

      Scholomance = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(Constants.UNIT_U012_SCHOLOMANCE),
        DeathMessage = "Scholomance, the center of the ScourgeFourCC(s operations in Lordaeron, has been destroyed."
      };
      Legend.Register(Scholomance);
    }
  }
}