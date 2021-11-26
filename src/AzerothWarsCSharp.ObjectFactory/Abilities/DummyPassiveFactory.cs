using War3Api.Object;
using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.ObjectFactory.Abilities
{
  public class DummyPassiveFactory : PassiveAbilityFactory<GyrocopterBombs>
  {
    protected override void ApplyStats(GyrocopterBombs ability) { }

    public override GyrocopterBombs Generate(string newRawCode, ObjectDatabase objectDatabase)
    {
      var newAbility = new GyrocopterBombs(newRawCode, objectDatabase);
      Apply(newAbility);
      return newAbility;
    }
  }
}