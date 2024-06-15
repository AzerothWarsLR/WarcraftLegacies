using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.UnitBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Cthun
{
  /// <summary>
  /// Kill many units to give C'thun some extra skill points.
  /// </summary>
  public sealed class QuestFreshMeat : QuestData
  {
    private readonly LegendaryHero _cthun;
    private const int SkillPoints = 2;

    /// <inheritdoc/>
    public override string RewardFlavour =>
      "The Qiraji have ripped, torn, and consumed scores of fallen prey, satiating their hunger and lifting a bloody haze from C'thun's mind.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"Cthun gains {SkillPoints} skill points";

    /// <summary>
    /// Initializes a new instance of the <see cref="QuestFreshMeat"/> class.
    /// </summary>
    public QuestFreshMeat(LegendaryHero cthun) : base("Fresh Meat",
      "Only recently awoken from their long slumber, the Qiraji are ravenous for flesh.",
      @"ReplaceableTextures\CommandButtons\BTNSilithid.blp")
    {
      _cthun = cthun;
      AddObjective(new ObjectiveKillCount(200));
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction) => UnitModifySkillPoints(_cthun.Unit, SkillPoints);
  }
}