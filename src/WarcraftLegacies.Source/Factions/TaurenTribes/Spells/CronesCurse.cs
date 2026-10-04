using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Events;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.TaurenTribes.Spells;

public sealed class CronesCurse : Spell
{
  public required LeveledAbilityField<float> Healing { get; init; }

  public required float Radius { get; init; }

  public required float Duration { get; init; }

  public required float HeroDuration { get; init; }

  public string BurstEffect { get; init; } = @"Abilities\Spells\Undead\DeathPact\DeathPactTarget.mdl";

  public string HealEffect { get; init; } = @"Abilities\Spells\Orc\HealingWave\HealingWaveTarget.mdl";

  private readonly Dictionary<unit, CurseData> _cursedUnits = new();

  private readonly HashSet<unit> _watchedUnits = new();

  public CronesCurse(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var curse = new CurseData(caster, GetAbilityLevel(caster));
    _cursedUnits[target] = curse;

    if (_watchedUnits.Add(target))
    {
      PlayerUnitEvents.Register(UnitEvent.Dies, () => OnCursedUnitDies(target), target);
    }

    var duration = target.IsUnitType(unittype.Hero) ? HeroDuration : Duration;
    timer.Create().Start(duration, false, () =>
    {
      if (_cursedUnits.TryGetValue(target, out var current) && current == curse)
      {
        _cursedUnits.Remove(target);
      }

      @event.ExpiredTimer.Dispose();
    });
  }

  private void OnCursedUnitDies(unit cursedUnit)
  {
    if (!_cursedUnits.TryGetValue(cursedUnit, out var curse))
    {
      return;
    }

    _cursedUnits.Remove(cursedUnit);
    effect.Create(BurstEffect, cursedUnit.X, cursedUnit.Y).Dispose();
    var healing = Healing.GetValue(curse.Level);
    foreach (var ally in GlobalGroup.EnumUnitsInRange(cursedUnit.X, cursedUnit.Y, Radius))
    {
      if (!ally.IsAllyTo(curse.Caster.Owner) || !ally.Alive || ally.IsUnitType(unittype.Structure) ||
          ally.IsUnitType(unittype.Mechanical))
      {
        continue;
      }

      ally.Life += healing;
      effect.Create(HealEffect, ally, "origin").Dispose();
    }
  }

  private sealed class CurseData
  {
    public CurseData(unit caster, int level)
    {
      Caster = caster;
      Level = level;
    }

    public unit Caster { get; }

    public int Level { get; }
  }
}
