using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.Factions;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendBlackEmpire
  {
    public static Legend legendYogg;
    public static Legend legendVolazj;
    public static Legend legendZakajz;
    
    public static void Setup()
    {
      Legend.Register(legendYogg = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("U02C")),
        PermaDies = true,
        DeathMessage =
          "Yogg-Saron, the Fiend of a Thousand Faces, has been vanquished. The countless souls consigned to his maw have finally been avenged."
      });
      
      Legend.Register(legendVolazj = new Legend
      {
        UnitType = FourCC("E01D")
      });

      Legend.Register(legendZakajz = new Legend
      {
        UnitType = FourCC("U00P"),
        StartingXp = 8800
      });
    }
  }
}