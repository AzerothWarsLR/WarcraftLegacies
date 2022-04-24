using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
{
  public static class LegendForsaken
  {
    public static Legend LegendSylvanasv { get; private set; }
    public static Legend LegendScholomance { get; private set; }
    public static Legend LegendVarimathras { get; private set; }
    public static Legend LegendNathanos { get; private set; }

    public static void Setup()
    {
      LegendSylvanasv = new Legend
      {
        UnitType = FourCC("Usyl"),
        StartingXp = 15400
      };
      Legend.Register(LegendSylvanasv);

      LegendNathanos = new Legend
      {
        UnitType = FourCC("H049"),
        StartingXp = 4000
      };
      Legend.Register(LegendNathanos);

      LegendVarimathras = new Legend
      {
        UnitType = FourCC("Uvar"),
        PlayerColor = PLAYER_COLOR_RED
      };
      Legend.Register(LegendVarimathras);

      LegendScholomance = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("u012")),
        DeathMessage = "Scholomance, the center of the ScourgeFourCC(s operations in Lordaeron, has been destroyed."
      };
      Legend.Register(LegendScholomance);
    }
  }
}