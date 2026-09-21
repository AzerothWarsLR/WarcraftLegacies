using MacroTools.DummyCasters;
using MacroTools.Hazards;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Buffs;
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
  public required int CorruptionAbilityId { get; init; }
  public required int CorruptionBuffApplicatorId { get; init; }
  public required int CorruptionBuffId { get; init; }
  public required float CorruptionDuration { get; init; }
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
      CorruptionAbilityId = CorruptionAbilityId,
      CorruptionBuffApplicatorId = CorruptionBuffApplicatorId,
      CorruptionBuffId = CorruptionBuffId,
      CorruptionDuration = CorruptionDuration,
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
  public int CorruptionAbilityId { get; init; }
  public int CorruptionBuffApplicatorId { get; init; }
  public int CorruptionBuffId { get; init; }
  public float CorruptionDuration { get; init; }
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
      BuffSystem.Add(new CorruptionMineDebuff(_caster, unit, CorruptionBuffApplicatorId, CorruptionBuffId,
        CorruptionAbilityId)
      {
        Duration = CorruptionDuration
      }, StackBehaviour.Stack);
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

public sealed class CorruptionMineDebuff : BoundBuff
{
  private readonly int _corruptionAbilityId;
  private bool _applied;

  public CorruptionMineDebuff(unit caster, unit target, int buffApplicatorId, int buffId, int corruptionAbilityId) :
    base(caster, target)
  {
    _corruptionAbilityId = corruptionAbilityId;
    BindAura(buffApplicatorId, buffId);
  }

  public override void OnApply()
  {
    _applied = true;
    Target.AddAbility(_corruptionAbilityId);
  }

  public override StackResult OnStack(Buff newStack)
  {
    Duration = newStack.Duration;
    return StackResult.Stack;
  }

  public override void OnDispose()
  {
    if (_applied)
    {
      Target.RemoveAbility(_corruptionAbilityId);
    }

    base.OnDispose();
  }
}
