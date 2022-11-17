using MacroTools;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendDragonmaw
  {
    public static Legend? DragonmawPort { get; private set; }
    public static Legend? LegendZaela { get; private set; }
    public static Legend? LegendNekrosh { get; private set; }

    public static void Setup()
    {
      DragonmawPort = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o06E")),
        DeathMessage =
          "The Dragonmaw Port has fallen, the Twilight Highlands are finally liberated"
      };
      Legend.Register(DragonmawPort);

      Legend.Register(LegendZaela = new Legend
      {
        UnitType = FourCC("O05S")
      });

      Legend.Register(LegendNekrosh = new Legend
      {
        UnitType = FourCC("O01Q")
      });

    }
  }
}