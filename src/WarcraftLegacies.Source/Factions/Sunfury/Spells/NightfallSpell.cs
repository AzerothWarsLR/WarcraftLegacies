using MacroTools.DummyCasters;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Sunfury.Spells;

/// <summary>Covers an area in darkness that silences and damages enemies inside and restores mana to the caster's units.</summary>
public sealed class NightfallSpell : Spell
{
  private const float Interval = 1;

  public required float Radius { get; init; }
  public required float Duration { get; init; }
  public required LeveledAbilityField<float> DamagePerSecond { get; init; }
  public required LeveledAbilityField<float> ManaPerSecond { get; init; }
  public required int SilenceAbilityId { get; init; }
  public required string CastEffectPath { get; init; }
  public required string AreaEffectPath { get; init; }
  public required float AreaEffectScale { get; init; }

  public NightfallSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var center = new Point(targetPoint.X, targetPoint.Y);
    effect.Create(CastEffectPath, center.X, center.Y).Dispose();
    var area = effect.Create(AreaEffectPath, center.X, center.Y);
    area.Scale = AreaEffectScale;
    Pulse(caster, center, level);
    var elapsed = 0f;
    var pulses = timer.Create();
    pulses.Start(Interval, true, () =>
    {
      elapsed += Interval;
      if (elapsed >= Duration)
      {
        pulses.Dispose();
        area.Dispose();
        return;
      }

      Pulse(caster, center, level);
    });
  }

  private void Pulse(unit caster, Point center, int level)
  {
    DummyCasterManager.GetGlobalDummyCaster().CastPoint(caster.Owner, SilenceAbilityId, ORDER_SILENCE, 1, center);
    var damage = DamagePerSecond.GetValue(level);
    var mana = ManaPerSecond.GetValue(level);
    foreach (var unit in GlobalGroup.EnumUnitsInRange(center.X, center.Y, Radius))
    {
      if (!unit.Alive || unit.UnitType == DummyCasterManager.UnitTypeId)
      {
        continue;
      }

      if (unit.Owner == caster.Owner)
      {
        if (unit.MaxMana > 0)
        {
          unit.Mana += mana;
        }

        continue;
      }

      if (unit.IsEnemyTo(caster.Owner) && !unit.IsUnitType(unittype.Structure))
      {
        caster.DealDamage(unit, damage, false, false, attacktype.Magic, damagetype.Magic, weapontype.WhoKnows);
      }
    }
  }
}
