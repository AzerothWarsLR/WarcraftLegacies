using MacroTools.Factions;
using MacroTools.Legends;
using WarcraftLegacies.Source.Setup.Legends;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.FactionMechanics.Druids;

public static class CenariusGhost
{
  private static void Dies(LegendDiedEventArgs args, Faction druids)
  {
    if (args.Permanent)
    {
      return;
    }

    var cenarius = args.LegendaryHero;

    cenarius.UnitType = LegendDruids.UnittypeCenariusGhost;
    cenarius.PermaDies = false;
    cenarius.ClearUnitDependencies();
    cenarius.StartingXp = 5400;
    cenarius.ForceCreate(druids.Player, new Point(Regions.Cenarius.Center.X, Regions.Cenarius.Center.Y),
      270);
  }

  public static void Setup(LegendaryHero cenarius, Faction druids)
  {
    cenarius.Died += (sender, hero) => Dies(hero, druids);
    cenarius.DeathMessage =
      "Cenarius, Demigod of the Night Elves, has fallen. His spirit lives on, a mere echo of his former self.";
  }
}
