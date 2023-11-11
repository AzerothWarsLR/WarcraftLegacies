using System;
using System.Linq;
using MacroTools.Buffs;
using MacroTools.DummyCasters;
using MacroTools.Extensions;
using MacroTools.Libraries;
using MacroTools.SpellSystem;
using WCSharp.Buffs;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Spells
{
  /// <summary>Summons a limited number of units from an area to the caster's position.</summary>
  public sealed class DelayedMultiTargetRecall : Spell
  {
    public float Radius { get; init; }
    
    /// <summary>How many units get summoned by the spell.</summary>
    public int AmountToTarget { get; init; }

    public SpellTargetType TargetType { get; init; } = SpellTargetType.None;
    
    private DummyCasterManager.CastFilter CastFilter { get; }
    
    public DelayedMultiTargetRecall(int id, DummyCasterManager.CastFilter castFilter) : base(id)
    {
      CastFilter = castFilter;
    }
    
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var center = TargetType == SpellTargetType.None ? new Point(GetUnitX(caster), GetUnitY(caster)) : targetPoint;
      var duration =
        Math.Clamp(
          (int)Math.Floor(MathEx.GetDistanceBetweenPoints(new Point(GetUnitX(caster), GetUnitY(caster)), center)/1000), 3,
          30);
      var targets = CreateGroup()
        .EnumUnitsInRange(center, Radius)
        .EmptyToList()
        .Where(unit => CastFilter(caster, unit) && !unit.IsResistant() && unit != caster)
        .Take(AmountToTarget)
        .ToList();
      var delayedRecallBuff = new DelayedRecallBuff(caster, caster, targets)
      {
        InitialDuration = duration,
        Duration = duration
      };
      BuffSystem.Add(delayedRecallBuff);
    }
  }
}