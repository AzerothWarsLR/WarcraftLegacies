using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.MacroTools.FactionSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Legends
{
  public static class LegendIronforge
  {
    public static Legend LegendDagran { get; private set; }
    public static Legend LegendFalstad { get; private set; }
    public static Legend LegendMagni { get; private set; }
    public static Legend LegendGreatforge { get; private set; }
    public static Legend LegendThelsamar { get; private set; }


    public static void Setup()
    {
      LegendDagran = new Legend
      {
        UnitType = FourCC("H03G"),
        StartingXp = 1000
      };

      LegendFalstad = new Legend
      {
        UnitType = FourCC("H028"),
        StartingXp = 1000
      };

      LegendMagni = new Legend
      {
        UnitType = FourCC("H00S")
      };
      LegendMagni.AddUnitDependency(PreplacedUnitSystem.GetUnitByUnitType(FourCC("h001")));
      LegendMagni.DeathMessage = "King Magni Bronzebeard has died.";
      LegendMagni.Essential = true;
      LegendMagni.StartingXp = 1000;

      LegendGreatforge = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h001")),
        DeathMessage = "The Great Forge has been extinguished.",
        IsCapital = true
      };

      LegendThelsamar = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnitByUnitType(FourCC("h05H"))
      };
    }
  }
}