namespace MacroTools.SpellSystem;

public static class UnitExtensions
{
  public static void SetAbilityLevelWithEvents(this unit unit, int abilityId, int level)
  {
    var currentLevel = unit.GetAbilityLevel(abilityId);
    if (SpellSystem.TryGetSpellByAbilityId(abilityId, out var spell))
    {
      if (spell is IEffectOnLearn effectOnLearn)
      {
        if (level > currentLevel)
        {
          for (var i = currentLevel; i < level; i++)
          {
            effectOnLearn.OnLearn(unit);
          }
        }
      }
    }
    unit.SetAbilityLevel(abilityId, level);
  }
}
