using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.Powers;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Stormwind;

/// <summary>
/// Capture various control points and upgrade the main building to Tier 3 in order to gain control of Stormwind.
/// </summary>
public sealed class QuestStormwindCity : QuestData
{
  private readonly List<unit> _rescueUnits;
  private const string RewardPowerName = "City of Heroes";

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestStormwindCity"/> class.
  /// </summary>
  /// <param name="rescueRect">Units in this area will be made invulnerable, then rescued when the quest is completed.</param>
  /// <param name="prerequisites">Must be completed first to complete this quest.</param>
  public QuestStormwindCity(Rectangle rescueRect, params QuestData[] prerequisites) : base("Clear the Outskirts",
    "The outskirts of Stormwind are infested by rebels and foul creatures. Defeat them to regain control of your lands.",
    @"ReplaceableTextures\CommandButtons\BTNStormwindCastle.blp")
  {
    foreach (var prerequisite in prerequisites)
    {
      AddObjective(new ObjectiveQuestComplete(prerequisite));
    }

    AddObjective(new ObjectiveUpgrade(UNIT_H06N_CASTLE_STORMWIND_T3,
      UNIT_H06K_TOWN_HALL_STORMWIND_T1));
    AddObjective(new ObjectiveExpire(600, Title));
    AddObjective(new ObjectiveSelfExists());
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.HideNonStructures);
    ResearchId = UPGRADE_R02S_QUEST_COMPLETED_CLEAR_THE_OUTSKIRTS;
  }

  //Todo: bad flavour
  /// <inheritdoc />
  public override string RewardFlavour =>
    "Stormwind has been liberated, and its grand army is now free to assist the Alliance.";

  /// <inheritdoc />
  protected override string RewardDescription =>
    "Gain control of all units in Stormwind, " +
    $"learn to train Varian from the {GetObjectName(UNIT_H06T_ALTAR_OF_KINGS_STORMWIND_ALTAR)}, " +
    $"learn to cast {GetObjectName(ABILITY_A0GD_SUMMON_GARRISON_STORMWIND)} from {GetObjectName(UNIT_H06M_KEEP_STORMWIND_T2)}s and {GetObjectName(UNIT_H06N_CASTLE_STORMWIND_T3)}s, " +
    $"and acquire the {RewardPowerName} Power";

  /// <inheritdoc />
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc />
  protected override void OnComplete(Faction completingFaction)
  {
    var rewardPower = new CityOfHeroes(0.125f, 1.5f, "Units")
    {
      IconName = "Angel",
      Name = RewardPowerName,
      HeroGlowAbilityTypeId = ABILITY_A0GK_HERO_GLOW_ORIGIN,
      Filter = unit => !unit.IsUnitType(unittype.Mechanical) && unit.UnitType != UNIT_H05F_STORMWIND_CHAMPION_STORMWIND_ELITE,
    };

    completingFaction.AddPower(rewardPower);

    completingFaction.Player?.RescueGroup(_rescueUnits);
    completingFaction.Player?.DisplayPowerAcquired(rewardPower);
    completingFaction.Player?.PlayMusicThematic("war3mapImported\\StormwindTheme.mp3");
  }
}
