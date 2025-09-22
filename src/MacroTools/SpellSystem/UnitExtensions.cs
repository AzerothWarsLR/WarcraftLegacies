namespace MacroTools.SpellSystem;

public static class UnitExtensions
{
  /// <summary>
  /// Selects the hero skill for the hero, triggering any <see cref="IEffectOnLearn.OnLearn"/> callbacks.
  /// </summary>
  public static void SelectHeroSkillWithEvents(this unit unit, int abilityId)
  {
    if (SpellSystem.TryGetSpellByAbilityId(abilityId, out var spell))
    {
      if (spell is IEffectOnLearn effectOnLearn)
      {
        effectOnLearn.OnLearn(unit);
      }
    }

    unit.SelectHeroSkill(abilityId);
  }
}
