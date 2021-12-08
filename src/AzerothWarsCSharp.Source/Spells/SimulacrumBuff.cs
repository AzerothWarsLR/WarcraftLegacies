using AzerothWarsCSharp.MacroTools;
using AzerothWarsCSharp.Source.Libraries;
using WCSharp.Buffs;
using static War3Api.Common;

namespace AzerothWarsCSharp.Source.Spells
{
  public class SimulacrumBuff : PassiveBuff
  {
    private readonly float _damageScale;
    private readonly float _hitpointScale;
    private readonly float _timedLifeDuration;
    private readonly string _effectTarget;
    private readonly float _effectScaleTarget;
    
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