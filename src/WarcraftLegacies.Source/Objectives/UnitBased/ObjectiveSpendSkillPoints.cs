using MacroTools.Factions;
using MacroTools.Legends;
using MacroTools.Quests;
using WCSharp.Events;

namespace WarcraftLegacies.Source.Objectives.UnitBased;

/// <summary>
/// Complete by spending a certain number of skill points on a specific hero.
/// </summary>
public sealed class ObjectiveSpendSkillPoints : Objective
{
  private readonly LegendaryHero _hero;
  private readonly int _skillPointsRequired;
  private int _pointsSpent;

  public ObjectiveSpendSkillPoints(LegendaryHero hero, int skillPointsRequired)
  {
    _hero = hero;
    _skillPointsRequired = skillPointsRequired;
    Description = $"{hero.Name} has spent {skillPointsRequired} Skill Points";
  }

  /// <inheritdoc />
  public override void OnAdd(Faction faction)
  {
    PlayerUnitEvents.Register(HeroTypeEvent.LearnsSpell, OnSkillPointSpent, _hero.UnitType);
    _hero.PermanentlyDied += OnHeroPermanentlyDied;
  }

  private void OnSkillPointSpent()
  {
    _pointsSpent++;
    if (_pointsSpent >= _skillPointsRequired)
    {
      Progress = QuestProgress.Complete;
    }
  }

  private void OnHeroPermanentlyDied(object? sender, LegendaryHero hero) => Progress = QuestProgress.Failed;
}
