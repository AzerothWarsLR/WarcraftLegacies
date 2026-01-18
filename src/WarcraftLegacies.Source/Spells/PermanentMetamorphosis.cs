using MacroTools.Legends;
using MacroTools.Spells;

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

  public string? LearnEffectPath { get; init; }

  public required int UnitTypeId { get; init; }

  public void OnLearn(unit learner)
  {
    if (learner.UnitType != UnitTypeId)
    {
      TransformHero(learner);
      return;
    }

    var level = learner.GetAbilityLevel(Id);

    if (level == 1)
    {
      learner.MaxLife += HitPointBonus.Base + HitPointBonus.PerLevel;
    }
    else
    {
      learner.AttackBaseDamage1 += DamageBonus.PerLevel;
      learner.MaxLife += HitPointBonus.PerLevel;
    }
  }

  /// <summary>
  /// Transforms the hero into their alternate form.
  /// <remarks>Only happens once, when the ability is first learned.</remarks>
  /// </summary>
  private void TransformHero(unit learner)
  {
    var legend = LegendaryHeroManager.GetFromUnit(learner);
    if (legend?.Unit != null)
    {
      legend.UnitType = UnitTypeId;
    }

    var illidan = legend!.Unit!;
    illidan.AddAnimationProperty("alternate");
    if (LearnEffectPath != null)
    {
      effect.Create(LearnEffectPath, illidan.X, illidan.Y).Dispose();
    }

    illidan.SelectHeroSkill(Id);
  }
}
