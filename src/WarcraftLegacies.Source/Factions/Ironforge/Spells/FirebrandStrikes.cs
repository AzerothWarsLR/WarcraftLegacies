using MacroTools.DummyCasters;
using MacroTools.UnitTraits;
using MacroTools.Utils;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>The unit's attacks set their target burning, and ignite targets under Drunken Haze.</summary>
public sealed class FirebrandStrikes : UnitTrait, IAppliesEffectOnDamage
{
  public required int AbilityTypeId { get; init; }
  public required float DamagePerSecond { get; init; }
  public required float Duration { get; init; }
  public required int BuffApplicatorId { get; init; }
  public required int BuffId { get; init; }
  public required int IgniteAbilityId { get; init; }

  /// <inheritdoc />
  public void OnDealsDamage()
  {
    var attacker = @event.DamageSource;
    var target = @event.Unit;
    if (!@event.IsAttack || attacker.GetAbilityLevel(AbilityTypeId) == 0 || !target.Alive ||
        target.IsUnitType(unittype.Structure) || !target.IsEnemyTo(attacker.Owner))
    {
      return;
    }

    BuffSystem.Add(new FirebrandBuff(attacker, target, BuffApplicatorId, BuffId)
    {
      Duration = Duration,
      Interval = 1,
      DamagePerSecond = DamagePerSecond
    }, StackBehaviour.Stack);

    if (target.GetAbilityLevel(BUFF_BNDH_DRUNKEN_HAZE) > 0)
    {
      Ignite(attacker, target);
    }
  }

  private void Ignite(unit attacker, unit target)
  {
    var angle = MathEx.GetAngleBetweenPoints(attacker.X, attacker.Y, target.X, target.Y);
    var dummy = DummyCasterManager.GetGlobalDummyCaster();
    dummy.SetFacing(angle);
    dummy.CastPointFromCaster(attacker, IgniteAbilityId, ORDER_BREATH_OF_FIRE, 1,
      MathEx.GetPolarOffsetX(target.X, -100, angle), MathEx.GetPolarOffsetY(target.Y, -100, angle));
  }
}

/// <summary>The burn from <see cref="FirebrandStrikes"/>.</summary>
public sealed class FirebrandBuff : BoundBuff
{
  public required float DamagePerSecond { get; set; }

  public FirebrandBuff(unit caster, unit target, int buffApplicatorId, int buffId) : base(caster, target)
  {
    IsBeneficial = false;
    BindAura(buffApplicatorId, buffId);
  }

  /// <inheritdoc />
  public override void OnTick() =>
    Caster.DealDamage(Target, DamagePerSecond, false, false, attacktype.Normal, damagetype.Fire, weapontype.WhoKnows);

  /// <inheritdoc />
  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    return StackResult.Stack;
  }
}
