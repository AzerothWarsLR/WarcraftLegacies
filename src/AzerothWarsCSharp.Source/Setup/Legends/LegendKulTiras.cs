using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendKultiras
  {
    public static Legend LegendAdmiral { get; private set; }
    public static Legend LegendLucille { get; private set; }
    public static Legend LegendKatherine { get; private set; }
    public static Legend LegendBoralus { get; private set; }


    public static void Setup()
    {
      LegendAdmiral = new Legend
      {
        UnitType = FourCC("Hapm"),
        Essential = true
      };

      LegendLucille = new Legend
      {
        UnitType = FourCC("E016"),
        StartingXp = 2800
      };

      LegendKatherine = new Legend
      {
        UnitType = FourCC("H05L"),
        StartingXp = 1200
      };

      LegendBoralus = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h046")),
        DeathMessage = "Boralus Keep has fallen"
      };
    }
  }
}