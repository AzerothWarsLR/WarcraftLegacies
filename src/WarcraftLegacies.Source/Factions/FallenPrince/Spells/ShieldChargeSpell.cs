using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Hazards;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FallenPrince.Spells;

/// <summary>The caster charges at a target, shoving enemies aside, then strikes and stuns it.</summary>
public sealed class ShieldChargeSpell : Spell
{
  public required LeveledAbilityField<float> Damage { get; init; }
  public required float Speed { get; init; }
  public required int StunAbilityId { get; init; }
  public required string ImpactEffectPath { get; init; }

  public ShieldChargeSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    HazardSystem.Add(new ShieldCharge(caster, target)
    {
      Damage = Damage.GetValue(GetAbilityLevel(caster)),
      Speed = Speed,
      StunAbilityId = StunAbilityId,
      ImpactEffectPath = ImpactEffectPath,
      Interval = 0.03f,
      Duration = 2
    });
  }
}

/// <summary>Moves a charging unit toward its target each tick and pushes enemies out of its path.</summary>
public sealed class ShieldCharge : Hazard
{
  private const float ArrivalDistance = 100;
  private const float ShoveRadius = 125;
  private const float ShoveDistance = 175;
  private const float ShoveDuration = 0.3f;

  private readonly unit _caster;
  private readonly unit _target;
  private readonly List<ShovedUnit> _shoved = new();
  private readonly HashSet<unit> _alreadyShoved = new();
  private bool _finished;

  public required float Damage { get; init; }
  public required float Speed { get; init; }
  public required int StunAbilityId { get; init; }
  public required string ImpactEffectPath { get; init; }

  public ShieldCharge(unit caster, unit target) : base(caster, caster.X, caster.Y)
  {
    _caster = caster;
    _target = target;
  }

  public override void OnCreate()
  {
    _caster.SetPausedEx(true);
    _caster.SetPathing(false);
    _caster.SetAnimation("walk");
    _caster.SetTimeScale(2);
  }

  protected override void OnPeriodic()
  {
    MoveShovedUnits();
    if (_finished)
    {
      if (_shoved.Count == 0)
      {
        Duration = 0;
      }

      return;
    }

    if (!_caster.Alive || !_target.Alive)
    {
      Finish();
      return;
    }

    var dx = _target.X - _caster.X;
    var dy = _target.Y - _caster.Y;
    var distance = SquareRoot(dx * dx + dy * dy);
    if (distance <= ArrivalDistance)
    {
      Strike();
      return;
    }

    var step = Speed * Interval;
    if (step > distance - ArrivalDistance + 1)
    {
      step = distance - ArrivalDistance + 1;
    }

    var newX = _caster.X + dx / distance * step;
    var newY = _caster.Y + dy / distance * step;
    if (pathingtype.Walkability.GetPathable(newX, newY))
    {
      Finish();
      return;
    }

    _caster.X = newX;
    _caster.Y = newY;
    _caster.Facing = MathEx.GetAngleBetweenPoints(newX, newY, _target.X, _target.Y);
    ShoveEnemies(dx / distance, dy / distance);
  }

  protected override void OnDispose()
  {
    if (!_finished)
    {
      Finish();
    }
  }

  private void ShoveEnemies(float directionX, float directionY)
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRange(_caster.X, _caster.Y, ShoveRadius))
    {
      if (unit == _target || _alreadyShoved.Contains(unit) || !unit.Alive || !unit.IsEnemyTo(_caster.Owner) ||
          unit.IsUnitType(unittype.Structure) || unit.IsUnitType(unittype.Flying) || unit.IsInvulnerable ||
          unit.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      var side = directionX * (unit.Y - _caster.Y) - directionY * (unit.X - _caster.X) >= 0 ? 1 : -1;
      var speed = ShoveDistance / ShoveDuration;
      _alreadyShoved.Add(unit);
      _shoved.Add(new ShovedUnit(unit, -directionY * side * speed, directionX * side * speed, ShoveDuration));
    }
  }

  private void MoveShovedUnits()
  {
    foreach (var shoved in _shoved.ToArray())
    {
      shoved.TimeLeft -= Interval;
      var newX = shoved.Unit.X + shoved.VelocityX * Interval;
      var newY = shoved.Unit.Y + shoved.VelocityY * Interval;
      if (!shoved.Unit.Alive || shoved.TimeLeft <= 0 || pathingtype.Walkability.GetPathable(newX, newY))
      {
        _shoved.Remove(shoved);
        continue;
      }

      shoved.Unit.X = newX;
      shoved.Unit.Y = newY;
    }
  }

  private void Strike()
  {
    effect.Create(ImpactEffectPath, _target.X, _target.Y).Dispose();
    _caster.DealDamage(_target, Damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
    DummyCasterManager.GetGlobalDummyCaster().CastUnit(_caster, StunAbilityId, ORDER_THUNDERBOLT, 1, _target,
      DummyCastOriginType.Target);
    Finish();
    if (_target.Alive)
    {
      _caster.IssueOrder(ORDER_ATTACK, _target);
    }
  }

  private void Finish()
  {
    _finished = true;
    _caster.SetTimeScale(1);
    _caster.SetPathing(true);
    _caster.SetPausedEx(false);
    _caster.SetAnimation("stand");
  }

  private sealed class ShovedUnit
  {
    public ShovedUnit(unit unit, float velocityX, float velocityY, float timeLeft)
    {
      Unit = unit;
      VelocityX = velocityX;
      VelocityY = velocityY;
      TimeLeft = timeLeft;
    }

    public unit Unit { get; }
    public float VelocityX { get; }
    public float VelocityY { get; }
    public float TimeLeft { get; set; }
  }
}
