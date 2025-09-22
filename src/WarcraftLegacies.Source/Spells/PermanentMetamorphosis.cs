using MacroTools.Data;
using MacroTools.SpellSystem;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// When learned, permanently turns the hero into a demon with a ranged attack.
/// </summary>
public sealed class PermanentMetamorphosis : Spell, IEffectOnLearn
{
  public PermanentMetamorphosis(int id) : base(id)
  {
  }

  public LeveledAbilityField<int> HitPointBonus { get; init; } = new();

  public LeveledAbilityField<int> DamageBonus { get; init; } = new();

  /// <summary>
  /// Adds the specified Chaos-based ability to the hero to transform it into a demon.
  /// </summary>
  public int ChaosAbilityTypeId { get; init; }

  public string? LearnEffectPath { get; init; }

  /// <inheritdoc />
  public void OnLearn(unit learner)
  {
    var level = learner.GetAbilityLevel(Id);

    if (level == 1)
    {
      learner.AddAbility(ChaosAbilityTypeId);
      if (LearnEffectPath != null)
      {
        var learnEffect = AddSpecialEffect(LearnEffectPath, learner.X, learner.Y);
        learnEffect.Dispose();
      }
      learner.MaxLife += HitPointBonus.Base + HitPointBonus.PerLevel;
      learner.AttackBaseDamage1 += DamageBonus.Base + DamageBonus.PerLevel;
    }
    else
    {
      learner.MaxLife += DamageBonus.PerLevel;
      learner.AttackBaseDamage1 += DamageBonus.PerLevel;
    }
  }
}
