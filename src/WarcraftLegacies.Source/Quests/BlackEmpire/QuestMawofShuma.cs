using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;
using WarcraftLegacies.Source.Factions;

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
    public QuestMawofShuma(LegendaryHero yorsahj) : base("Maw of Shu'ma",
      "Yor'sahj can awaken the Maw of Shu'ma, a terrible Forgotten One.",
      @"ReplaceableTextures\CommandButtons\BTNFacelessOneWidow.blp")
    {
      AddObjective(new ObjectiveControlLevel(UNIT_N02Q_DRAGONBLIGHT, 10));
      AddObjective(new ObjectiveLegendLevel(yorsahj, 8));
      AddObjective(new ObjectiveLegendInRect(yorsahj, Regions.WyrmrestTemple, "Wyrmrest Temple"));

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