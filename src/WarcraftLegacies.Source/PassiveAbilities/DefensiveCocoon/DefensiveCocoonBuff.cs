using System;
using MacroTools.Extensions;
using WCSharp.Buffs;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.PassiveAbilities.DefensiveCocoon
{
  public sealed class DefensiveCocoonBuff : PassiveBuff
  {
    private static readonly int[] HeroXpTable = { 100, 120, 160, 220, 300 };
    private unit? _egg;
    private trigger? _deathTrigger;
    private readonly int _originalHeroLevel;

    public required int MaximumHitPoints { private get; init; }
    public required string ReviveEffect { private get; init; }
    public required int EggId { private get; init; }

    public DefensiveCocoonBuff(unit caster, unit target) : base(caster, target)
    {
      _originalHeroLevel = GetHeroLevel(target);
    }
    
    public override void OnApply()
    {
      Target.SetLifePercent(100);
      BlzPauseUnitEx(Target, true);
      ShowUnit(Target, false);

      _egg = CreateUnit(Target.OwningPlayer(), EggId, GetUnitX(Target), GetUnitY(Target), 0);
      _egg.SetTimedLife(Duration + 1);
      BlzSetUnitMaxHP(_egg, MaximumHitPoints);
      _egg.SetLifePercent(100);
      BlzSetUnitArmor(_egg, BlzGetUnitArmor(Target));
      BlzSetUnitName(_egg, $"Cocoon ({Target.GetProperName()})");

      var reviveEffect = AddSpecialEffect(ReviveEffect, GetUnitX(Target), GetUnitY(Target));
      BlzSetSpecialEffectScale(reviveEffect, 2);
      EffectSystem.Add(reviveEffect);

      _deathTrigger = CreateTrigger();
      TriggerRegisterUnitEvent(_deathTrigger, _egg, EVENT_UNIT_DEATH);
      TriggerAddAction(_deathTrigger, () =>
      {
        var killingUnit = GetKillingUnit();
        if (killingUnit != null && IsUnitType(killingUnit, UNIT_TYPE_HERO))
        {
          var index = Math.Min(_originalHeroLevel - 1, HeroXpTable.Length - 1);
          var experienceGained = HeroXpTable[index];
          SetHeroXP(killingUnit, GetHeroXP(killingUnit) + experienceGained, true);
        }

        KillUnit(Target);
      });
    }

    public override void OnDispose()
    {
      if (_deathTrigger != null) 
        DestroyTrigger(_deathTrigger);

      ShowUnit(Target, true);
      BlzPauseUnitEx(Target, false);

      if (UnitAlive(_egg)) 
        Revive();
      else
      {
        KillUnit(Target);
        Target
          .SetPosition(_egg!.GetPosition());
      }
    }

    private void Revive()
    {
      SetUnitState(Target, UNIT_STATE_LIFE, GetUnitState(_egg!, UNIT_STATE_LIFE));
      KillUnit(_egg!);
      Target.SetPosition(_egg!.GetPosition());

      var reviveEffect = AddSpecialEffect(ReviveEffect, GetUnitX(Target), GetUnitY(Target));
      BlzSetSpecialEffectScale(reviveEffect, 2);
      EffectSystem.Add(reviveEffect);
    }
  }
}