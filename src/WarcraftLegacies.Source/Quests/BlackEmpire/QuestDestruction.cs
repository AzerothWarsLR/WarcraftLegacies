using MacroTools.FactionSystem;
using MacroTools.Legends;
using MacroTools.Quests;
using WarcraftLegacies.Source.Objectives.LegendBased;

namespace WarcraftLegacies.Source.Quests.BlackEmpire;

public sealed class QuestDestruction : QuestData
{
  private readonly LegendaryHero _nzoth;
  private readonly ObjectiveDestroyAnyCapital _objectiveDestroyAnyCapital;
  private const int SkillPoints = 2;

  /// <inheritdoc/>
  public override string RewardFlavour =>
    $"{_objectiveDestroyAnyCapital.DestroyedCapital?.Name} has fallen, but more will fall to my influence.";

  /// <inheritdoc/>
  protected override string RewardDescription =>
    $"N'zoth gain {SkillPoints} skill points";

  /// <inheritdoc />
  public QuestDestruction(LegendaryHero nzoth) : base("Destruction",
    "Before this time of mortals, The Old Gods ruled this world, our empires stretching to every corner. I will bury their cities, and return Azeroth to primordial chaos.",
    @"ReplaceableTextures\CommandButtons\BTNWallOfFire.blp")
  {
    _nzoth = nzoth;
    _objectiveDestroyAnyCapital = new ObjectiveDestroyAnyCapital();
    AddObjective(_objectiveDestroyAnyCapital);
  }

  /// <inheritdoc/>
  protected override void OnComplete(Faction completingFaction) => _nzoth.Unit.AddSkillPoints(SkillPoints);
}
