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
  /// With Illidari destroyed, The Twilight Hammer can reveal themselves in the Highlands
  /// </summary>
  public sealed class QuestIllidariDead : QuestData
  {
    /// <inheritdoc/>
    protected override string RewardFlavour => "The Illidari are defeated, a crisis can be picked in South Alliance";

    /// <inheritdoc/>
    protected override string RewardDescription => "The South Alliance crisis are available";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestIllidariDead"/> class.
    /// </summary>
    public QuestIllidariDead() : base("Illidari is Defeated",
      "With the Illidari eliminated, The Twiligh Highlands have a raise in activity",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp")
    {
      AddObjective(new ObjectiveTeamControlPointAmountLessThan(TeamSetup.Illidari, 10));
      AddObjective(new ObjectiveEitherOf(
new ObjectiveTeamControlPointAmountGreaterThan(TeamSetup.SouthAlliance, 40),
new ObjectiveTeamDefeated(TeamSetup.Illidari)));
      ResearchId = Constants.UPGRADE_R09B_QUEST_COMPLETED_SOUTH_ALLIANCE_OR_ILLIDARI_DEFEATED;
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