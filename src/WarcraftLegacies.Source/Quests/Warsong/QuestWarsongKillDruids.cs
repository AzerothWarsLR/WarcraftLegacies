using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.QuestSystem;
using MacroTools.QuestSystem.UtilityStructs;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Warsong
{
  /// <summary>
  /// Warsong kills the Druids and Grom is finally happy.
  /// </summary>
  public sealed class QuestWarsongKillDruids : QuestData
  {
    private const int ExperienceReward = 10000;

    /// <inheritdoc/>
    protected override string CompletionPopup => "Nordrassil has been captured. The Warsong is supreme!";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Grom Hellscream gains {ExperienceReward} experience and you can now train Foreman Glibbs";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestWarsongKillDruids"/> class.
    /// </summary>
    public QuestWarsongKillDruids() : base("Tear It Down",
      "The World Tree, Nordrassil, is the Night Elves' source of immortality. Capture it to cripple them permanently.",
      "ReplaceableTextures\\CommandButtons\\BTNFountainOfLife.blp")
    {
      AddObjective(new ObjectiveControlCapital(LegendDruids.LegendNordrassil, false));
      AddObjective(new ObjectiveLegendNotPermanentlyDead(LegendWarsong.GromHellscream));
      ResearchId = Constants.UPGRADE_R08M_QUEST_COMPLETED_TEAR_IT_DOWN;
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      LegendWarsong.GromHellscream?.Unit?.AddExperience(ExperienceReward);
    }
  }
}