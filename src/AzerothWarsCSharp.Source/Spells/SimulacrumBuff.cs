using System.IO;
using AzerothWarsCSharp.Source.Libraries;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Spells
{
  public class SimulacrumBuff : PassiveBuff
  {
    private float _damageScale;
    private float _hitpointScale;
    private float _timedLifeDuration;
    private string _effectTarget;
    private float _effectScaleTarget;
    
    public override void OnDeath(bool killingBlow)
    {
      RemoveUnit(Target);
    }

    public override void OnApply()
    {
      UnitAddType(Target, UNIT_TYPE_SUMMONED);
      UnitApplyTimedLife(Target, 0, _timedLifeDuration);
      SetUnitVertexColor(Target, 100, 100, 230, 150);
      GeneralHelpers.ScaleUnitBaseDamage(Target, _damageScale, 0);
      GeneralHelpers.ScaleUnitMaxHitpoints(Target, _hitpointScale);
      var tempEffect = AddSpecialEffect(_effectTarget, GetUnitX(Target), GetUnitY(Target));
      BlzSetSpecialEffectScale(tempEffect, _effectScaleTarget);
      DestroyEffect(tempEffect);
    }
    
    public SimulacrumBuff(unit caster, unit target, float damageScale, float hitPointScale, float timedLifeDuration, string effectTarget, float effectScaleTarget) : base(caster, target)
    {
      _damageScale = damageScale;
      _hitpointScale = hitPointScale;
      _timedLifeDuration = timedLifeDuration;
      _effectTarget = effectTarget;
      _effectScaleTarget = effectScaleTarget;
    }
  }
}