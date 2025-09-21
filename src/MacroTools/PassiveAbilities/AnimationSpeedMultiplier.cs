using MacroTools.PassiveAbilitySystem;

namespace MacroTools.PassiveAbilities;

public sealed class AnimationSpeedMultiplier : PassiveAbility, IEffectOnConstruction
{
  private readonly float _multiplier;

  public AnimationSpeedMultiplier(int unitTypeId, float multiplier) : base(unitTypeId)
  {
    _multiplier = multiplier;
  }

  public void OnConstruction()
  {
    @event.ConstructedStructure.SetTimeScale(_multiplier);
  }
}
