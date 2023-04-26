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
  /// Once the horde is dead, Cthun becomes available.
  /// </summary>
  public sealed class QuestHordeDead : QuestData
  {
    /// <inheritdoc/>
    protected override string RewardFlavour => "The Horde is defeated, a crisis can be picked in Kalimdor";

    /// <inheritdoc/>
    protected override string RewardDescription => "The Kalimdor crisis are available";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestHordeDead"/> class.
    /// </summary>
    public QuestHordeDead() : base("Horde is Defeated",
      "With the Horde eliminated, something stirs in the sands of Ahn'qiraj",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp")
    {
      AddObjective(new ObjectiveTeamControlPointAmountLessThan(TeamSetup.Horde, 10));
      AddObjective(new ObjectiveEitherOf(
new ObjectiveTeamControlPointAmountGreaterThan(TeamSetup.NightElves, 40),
new ObjectiveTeamDefeated(TeamSetup.Horde)));


      ResearchId = Constants.UPGRADE_R091_QUEST_COMPLETED_HORDE_OR_NIGHT_ELF_DEFEATED;
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