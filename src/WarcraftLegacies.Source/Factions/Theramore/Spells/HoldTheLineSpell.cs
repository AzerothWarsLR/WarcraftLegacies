using System;
using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.Utils;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Factions.Theramore.Spells;

/// <summary>Marcus and nearby allied soldiers form up, gaining armor for every other ally in the formation.</summary>
public sealed class HoldTheLineSpell : Spell
{
  private static readonly Dictionary<unit, timer> _expiries = new();

  public required float Radius { get; init; }
  public required float Duration { get; init; }
  public required LeveledAbilityField<float> ArmorPerAlly { get; init; }
  public required LeveledAbilityField<float> MaximumArmor { get; init; }
  public required int ArmorAuraId { get; init; }
  public required float ArmorPerAuraLevel { get; init; }
  public required int MaximumAuraLevel { get; init; }

  public HoldTheLineSpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    var level = GetAbilityLevel(caster);
    var formation = new List<unit> { caster };
    foreach (var nearby in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (nearby != caster && !nearby.IsUnitType(unittype.Hero) && CastFilters.IsTargetAllyAndAlive(caster, nearby) &&
          !nearby.IsUnitType(unittype.Structure))
      {
        formation.Add(nearby);
      }
    }

    var armor = Math.Min(MaximumArmor.GetValue(level), ArmorPerAlly.GetValue(level) * (formation.Count - 1));
    var auraLevel = Math.Min(MaximumAuraLevel, (int)Math.Round(armor / ArmorPerAuraLevel));
    if (auraLevel < 1)
    {
      return;
    }

    foreach (var soldier in formation)
    {
      Apply(soldier, auraLevel);
    }
  }

  private void Apply(unit soldier, int auraLevel)
  {
    if (_expiries.TryGetValue(soldier, out var existing))
    {
      existing.Dispose();
    }
    else
    {
      soldier.AddAbility(ArmorAuraId);
    }

    soldier.SetAbilityLevel(ArmorAuraId, auraLevel);
    var expiry = timer.Create();
    _expiries[soldier] = expiry;
    expiry.Start(Duration, false, () =>
    {
      expiry.Dispose();
      _expiries.Remove(soldier);
      soldier.RemoveAbility(ArmorAuraId);
    });
  }
}
