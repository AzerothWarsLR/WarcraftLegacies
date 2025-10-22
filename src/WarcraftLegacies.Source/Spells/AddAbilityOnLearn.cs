using MacroTools.Spells;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// A spell that, when learned, teaches the hero another spell of the same level.
/// </summary>
public sealed class AddAbilityOnLearn : Spell, IEffectOnLearn
{
  /// <inheritdoc />
  public AddAbilityOnLearn(int id) : base(id)
  {
  }

  public required int AbilityToAddId { get; init; }

  /// <inheritdoc />
  public void OnLearn(unit learner)
  {
    var targetLevel = learner.GetAbilityLevel(Id);

    if (learner.GetAbilityLevel(AbilityToAddId) == 0)
    {
      learner.AddAbility(AbilityToAddId);
    }

    learner.SetAbilityLevel(AbilityToAddId, targetLevel);
  }
}
