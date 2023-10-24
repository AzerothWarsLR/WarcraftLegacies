using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;
using static War3Api.Blizzard;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using System.Linq;
using MacroTools.Libraries;
using static MacroTools.Libraries.GeneralHelpers;

namespace WarcraftLegacies.Source.Quests.Lordaeron
{ 
  /// <summary>
  /// Lordaeron gives up and is destroyed, the scarlet crusade spawns.
  /// </summary>
  public sealed class QuestScarletCrusade : QuestData
  {
    private readonly unit _tyrHand;
    private readonly LegendaryHero _saiden;
    private readonly List<unit> _rescueUnits;
    private readonly Faction _scarletCrusade;
    private player _whichPlayer;

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestScarletCrusade"/> class.
    /// </summary>
    public QuestScarletCrusade(Rectangle rescueRect, Capital tyrHand, LegendaryHero saiden, Faction scarletCrusade) : base("All is Lost",
      "Lordaeron has been lost to the plague, but the Scarlet Crusade has taken a vow of vengeance to retake the lands and purge the undead.",
      @"ReplaceableTextures\CommandButtons\BTNDivine_Reckoning_Icon.blp")
    {
      AddObjective(new ObjectiveResearch(Constants.UPGRADE_R0XZ_ALL_IS_LOST_LORDAERON_SCARLET, Constants.UNIT_H030_TYR_S_HAND_CITADEL_LORDAERON_OTHER));
      _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
      _tyrHand = tyrHand.Unit;
      _saiden = saiden;
      _scarletCrusade = scarletCrusade;
    }

    /// <inheritdoc/>
    protected override string RewardFlavour => "Lordaeron abandons all hope, but the Scarlet Crusade begins their quest to reclaim Lordaeron and purge the Undead.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      "All of Lordaeron forces will go hostile, Tyr Hand will be emptied of neutral hostile units and you will spawn with an army and a base in Tyr's Hand.";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {

      _whichPlayer = completingFaction.Player;
      LordaeronSurrender(_whichPlayer);
      _whichPlayer.SetFaction(_scarletCrusade);
      GrantTyrHand(_whichPlayer);
      _whichPlayer.RescueGroup(_rescueUnits);
      _tyrHand.Rescue(_whichPlayer);
      _saiden.ForceCreate(_whichPlayer, Regions.Scarlet_Spawn.Center, 270);
      _saiden.Unit.SetLevel(7, false);


    }

    private void LordaeronSurrender(player whichPlayer)
    {
      foreach (var unit in CreateGroup().EnumUnitsInRect(Rectangle.WorldBounds).EmptyToList().Where(x => x.OwningPlayer() == whichPlayer))
      {
        if (!IsUnitType(unit, UNIT_TYPE_HERO))
          unit.Rescue(Player(PLAYER_NEUTRAL_AGGRESSIVE));
      }
      PlayerDistributor.DistributePlayer(whichPlayer);

      foreach (var unit in CreateGroup().EnumUnitsInRect(Regions.TyrUnlock).EmptyToList().Where(x => x.OwningPlayer() == Player(PLAYER_NEUTRAL_AGGRESSIVE)))
      {
        if
          (!IsUnitType(unit, UNIT_TYPE_ANCIENT))
          unit.Kill();
        
        if (IsUnitType(unit, UNIT_TYPE_ANCIENT))
            unit.Rescue(whichPlayer);
      }
    }

    private void GrantTyrHand(player whichPlayer)
    {
      CreateStructureForced(whichPlayer, Constants.UNIT_H0BJ_IMPROVED_CANNON_TOWER_CRUSADE_TOWER, 19082, 8573, 4.712389f * MathEx.DegToRad, 256);
      CreateStructureForced(whichPlayer, Constants.UNIT_H0BJ_IMPROVED_CANNON_TOWER_CRUSADE_TOWER, 18427, 7929, 4.712389f * MathEx.DegToRad, 256);

      CreateStructureForced(whichPlayer, Constants.UNIT_H0BJ_IMPROVED_CANNON_TOWER_CRUSADE_TOWER, 20040, 8111, 4.712389f * MathEx.DegToRad, 256);
      CreateStructureForced(whichPlayer, Constants.UNIT_H0BJ_IMPROVED_CANNON_TOWER_CRUSADE_TOWER, 20037, 7406, 4.712389f * MathEx.DegToRad, 256);

      CreateStructureForced(whichPlayer, Constants.UNIT_H0BJ_IMPROVED_CANNON_TOWER_CRUSADE_TOWER, 21500, 7378, 4.712389f * MathEx.DegToRad, 256);
      CreateStructureForced(whichPlayer, Constants.UNIT_H0BJ_IMPROVED_CANNON_TOWER_CRUSADE_TOWER, 20669, 8047, 4.712389f * MathEx.DegToRad, 256);
      CreateStructureForced(whichPlayer, Constants.UNIT_H0BJ_IMPROVED_CANNON_TOWER_CRUSADE_TOWER, 19310, 7800, 4.712389f * MathEx.DegToRad, 256);

      CreateStructureForced(whichPlayer, Constants.UNIT_H0AG_HALL_OF_SWORDS_CRUSADE_BARRACKS, 19484, 7205, 4.712389f * MathEx.DegToRad, 256);
      CreateStructureForced(whichPlayer, Constants.UNIT_H0BE_STUDIUM_CRUSADE_MAGIC, 19435, 8580, 4.712389f * MathEx.DegToRad, 256);
      CreateStructureForced(whichPlayer, Constants.UNIT_H0BL_ROOKERY_CRUSADE_BEAST, 21216, 8400, 4.712389f * MathEx.DegToRad, 256);

      CreateStructureForced(whichPlayer, Constants.UNIT_N0D8_TRADE_HOUSE_CRUSADE_SHOP, 20352, 8650, 4.712389f * MathEx.DegToRad, 256);
      CreateStructureForced(whichPlayer, Constants.UNIT_H0A3_BLACKSMITH_CRUSADE_RESEARCH, 21218, 9000, 4.712389f * MathEx.DegToRad, 256);
      CreateStructureForced(whichPlayer, Constants.UNIT_H0BQ_ALTAR_OF_CRUSADERS_CRUSADE_ALTAR, 21724, 9180, 4.712389f * MathEx.DegToRad, 256);

      CreateStructureForced(whichPlayer, Constants.UNIT_H0BP_HOUSEHOLD_CRUSADE_FARM, 19705, 8324, 4.712389f * MathEx.DegToRad, 256);
      CreateStructureForced(whichPlayer, Constants.UNIT_H0BP_HOUSEHOLD_CRUSADE_FARM, 20871, 7300, 4.712389f * MathEx.DegToRad, 256);
      CreateStructureForced(whichPlayer, Constants.UNIT_H0BP_HOUSEHOLD_CRUSADE_FARM, 20917, 8193, 4.712389f * MathEx.DegToRad, 256);


      if (GetLocalPlayer() == whichPlayer)
        SetCameraPosition(20629, 10112);
    }

  }
}