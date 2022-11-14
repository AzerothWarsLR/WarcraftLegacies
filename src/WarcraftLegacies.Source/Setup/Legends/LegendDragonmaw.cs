using MacroTools;
using MacroTools.FactionSystem;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Setup.Legends
{
  public static class LegendDragonmaw
  {
    public static Legend LegendDragonmawPort { get; private set; }


    public static void Setup()
    {
      LegendDragonmawPort = new Legend
      {
        Unit = PreplacedUnitSystem.GetUnit(FourCC("o06E")),
        DeathMessage =
          "The Dragonmaw Port has fallen, the Twilight Highlands are finally liberated"
      };
      Legend.Register(LegendDragonmawPort);

    }
  }
}