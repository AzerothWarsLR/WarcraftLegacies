using WarcraftLegacies.MacroTools.PassiveAbilitySystem;
using static War3Api.Common;

namespace WarcraftLegacies.MacroTools.PassiveAbilities
{
  public sealed class AnimationSpeedMultiplier : PassiveAbility
  {
    private readonly float _multiplier;

    public AnimationSpeedMultiplier(int unitTypeId, float multiplier) : base(unitTypeId)
    {
      _multiplier = multiplier;
    }

    public override void OnConstruction()
    {
      SetUnitTimeScale(GetConstructedStructure(), _multiplier);
    }
  }
}