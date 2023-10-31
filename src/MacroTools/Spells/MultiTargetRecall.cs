using System.Linq;
using MacroTools.DummyCasters;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using static War3Api.Common;

namespace MacroTools.Spells
{
  /// <summary>Summons a limited number of units from an area to the caster's position.</summary>
  public sealed class MultiTargetRecall : Spell
  {
    public float Radius { get; init; }
    
    /// <summary>How many units get summoned by the spell.</summary>
    public int AmountToTarget { get; init; }

    public SpellTargetType TargetType { get; init; } = SpellTargetType.None;

    private Point? Center { get; set; }
    
    private DummyCasterManager.CastFilter CastFilter { get; }
    
    public MultiTargetRecall(int id, DummyCasterManager.CastFilter castFilter) : base(id)
    {
      CastFilter = castFilter;
    }
    
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var center = TargetType == SpellTargetType.None ? new Point(GetUnitX(caster), GetUnitY(caster)) : targetPoint;
      var targets = CreateGroup()
        .EnumUnitsInRange(center, Radius)
        .EmptyToList()
        .Where(unit => CastFilter(caster, unit) && !unit.IsResistant() && unit != caster)
        .Take(AmountToTarget);
      
      foreach (var unit in targets) 
        SetUnitPosition(unit, GetUnitX(caster), GetUnitY(caster));
    }

    
  }
}