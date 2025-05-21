using MacroTools.SpellSystem;
using static War3Api.Common;

namespace MacroTools.Spells
{
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
      var trig = CreateTrigger();

      for (var i = 0; i < 24; i++)
      {
        var player = Player(i);
        if (GetPlayerController(player) == MAP_CONTROL_USER)
        {
          TriggerRegisterPlayerUnitEvent(trig, player, EVENT_PLAYER_HERO_SKILL, null);
        }
      }

      TriggerAddAction(trig, OnAbilityLearned);
    }

    private void OnAbilityLearned()
    {
      var learningUnit = GetTriggerUnit();

      if (GetUnitTypeId(learningUnit) != UnitTypeId) return;
      if (GetLearnedSkill() != TargetAbilityId) return;

      AddOrUpdateAbility(learningUnit);
    }

    private void AddOrUpdateAbility(unit whichUnit)
    {
      var targetLevel = GetUnitAbilityLevel(whichUnit, TargetAbilityId);

      if (GetUnitAbilityLevel(whichUnit, AbilityToAddId) == 0)
      {
        UnitAddAbility(whichUnit, AbilityToAddId);
      }

      SetUnitAbilityLevel(whichUnit, AbilityToAddId, targetLevel);
    }
  }
}