using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.MetaBased;
using MacroTools.ObjectiveSystem.Objectives.TeamBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.CrisisSpawn
{
  /// <summary>
  /// With South Alliance destroyed, The Twilight Hammer can reveal themselves in the Highlands
  /// </summary>
  public sealed class QuestNADead : QuestData
  {
    /// <inheritdoc/>
    protected override string RewardFlavour => "The North Alliance are defeated, a crisis can be picked in the North";

    /// <inheritdoc/>
    protected override string RewardDescription => "The North crisis are available";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestNADead"/> class.
    /// </summary>
    public QuestNADead() : base("North Alliance is Defeated",
      "With the South Alliance eliminated, The Twilight Highlands have a raise in activity",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp")
    {
      AddObjective(new ObjectiveTeamControlPointAmountLessThan(TeamSetup.NorthAlliance, 10));
      AddObjective(new ObjectiveEitherOf(
        new ObjectiveTeamControlPointAmountGreaterThan(TeamSetup.Legion, 40),
        new ObjectiveTeamDefeated(TeamSetup.NorthAlliance)));
      ResearchId = Constants.UPGRADE_R09C_QUEST_COMPLETED_SCOURGE_OR_NA_DEFEATED;
      Required = true;
    }

    protected override void OnComplete(Faction completingFaction)
    {
      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        SetPlayerTechResearched(player, Constants.UPGRADE_R09D_TURN_25_HAS_PASSED_OR_OLD_GODS_ARE_PICKABLE, 1);
      }
    }
  }
}