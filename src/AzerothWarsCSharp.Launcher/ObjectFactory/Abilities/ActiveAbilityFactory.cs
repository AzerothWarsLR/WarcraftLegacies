using War3Api.Object;

namespace AzerothWarsCSharp.Launcher.ObjectFactory.Abilities
{
  public abstract class ActiveAbilityFactory<T> : AbilityFactory<T> where T : Ability
  {
    /// <summary>
    /// How much mana the ability costs.
    /// </summary>
    public int ManaCost { get; set; } = 0;
    
    /// <summary>
    /// The time the unit with the ability has to wait before using the ability again.
    /// </summary>
    public float Cooldown { get; set; } = 0;
  }
}