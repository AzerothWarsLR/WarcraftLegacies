using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.UnitTypeTraits;
using WarcraftLegacies.Source.UnitTypeTraits;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.Spells.MassiveAttack;

/// <summary>
/// When the unit deals damage, it casts Shockwave on the target.
/// The Shockwave deals damage based on the caster's average attack damage.
/// </summary>
public sealed class MassiveAttackAbility : UnitTypeTrait, IAppliesEffectOnDamage
{
  /// <summary>
  /// Damage is equal to this percentage of the caster's attack damage.
  /// </summary>
  public required float AttackDamagePercentage { get; init; }

  /// <summary>
  /// How far the wave travels.
  /// </summary>
  public required float Distance { get; init; }

  /// <summary>
  /// If set, additional damage is NOT dealt to the attack target the ability was triggered against.
  /// </summary>
  public bool IgnoreAttackTarget { get; init; }

  /// <summary>
  /// Initializes a new instance of the <see cref="SpellOnAttack"/> class.
  /// </summary>
  /// <param name="unitTypeId"><inheritdoc /></param>
  public MassiveAttackAbility(int unitTypeId) : base(unitTypeId)
  {
  }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    if (!@event.IsAttack)
    {
      return;
    }

    var caster = @event.DamageSource;

    DoSpellOnTarget(caster, @event.Unit);
  }

  private void DoSpellOnTarget(unit caster, unit attackTarget)
  {
    var facing = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, attackTarget.X,
      attackTarget.Y);
    var targetX = MathEx.GetPolarOffsetX(caster.X, Distance, facing);
    var targetY = MathEx.GetPolarOffsetY(caster.Y, Distance, facing);

    var missile = new MassiveAttackProjectile(caster, targetX, targetY)
    {
      Damage = caster.GetAverageDamage(0) * AttackDamagePercentage,
      AttackType = ConvertAttackType((int)caster.AttackAttackType1),
      DamageType = @event.DamageType
    };
    if (IgnoreAttackTarget)
    {
      missile.Hits.Add(attackTarget);
    }

    MissileSystem.Add(missile);
  }
}
