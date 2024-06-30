using System;
using System.Linq;
using MacroTools.Buffs;
using MacroTools.Extensions;
using MacroTools.Instances;
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
    
    /// <summary>The minimum number of seconds the spell will take to finish.</summary>
    public int MinDuration { get; init; }
    
    /// <summary>The maximum number of seconds the spell will take to finish.</summary>
    public int MaxDuration { get; init; }
    
    /// <summary>
    /// How long it takes to travel between two <see cref="Instance"/>s with no <see cref="Gate"/>s connecting them.
    /// </summary>
    public int CrossDimensionalDuration { get; init; }
    
    /// <summary>The value used to divide the distance to calculate the time. smaller value means spell will take longer and larger value means spell will be quicker</summary>
    public int DistanceDivider { get; init; }
    
    /// <summary>The percentage of units to lose when the caster dies (rounded down)</summary>
    public float DeathPenalty { get; init; }

    public SpellTargetType TargetType { get; init; } = SpellTargetType.None;
    
    public DelayedMultiTargetRecall(int id) : base(id)
    {
    }
    
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var center = TargetType == SpellTargetType.None ? new Point(GetUnitX(caster), GetUnitY(caster)) : targetPoint;
      
      var distance = InstanceSystem.GetDistanceBetweenPointsEx(new Point(GetUnitX(caster), GetUnitY(caster)), center);
      var distanceDuration = (int)distance / DistanceDivider;
      var finalDuration = distance == -1 
        ? CrossDimensionalDuration 
        : Math.Clamp(distanceDuration, MinDuration, MaxDuration);

      var targets = CreateGroup()
        .EnumUnitsInRange(center, Radius)
        .EmptyToList()
        .Where(x => IsValidTarget(caster, x))
        .Take(AmountToTarget)
        .ToList();

      if (!targets.Any())
        return;
      
      var delayedRecallBuff = new DelayedRecallBuff(caster, caster, targets)
      {
        Duration = finalDuration,
        DeathPenalty = DeathPenalty
      };
      
      BuffSystem.Add(delayedRecallBuff);
    }

    private static bool IsValidTarget(unit caster, unit target)
    {
      return GetOwningPlayer(caster) == GetOwningPlayer(target) &&
             UnitAlive(target) &&
             BlzIsUnitInvulnerable(target) == false && 
             !target.IsResistant() &&
             !IsUnitType(target, UNIT_TYPE_STRUCTURE) && 
             !IsUnitType(target, UNIT_TYPE_ANCIENT) &&
             caster != target &&
             !target.IsUnitBoat();
    }
  }
}