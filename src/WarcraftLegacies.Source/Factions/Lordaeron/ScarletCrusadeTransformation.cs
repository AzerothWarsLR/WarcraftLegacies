using System;
using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Utils;
using WarcraftLegacies.Source.Factions.ScarletCrusade;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Lordaeron;

/// <summary>
/// Removes everything Lordaeron owns and restarts the player as the Scarlet Crusade in Tyr's Hand.
/// Shared by <see cref="Quests.QuestScarletCrusade"/> and <see cref="Paths.PathScarletCrusade"/>.
/// </summary>
public sealed class ScarletCrusadeTransformation
{
  private readonly unit _tyrsHand;
  private readonly LegendaryHero _saiden;
  private readonly List<unit> _rescueUnits;

  public ScarletCrusadeTransformation(Rectangle rescueRect, Capital tyrsHand, LegendaryHero saiden)
  {
    if (tyrsHand.Unit == null)
    {
      throw new ArgumentException($"Expected {nameof(tyrsHand)} to have a non-null {tyrsHand.Unit} property.", nameof(tyrsHand));
    }

    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideAll);
    _tyrsHand = tyrsHand.Unit;
    _saiden = saiden;
  }

  /// <summary>Turns <paramref name="lordaeron"/>'s player into the Scarlet Crusade.</summary>
  public void Execute(Faction lordaeron)
  {
    var whichPlayer = lordaeron.Player;
    if (whichPlayer == null)
    {
      return;
    }

    whichPlayer.RemoveAllUnits();
    EvacuateTyrsHand(whichPlayer);
    AssignScarletCrusadeFaction(lordaeron);
    GrantTyrsHand(whichPlayer);
    whichPlayer.RescueGroup(_rescueUnits);
    _saiden.ForceCreate(whichPlayer, Regions.Scarlet_Spawn.Center, 270);
    whichPlayer.PlayMusicThematic(@"war3mapImported\ScarletTheme.mp3");
  }

  private static void AssignScarletCrusadeFaction(Faction completingFaction)
  {
    var scarletCrusade = new ScarletCrusadeFaction();
    FactionTransition.AssignNewFaction(completingFaction, scarletCrusade);
  }

  private static void EvacuateTyrsHand(player newOwner)
  {
    var neutralHostileUnitsInTyrsHand = GlobalGroup
      .EnumUnitsInRect(Regions.TyrUnlock)
      .Where(x => x.Owner == player.NeutralAggressive);

    foreach (var unit in neutralHostileUnitsInTyrsHand)
    {
      if (unit.IsRemovable())
      {
        unit.SafelyRemove();
      }
      else
      {
        unit.Rescue(newOwner);
      }
    }
  }

  private void GrantTyrsHand(player whichPlayer)
  {
    _tyrsHand.Rescue(whichPlayer);

    CreateStructureForced(whichPlayer, UNIT_H0BJ_IMPROVED_BOMBARD_TOWER_SCARLET_TOWER, 19082, 8573,
      4.712389f * MathEx.DegToRad, 256);
    CreateStructureForced(whichPlayer, UNIT_H0BJ_IMPROVED_BOMBARD_TOWER_SCARLET_TOWER, 18427, 7929,
      4.712389f * MathEx.DegToRad, 256);

    CreateStructureForced(whichPlayer, UNIT_H09X_SHIPYARD_SCARLET_SHIPYARD, 21447, 9882,
      4.712389f * MathEx.DegToRad, 256);

    CreateStructureForced(whichPlayer, UNIT_H0BJ_IMPROVED_BOMBARD_TOWER_SCARLET_TOWER, 20040, 8111,
      4.712389f * MathEx.DegToRad, 256);
    CreateStructureForced(whichPlayer, UNIT_H0BJ_IMPROVED_BOMBARD_TOWER_SCARLET_TOWER, 20037, 7406,
      4.712389f * MathEx.DegToRad, 256);

    CreateStructureForced(whichPlayer, UNIT_H0BJ_IMPROVED_BOMBARD_TOWER_SCARLET_TOWER, 21500, 7378,
      4.712389f * MathEx.DegToRad, 256);
    CreateStructureForced(whichPlayer, UNIT_H0BJ_IMPROVED_BOMBARD_TOWER_SCARLET_TOWER, 20669, 8047,
      4.712389f * MathEx.DegToRad, 256);
    CreateStructureForced(whichPlayer, UNIT_H0BJ_IMPROVED_BOMBARD_TOWER_SCARLET_TOWER, 19310, 7800,
      4.712389f * MathEx.DegToRad, 256);

    CreateStructureForced(whichPlayer, UNIT_H0AG_HALL_OF_SWORDS_SCARLET_BARRACKS, 19484, 7205,
      4.712389f * MathEx.DegToRad, 256);
    CreateStructureForced(whichPlayer, UNIT_H0BE_STUDIUM_SCARLET_MAGIC, 19435, 8580,
      4.712389f * MathEx.DegToRad, 256);
    CreateStructureForced(whichPlayer, UNIT_H0BL_ROOKERY_SCARLET_BEAST, 21216, 8400,
      4.712389f * MathEx.DegToRad, 256);

    CreateStructureForced(whichPlayer, UNIT_N0D8_VENDOR_HALL_SCARLET_SHOP, 20352, 8650,
      4.712389f * MathEx.DegToRad, 256);
    CreateStructureForced(whichPlayer, UNIT_H0A3_BLACKSMITH_SCARLET_RESEARCH, 21218, 9000,
      4.712389f * MathEx.DegToRad, 256);
    CreateStructureForced(whichPlayer, UNIT_H0BQ_ALTAR_OF_CRUSADERS_SCARLET_ALTAR, 21724, 9180,
      4.712389f * MathEx.DegToRad, 256);

    CreateStructureForced(whichPlayer, UNIT_H0BP_FARMSTEAD_SCARLET_FARM, 19705, 8324,
      4.712389f * MathEx.DegToRad, 256);
    CreateStructureForced(whichPlayer, UNIT_H0BP_FARMSTEAD_SCARLET_FARM, 20871, 7300,
      4.712389f * MathEx.DegToRad, 256);
    CreateStructureForced(whichPlayer, UNIT_H0BP_FARMSTEAD_SCARLET_FARM, 20917, 8193,
      4.712389f * MathEx.DegToRad, 256);

    whichPlayer.RepositionCamera(20629, 10112);
  }
}
