using MacroTools.Data;
using MacroTools.LegendSystem;
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

  public string? LearnEffectPath { get; init; }

  public required int UnitTypeId { get; init; }

  public void OnLearn(unit learner)
  {
    if (learner.UnitType != UnitTypeId)
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
        var learnEffect = AddSpecialEffect(LearnEffectPath, illidan.X, illidan.Y);
        learnEffect.Dispose();
      }

      illidan.SelectHeroSkill(Id);
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
}
