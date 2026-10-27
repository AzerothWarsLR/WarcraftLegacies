using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sunfury.Spells;

/// <summary>Fills Tempest Keep's barrier with lightning, damaging every enemy unit inside it over time.</summary>
public sealed class TempestStormSpell : Spell
{
  public required Point Center { get; init; }
  public required float RadiusX { get; init; }
  public required float RadiusY { get; init; }
  public required float Duration { get; init; }
  public required float TickInterval { get; init; }
  public required float DamagePerTick { get; init; }
  public required string StormEffectPath { get; init; }
  public required float StormEffectScale { get; init; }
  public required float StormEffectSpacing { get; init; }
  public required int StormRed { get; init; }
  public required int StormGreen { get; init; }
  public required int StormBlue { get; init; }

  public TempestStormSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var storm = CreateStorm();
    var elapsed = 0f;
    var ticker = timer.Create();
    ticker.Start(TickInterval, true, () =>
    {
      elapsed += TickInterval;
      if (elapsed > Duration || !caster.Alive)
      {
        ticker.Dispose();
        foreach (var fx in storm)
        {
          fx.Dispose();
        }

        return;
      }

      DamageEnemiesInside(caster);
    });
  }

  private List<effect> CreateStorm()
  {
    var storm = new List<effect>();
    for (var offsetX = -RadiusX; offsetX <= RadiusX; offsetX += StormEffectSpacing)
    {
      for (var offsetY = -RadiusY; offsetY <= RadiusY; offsetY += StormEffectSpacing)
      {
        var x = Center.X + offsetX;
        var y = Center.Y + offsetY;
        if (!IsInside(x, y))
        {
          continue;
        }

        var fx = effect.Create(StormEffectPath, x, y);
        BlzSetSpecialEffectScale(fx, StormEffectScale);
        BlzSetSpecialEffectColor(fx, StormRed, StormGreen, StormBlue);
        storm.Add(fx);
      }
    }

    return storm;
  }

  private bool IsInside(float x, float y)
  {
    var dx = (x - Center.X) / RadiusX;
    var dy = (y - Center.Y) / RadiusY;
    return dx * dx + dy * dy <= 1;
  }

  private void DamageEnemiesInside(unit caster)
  {
    foreach (var victim in GlobalGroup.EnumUnitsInRange(Center.X, Center.Y, MathEx.Max(RadiusX, RadiusY)))
    {
      if (!CastFilters.IsTargetEnemyAndAliveUnits(caster, victim) || victim.UnitType == DummyCasterManager.UnitTypeId ||
          victim.IsUnitType(unittype.Structure) || !IsInside(victim.X, victim.Y))
      {
        continue;
      }

      caster.DealDamage(victim, DamagePerTick, false, false, attacktype.Magic, damagetype.Magic, weapontype.WhoKnows);
    }
  }
}
