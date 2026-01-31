using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.ControlPointBased;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Quests.Warsong;

public sealed class QuestGarrosh : QuestData
{
  /// <inheritdoc/>
  public override string RewardFlavour =>
    "The nightmarish grasp of N'Zoth and the Black Empire has been shattered, allowing Garrosh and the Warsong clan to rally and press forward towards new territories.";

  /// <inheritdoc/>
  protected override string RewardDescription => $"Can now train Garrosh from the {GetObjectName(UNIT_O020_ALTAR_OF_CONQUERORS_WARSONG_ALTAR)} and research the Warsong expedition from the {GetObjectName(UNIT_O02T_SHIPYARD_WARSONG_SHIPYARD)}";

  public QuestGarrosh(Legend nzoth) : base("Twilight's Reckoning",
    "The monstrous Old God N'Zoth threatens Kalimdor with madness and ruin. End his terrifying reign to secure the continent and further the Horde's ambitions.",
    @"ReplaceableTextures\CommandButtons\BTNFacelessMadness.blp")
  {
    AddObjective(new ObjectiveKillUnit(nzoth.Unit));
    AddObjective(new ObjectiveControlPoint(UNIT_NNYA_NY_ALOTHA_THE_WAKING_CITY));
    ResearchId = UPGRADE_R062_QUEST_COMPLETED_TWILIGHT_S_RECKONING;
  }

}
