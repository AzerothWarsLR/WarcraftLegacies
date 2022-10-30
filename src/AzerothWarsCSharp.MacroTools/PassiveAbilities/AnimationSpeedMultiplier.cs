using AzerothWarsCSharp.MacroTools.PassiveAbilitySystem;
using static War3Api.Common;

namespace AzerothWarsCSharp.MacroTools.PassiveAbilities
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