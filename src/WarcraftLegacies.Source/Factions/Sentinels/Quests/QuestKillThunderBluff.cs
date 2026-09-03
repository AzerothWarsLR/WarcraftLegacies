using MacroTools.Factions;
using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Shared;

namespace WarcraftLegacies.Source.Factions.Sentinels.Quests;

/// <summary>
/// Destroy Thunderbluff to unlock a hero and a demi hero.
/// </summary>
public sealed class QuestKillThunderBluff : QuestData
{

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestSentinelsKillCthun"/> class.
  /// </summary>
  public QuestKillThunderBluff() : base("The Planerunners",
    "The Tauren have joined up with the Horde. They need to be ridden from the surface of Kalimdor.",
    @"ReplaceableTextures\CommandButtons\BTNCthunIcon.blp")
  {
    AddObjective(new ObjectiveCapitalDead(AllLegends.Frostwolf.ThunderBluff));
    ResearchId = UPGRADE_MD56_QUEST_COMPLETED_THE_PLANERUNNERS;

  }

  /// <inheritdoc/>
  protected override string RewardDescription => Loc.Format(
    "Learn to train {moonRider}s from the {roost}s and research {upgrade}'s second level from the {academy}",
    ("{moonRider}", GetObjectName(UNIT_E022_MOON_RIDER_SENTINELS)),
    ("{roost}", GetObjectName(UNIT_EDOS_ROOST_SENTINELS_SPECIALIST)),
    ("{upgrade}", GetObjectName(UPGRADE_REMG_UPGRADE_MOON_GLAIVE_LIGHT_BLUE_RESEARCH)),
    ("{academy}", GetObjectName(UNIT_E00L_WAR_ACADEMY_SENTINELS_BARRACKS)));

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
