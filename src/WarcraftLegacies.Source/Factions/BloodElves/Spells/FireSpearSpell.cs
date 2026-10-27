using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Hazards;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Missiles;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.BloodElves.Spells;

/// <summary>Hurls a spear of fire in a line, damaging each enemy it passes and leaving burning ground behind it.</summary>
public sealed class FireSpearSpell : Spell
{
  public required float Damage { get; init; }
  public required float MaximumDamage { get; init; }
  public required float Range { get; init; }
  public required float Width { get; init; }
  public required float Speed { get; init; }
  public required float TrailSpacing { get; init; }
  public required float TrailRadius { get; init; }
  public required float TrailDamagePerSecond { get; init; }
  public required float TrailDuration { get; init; }
  public required string SpearPath { get; init; }
  public required string HitEffectPath { get; init; }
  public required string TrailEffectPath { get; init; }
  public required string BurnEffectPath { get; init; }
  public required ArcaneHunger Hunger { get; init; }

  private readonly HashSet<unit> _burnedThisSecond = new();
  private timer? _burnReset;

  public FireSpearSpell(int id) : base(id)
  {
  }

  /// <summary>Whether <paramref name="target"/> can take burning damage now; each unit burns at most once a second.</summary>
  public bool TryBurn(unit target)
  {
    if (_burnedThisSecond.Contains(target))
    {
      return false;
    }

    _burnedThisSecond.Add(target);
    if (_burnReset == null)
    {
      _burnReset = timer.Create();
      _burnReset.Start(1, true, () => _burnedThisSecond.Clear());
    }

    return true;
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var multiplier = Hunger.GetDamageMultiplier(caster);
    Hunger.Consume(caster);
    var angle = MathEx.GetAngleBetweenPoints(caster.X, caster.Y, targetPoint.X, targetPoint.Y);
    var end = new Point(MathEx.GetPolarOffsetX(caster.X, Range, angle), MathEx.GetPolarOffsetY(caster.Y, Range, angle));
    MissileSystem.Add(new FireSpearMissile(caster.Owner, caster.X, caster.Y, end.X, end.Y)
    {
      Caster = caster,
      EffectString = SpearPath,
      Speed = Speed,
      CollisionRadius = Width,
      Interval = TrailSpacing / Speed,
      CasterLaunchZ = 60,
      TargetImpactZ = 60,
      Damage = Damage * multiplier,
      TrailDamagePerSecond = TrailDamagePerSecond * multiplier,
      Budget = new FireSpearBudget { Remaining = MaximumDamage * multiplier },
      Spell = this,
      Active = true
    });
  }

  /// <summary>Leaves a patch of burning ground at the point.</summary>
  public void Ignite(unit caster, float x, float y, float damagePerSecond, FireSpearBudget budget)
  {
    HazardSystem.Add(new BurningGroundHazard(caster, x, y)
    {
      Spell = this,
      Budget = budget,
      Radius = TrailRadius,
      DamagePerTick = damagePerSecond,
      FlamePath = TrailEffectPath,
      BurnEffectPath = BurnEffectPath,
      Interval = 1,
      Duration = TrailDuration
    });
  }
}

/// <summary>The spear thrown by <see cref="FireSpearSpell"/>.</summary>
public sealed class FireSpearMissile : BasicMissile
{
  public required float Damage { get; init; }
  public required float TrailDamagePerSecond { get; init; }
  public required FireSpearBudget Budget { get; init; }
  public required FireSpearSpell Spell { get; init; }

  public FireSpearMissile(player castingPlayer, float casterX, float casterY, float targetX, float targetY) :
    base(castingPlayer, casterX, casterY, targetX, targetY)
  {
  }

  public override void OnCollision(unit unit)
  {
    if (!CastFilters.IsTargetEnemyAndAliveUnits(Caster, unit) || unit.UnitType == DummyCasterManager.UnitTypeId)
    {
      return;
    }

    var damage = Budget.Take(Damage);
    if (damage <= 0)
    {
      return;
    }

    effect.Create(Spell.HitEffectPath, unit, "chest").Dispose();
    Caster.DealDamage(unit, damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
  }

  public override void OnPeriodic() => Spell.Ignite(Caster, MissileX, MissileY, TrailDamagePerSecond, Budget);
}

/// <summary>A patch of burning ground left by <see cref="FireSpearSpell"/>.</summary>
public sealed class BurningGroundHazard : Hazard
{
  private readonly unit _caster;
  private readonly float _x;
  private readonly float _y;
  private effect? _flame;

  public required float Radius { get; init; }
  public required float DamagePerTick { get; init; }
  public required FireSpearBudget Budget { get; init; }
  public required FireSpearSpell Spell { get; init; }
  public required string FlamePath { get; init; }
  public required string BurnEffectPath { get; init; }

  public BurningGroundHazard(unit caster, float x, float y) : base(caster, x, y)
  {
    _caster = caster;
    _x = x;
    _y = y;
  }

  public override void OnCreate()
  {
    _flame = effect.Create(FlamePath, _x, _y);
  }

  protected override void OnPeriodic()
  {
    foreach (var target in GlobalGroup.EnumUnitsInRange(_x, _y, Radius))
    {
      if (!CastFilters.IsTargetEnemyAndAliveUnits(_caster, target) || target.UnitType == DummyCasterManager.UnitTypeId ||
          target.IsUnitType(unittype.Structure) || !Spell.TryBurn(target))
      {
        continue;
      }

      var damage = Budget.Take(DamagePerTick);
      if (damage <= 0)
      {
        return;
      }

      effect.Create(BurnEffectPath, target, "chest").Dispose();
      _caster.DealDamage(target, damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    }
  }

  protected override void OnDispose()
  {
    if (_flame != null)
    {
      _flame.Dispose();
    }
  }
}

/// <summary>The damage one <see cref="FireSpearSpell"/> cast has left to deal.</summary>
public sealed class FireSpearBudget
{
  public float Remaining { get; set; }

  /// <summary>Takes up to <paramref name="amount"/> from what's left and returns how much was taken.</summary>
  public float Take(float amount)
  {
    var taken = amount < Remaining ? amount : Remaining;
    Remaining -= taken;
    return taken;
  }
}
