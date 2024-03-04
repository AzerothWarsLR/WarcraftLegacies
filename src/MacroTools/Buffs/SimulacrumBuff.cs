using MacroTools.Extensions;
using WCSharp.Buffs;


namespace MacroTools.Buffs
{
  public sealed class SimulacrumBuff : PassiveBuff
  {
    private readonly float _damageScale;
    private readonly float _effectScaleTarget;
    private readonly string _effectTarget;
    private readonly float _hitpointScale;

    public SimulacrumBuff(unit caster, unit target, float damageScale, float hitPointScale, string effectTarget,
      float effectScaleTarget) : base(caster, target)
    {
      _damageScale = damageScale;
      _hitpointScale = hitPointScale;
      _effectTarget = effectTarget;
      _effectScaleTarget = effectScaleTarget;
    }

    public override void OnDeath(bool killingBlow)
    {
      Active = false;
      base.OnDeath(killingBlow);
    }

    public override void OnDispose()
    {
      var tempEffect = AddSpecialEffect(_effectTarget, GetUnitX(Target), GetUnitY(Target));
      BlzSetSpecialEffectScale(tempEffect, _effectScaleTarget);
      DestroyEffect(tempEffect);
      KillUnit(Target);
      RemoveUnit(Target);
      base.OnDispose();
    }

    public override void OnApply()
    {
      UnitAddType(Target, UNIT_TYPE_SUMMONED);
      UnitApplyTimedLife(Target, 0, Duration);
      SetUnitVertexColor(Target, 100, 100, 230, 150);
      Target.MultiplyBaseDamage(_damageScale, 0);
      Target.MultiplyMaxHitpoints(_hitpointScale);
      var tempEffect = AddSpecialEffect(_effectTarget, GetUnitX(Target), GetUnitY(Target));
      BlzSetSpecialEffectScale(tempEffect, _effectScaleTarget);
      DestroyEffect(tempEffect);
    }
  }
}