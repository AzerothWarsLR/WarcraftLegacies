using System;
using AzerothWarsCSharp.MacroTools.SpellSystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.Spells
{
  public sealed class ElectricStrike : Spell
  {
    public int STUN_ID { get; init; } = FourCC("A0RD"); //The ability that gets cast on each unit in the radius
    public int PURGE_ID { get; init; } = FourCC("Aprg"); //The ability that gets cast on each unit in the radius
    public string PURGE_ORDER { get; init; } = "purge";
    public string STUN_ORDER { get; init; } = "firebolt";
    private float RADIUS { get; init; } = 200.00F;
    private string EFFECT { get; init; } = "Abilities\\Spells\\Human\\Thunderclap\\ThunderClapCaster.mdl";

    private group TempGroup = CreateGroup();

    public ElectricStrike(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, unit target, float targetX, float targetY)
    {
      try
      {
        GroupEnumUnitsInRange(TempGroup, targetX, targetY, RADIUS, null);
        while (true)
        {
          unit u = FirstOfGroup(TempGroup);
          if (u == null)
          {
            return;
          }  

          if (IsUnitType(u, UNIT_TYPE_STRUCTURE) == false && UnitAlive(u))
          {
            DummyCast.DummyCastUnit(GetOwningPlayer(caster), STUN_ID, STUN_ORDER, 1, u);
            DummyCast.DummyCastUnit(GetOwningPlayer(caster), PURGE_ID, PURGE_ORDER, 1, u);
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