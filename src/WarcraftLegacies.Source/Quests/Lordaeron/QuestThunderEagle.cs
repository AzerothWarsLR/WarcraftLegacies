using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.LegendBased;
using WarcraftLegacies.Source.Setup.Legends;

namespace WarcraftLegacies.Source.Quests.Lordaeron;

/// <summary>
/// Gain control of <see cref="LegendNeutral.DraktharonKeep"/> and the Storm Peaks control point to unlock Thunder Eagles.
/// </summary>
public sealed class QuestThunderEagle : QuestData
{
  private new const int ResearchId = UPGRADE_R04L_QUEST_COMPLETED_TO_THE_SKIES_LORDAERON;
  private const int ThunderEagleId = UNIT_NWE2_THUNDER_EAGLE_LORDAERON;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestThunderEagle"/> class.
  /// </summary>
  public QuestThunderEagle(Capital draktharonKeep) : base("To the Skies!",
    "The Thunder Eagles of the Storm Peaks live in fear of the Legion. Wipe out the Legion Nexus to bring these great birds out into the open.",
    @"ReplaceableTextures\CommandButtons\BTNWarEagle.blp")
  {
    AddObjective(new ObjectiveControlCapital(draktharonKeep, false));
    AddObjective(new ObjectiveControlPoint(UNIT_N02S_STORM_PEAKS));
  }

  /// <inheritdoc/>
  protected override string RewardDescription => "Learn to train " + GetObjectName(ThunderEagleId) + "s";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    completingFaction.Player.SetTechResearched(ResearchId, 1);
    completingFaction.Player?.DisplayUnitTypeAcquired(ThunderEagleId,
      "You can now train Thunder Eagles at the High Tower.");
  }
}
