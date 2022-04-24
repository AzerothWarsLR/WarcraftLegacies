using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
{
  public static class LegendTwilight
  {
    public static Legend LEGEND_DEATHWING { get; private set; }
    public static Legend LEGEND_FELUDIUS { get; private set; }
    public static Legend LEGEND_IGNACIOUS { get; private set; }
    public static Legend LEGEND_AZIL { get; private set; }
    public static Legend LegendTwilightcitadel { get; private set; }


    public static void Setup()
    {
      LegendTwilightcitadel = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("h05U")),
        DeathMessage =
          "The Twilight Citadel has been toppled. Already the land has begun to heal, but it may be decades before the permeating Old God stink fully dissipates from the Twilight Highlands."
      };
      Legend.Register(LegendTwilightcitadel);

      LEGEND_DEATHWING = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("u01Y")),
        PermaDies = true,
        DeathMessage = "Deathwing, the Black Scourge, is no more. The Destroyer has finally been defeated."
      };
      Legend.Register(LEGEND_DEATHWING);

      LEGEND_AZIL = new Legend
      {
        UnitType = FourCC("H08Q"),
        StartingXp = 1800
      };
      LEGEND_AZIL.AddUnitDependency(LegendTwilightcitadel.Unit);
      Legend.Register(LEGEND_AZIL);

      LEGEND_FELUDIUS = new Legend
      {
        UnitType = FourCC("U01S"),
        StartingXp = 2800
      };
      Legend.Register(LEGEND_FELUDIUS);

      LEGEND_IGNACIOUS = new Legend
      {
        UnitType = FourCC("O04H"),
        StartingXp = 2800
      };
      Legend.Register(LEGEND_IGNACIOUS);
    }
  }
}