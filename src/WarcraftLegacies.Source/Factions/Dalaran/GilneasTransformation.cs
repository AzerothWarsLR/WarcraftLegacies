using System.Collections.Generic;
using MacroTools.Factions;
using MacroTools.Shared;
using WarcraftLegacies.Shared.FactionObjectLimits;
using WarcraftLegacies.Source.Factions.Gilneas;
using WarcraftLegacies.Source.Factions.Gilneas.Powers;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Dalaran;

/// <summary>Turns Dalaran into Gilneas, keeping what it holds in Gilneas and leaving the rest of its land to its allies.</summary>
public sealed class GilneasTransformation
{
  private static readonly Point[] _armySpots =
  {
    new(6571, 2450),
    new(6151, 1516),
    new(8203, 702)
  };

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
  public void Execute(Faction dalaran, bool standsAlone)
  {
    var whichPlayer = dalaran.Player;
    if (whichPlayer == null)
    {
      return;
    }

    DalaranHomeland.ClaimHeldLands(dalaran);
    var gilneas = new GilneasFaction(playercolor.Coal) { FormedMidGame = true, StandsAlone = standsAlone };
    FactionTransition.AssignNewFaction(dalaran, gilneas);
    gilneas.AddPower(new CurseOfTheWorgen());
    PathBase.RemoveHero(AllLegends.Dalaran.Antonidas);
    PathBase.RemoveHero(AllLegends.Dalaran.Jaina);
    PathBase.RemoveHero(AllLegends.Dalaran.Aegwynn);
    PathBase.RemoveHero(AllLegends.Dalaran.Medivh);

    var heir = DalaranHomeland.GetHeir(out var heirEquivalents);
    PathBase.HandOverStructures(whichPlayer, heir, heirEquivalents, Regions.Gilneas);
    DalaranHomeland.MakeBookKeeper(heir);
    PathBase.ConvertStructures(whichPlayer, GilneasEquivalents, Regions.Gilneas);
    ClaimShadowfangKeep(whichPlayer, heir);

    PathBase.RelocateArmy(whichPlayer, ArmyEquivalents, _armySpots);
    PathBase.SummonLegend(AllLegends.Gilneas.Genn, whichPlayer, new Point(4339, -851));
    PathBase.SummonLegend(AllLegends.Gilneas.Tess, whichPlayer, new Point(6537, 1999));
    GreymaneFortification.Activate();
  }

  private static void ClaimShadowfangKeep(player gilneas, player heir)
  {
    var shadowfangKeep = AllLegends.Dalaran.Shadowfang.Unit;
    if (shadowfangKeep != null && shadowfangKeep.Alive && shadowfangKeep.Owner == heir)
    {
      shadowfangKeep.SetOwner(gilneas);
    }
  }
}
