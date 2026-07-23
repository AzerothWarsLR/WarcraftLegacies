using MacroTools.Localization;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.UnitBased;

namespace WarcraftLegacies.Source.Factions.Ahnqiraj.Quests;

/// <summary>
/// Kill a bunch of different units to unlock Ouro.
/// </summary>
public sealed class QuestMockeryOfLife : QuestData
{
  /// <summary>
  /// Initializes a new instance of the <see cref="QuestMockeryOfLife"/> class.
  /// </summary>
  public QuestMockeryOfLife() : base("Mockery of Life",
    "C'thun, the great distorter of flesh, needs to amass samples from many beings to create ",
    @"ReplaceableTextures\CommandButtons\BTNMindWorm.blp")
  {
    AddObjective(new ObjectiveKillCount(50));
    ResearchId = UPGRADE_RLLL_QUEST_COMPLETED_MOCKERY_OF_LIFE;
  }

  /// <inheritdoc />
  public override string RewardFlavour => "The abominable sandwurm Ouro has been created by Cthun";

  /// <inheritdoc />
  protected override string RewardDescription => Loc.Format(
    "Learn to train {sandWorm}s from the {altar}",
    ("{sandWorm}", GetObjectName(UNIT_U02S_ANCIENT_SAND_WORM)),
    ("{altar}", GetObjectName(UNIT_U01F_ALTAR_OF_THE_OLD_ONES_CTHUN_ALTAR)));
}
