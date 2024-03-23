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
using static War3Api.Common;


namespace WarcraftLegacies.Source.Quests.Ironforge
{
  public sealed class QuestDominion : QuestData
  {
    private readonly List<unit> _rescueUnits;

    public QuestDominion(Rectangle rescueRect, QuestData prerequisite) : base("Dwarven Dominion",
      "The Dwarven Dominion must be established before Ironforge can join the war.",
      @"ReplaceableTextures\CommandButtons\BTNDwarvenFortress.blp")
    {
      AddObjective(new ObjectiveQuestComplete(prerequisite));
      AddObjective(new ObjectiveControlPoint(Constants.UNIT_N017_DUN_MODR));
      AddObjective(new ObjectiveControlPoint(Constants.UNIT_N014_DUN_MOROGH));
      AddObjective(new ObjectiveUpgrade(Constants.UNIT_H07G_GREAT_HOLD_IRONFORGE_T3,
        Constants.UNIT_H07E_MINING_COLONY_IRONFORGE_T1));
      AddObjective(new ObjectiveExpire(1462, Title));
      AddObjective(new ObjectiveSelfExists());
      ResearchId = Constants.UPGRADE_R043_QUEST_COMPLETED_DWARVEN_DOMINION;
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
        ? Player(PLAYER_NEUTRAL_AGGRESSIVE)
        : completingFaction.Player;

      rescuer.RescueGroup(_rescueUnits);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var unit in _rescueUnits) unit.Rescue(completingFaction.Player ?? Player(PLAYER_NEUTRAL_AGGRESSIVE));
      completingFaction.Player?.PlayMusicThematic("war3mapImported\\DwarfTheme.mp3");
    }
  }
}