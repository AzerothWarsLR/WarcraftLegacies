using System;
using MacroTools.Extensions;
using WCSharp.Buffs;

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
      Target
        .SetLifePercent(100)
        .PauseEx(true)
        .Show(false);
      
      _egg = CreateUnit(Target.OwningPlayer(), EggId, GetUnitX(Target), GetUnitY(Target), 0)
        .SetTimedLife(Duration + 1)
        .SetMaximumHitpoints(MaximumHitPoints)
        .SetLifePercent(100)
        .SetArmor((int)BlzGetUnitArmor(Target))
        .SetName($"Cocoon ({Target.GetProperName()})");
      
      AddSpecialEffect(ReviveEffect, GetUnitX(Target), GetUnitY(Target))
        .SetScale(2)
        .SetLifespan();

      _deathTrigger = CreateTrigger()
        .RegisterUnitEvent(_egg, EVENT_UNIT_DEATH)
        .AddAction(() => {
          var killingUnit = GetKillingUnit();
          if (killingUnit != null && IsUnitType(killingUnit, UNIT_TYPE_HERO))
          {
            var index = Math.Min(_originalHeroLevel - 1, HeroXpTable.Length - 1);
            var experienceGained = HeroXpTable[index];
            SetHeroXP(killingUnit, GetHeroXP(killingUnit) + experienceGained, true);
          }
          Target.Kill();
        });
    }

    public override void OnDispose()
    {
      _deathTrigger?.Destroy();
      Target
        .Show(true)
        .PauseEx(false);

      if (UnitAlive(_egg)) 
        Revive();
      else
      {
        Target
          .Kill()
          .SetPosition(_egg!.GetPosition());
      }
    }

    private void Revive()
    {
      Target.SetCurrentHitpoints(_egg!.GetCurrentHitPoints());
      _egg!.Kill();
      Target.SetPosition(_egg!.GetPosition());
      
      AddSpecialEffect(ReviveEffect, GetUnitX(Target), GetUnitY(Target))
        .SetScale(2)
        .SetLifespan();
    }
  }
}