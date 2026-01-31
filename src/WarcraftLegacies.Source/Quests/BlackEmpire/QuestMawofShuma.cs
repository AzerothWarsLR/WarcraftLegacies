using MacroTools.FactionSystem;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.BlackEmpire;

/// <summary>
/// Gain an additional Forgotten one
/// </summary>
public sealed class QuestMawofShuma : QuestData
{
  private readonly ObjectiveDestroyAnyCapital _objectiveDestroyAnyCapital;

  /// <summary>
  /// Initializes a new instance of the <see cref="QuestMawofShuma"/> class.
  /// </summary>
  public QuestMawofShuma(LegendaryHero yorsahj) : base("Maw of Shu'ma",
    "Yor'sahj needs souls to awaken the Maw of Shu'ma, a terrible Forgotten one, for me. Destroying and ravaging one of the mortals great cities will grant him the souls he needs.",
    @"ReplaceableTextures\CommandButtons\BTNFacelessOneWidow.blp")
  {
    _objectiveDestroyAnyCapital = new ObjectiveDestroyAnyCapital();
    AddObjective(_objectiveDestroyAnyCapital);
    AddObjective(new ObjectiveLegendLevel(yorsahj, 8));

  }

  /// <inheritdoc />
  public override string RewardFlavour => "We have gained a new Forgotten One.";

  /// <inheritdoc />
  protected override string RewardDescription => $"Learn to train one additional {GetObjectName(UNIT_U02F_FORGOTTEN_ONE_NZOTH)} from the {GetObjectName(UNIT_N0AX_MUTATION_CIRCLE_NZOTH_SPECIALIST)}";

  /// <inheritdoc/>
  protected override void OnComplete(Faction whichFaction)
  {
    whichFaction.ModObjectLimit(UNIT_U02F_FORGOTTEN_ONE_NZOTH, 1);
  }
}
