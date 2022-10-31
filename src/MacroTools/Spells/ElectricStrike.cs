using System;
using WarcraftLegacies.MacroTools.SpellSystem;
using WarcraftLegacies.MacroTools.Wrappers;
using static War3Api.Common;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.MacroTools.Spells
{
  /// <summary>
  /// Casts Storm Bolt and Purge on each unit in the target radius.
  /// </summary>
  public sealed class ElectricStrike : Spell
  {
    /// <summary>
    /// Gets cast on each unit in the radius. Should be based off Storm Bolt or Fire Bolt.
    /// </summary>
    public int StunId { get; init; }
    
    /// <summary>
    /// Gets cast on each unit in the radius. Should be based off Purge.
    /// </summary>
    public int PurgeId { get; init; }
    
    /// <summary>
    /// The order ID for casting the specified Purge ability on targets.
    /// </summary>
    public string PurgeOrder { get; init; } = string.Empty;
    
    /// <summary>
    /// The order ID for casting the specified Storm Bolt ability on targets.
    /// </summary>
    public string StunOrder { get; init; } = string.Empty;
    
    /// <summary>
    /// The radius in which to cast Purge and Storm Bolt on units.
    /// </summary>
    public float Radius { get; init; }
    
    /// <summary>
    /// The visual effect to create at the center of the cast location.
    /// </summary>
    public string Effect { get; init; } = string.Empty;

    /// <inheritdoc />
    public ElectricStrike(int id) : base(id)
    {
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      try
      {
        EffectSystem.Add(AddSpecialEffect(Effect, targetPoint.X, targetPoint.Y));
        foreach (var unit in new GroupWrapper().EnumUnitsInRange(targetPoint, Radius).EmptyToList())
        {
          if (IsUnitType(unit, UNIT_TYPE_STRUCTURE) || !UnitAlive(unit)) 
            continue;
          DummyCast.DummyCastUnit(GetOwningPlayer(caster), StunId, StunOrder, 1, unit);
          DummyCast.DummyCastUnit(GetOwningPlayer(caster), PurgeId, PurgeOrder, 1, unit);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to execute spell {nameof(ElectricStrike)}: {ex}");
      }
    }
  }
}