using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Sentinels
{
  /// <summary>
  /// Destroy Nzoth to defeat the black empire.
  /// </summary>
  public sealed class QuestSentinelsKillBlackEmpire : QuestData
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="QuestSentinelsKillBlackEmpire"/> class.
    /// </summary>
    public QuestSentinelsKillBlackEmpire(Legend nzoth) : base("Otherwordly Invaders",
      "The Black Empire has poored out near Feathermoon and begun threatening the wilds. These invaders must be repelled.",
      @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
    {
      AddObjective(new ObjectiveKillUnit(nzoth.Unit));
      ResearchId = UPGRADE_R007_QUEST_COMPLETED_OTHERWORDLY_INVADERS_SENTINELS;
      
    }

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "The Black Empire presence on Kalimdor has been eliminated. The land has been protected from their misbegotten race.";

    /// <inheritdoc/>
    protected override string RewardDescription => $"Allows {GetObjectName(UNIT_N034_GUILD_RANGER_SENTINELS)}s to be trained from {GetObjectName(UNIT_E00T_WATCHER_S_BASTION_SENTINEL_SIEGE)}s";

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction)
    {
      SetPlayerTechResearched(completingFaction.Player, ResearchId, 1);
    }

    /// <inheritdoc/>
    protected override void OnAdd(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(ResearchId, Faction.UNLIMITED);
    }
  }
}