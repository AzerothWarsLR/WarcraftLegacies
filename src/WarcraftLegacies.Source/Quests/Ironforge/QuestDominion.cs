using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.FactionBased;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.TimeBased;
using WarcraftLegacies.Source.Objectives.UnitBased;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Ironforge;

public sealed class QuestDominion : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestDominion(Rectangle rescueRect, params QuestData[] prerequisites) : base("Dwarven Dominion",
    "The Dwarven Dominion must be established before Ironforge can join the war.",
    @"ReplaceableTextures\CommandButtons\BTNDwarvenFortress.blp")
  {
    Knowledge = 10;

    foreach (var prerequisite in prerequisites)
    {
      AddObjective(new ObjectiveQuestComplete(prerequisite));
    }

    AddObjective(new ObjectiveUpgrade(UNIT_H07G_GREAT_HOLD_IRONFORGE_T3,
      UNIT_H07E_MINING_COLONY_IRONFORGE_T1));
    AddObjective(new ObjectiveExpire(1462, Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R043_QUEST_COMPLETED_DWARVEN_DOMINION;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
  }

  /// <inheritdoc/>
  protected override string RewardDescription => "Control of all units in Ironforge";

  /// <inheritdoc/>
  protected override void OnFail(Faction completingFaction)
  {
    var rescuer = completingFaction.ScoreStatus == ScoreStatus.Defeated
      ? player.NeutralAggressive
      : completingFaction.Player;

    rescuer.RescueGroup(_rescueUnits);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    foreach (var unit in _rescueUnits)
    {
      unit.Rescue(completingFaction.Player ?? player.NeutralAggressive);
    }

    completingFaction.Player?.PlayMusicThematic("war3mapImported\\DwarfTheme.mp3");
  }
}
