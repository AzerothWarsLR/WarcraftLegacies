using AzerothWarsCSharp.MacroTools;
using Legend = AzerothWarsCSharp.MacroTools.FactionSystem.Legend;

using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Setup.Legends
{
  public static class LegendFrostwolf
  {
    public static Legend? LegendCairne { get; private set; }
    public static Legend? LegendThrall { get; private set; }
    public static Legend? LegendRexxar { get; private set; }

    public static Legend? LegendThunderbluff { get; private set; }
    public static Legend? LegendDarkspearhold { get; private set; }
    public static Legend? LegendOrgrimmar { get; private set; }
    
    public static void Setup( ){
      LegendCairne = new Legend
      {
        UnitType = FourCC("Ocbh"),
        DeathMessage = "CairneFourCC(s spirit has passed on from this world. The Tauren have already begun to revere their fallen ancestor.",
        StartingXp = 1000
      };

      LegendThrall = new Legend
      {
        UnitType = FourCC("Othr"),
        Essential = true
      };

      LegendThunderbluff = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o00J")),
        DeathMessage = "The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home.",
        IsCapital = true
      };

      LegendDarkspearhold = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("o02D")),
        IsCapital = true
      };

      LegendRexxar = new Legend
      {
        UnitType = FourCC("Orex"),
        StartingXp = 1800
      };

      LegendOrgrimmar = new Legend
      {
        DeathMessage = "Orgrimmar has been demolished. With it dies the hopes && dreams of a wartorn race seeking refuge in a new world."
      };
    }

  }
}
