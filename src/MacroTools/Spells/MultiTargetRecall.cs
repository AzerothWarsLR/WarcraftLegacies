using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Spells
{
  public sealed class MultiTargetRecall : Spell
  {
    public float Radius { get; init; }
    
    public int AmountToTarget { get; init; }

    private DummyCast.CastFilter CastFilter { get; }
    
    public SpellTargetType TargetType { get; init; } = SpellTargetType.None;
    
    public MultiTargetRecall(int id, DummyCast.CastFilter castFilter) : base(id)
    {
      CastFilter = castFilter;
    }
    
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      base.OnCast(caster, target, targetPoint);
      var center = TargetType == SpellTargetType.None ? new Point(GetUnitX(caster), GetUnitY(caster)) : targetPoint;
      foreach (var unit in CreateGroup()
                 .EnumUnitsInRange(center, Radius).EmptyToList()
                 .FindAll(unit => CastFilter(caster, unit))
                 .Take(AmountToTarget))
      {
        SetUnitPosition(unit, GetUnitX(caster), GetUnitY(caster));
      }
    }
  }
}