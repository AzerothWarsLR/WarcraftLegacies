using System;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using WCSharp.Effects;
using WCSharp.Shared.Data;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public sealed class ElectricStrike : Spell
  {
    public int StunId { get; init; }//The ability that gets cast on each unit in the radius
    public int PurgeId { get; init; } //The ability that gets cast on each unit in the radius
    public string PurgeOrder { get; init; } = string.Empty;
    public string StunOrder { get; init; } = string.Empty;
    public float Radius { get; init; }
    public string Effect { get; init; } = string.Empty;

    private group TempGroup = CreateGroup();

    public ElectricStrike(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      try
      {
        GroupEnumUnitsInRange(TempGroup, targetPoint.X, targetPoint.Y, Radius, null);
        EffectSystem.Add(AddSpecialEffect(Effect, targetPoint.X, targetPoint.Y));
        while (true)
        {
          unit u = FirstOfGroup(TempGroup);
          if (u == null)
          {
            return;
          }  

          if (IsUnitType(u, UNIT_TYPE_STRUCTURE) == false && UnitAlive(u))
          {
            DummyCast.DummyCastUnit(GetOwningPlayer(caster), StunId, StunOrder, 1, u);
            DummyCast.DummyCastUnit(GetOwningPlayer(caster), PurgeId, PurgeOrder, 1, u);
          }
          
          GroupRemoveUnit(TempGroup, u);
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Failed to execute spell {nameof(ElectricStrike)}: {ex}");
      }
    }
  }
}