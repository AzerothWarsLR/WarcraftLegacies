using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Ironforge.Spells;

/// <summary>Inscribes a rune on the ground that pulses, damaging and slowing enemies standing on it.</summary>
public sealed class ShadowforgeRuneSpell : Spell
{
  public required float Radius { get; init; }
  public required float Duration { get; init; }
  public required float PulseInterval { get; init; }
  public required float DamagePerPulse { get; init; }
  public required int SlowAbilityId { get; init; }
  public required string RunePath { get; init; }
  public required float RuneScale { get; init; }
  public required string PulseEffectPath { get; init; }

  public ShadowforgeRuneSpell(int id) : base(id)
  {
  }

  /// <inheritdoc />
  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var x = targetPoint.X;
    var y = targetPoint.Y;
    var rune = effect.Create(RunePath, x, y);
    rune.Scale = RuneScale;
    var elapsed = 0f;
    var pulser = timer.Create();
    pulser.Start(PulseInterval, true, () =>
    {
      elapsed += PulseInterval;
      Pulse(caster, x, y);
      if (elapsed >= Duration)
      {
        pulser.Dispose();
        rune.Dispose();
      }
    });
  }

  private void Pulse(unit caster, float x, float y)
  {
    foreach (var victim in GlobalGroup.EnumUnitsInRange(x, y, Radius))
    {
      if (!CastFilters.IsTargetEnemyAndAliveUnits(caster, victim) || victim.UnitType == DummyCasterManager.UnitTypeId ||
          victim.IsUnitType(unittype.Structure))
      {
        continue;
      }

      effect.Create(PulseEffectPath, victim, "origin").Dispose();
      caster.DealDamage(victim, DamagePerPulse, false, false, attacktype.Magic, damagetype.Fire, weapontype.WhoKnows);
      if (victim.Alive)
      {
        DummyCasterManager.GetGlobalDummyCaster()
          .CastUnit(caster, SlowAbilityId, ORDER_SLOW, 1, victim, DummyCastOriginType.Target);
      }
    }
  }
}
