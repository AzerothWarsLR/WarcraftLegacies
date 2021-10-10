using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public abstract class PassiveAbilityFactory<T> : AbilityFactory<T> where T : Ability
  {
    protected override void ApplyCore(T ability)
    {
    }
  }
}