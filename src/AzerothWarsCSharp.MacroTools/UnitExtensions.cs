using System;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public static class UnitExtensions
  {
    /// <summary>
    ///   Resurrects a dead unit.
    /// </summary>
    /// <param name="whichUnit">The unit to resurrect.</param>
    public static void Resurrect(this unit whichUnit)
    {
      if (UnitAlive(whichUnit)) throw new ArgumentException("Tried to resurrect a unit that is already alive.");

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

    /// <summary>
    ///   Reveals the unit, makes it vulnerable, and transfers its ownership to the specified player.
    /// </summary>
    public static void Rescue(this unit whichUnit, player whichPlayer)
    {
      //If the unit costs 10 food, that means it should be owned by neutral passive instead of the rescuing player.
      SetUnitOwner(whichUnit, GetUnitFoodUsed(whichUnit) == 10 ? Player(PLAYER_NEUTRAL_PASSIVE) : whichPlayer, true);
      ShowUnit(whichUnit, true);
      SetUnitInvulnerable(whichUnit, false);
    }
  }
}