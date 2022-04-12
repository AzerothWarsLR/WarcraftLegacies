using AzerothWarsCSharp.MacroTools.FactionSystem;
using AzerothWarsCSharp.Source.Legends;
using AzerothWarsCSharp.Source.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.Mechanics.Druids
{
  public static class CenariusGhost
  {
    private static void Dies(object? sender, Legend legend)
    {
      var cenarius = LegendDruids.LegendCenarius;
      if (cenarius == legend && legend.UnitType == LegendDruids.UnittypeCenariusAlive)
      {
        cenarius.UnitType = LegendDruids.UnittypeCenariusGhost;
        cenarius.PermaDies = false;
        cenarius.ClearUnitDependencies();
        cenarius.Spawn(DruidsSetup.factionDruids.Player, Regions.Cenarius.Center.X, Regions.Cenarius.Center.Y, 270);
      }
    }

    public static void Setup()
    {
      Legend.OnLegendPermaDeath += Dies;
      LegendDruids.LegendCenarius.DeathMessage =
        "Cenarius, Demigod of the Night Elves, has fallen. His spirit lives on, a mere echo of his former self.";
    }
  }
}