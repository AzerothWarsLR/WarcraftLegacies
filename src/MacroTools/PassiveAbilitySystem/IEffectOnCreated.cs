namespace MacroTools.PassiveAbilitySystem;

/// <summary>
/// Called when a unit of the specified type is created or revived.
/// </summary>
public interface IEffectOnCreated
{
  void OnCreated(unit createdUnit);
}
