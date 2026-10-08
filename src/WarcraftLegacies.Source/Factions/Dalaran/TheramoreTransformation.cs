using MacroTools.Extensions;
using MacroTools.Factions;
using WarcraftLegacies.Source.Factions.Theramore;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Dalaran;

/// <summary>
/// Removes everything Dalaran owns and restarts the player as Theramore, with a new base in Dustwallow Marsh led by
/// Jaina.
/// </summary>
public sealed class TheramoreTransformation
{
  /// <summary>Turns <paramref name="dalaran"/>'s player into Theramore.</summary>
  public void Execute(Faction dalaran)
  {
    var whichPlayer = dalaran.Player;
    if (whichPlayer == null)
    {
      return;
    }

    whichPlayer.RemoveAllUnits();
    FactionTransition.AssignNewFaction(dalaran, new TheramoreFaction());

    var center = Regions.Theramore.Center;
    PathBase.ClaimArea(Regions.Theramore, whichPlayer);
    CreateBase(whichPlayer, center);
    PathBase.SummonLegend(AllLegends.Dalaran.Jaina, whichPlayer, new Point(center.X, center.Y + 300));
  }

  private static void CreateBase(player whichPlayer, Point center)
  {
    PathBase.CreateStructure(whichPlayer, UNIT_H065_REFUGE_DALARAN_T1, center.X, center.Y);
    PathBase.CreateStructure(whichPlayer, UNIT_H069_MILITARY_QUARTER_DALARAN_BARRACKS, center.X - 500, center.Y + 300);
    PathBase.CreateStructure(whichPlayer, UNIT_H044_ALTAR_OF_KNOWLEDGE_DALARAN_ALTAR, center.X + 500, center.Y + 300);
    PathBase.CreateStructure(whichPlayer, UNIT_H02N_LUMBER_MILL_DALARAN_RESEARCH, center.X, center.Y - 550);
    PathBase.CreateStructure(whichPlayer, UNIT_H063_ARCANE_WELL_DALARAN_FARM, center.X - 550, center.Y - 450);
    PathBase.CreateStructure(whichPlayer, UNIT_H063_ARCANE_WELL_DALARAN_FARM, center.X + 550, center.Y - 450);
    PathBase.CreateUnits(whichPlayer, UNIT_H022_FARMER_DALARAN_WORKER, 5, center.X, center.Y - 250);
    PathBase.CreateUnits(whichPlayer, UNIT_H032_BATTLEMAGE_DALARAN, 4, center.X - 250, center.Y + 600);
    PathBase.CreateUnits(whichPlayer, UNIT_N0AK_INITIATE_MAGE_DALARAN, 4, center.X + 250, center.Y + 600);
  }
}
