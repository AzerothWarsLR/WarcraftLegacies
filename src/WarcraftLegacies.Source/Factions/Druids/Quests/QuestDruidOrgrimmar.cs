using MacroTools.Extensions;
using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Druids.Quests;

/// <summary>
/// Destroy Nzoth to defeat the black empire.
/// </summary>
public sealed class QuestDruidOrgrimmar : QuestData
{
  private const int UnittypeId = UNIT_E012_SIEGE_ANCIENT_DRUIDS_ELITE;
  /// <summary>
  /// Initializes a new instance of the <see cref="QuestSentinelsKillBlackEmpire"/> class.
  /// </summary>
  public QuestDruidOrgrimmar() : base("Greenskins",
    "This new Horde has appeared near Ashenvale and begun threatening the wilds. These invaders must be repelled.",
    @"ReplaceableTextures\CommandButtons\BTNNzothIcon.blp")
  {
    AddObjective(new ObjectiveCapitalDead(AllLegends.Warsong.Orgrimmar));

    ResearchId = UPGRADE_MD55_QUEST_COMPLETED_GREENSKINS;
  }

  /// <inheritdoc/>
  protected override string RewardDescription => Loc.Format(
    "Learn to train {unit}s", ("{unit}", GetObjectName(UnittypeId)));

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.DisplayUnitTypeAcquired(UnittypeId, "You can now train Siege Ancients at the Ancient of War.");
  }
}
