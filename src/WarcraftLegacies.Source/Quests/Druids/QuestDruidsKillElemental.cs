using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Druids;

public sealed class QuestDruidsKillElemental : QuestData
{
  private const int ElementalGuardianId = UNIT_E00X_ELEMENTAL_GUARDIAN_DRUIDS_DEMI;

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The elementals have been subdued. This new found balance reveals the existence of a powerful nature spirit that now heeds the call of the Druids.";

  /// <inheritdoc/>
  protected override string RewardDescription => $"The demihero {GetObjectName(ElementalGuardianId)}";

  public QuestDruidsKillElemental(Capital vortex) : base("Deformed Nature",
    "The elemental planes have gone out of control, disturbing the balance of nature. We need to put an end to it.",
    @"ReplaceableTextures\CommandButtons\BTNAlAkirTownHall3.blp")
  {
    AddObjective(new ObjectiveControlCapital(vortex, false));
    ResearchId = UPGRADE_R044_QUEST_COMPLETED_DEFORMED_NATURE_DRUIDS;
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player?.DisplayUnitTypeAcquired(ElementalGuardianId,
      "You can now train the Elemental Guardian from the Altar of Elders.");
  }
}
