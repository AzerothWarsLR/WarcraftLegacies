using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Mechanics.Druids
{
  public static class CenariusGhost
  {
    private static void Dies(object? sender, Legend legend)
    {
      var cenarius = LegendDruids.legendCenarius;
      if (cenarius == legend && legend.UnitType == LegendDruids.unittypeCenariusAlive)
      {
        cenarius.UnitType = LegendDruids.unittypeCenariusGhost;
        cenarius.PermaDies = false;
        cenarius.ClearUnitDependencies();
        cenarius.Spawn(DruidsSetup.factionDruids.Player, Regions.Cenarius.Center.X, Regions.Cenarius.Center.Y, 270);
      }
    }

    public static void Setup()
    {
      Legend.OnLegendPermaDeath += Dies;
      LegendDruids.legendCenarius.DeathMessage =
        "Cenarius, Demigod of the Night Elves, has fallen. His spirit lives on, a mere echo of his former self.";
    }
  }
}