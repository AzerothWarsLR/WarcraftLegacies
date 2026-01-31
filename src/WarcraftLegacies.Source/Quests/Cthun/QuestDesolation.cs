using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.Cthun;

public sealed class QuestDesolation : QuestData
{
  private readonly LegendaryHero _cthun;
  private readonly ObjectiveDestroyAnyCapital _objectiveDestroyAnyCapital;
  private const int SkillPoints = 2;

  /// <inheritdoc/>
  public override string RewardFlavour =>
    $"{_objectiveDestroyAnyCapital.DestroyedCapital?.Name} has fallen, merely the first in a row of dominoes that will topple this world.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    $"C'thun gain {SkillPoints} skill points";

  /// <inheritdoc />
  public QuestDesolation(LegendaryHero cthun) : base("Desolation",
    "Before this time of mortals, the Old Gods ruled this world, our empires stretching to every corner. I will bury their cities, and return Azeroth to primordial chaos.",
    @"ReplaceableTextures\CommandButtons\BTNWallOfFire.blp")
  {
    _cthun = cthun;
    _objectiveDestroyAnyCapital = new ObjectiveDestroyAnyCapital();
    AddObjective(_objectiveDestroyAnyCapital);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction) => _cthun.Unit.AddSkillPoints(SkillPoints);
}
