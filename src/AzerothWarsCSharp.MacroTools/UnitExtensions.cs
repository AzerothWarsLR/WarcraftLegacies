using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools
{
  public static class UnitExtensions
  {
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