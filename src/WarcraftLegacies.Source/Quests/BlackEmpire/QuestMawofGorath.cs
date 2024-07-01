using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.ControlPointBased;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
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
      "Zon'ozz has been tasked awaken the Maw of Go'rath, a terrible Forgotten One. To that end, he will need to carve a crest of blood with the corpses of his enemies.",
      @"ReplaceableTextures\CommandButtons\BTNFacelessKing.blp")
    {
      AddObjective(new ObjectiveKillCount(200));
      AddObjective(new ObjectiveLegendLevel(zonozz, 8));

    }

    /// <inheritdoc />
    public override string RewardFlavour => "I have gained a new Forgotten One.";

    /// <inheritdoc />
    protected override string RewardDescription => $"Learn to train one additional {GetObjectName(UNIT_U02F_FORGOTTEN_ONE_YOGG)}";

    /// <inheritdoc/>
    protected override void OnComplete(Faction whichFaction)
    {
      whichFaction.ModObjectLimit(UNIT_U02F_FORGOTTEN_ONE_YOGG, 1);
    }

  }
}