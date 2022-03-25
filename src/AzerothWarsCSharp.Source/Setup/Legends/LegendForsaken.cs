using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendForsaken
  {
    public static Legend LEGEND_SYLVANASV { get; private set; }
    public static Legend LEGEND_SCHOLOMANCE { get; private set; }
    public static Legend LEGEND_VARIMATHRAS { get; private set; }
    public static Legend LEGEND_NATHANOS { get; private set; }


    public static void Setup()
    {
      LEGEND_SYLVANASV = new Legend();
      LEGEND_SYLVANASV.UnitType = FourCC("Usyl");
      LEGEND_SYLVANASV.StartingXp = 15400;

      LEGEND_NATHANOS = new Legend();
      LEGEND_NATHANOS.UnitType = FourCC("H049");
      LEGEND_NATHANOS.StartingXp = 4000;

      LEGEND_VARIMATHRAS = new Legend();
      LEGEND_VARIMATHRAS.UnitType = FourCC("Uvar");
      LEGEND_VARIMATHRAS.PlayerColor = PLAYER_COLOR_RED;

      LEGEND_SCHOLOMANCE = new Legend();
      LEGEND_SCHOLOMANCE.Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("u012"));
      LEGEND_SCHOLOMANCE.DeathMessage =
        "Scholomance, the center of the ScourgeFourCC(s operations in Lordaeron, has been destroyed.";
    }
  }
}