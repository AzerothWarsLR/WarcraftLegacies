using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.Theramore;
using WarcraftLegacies.Source.Factions.Theramore.Quests;
using WarcraftLegacies.Source.Shared;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Dalaran;

/// <summary>Turns Dalaran into Theramore, keeping only what it holds in Theramore and leaving its other buildings to its allies.</summary>
public sealed class TheramoreTransformation
{
  private static readonly Dictionary<int, int> _theramoreEquivalents = new()
  {
    { UNIT_H032_BATTLEMAGE_DALARAN, UNIT_H041_MARINE_KULTIRAS },
    { UNIT_NHYM_HYDROMANCER_DALARAN, UNIT_H0D0_TIDESAGE_THERAMORE },
    { UNIT_H02D_GEOMANCER_DALARAN, UNIT_H0D6_ARCANIST_THERAMORE },
    { UNIT_H01I_ARCANIST_DALARAN, UNIT_H0D6_ARCANIST_THERAMORE },
    { UNIT_N0AK_INITIATE_MAGE_DALARAN, UNIT_H0D7_NAVY_SNIPER_THERAMORE },
    { UNIT_N007_KIRIN_TOR_DALARAN_ELITE, UNIT_H0D4_STORM_SORCERER_THERAMORE_ELITE },
    { UNIT_N096_EARTH_GOLEM_DALARAN, UNIT_H0D9_BOSUN_THERAMORE },
    { UNIT_O02U_CRYSTAL_ARTILLERY_DALARAN, UNIT_H0D8_CANNON_THERAMORE },
    { UNIT_H067_MANAFORGE_DALARAN_SPECIALIST, UNIT_H0DA_BASTION_THERAMORE_SPECIALIST }
  };

  /// <summary>Turns <paramref name="dalaran"/>'s player into Theramore.</summary>
  public void Execute(Faction dalaran)
  {
    var whichPlayer = dalaran.Player;
    if (whichPlayer == null)
    {
      return;
    }

    var center = Regions.Theramore.Center;
    DalaranHomeland.ClaimHeldLands(dalaran);
    var heir = DalaranHomeland.GetHeir(out var heirEquivalents);
    PathBase.HandOverStructures(whichPlayer, heir, heirEquivalents, Regions.Theramore);
    DalaranHomeland.MakeBookKeeper(heir);
    PathBase.SummonLegend(AllLegends.Dalaran.Jaina, whichPlayer, new Point(center.X, center.Y));
    PathBase.RemoveAllUnitsOutside(whichPlayer, Regions.Theramore);
    var theramore = new TheramoreFaction();
    FactionTransition.AssignNewFaction(dalaran, theramore);
    theramore.DisplayDiscovered(theramore.AddQuest(new QuestSecuringDustwallow()), false);
    theramore.DisplayDiscovered(theramore.AddQuest(new QuestGoblinShipyard()), false);
    TheramoreDialogue.SetupFatherAndDaughter();

    PathBase.ClaimArea(Regions.Theramore, whichPlayer);
    if (dalaran is DalaranFaction dalaranFaction && dalaranFaction.TheramoreQuest != null)
    {
      dalaranFaction.TheramoreQuest.GiveTheramoreTo(whichPlayer);
    }

    ReplaceDalaranTroops(whichPlayer);
    PathBase.CreateUnits(whichPlayer, UNIT_H022_FARMER_DALARAN_WORKER, 5, center.X, center.Y - 250);
    PathBase.CreateUnits(whichPlayer, UNIT_H041_MARINE_KULTIRAS, 4, center.X - 250, center.Y + 300);
    PathBase.CreateUnits(whichPlayer, UNIT_H0D7_NAVY_SNIPER_THERAMORE, 4, center.X + 250, center.Y + 300);
    PathBase.CreateUnits(whichPlayer, UNIT_H0AX_FRIGATE_ALLIANCE, 2, -7406, -10387);
    PathBase.CreateUnits(whichPlayer, UNIT_H0AX_FRIGATE_ALLIANCE, 1, -6549, -10348);
    PathBase.CreateUnits(whichPlayer, UNIT_H0AN_JUGGERNAUT_ALLIANCE, 1, -6985, -10595);
    whichPlayer.PlayMusicThematic(@"Sound\Music\mp3Music\HumanX1.mp3");
  }

  /// <summary>Swaps Dalaran's troops for the Theramore units that replace them.</summary>
  private static void ReplaceDalaranTroops(player whichPlayer)
  {
    foreach (var whichUnit in GlobalGroup.EnumUnitsOfPlayer(whichPlayer))
    {
      if (whichUnit.Alive && _theramoreEquivalents.TryGetValue(whichUnit.UnitType, out var theramoreType))
      {
        PathBase.ReplaceUnit(whichUnit, whichPlayer, theramoreType, whichUnit.X, whichUnit.Y);
      }
    }
  }
}
