using System;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.Spells
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

    private readonly group _tempGroup = CreateGroup();

    /// <inheritdoc />
    public ElectricStrike(int id) : base(id)
    {
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      try
      {
        GroupEnumUnitsInRange(_tempGroup, targetPoint.X, targetPoint.Y, Radius, null);
        EffectSystem.Add(AddSpecialEffect(Effect, targetPoint.X, targetPoint.Y));
        while (true)
        {
          var u = FirstOfGroup(_tempGroup);
          if (u == null)
          {
            return;
          }  

          if (IsUnitType(u, UNIT_TYPE_STRUCTURE) == false && UnitAlive(u))
          {
            DummyCast.DummyCastUnit(GetOwningPlayer(caster), StunId, StunOrder, 1, u);
            DummyCast.DummyCastUnit(GetOwningPlayer(caster), PurgeId, PurgeOrder, 1, u);
          }
          
          GroupRemoveUnit(_tempGroup, u);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to execute spell {nameof(ElectricStrike)}: {ex}");
      }
    }
  }
}