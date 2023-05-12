
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.TimeBased;
using MacroTools.QuestSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace WarcraftLegacies.Source.Quests.CrisisSpawn
{
  /// <summary>
  /// boats will be unlocked at a certain turn
  /// </summary>
  public sealed class QuestTurn25OG : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestTurn25OG"/> class.
    /// </summary>

    public QuestTurn25OG() : base("Awakening of the Crisis",
      "The time has come for the Crisis to pick their fate.",
      @"ReplaceableTextures\\CommandButtons\\BTNSleep.blp")
    {
      AddObjective(new ObjectiveTime(1500));
      Shared = true;
    }

    /// <inheritdoc/>
    protected override string RewardDescription => "Crisis team will be pickable";

    /// <inheritdoc/>
    protected override string RewardFlavour => "Crisis team will be pickable.";

    protected override void OnComplete(Faction completingFaction)
    {

      foreach (var player in WCSharp.Shared.Util.EnumeratePlayers())
      {
        SetPlayerTechResearched(player, Constants.UPGRADE_R09D_TURN_25_HAS_PASSED_OR_OLD_GODS_ARE_PICKABLE, 1);
      }

    }

  }
}