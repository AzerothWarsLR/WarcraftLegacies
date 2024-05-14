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
  public sealed class QuestMawofGorath : QuestData
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestMawofGorath"/> class.
    /// </summary>
    public QuestMawofGorath(LegendaryHero zonozz) : base("Maw of Go'rath",
      "Zon'ozz can awaken the Maw of Go'rath, a terrible Forgotten One.",
      @"ReplaceableTextures\CommandButtons\BTNFacelessKing.blp")
    {
      AddObjective(new ObjectiveControlLevel(UNIT_N02Q_DRAGONBLIGHT, 10));
      AddObjective(new ObjectiveLegendLevel(zonozz, 8));
      AddObjective(new ObjectiveLegendInRect(zonozz, Regions.WyrmrestTemple, "Wyrmrest Temple"));

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