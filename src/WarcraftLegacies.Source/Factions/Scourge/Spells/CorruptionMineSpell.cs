using MacroTools.DummyCasters;
using MacroTools.Hazards;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Scourge.Spells;

public sealed class CorruptionMineSpell : Spell
{
  public required LeveledAbilityField<float> Damage { get; init; }
  public required float BlastRadius { get; init; }
  public required float TriggerRadius { get; init; }
  public required float ArmTime { get; init; }
  public required float Lifetime { get; init; }
  public required int StunAbilityId { get; init; }
  public required string MinePath { get; init; }
  public float MineScale { get; init; } = 1;
  public required string EruptionPath { get; init; }
  public float EruptionScale { get; init; } = 1;
  public float EruptionDuration { get; init; } = 1;

  public CorruptionMineSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);

    HazardSystem.Add(new CorruptionMineHazard(caster, targetPoint.X, targetPoint.Y)
    {
      Damage = Damage.GetValue(level),
      AbilityLevel = level,
      BlastRadius = BlastRadius,
      TriggerRadius = TriggerRadius,
      ArmTime = ArmTime,
      StunAbilityId = StunAbilityId,
      MinePath = MinePath,
      MineScale = MineScale,
      EruptionPath = EruptionPath,
      EruptionScale = EruptionScale,
      EruptionDuration = EruptionDuration,
      Interval = 0.1f,
      Duration = Lifetime
    });
  }
}

public sealed class CorruptionMineHazard : Hazard
{
  private readonly unit _caster;
  private effect? _mineEffect;
  private effect? _eruptionEffect;
  private float _age;
  private float _eruptionTimeLeft;
  private bool _armed;
  private bool _erupted;

  public float Damage { get; init; }
  public int AbilityLevel { get; init; }
  public float BlastRadius { get; init; }
  public float TriggerRadius { get; init; }
  public float ArmTime { get; init; }
  public int StunAbilityId { get; init; }
  public required string MinePath { get; init; }
  public float MineScale { get; init; } = 1;
  public required string EruptionPath { get; init; }
  public float EruptionScale { get; init; } = 1;
  public float EruptionDuration { get; init; } = 1;

  public CorruptionMineHazard(unit caster, float x, float y) : base(caster, x, y)
  {
    _caster = caster;
  }

  public override void OnCreate()
  {
    _mineEffect = effect.Create(MinePath, Position.X, Position.Y);
    _mineEffect.Scale = MineScale;
  }

  protected override void OnPeriodic()
  {
    if (_erupted)
    {
      _eruptionTimeLeft -= Interval;
      if (_eruptionTimeLeft <= 0)
      {
        Duration = 0;
      }

      return;
    }

    _age += Interval;

    if (!_armed)
    {
      if (_age < ArmTime)
      {
        return;
      }

      Arm();
    }

    if (IsTriggered())
    {
      Erupt();
    }
  }

  protected override void OnDispose()
  {
    _mineEffect?.Dispose();
    _eruptionEffect?.Dispose();
  }

  private void Arm()
  {
    _armed = true;
    _mineEffect?.Dispose();

    var visiblePath = _caster.IsAllyTo(player.LocalPlayer) ? MinePath : "";
    _mineEffect = effect.Create(visiblePath, Position.X, Position.Y);
    _mineEffect.Scale = MineScale;
  }

  private bool IsTriggered()
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRange(Position.X, Position.Y, TriggerRadius))
    {
      if (IsEnemy(unit) && !unit.IsUnitType(unittype.Flying))
      {
        return true;
      }
    }

    return false;
  }

  private void Erupt()
  {
    _erupted = true;
    _eruptionTimeLeft = EruptionDuration;
    _mineEffect?.Dispose();
    _mineEffect = null;

    _eruptionEffect = effect.Create(EruptionPath, Position.X, Position.Y);
    _eruptionEffect.Scale = EruptionScale;

    var dummyCaster = DummyCasterManager.GetGlobalDummyCaster();
    foreach (var unit in GlobalGroup.EnumUnitsInRange(Position.X, Position.Y, BlastRadius))
    {
      if (!IsEnemy(unit))
      {
        continue;
      }

      _caster.DealDamage(unit, Damage, false, false, attacktype.Normal, damagetype.Magic, weapontype.WhoKnows);
      dummyCaster.CastUnit(_caster, StunAbilityId, ORDER_THUNDERBOLT, AbilityLevel, unit,
        DummyCastOriginType.Target);
    }
  }

  private bool IsEnemy(unit target)
  {
    return target.Alive
           && !target.IsInvulnerable
           && target.IsEnemyTo(_caster.Owner)
           && !target.IsUnitType(unittype.Structure)
           && target.UnitType != DummyCasterManager.UnitTypeId;
  }
}
