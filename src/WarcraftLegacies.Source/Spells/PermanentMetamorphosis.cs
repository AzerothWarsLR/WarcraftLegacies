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

  public int[] UnitTypeIdsByLevel { get; init; } = System.Array.Empty<int>();

  public string? LearnEffectPath { get; init; }

  /// <inheritdoc />
  public void OnLearn(unit learner)
  {
    var level = learner.GetAbilityLevel(Id);

    var legend = LegendaryHeroManager.GetFromUnit(learner);
    if (legend == null)
    {
      return;
    }

    legend.UnitType = UnitTypeIdsByLevel[level-1];

    if (level == 1)
    {
      if (LearnEffectPath != null)
      {
        var learnEffect = AddSpecialEffect(LearnEffectPath, learner.X, learner.Y);
        learnEffect.Dispose();
      }
    }

    learner.MaxLife += HitPointBonus.Base + HitPointBonus.PerLevel;
  }
}
