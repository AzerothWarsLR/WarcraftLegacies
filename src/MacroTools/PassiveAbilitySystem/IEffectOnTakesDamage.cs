namespace MacroTools.PassiveAbilitySystem
{
  /// <summary>
  /// Provides methods for responding to damage taken events.
  /// </summary>
  public interface IEffectOnTakesDamage
  {
    /// <summary>
    /// A response to a unit taking damage.
    /// </summary>
    public abstract void OnTakesDamage();
  }
}