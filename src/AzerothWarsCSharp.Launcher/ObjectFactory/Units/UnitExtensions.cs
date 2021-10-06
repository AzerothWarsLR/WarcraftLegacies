using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Units
{
  public static class UnitExtensions
  {
    public static string DamageRangeString(this Unit unit)
    {
      var minimum = unit.CombatAttack1DamageBase + unit.CombatAttack1DamageNumberOfDice;
      var maximum = unit.CombatAttack1DamageBase + unit.CombatAttack1DamageNumberOfDice * unit.CombatAttack1DamageSidesPerDie;
      return $"{minimum} - {maximum}";
    }
  }
}