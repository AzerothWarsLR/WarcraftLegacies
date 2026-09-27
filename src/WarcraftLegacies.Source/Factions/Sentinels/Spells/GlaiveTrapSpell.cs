using MacroTools.DummyCasters;
using MacroTools.Hazards;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sentinels.Spells;

public sealed class GlaiveTrapEffectSettings
{
  public string? GlaivePath { get; init; }
  public float GlaiveScale { get; init; } = 1;
  public int AllyGlaiveAlpha { get; init; } = 255;
  public string? EruptionPath { get; init; }
  public float EruptionScale { get; init; } = 1;
  public float EruptionDuration { get; init; } = 1;
}

public sealed class GlaiveTrapSpell : Spell
{
  public required LeveledAbilityField<float> Damage { get; init; }
  public required float BlastRadius { get; init; }
  public required float TriggerRadius { get; init; }
  public required float ArmTime { get; init; }
  public required float Lifetime { get; init; }
  public required int TrapCount { get; init; }
  public required float SpreadFraction { get; init; }
  public required int StunAbilityId { get; init; }
  public required GlaiveTrapEffectSettings Effects { get; init; }

  public GlaiveTrapSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var areaRadius = caster.GetAbility(Id).GetAreaOfEffect_aare(level - 1);
    var startAngle = GetRandomReal(0, 2 * MathEx.Pi);

    for (var i = 0; i < TrapCount; i++)
    {
      var angle = startAngle + 2 * MathEx.Pi * i / TrapCount;
      var distance = areaRadius * SpreadFraction;
      HazardSystem.Add(new GlaiveTrapHazard(caster, targetPoint.X + distance * Cos(angle),
        targetPoint.Y + distance * Sin(angle))
      {
        Damage = Damage.GetValue(level),
        AbilityLevel = level,
        BlastRadius = BlastRadius,
        TriggerRadius = TriggerRadius,
        ArmTime = ArmTime,
        StunAbilityId = StunAbilityId,
        Effects = Effects,
        Interval = 0.1f,
        Duration = Lifetime
      });
    }
  }
}

public sealed class GlaiveTrapHazard : Hazard
{
  private readonly unit _caster;
  private effect? _glaiveEffect;
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
  public required GlaiveTrapEffectSettings Effects { get; init; }

  public GlaiveTrapHazard(unit caster, float x, float y) : base(caster, x, y)
  {
    _caster = caster;
  }

  public override void OnCreate()
  {
    if (Effects.GlaivePath != null)
    {
      _glaiveEffect = effect.Create(Effects.GlaivePath, Position.X, Position.Y);
      _glaiveEffect.Scale = Effects.GlaiveScale;
    }
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
    _glaiveEffect?.Dispose();
    _eruptionEffect?.Dispose();
  }

  private void Arm()
  {
    _armed = true;
    _glaiveEffect?.Dispose();
    _glaiveEffect = null;

    if (Effects.GlaivePath == null)
    {
      return;
    }

    var visiblePath = _caster.IsAllyTo(player.LocalPlayer) ? Effects.GlaivePath : "";
    _glaiveEffect = effect.Create(visiblePath, Position.X, Position.Y);
    _glaiveEffect.Scale = Effects.GlaiveScale;
    _glaiveEffect.SetAlpha(Effects.AllyGlaiveAlpha);
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
    _eruptionTimeLeft = Effects.EruptionDuration;
    _glaiveEffect?.Dispose();
    _glaiveEffect = null;

    if (Effects.EruptionPath != null)
    {
      _eruptionEffect = effect.Create(Effects.EruptionPath, Position.X, Position.Y);
      _eruptionEffect.Scale = Effects.EruptionScale;
    }

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
