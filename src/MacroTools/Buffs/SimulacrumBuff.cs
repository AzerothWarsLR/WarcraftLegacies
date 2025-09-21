using MacroTools.Extensions;
using WCSharp.Buffs;

namespace MacroTools.Buffs;

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
    var tempEffect = effect.Create(_effectTarget, Target.X, Target.Y);
    tempEffect.Scale = _effectScaleTarget;
    tempEffect.Dispose();
    Target.Kill();
    Target.Dispose();
    base.OnDispose();
  }

  public override void OnApply()
  {
    Target.AddType(unittype.Summoned);
    Target.ApplyTimedLife(0, Duration);
    Target.SetVertexColor(100, 100, 230, 150);
    Target.MultiplyBaseDamage(_damageScale, 0);
    Target.MultiplyMaxHitpoints(_hitpointScale);
    var tempEffect = effect.Create(_effectTarget, Target.X, Target.Y);
    tempEffect.Scale = _effectScaleTarget;
    tempEffect.Dispose();
  }
}
