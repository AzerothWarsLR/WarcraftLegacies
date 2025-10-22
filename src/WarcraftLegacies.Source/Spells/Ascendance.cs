using System.Collections.Generic;
using MacroTools.Spells;
using MacroTools.Utils;
using WarcraftLegacies.Source.Buffs;
using WCSharp.Buffs;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

/// <summary>
/// Heals nearby friendly units and removes specific abilities from the caster for a limited duration.
/// </summary>
public sealed class Ascendance : Spell
{
  public float DurationBase { get; init; }
  public float DurationLevel { get; init; }
  public float HealBase { get; init; }
  public float HealLevel { get; init; }
  public float Radius { get; init; }

  public IEnumerable<int>? AbilitiesToRemove { get; init; }

  public Ascendance(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    foreach (var unit in GlobalGroup.EnumUnitsInRange(caster.X, caster.Y, Radius))
    {
      if (caster.Owner.IsAlly(unit.Owner))
      {
        unit.Life += HealBase + HealLevel * GetAbilityLevel(caster);
      }
    }
    var ascendancyBuff = new AscendancyBuff(caster, caster)
    {
      Duration = DurationBase + DurationLevel * GetAbilityLevel(caster),
      AbilitiesToRemove = AbilitiesToRemove
    };
    BuffSystem.Add(ascendancyBuff);
  }
}
