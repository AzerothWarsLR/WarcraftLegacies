using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class MetamorphosisFactory : ActiveAbilityFactory<DemonHunterMetamorphosis>
  {
    public override DemonHunterMetamorphosis Generate(string newRawCode)
    {
      var newAbility = new DemonHunterMetamorphosis(newRawCode);
      GenerateCore(newAbility);
      return newAbility;
    }
  }
}