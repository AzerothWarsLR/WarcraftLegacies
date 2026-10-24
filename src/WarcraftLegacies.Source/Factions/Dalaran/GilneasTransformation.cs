using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Shared;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Gilneas;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Dalaran;

/// <summary>Turns Dalaran into Gilneas, keeping what it holds in Gilneas and leaving the rest of its land to its allies.</summary>
public sealed class GilneasTransformation
{
  private static Dictionary<int, int> GilneasEquivalents => UnitEquivalents.Pair(
    DalaranObjectInfo.GetAllObjectLimits(), GilneasObjectInfo.GetAllObjectLimits(), new Dictionary<int, int>
    {
      { UNIT_H00I_WINDMILL_LORDAERON_OTHER, UNIT_H02F_HOUSEHOLD_GILNEAS_FARM }
    });

  private static Dictionary<int, int> ArmyEquivalents => UnitEquivalents.Pair(
    DalaranObjectInfo.GetAllObjectLimits(), GilneasObjectInfo.GetAllObjectLimits(), new Dictionary<int, int>
    {
      { UNIT_N007_KIRIN_TOR_DALARAN_ELITE, UNIT_O01V_GREYGUARD_GILNEAS },
      { UNIT_N096_EARTH_GOLEM_DALARAN, UNIT_N06L_ARMORED_WOLF_GILNEAS }
    });

  /// <summary>Turns <paramref name="dalaran"/>'s player into Gilneas.</summary>
  public void Execute(Faction dalaran)
  {
    var whichPlayer = dalaran.Player;
    if (whichPlayer == null)
    {
      return;
    }

    DalaranHomeland.ClaimHeldLands(dalaran);
    FactionTransition.AssignNewFaction(dalaran, new GilneasFaction(playercolor.Coal) { FormedMidGame = true });
    PathBase.RemoveHero(AllLegends.Dalaran.Antonidas);
    PathBase.RemoveHero(AllLegends.Dalaran.Jaina);
    PathBase.RemoveHero(AllLegends.Dalaran.Aegwynn);
    PathBase.RemoveHero(AllLegends.Dalaran.Medivh);

    var heir = DalaranHomeland.GetHeir(out var heirEquivalents);
    PathBase.HandOverStructures(whichPlayer, heir, heirEquivalents, Regions.Gilneas);
    DalaranHomeland.MakeBookKeeper(heir);
    PathBase.ConvertStructures(whichPlayer, GilneasEquivalents, Regions.Gilneas);

    var castle = AllLegends.Gilneas.GilneasCastle.Unit;
    PathBase.RelocateArmy(whichPlayer, ArmyEquivalents, castle.X, castle.Y - 700);
    PathBase.SummonLegend(AllLegends.Gilneas.Genn, whichPlayer, new Point(castle.X, castle.Y - 400));
  }
}
