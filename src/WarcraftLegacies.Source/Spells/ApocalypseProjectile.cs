using MacroTools.DummyCasters;
using MacroTools.Extensions;
using WCSharp.Effects;
using WCSharp.Events;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.Spells;

public sealed class ApocalypseProjectile : BasicMissile
{
  public float Damage { get; init; }

  public string EffectOnHitModel { get; init; } = "";

  public float EffectOnHitScale { get; init; }

  public int DummyAbilityId { get; init; }

  public int DummyAbilityOrderId { get; init; }

  public int DummyAbilityLevel { get; init; }

  public string EffectOnProjectileDespawnModel { get; init; } = "";

  public float EffectOnProjectileDespawnScale { get; init; }

  /// <inheritdoc />
  public ApocalypseProjectile(player castingPlayer, float casterX, float casterY, float targetX, float targetY) :
    base(castingPlayer, casterX, casterY, targetX, targetY)
  {
    Interval = PeriodicEvents.SYSTEM_INTERVAL;
  }

  /// <inheritdoc />
  public override void OnCollision(unit unit)
  {
    if (!IsValidTarget(Caster, unit))
    {
      return;
    }

    unit.TakeDamage(Caster, Damage, false, false, damageType: damagetype.Normal);

    DummyCaster.Cast(Caster, DummyAbilityId, DummyAbilityOrderId, DummyAbilityLevel, unit,
      DummyCastOriginType.Target);

    effect effect = effect.Create(EffectOnHitModel, unit.X, unit.Y);
    effect.Scale = EffectOnHitScale;
    EffectSystem.Add(effect);
  }

  /// <inheritdoc />
  public override void OnPeriodic()
  {
    Effect.SetColor(player.Create(3));
    Effect.PlayAnimation(animtype.Walk);
    Effect.SetAlpha(175);
    Interval = 0;
  }

  /// <inheritdoc />
  public override void OnDispose()
  {
    Effect.SetPosition(21623f, 24212f, 0);
    effect effect = effect.Create(EffectOnProjectileDespawnModel, MissileX, MissileY);
    effect.Scale = EffectOnProjectileDespawnScale;
    EffectSystem.Add(effect);
  }

  private static bool IsValidTarget(unit target, unit caster) =>
    target.Alive &&
    !target.IsUnitType(unittype.Structure) &&
    !target.IsUnitType(unittype.Ancient) &&
    !target.IsUnitType(unittype.Mechanical) &&
    !caster.Owner.IsAlly(target.Owner);
}
