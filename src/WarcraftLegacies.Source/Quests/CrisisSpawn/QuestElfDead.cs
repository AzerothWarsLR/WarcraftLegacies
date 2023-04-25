using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.TeamBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Setup;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.CrisisSpawn
{
  /// <summary>
  /// Once the elves are dead, Cthun becomes available
  /// </summary>
  public sealed class QuestElfDead : QuestData
  {
    /// <inheritdoc/>
    protected override string RewardFlavour => "The Night Elves are defeated, a crisis can be picked in Kalimdor";

    /// <inheritdoc/>
    protected override string RewardDescription => "The Kalimdor crisis are available";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestElfDead"/> class.
    /// </summary>
    public QuestElfDead() : base("Night Elves are Defeated",
      "With the Night Elves eliminated, something stirs in the sands of Ahn'qiraj",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp")
    {
      AddObjective(new ObjectiveTeamContolPointAmountLessThan(TeamSetup.NightElves, 10));
      AddObjective(new ObjectiveTeamContolPointAmountGreaterThan(TeamSetup.Horde, 40));
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