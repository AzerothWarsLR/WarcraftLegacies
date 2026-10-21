using MacroTools.DummyCasters;
using MacroTools.Extensions;
using MacroTools.Hazards;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.FallenPrince.Spells;

/// <summary>Summons a ward that keeps stripping buffs from enemies and debuffs from allies, healing itself for each.</summary>
public sealed class WardOfCorruptionSpell : Spell
{
  public required int WardTypeId { get; init; }
  public required LeveledAbilityField<int> WardHealth { get; init; }
  public required float Duration { get; init; }
  public required float PulseInterval { get; init; }
  public required float Radius { get; init; }
  public required float HealPerEffect { get; init; }
  public required string PulseEffectPath { get; init; }
  public required string StripEffectPath { get; init; }

  public WardOfCorruptionSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var health = WardHealth.GetValue(GetAbilityLevel(caster));
    var ward = unit.Create(caster.Owner, WardTypeId, targetPoint.X, targetPoint.Y, 270);
    ward.MaxLife = health;
    ward.Life = health;
    ward.SetTimedLife(Duration);
    HazardSystem.Add(new WardOfCorruptionPulse(caster, ward)
    {
      Radius = Radius,
      HealPerEffect = HealPerEffect,
      PulseEffectPath = PulseEffectPath,
      StripEffectPath = StripEffectPath,
      Interval = PulseInterval,
      Duration = Duration + PulseInterval
    });
  }
}

/// <summary>The ward's periodic dispel.</summary>
public sealed class WardOfCorruptionPulse : Hazard
{
  private readonly unit _ward;

  public required float Radius { get; init; }
  public required float HealPerEffect { get; init; }
  public required string PulseEffectPath { get; init; }
  public required string StripEffectPath { get; init; }

  public WardOfCorruptionPulse(unit caster, unit ward) : base(caster, ward.X, ward.Y)
  {
    _ward = ward;
  }

  protected override void OnPeriodic()
  {
    if (!_ward.Alive)
    {
      Duration = 0;
      return;
    }

    effect.Create(PulseEffectPath, _ward.X, _ward.Y).Dispose();
    var owner = _ward.Owner;
    var removed = 0;
    foreach (var unit in GlobalGroup.EnumUnitsInRange(_ward.X, _ward.Y, Radius))
    {
      if (unit == _ward || !unit.Alive || unit.IsUnitType(unittype.Structure) ||
          unit.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      if (unit.IsEnemyTo(owner))
      {
        removed += Strip(unit, true);
      }
      else if (unit.IsAllyTo(owner))
      {
        removed += Strip(unit, false);
      }
    }

    if (removed > 0)
    {
      _ward.Life += removed * HealPerEffect;
    }
  }

  private int Strip(unit target, bool positive)
  {
    var before = target.CountBuffs(positive, !positive, true, false, false, false, false);
    if (before == 0)
    {
      return 0;
    }

    target.RemoveBuffs(positive, !positive, true, false, false, false, false);
    effect.Create(StripEffectPath, target, "origin").Dispose();
    return before - target.CountBuffs(positive, !positive, true, false, false, false, false);
  }
}
