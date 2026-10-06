using MacroTools.Factions;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.QuestBased;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Factions.Lordaeron.Quests;

/// <summary>
/// Lordaeron gives up and is destroyed, the scarlet crusade spawns.
/// </summary>
public sealed class QuestScarletCrusade : QuestData
{
  private readonly ScarletCrusadeTransformation _transformation;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestScarletCrusade"/> class.
  /// </summary>
  public QuestScarletCrusade(ScarletCrusadeTransformation transformation, QuestData fortifiedCity)
    : base("The Scarlet Crusade",
      "Lordaeron is destined to fall to the Scourge. Should such an event come to pass, the Silver Hand will be transformed beyond recognition, abandoning ideals of justice in favour of those of vengeance.",
      @"ReplaceableTextures\CommandButtons\BTNDivine_Reckoning_Icon.blp")
  {
    AddObjective(new ObjectiveResearch(UPGRADE_R0XZ_THE_SCARLET_CRUSADE_LORDAERON_SCARLET,
      UNIT_H030_TYR_S_HAND_CITADEL_LORDAERON_OTHER));
    AddObjective(new ObjectiveQuestComplete(fortifiedCity));
    _transformation = transformation;
    Global = true;
  }

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "Lordaeron has been destroyed by the vile Scourge, leaving those left alive with naught but vengeance in their hearts. From the ashes rises the Scarlet Crusade, the untempered bright that will bring to the undying dead the wrath of the living.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Your existing forces are removed, then you restart the game as the Scarlet Crusade in Tyr's Hand";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction) => _transformation.Execute(completingFaction);
}
