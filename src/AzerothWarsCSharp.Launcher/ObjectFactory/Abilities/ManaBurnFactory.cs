using War3Api.Object.Abilities;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public class ManaBurnFactory : ActiveAbilityFactory<DemonHunterManaBurn>
  {
    public override DemonHunterManaBurn Generate(string newRawCode)
    {
      var newAbility = new DemonHunterManaBurn(newRawCode);
      GenerateCore(newAbility);
      return newAbility;
    }
  }
}