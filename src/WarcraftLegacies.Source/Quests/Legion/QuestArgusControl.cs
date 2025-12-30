using MacroTools.Extensions;
using MacroTools.FactionSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.FactionBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.PreplacedWidgetsSystem;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Legion;

public sealed class QuestArgusControl : QuestData
{
  private readonly unit _legionTeleporter1;
  private readonly unit _legionTeleporter2;

  public QuestArgusControl() : base("Argus",
    "The planet of Argus is not yet fully under the control of the Legion.",
    @"ReplaceableTextures\CommandButtons\BTNMastersLodge.blp")
  {
    AddObjective(new ObjectiveControlPoint(UNIT_N0BF_ANTORAN_WASTES));
    AddObjective(new ObjectiveControlPoint(UNIT_N0BH_EREDATH));
    AddObjective(new ObjectiveControlPoint(UNIT_N0BG_KROKUUN));
    AddObjective(new ObjectiveUpgrade(UNIT_U00N_BURNING_CITADEL_LEGION_T3,
      UNIT_U00C_LEGION_BASTION_LEGION_T2));
    AddObjective(new ObjectiveSelfExists());
    ResearchId = UPGRADE_R055_QUEST_COMPLETED_ARGUS;


    _legionTeleporter1 =
      PreplacedWidgets.Units.GetClosest(UNIT_N0BE_LEGION_TELEPORTERS_LEGION_OTHER, 22939, -29345);
    _legionTeleporter2 =
      PreplacedWidgets.Units.GetClosest(UNIT_N0BE_LEGION_TELEPORTERS_LEGION_OTHER, 23536, -29975);
  }

  /// <inheritdoc/>
  protected override string RewardDescription =>
    "Learn to train Tichondrius and Anetheron from the Altar of Destruction, and to cast the Portal spells from the Legion Teleporter";

  /// <inheritdoc/>
  public override string RewardFlavour =>
    "With Argus finally under the Legion's control, the invasion of Azeroth can begin in earnest.";

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction)
  {
    _legionTeleporter1.SetWaygateDestination(Regions.NorthrendLegionLanding.Center);
    _legionTeleporter2.SetWaygateDestination(Regions.AlteracLegionLanding.Center);
  }
}
