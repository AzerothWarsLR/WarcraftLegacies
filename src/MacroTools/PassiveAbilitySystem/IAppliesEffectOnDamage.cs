namespace MacroTools.PassiveAbilitySystem;

/// <summary>
/// Provides methods for responding to damage events with some kind of effect.
/// </summary>
public interface IAppliesEffectOnDamage
{
  /// <summary>
  /// A response to a unit dealing damage.
  /// </summary>
  public abstract void OnDealsDamage();
}
