using static War3Api.Common; 

namespace MacroTools.SpellSystem
{
  public static class SpellHelpers
  {
    public static void StartUnitAbilityCooldownFull(unit whichUnit, int abilCode)
    {
      var fullCooldown = BlzGetUnitAbilityCooldown(whichUnit, abilCode, 0);
      BlzStartUnitAbilityCooldown(whichUnit, abilCode, fullCooldown);
    }
  }
}