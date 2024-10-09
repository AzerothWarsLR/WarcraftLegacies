using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Cthun
{
  /// <summary>
  /// Control level 5 Uldum control point.
  /// </summary>
  public sealed class QuestEmperorConstruct : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestEmperorConstruct"/> class.
    /// </summary>
    public QuestEmperorConstruct() : base("The Emperor's Constructs",
      "Queen Azshara studied many forms of arcane knowledge, some darker than others. With access to her library and enough time, the highborn scholares could uncover her secrets",
      @"ReplaceableTextures\CommandButtons\BTNObsidianStatue.blp")
    {
      AddObjective(new ObjectiveControlLevel(UNIT_N0BD_ULDUM, 5));
      ResearchId = UPGRADE_RZZL_QUEST_COMPLETED_THE_EMPEROR_S_CONSTRUCTS;
    }

    /// <inheritdoc />
    public override string RewardFlavour => "We have enslaved the Cursed Tol'vir";

    /// <inheritdoc />
    protected override string RewardDescription => $"Learn to train {GetObjectName(UNIT_SL2O_OBSIDIAN_ERADICATOR_CTHUN)}s from the {GetObjectName(UNIT_O00R_HATCHERY_C_THUN_BARRACK)},Learn to train {GetObjectName(UNIT_O001_TOL_VIR_STATUE_C_THUN_TOL_VIR_STATUE)}s from the {GetObjectName(UNIT_O00D_PYRAMID_C_THUN_MAGIC)} and learn to train Moam from the {GetObjectName(UNIT_U01F_ALTAR_OF_THE_OLD_ONES_C_THUN_ALTAR)} ";

  }
}