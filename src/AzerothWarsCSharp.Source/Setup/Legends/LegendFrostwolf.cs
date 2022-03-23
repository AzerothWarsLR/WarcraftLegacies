using AzerothWarsCSharp.MacroTools;
using Legend = AzerothWarsCSharp.MacroTools.FactionSystem.Legend;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendFrostwolf
  {
    public static Legend? legendCairne;
    public static Legend? legendThrall;
    public static Legend? legendRexxar;

    public static Legend? legendThunderbluff;
    public static Legend? legendDarkspearhold;
    public static Legend? legendOrgrimmar;
    
    public static void Setup( ){
      legendCairne = new Legend
      {
        UnitType = FourCC(""Ocbh""),
        DeathMessage = "CairneFourCC(s spirit has passed on from this world. The Tauren have already begun to revere their fallen ancestor.",
        StartingXp = 1000
      };

      legendThrall = new Legend
      {
        UnitType = FourCC(""Othr""),
        Essential = true
      };

      legendThunderbluff = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC(""o00J"")),
        DeathMessage = "The mesas of Thunderbluff have been swept clean of the Tauren. The Bloodhoof are without a home.",
        IsCapital = true
      };

      legendDarkspearhold = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC(""o02D"")),
        IsCapital = true
      };

      legendRexxar = new Legend
      {
        UnitType = FourCC(""Orex""),
        StartingXp = 1800
      };

      legendOrgrimmar = new Legend
      {
        DeathMessage = "Orgrimmar has been demolished. With it dies the hopes && dreams of a wartorn race seeking refuge in a new world."
      };
    }

  }
}
