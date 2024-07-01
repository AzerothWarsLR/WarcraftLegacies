using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.QuestBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Quests.Cthun;

namespace WarcraftLegacies.Source.Quests.BlackEmpire
{
  /// <summary>
  /// Gain an additional Forgotten one
  /// </summary>
  public sealed class QuestMawofShuma : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestMawofShuma"/> class.
    /// </summary>
    public QuestMawofShuma(LegendaryHero yorsahj, Faction cthun) : base("Maw of Shu'ma",
      "Yor'sahj needs souls to awaken the Maw of Shu'ma for me, a terrible Forgotten One. C'thun has been gathering samples of living things for his experiments, but i can use their souls for my own purposes.",
      @"ReplaceableTextures\CommandButtons\BTNFacelessOneWidow.blp")
    {
      AddObjective(new ObjectiveFactionQuestComplete(cthun.GetQuestByType<QuestMockeryOfLife>(), cthun));
      AddObjective(new ObjectiveLegendLevel(yorsahj, 8));

    }

    /// <inheritdoc />
    public override string RewardFlavour => "We have gained a new Forgotten One.";

    /// <inheritdoc />
    protected override string RewardDescription => $"Learn to train one additional {GetObjectName(UNIT_U02F_FORGOTTEN_ONE_YOGG)}";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(UNIT_U02F_FORGOTTEN_ONE_YOGG, 1);
    }
  }
}