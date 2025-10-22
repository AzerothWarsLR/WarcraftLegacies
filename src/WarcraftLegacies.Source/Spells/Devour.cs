using MacroTools.Data;
using MacroTools.Extensions;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Instantly kills the target unit, or damages it if it's Resistant. Also heals the caster.
/// </summary>
public sealed class Devour : Spell
{
  /// <summary>
  /// How much to heal the caster for.
  /// </summary>
  public float PercentageOfMaxHealth { get; init; } = 0.5f;

  /// <summary>
  /// How much damage to deal to resistant targets.
  /// </summary>
  public LeveledAbilityField<float> Damage { get; init; } = new();

  /// <summary>
  /// Initializes a new instance of the <see cref="Devour"/> class.
  /// </summary>
  /// <param name="id"><inheritdoc /></param>
  public Devour(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    if (target.IsResistant())
    {
      target.TakeDamage(caster, Damage.Base + Damage.PerLevel * GetAbilityLevel(caster), damageType: damagetype.Magic);
    }
    else
    {
      target.TakeDamage(caster, target.Life, damageType: damagetype.Universal, attackType: attacktype.Chaos);
    }

    caster.Life += caster.MaxLife * PercentageOfMaxHealth;
  }
}
