using MacroTools.SpellSystem;

namespace MacroTools.Spells;

/// <summary>
/// Adds a specific ability to a unit when it learns a target ability,
/// and keeps the levels of both abilities synchronized.
/// </summary>
public sealed class AddAbilityOnLearn : Spell
{
  public int UnitTypeId { get; init; }
  public int TargetAbilityId { get; init; }
  public int AbilityToAddId { get; init; }

  public AddAbilityOnLearn(int id) : base(id)
  {
    var trig = trigger.Create();

    for (var i = 0; i < 24; i++)
    {
      player player = player.Create(i);
      if (player.Controller == mapcontrol.User)
      {
        trig.RegisterPlayerUnitEvent(player, playerunitevent.HeroSkill);
      }
    }

    trig.AddAction(OnAbilityLearned);
  }

  private void OnAbilityLearned()
  {
    var learningUnit = @event.Unit;

    if (learningUnit.UnitType != UnitTypeId)
    {
      return;
    }

    if (@event.LearnedSkill != TargetAbilityId)
    {
      return;
    }

    AddOrUpdateAbility(learningUnit);
  }

  private void AddOrUpdateAbility(unit whichUnit)
  {
    var targetLevel = whichUnit.GetAbilityLevel(TargetAbilityId);

    if (whichUnit.GetAbilityLevel(AbilityToAddId) == 0)
    {
      whichUnit.AddAbility(AbilityToAddId);
    }

    whichUnit.SetAbilityLevel(AbilityToAddId, targetLevel);
  }
}
