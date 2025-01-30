using MacroTools.FactionSystem;
using MacroTools.LegendSystem;
using MacroTools.ObjectiveSystem.Objectives.LegendBased;
using MacroTools.QuestSystem;

namespace WarcraftLegacies.Source.Quests.Cthun
{
  public sealed class QuestDesolation : QuestData
  {
    private readonly LegendaryHero _cthun;
    private readonly ObjectiveDestroyAnyCapital _objectiveDestroyAnyCapital;
    private const int SkillPoints = 2;

    /// <inheritdoc/>
    public override string RewardFlavour =>
      $"{_objectiveDestroyAnyCapital.DestroyedCapital?.Name} has fallen, merely the first in a row of dominos that will topple this world.";

    /// <inheritdoc/>
    protected override string RewardDescription =>
      $"C'thun gain {SkillPoints} skill points";

    /// <inheritdoc />
    public QuestDesolation(LegendaryHero cthun) : base("Desolation",
      "Before this time of mortals, The Old Gods ruled this world, our empires stretching to every corner. I will bury their cities, and return Azeroth to primordial chaos.",
      @"ReplaceableTextures\CommandButtons\BTNWallOfFire.blp")
    {
      _cthun = cthun;
      _objectiveDestroyAnyCapital = new ObjectiveDestroyAnyCapital();
      AddObjective(_objectiveDestroyAnyCapital);
    }

    /// <inheritdoc/>
    protected override void OnComplete(Faction completingFaction) => UnitModifySkillPoints(_cthun.Unit, SkillPoints);
  }
}