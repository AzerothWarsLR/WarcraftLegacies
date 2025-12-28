using System.Collections.Generic;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.Utils;
using WCSharp.Buffs;
using WCSharp.Missiles;

namespace WarcraftLegacies.Source.Spells.AvengersShield;

public sealed class AvengersShieldProjectile : BasicMissile
{
  public float Damage { get; init; }
  public int RemainingBounces { get; set; }
  public float BounceRadius { get; init; }
  public float SilenceDuration { get; init; }
  public float BounceDelay { get; init; }
  public float DamageFalloff { get; init; }
  public bool IsReturn { get; init; }
  public string ImpactEffect { get; init; }

  private readonly List<unit> _hitUnits = new();

  public AvengersShieldProjectile(unit source, unit target)
    : base(source, target.X, target.Y)
  {
    CollisionRadius = 100f;
    CasterZ = 60;
    TargetImpactZ = 60;
  }

  public override void OnCollision(unit target)
  {
    if (IsReturn)
    {
      Dispose();
      return;
    }

    if (!IsValidTarget(target))
    {
      return;
    }

    Caster.DealDamage(
      target,
      Damage,
      false,
      false,
      attacktype.Normal,
      damagetype.Magic,
      weapontype.WhoKnows);

    _hitUnits.Add(target);

    if (!string.IsNullOrEmpty(ImpactEffect))
    {
      effect.Create(ImpactEffect, target, "origin").Dispose();
    }

    ApplySilence(target);

    RemainingBounces--;

    if (RemainingBounces > 0)
    {
      var nextTarget = FindNextTarget(target);
      if (nextTarget != null)
      {
        var source = target;
        timer.Create().Start(BounceDelay, false, () =>
        {
          var bounceMissile = new AvengersShieldProjectile(source, nextTarget)
          {
            Damage = Damage * DamageFalloff,
            RemainingBounces = RemainingBounces,
            BounceRadius = BounceRadius,
            SilenceDuration = SilenceDuration,
            BounceDelay = BounceDelay,
            DamageFalloff = DamageFalloff,
            Speed = Speed,
            EffectString = EffectString,
            ImpactEffect = ImpactEffect
          };

          bounceMissile._hitUnits.AddRange(_hitUnits);
          MissileSystem.Add(bounceMissile);
          @event.ExpiredTimer.Dispose();
        });
      }
      else
      {
        ReturnToCaster(target);
      }
    }
    else
    {
      ReturnToCaster(target);
    }

    Dispose();
  }

  private void ReturnToCaster(unit from)
  {
    timer.Create().Start(BounceDelay, false, () =>
    {
      var returnMissile = new AvengersShieldProjectile(from, Caster)
      {
        IsReturn = true,
        Speed = Speed,
        EffectString = EffectString,
        CollisionRadius = 150f
      };

      MissileSystem.Add(returnMissile);
      @event.ExpiredTimer.Dispose();
    });
  }

  private unit FindNextTarget(unit from)
  {
    var position = from.GetPosition();
    return GlobalGroup.EnumUnitsInRange(position, BounceRadius)
      .Where(u =>
        u.Alive &&
        !u.IsUnitType(unittype.Structure) &&
        !Caster.Owner.IsAlly(u.Owner) &&
        !_hitUnits.Contains(u))
      .OrderBy(u => MathEx.GetDistanceBetweenPoints(position, u.GetPosition()))
      .FirstOrDefault();
  }

  private void ApplySilence(unit target)
  {
    BuffSystem.Add(new AvengersShieldBuff(Caster, target)
    {
      Active = true,
      Duration = SilenceDuration,
      IsBeneficial = false
    });
  }

  private bool IsValidTarget(unit target)
  {
    return target.Alive &&
           !target.IsUnitType(unittype.Structure) &&
           !Caster.Owner.IsAlly(target.Owner) &&
           !_hitUnits.Contains(target);
  }
}
