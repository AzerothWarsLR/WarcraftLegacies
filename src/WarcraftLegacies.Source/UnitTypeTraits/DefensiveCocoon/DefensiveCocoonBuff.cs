using System;
using MacroTools.Extensions;
using WCSharp.Buffs;
using WCSharp.Effects;

namespace WarcraftLegacies.Source.UnitTypeTraits.DefensiveCocoon;

public sealed class DefensiveCocoonBuff : PassiveBuff
{
  private static readonly int[] _heroXpTable = { 100, 120, 160, 220, 300 };
  private unit? _egg;
  private trigger? _deathTrigger;
  private readonly int _originalHeroLevel;

  public required int MaximumHitPoints { private get; init; }
  public required string ReviveEffect { private get; init; }
  public required int EggId { private get; init; }

  public DefensiveCocoonBuff(unit caster, unit target) : base(caster, target)
  {
    _originalHeroLevel = target.HeroLevel;
  }

  public override void OnApply()
  {
    Target.SetLifePercent(100);
    Target.SetPausedEx(true);
    Target.IsVisible = false;

    _egg = unit.Create(Target.Owner, EggId, Target.X, Target.Y, 0);
    _egg.SetTimedLife(Duration + 1);
    _egg.MaxLife = MaximumHitPoints;
    _egg.SetLifePercent(100);
    _egg.Armor = Target.Armor;
    _egg.Name = $"Cocoon ({Target.GetProperName()})";

    var reviveEffect = effect.Create(ReviveEffect, Target.X, Target.Y);
    reviveEffect.Scale = 2;
    EffectSystem.Add(reviveEffect);

    _deathTrigger = trigger.Create();
    _deathTrigger.RegisterUnitEvent(_egg, unitevent.Death);
    _deathTrigger.AddAction(() =>
    {
      var killingUnit = @event.KillingUnit;
      if (killingUnit != null && killingUnit.IsUnitType(unittype.Hero))
      {
        var index = Math.Min(_originalHeroLevel - 1, _heroXpTable.Length - 1);
        var experienceGained = _heroXpTable[index];
        killingUnit.SetExperience(killingUnit.Experience + experienceGained, true);
      }

      Target.Kill();
    });
  }

  public override void OnDispose()
  {
    if (_deathTrigger != null)
    {
      _deathTrigger.Dispose();
    }

    Target.IsVisible = true;
    Target.SetPausedEx(false);

    if (_egg.Alive)
    {
      Revive();
    }
    else
    {
      Target.Kill();
      Target.SetPosition(_egg!.X, _egg!.Y);
    }
  }

  private void Revive()
  {
    Target.Life = _egg!.Life;
    _egg!.Kill();
    Target.SetPosition(_egg!.X, _egg!.Y);

    var reviveEffect = effect.Create(ReviveEffect, Target.X, Target.Y);
    reviveEffect.Scale = 2;
    EffectSystem.Add(reviveEffect);
  }
}
