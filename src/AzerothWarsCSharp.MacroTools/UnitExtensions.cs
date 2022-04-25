using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public static class UnitExtensions
  {
    /// <summary>
    /// Resurrects a dead unit.
    /// </summary>
    /// <param name="whichUnit">The unit to resurrect.</param>
    public static void Resurrect(this unit whichUnit)
    {
      if (UnitAlive(whichUnit))
      {
        throw new ArgumentException("Tried to resurrect a unit that is already alive.");
      }
      
      var x = GetUnitX(whichUnit);
      var y = GetUnitY(whichUnit);
      var unitType = GetUnitTypeId(whichUnit);
      var face = GetUnitFacing(whichUnit);
      DestroyEffect(AddSpecialEffect(@"Abilities\Spells\Human\Resurrect\ResurrectTarget.mdl", x, y));
      RemoveUnit(whichUnit);
      CreateUnit(GetOwningPlayer(whichUnit), unitType, x, y, face);
    }
    
    public static void Damage(this unit unit, unit damager, float amount)
    {
      SetUnitState(unit, UNIT_STATE_LIFE, GetUnitState(unit, UNIT_STATE_LIFE) - amount);
    }
    
    public static void Heal(this unit unit, float amount)
    {
      SetUnitState(unit, UNIT_STATE_LIFE, GetUnitState(unit, UNIT_STATE_LIFE) + amount);
    }
  }
}