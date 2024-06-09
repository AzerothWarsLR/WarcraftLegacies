using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.PassiveAbilities;
using MacroTools.PassiveAbilitySystem;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.Spells.MassiveAttack
{
  /// <summary>
  /// When the unit deals damage, it casts Shockwave on the target.
  /// The Shockwave deals damage based on the caster's average attack damage.
  /// </summary>
  public sealed class MassiveAttackAbility : PassiveAbility, IAppliesEffectOnDamage
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
      if (!BlzGetEventIsAttack())
        return;

      var caster = GetEventDamageSource();

      DoSpellOnTarget(caster, GetTriggerUnit());
    }

    private void DoSpellOnTarget(unit caster, unit attackTarget)
    {
      var facing = MathEx.GetAngleBetweenPoints(GetUnitX(caster), GetUnitY(caster), GetUnitX(attackTarget),
        GetUnitY(attackTarget));
      var targetX = MathEx.GetPolarOffsetX(GetUnitX(caster), Distance, facing);
      var targetY = MathEx.GetPolarOffsetY(GetUnitY(caster), Distance, facing);
      
      var missile = new MassiveAttackProjectile(caster, targetX, targetY)
      {
        Damage = caster.GetAverageDamage(0) * AttackDamagePercentage,
        AttackType = ConvertAttackType(caster.GetAttackType()),
        DamageType = BlzGetEventDamageType()
      };
      if (IgnoreAttackTarget)
        missile.Hits.Add(attackTarget);
      MissileSystem.Add(missile);
    }
  }
}