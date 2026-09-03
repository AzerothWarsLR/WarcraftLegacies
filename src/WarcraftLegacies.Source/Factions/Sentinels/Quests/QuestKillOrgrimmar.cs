using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Sentinels.Quests;

/// <summary>
/// Destroy Nzoth to defeat the black empire.
/// </summary>
public sealed class QuestKillOrgrimmar : QuestData
{
  /// <summary>
  /// Initializes a new instance of the <see cref="QuestSentinelsKillBlackEmpire"/> class.
  /// </summary>
  public QuestKillOrgrimmar() : base("Otherwordly Invaders",
    "This new Horde has appeared near Ashenvale and begun threatening the wilds. These invaders must be repelled.",
    @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
  {
    AddObjective(new ObjectiveCapitalDead(AllLegends.Warsong.Orgrimmar));
    ResearchId = UPGRADE_MD54_QUEST_COMPLETED_OTHERWORDLY_INVADERS;

  }

  /// <inheritdoc/>
  protected override string RewardDescription => Loc.Format(
    "Allows {guildRanger}s to be trained from {bastion}s",
    ("{guildRanger}", GetObjectName(UNIT_N034_GUILD_RANGER_SENTINELS)),
    ("{bastion}", GetObjectName(UNIT_E00T_WATCHER_S_BASTION_SENTINELS_SIEGE)));

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.SetTechResearched(ResearchId, 1);
  }

  /// <inheritdoc/>
  protected override void OnAdd(Faction whichFaction)
  {
    whichFaction.ModObjectLimit(ResearchId, Faction.Unlimited);
  }
}
