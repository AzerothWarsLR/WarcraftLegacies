using AzerothWarsCSharp.Source.Main.Libraries.MacroTools;
using AzerothWarsCSharp.Source.RoC.Legends;
using AzerothWarsCSharp.Source.RoC.Setup.FactionSetup;

namespace AzerothWarsCSharp.Source.RoC.Mechanics.Druids
{
  public static class CenariusGhost
  {
    private static void Dies(object? sender, Legend legend)
    {
      var cenarius = LegendDruids.LEGEND_CENARIUS;
      if (cenarius == legend && legend.UnitType == LegendDruids.UNITTYPE_CENARIUS_ALIVE)
      {
        cenarius.UnitType = LegendDruids.UNITTYPE_CENARIUS_GHOST;
        cenarius.PermaDies = false;
        cenarius.ClearUnitDependencies();
        cenarius.Spawn(DruidsSetup.FACTION_DRUIDS.Player, Regions.Cenarius.Center.X, Regions.Cenarius.Center.Y, 270);
      }
    }

    public static void Setup()
    {
      Legend.OnLegendPermaDeath += Dies;
      LegendDruids.LEGEND_CENARIUS.DeathMessage =
        "Cenarius, Demigod of the Night Elves, has fallen. His spirit lives on, a mere echo of his former self.";
    }
  }
}