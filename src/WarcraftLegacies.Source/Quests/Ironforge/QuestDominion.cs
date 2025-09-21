using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Quests.Ironforge;

public sealed class QuestDominion : QuestData
{
  private readonly List<unit> _rescueUnits;

  public QuestDominion(Rectangle rescueRect, params QuestData[] prerequisites) : base("Dwarven Dominion",
    "The Dwarven Dominion must be established before Ironforge can join the war.",
    @"ReplaceableTextures\CommandButtons\BTNDwarvenFortress.blp")
  {
    foreach (var prerequisite in prerequisites)
    {
      AddObjective(new ObjectiveQuestComplete(prerequisite));
    }

    AddObjective(new ObjectiveControlPoint(UNIT_N017_DUN_MODR));
    AddObjective(new ObjectiveControlPoint(UNIT_N014_DUN_MOROGH));
    AddObjective(new ObjectiveUpgrade(UNIT_H07G_GREAT_HOLD_IRONFORGE_T3,
      UNIT_H07E_MINING_COLONY_IRONFORGE_T1));
    AddObjective(new ObjectiveExpire(1462, Title));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R043_QUEST_COMPLETED_DWARVEN_DOMINION;
    _rescueUnits = rescueRect.PrepareUnitsForRescue(RescuePreparationMode.Invulnerable);
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The Dwarven Empire is re-united again, Ironforge is ready for war again.";

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
