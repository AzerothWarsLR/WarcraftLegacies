using System;
using System.Linq;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using War3Api;
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

    private Point? Center { get; set; }
    
    public MultiTargetRecall(int id, DummyCast.CastFilter castFilter) : base(id)
    {
      CastFilter = castFilter;
    }
    
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      Center = TargetType == SpellTargetType.None ? new Point(GetUnitX(caster), GetUnitY(caster)) : targetPoint;
    }

    public override void OnStop(unit caster)
    {
      if (Center == null) return;
      foreach (var unit in CreateGroup()
                 .EnumUnitsInRange(Center, Radius).EmptyToList()
                 .FindAll(unit => CastFilter(caster, unit) && !unit.IsResistant())
                 .Take(AmountToTarget))
      {
        SetUnitPosition(unit, GetUnitX(caster), GetUnitY(caster));
      }
    }

    
  }
}