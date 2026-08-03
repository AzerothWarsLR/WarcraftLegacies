namespace MacroTools.UnitTraits;

/// <summary>
/// Called when the unit learns any ability.
/// </summary>
public interface IEffectOnAbilityLearned
{
  void OnAbilityLearned(unit learner);
}
