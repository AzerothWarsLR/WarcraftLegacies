using MacroTools.DummyCasters;
using MacroTools.Extensions;
using WCSharp.Effects;
using WCSharp.Events;
using WCSharp.Missiles;
using WCSharp.Shared.Data;


namespace WarcraftLegacies.Source.Spells
{
  public sealed class ApocalypseProjectile : BasicMissile
  {
    private readonly GlobalDummyCaster _dummyCaster;

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
      _dummyCaster = DummyCasterManager.GetGlobalDummyCaster();
      Interval = PeriodicEvents.SYSTEM_INTERVAL;
    }

    /// <inheritdoc />
    public override void OnCollision(unit unit)
    {
      if (!IsValidTarget(Caster, unit))
        return;
      
      unit.TakeDamage(Caster, Damage, false, false, damageType: DAMAGE_TYPE_NORMAL);
      
      _dummyCaster.CastUnit(Caster, DummyAbilityId, DummyAbilityOrderId, DummyAbilityLevel, unit,
        DummyCastOriginType.Target);

      var collisionEffect = AddSpecialEffect(EffectOnHitModel, GetUnitX(unit), GetUnitY(unit));
      collisionEffect.SetTimeScale(EffectOnHitScale);
      EffectSystem.Add(collisionEffect);
    }

    /// <inheritdoc />
    public override void OnPeriodic()
    {
      BlzSetSpecialEffectColorByPlayer(Effect, Player(3));
      BlzPlaySpecialEffect(Effect, ANIM_TYPE_WALK);
      BlzSetSpecialEffectAlpha(Effect, 175);
      Interval = 0;
    }

    /// <inheritdoc />
    public override void OnDispose()
    {
      Point point = new Point(21623f, 24212f);
      Effect.SetPosition(point.X, point.Y, 0);
      var disposeEffect = AddSpecialEffect(EffectOnProjectileDespawnModel, MissileX, MissileY);
      disposeEffect.SetTimeScale(EffectOnProjectileDespawnScale);
      EffectSystem.Add(disposeEffect);
    }

    private static bool IsValidTarget(unit target, unit caster) =>
      UnitAlive(target) &&
      !IsUnitType(target, UNIT_TYPE_STRUCTURE) &&
      !IsUnitType(target, UNIT_TYPE_ANCIENT) && 
      !IsUnitType(target, UNIT_TYPE_MECHANICAL) &&
      !IsPlayerAlly(caster.Owner, target.Owner);
  }
}